// dichiaro l'uso di ML.Net e creo una cassetta degli attrezzi
using CalcolatricePC;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using System.Globalization;
using System.Text.RegularExpressions;
MLContext cassetta = new MLContext();

// dopo aver valutato i dati, li importo
//var dati = cassetta.Data.LoadFromTextFile<DatiIngresso>(
//    "C:\\test\\Costo_portatili_nelle_Filippine.csv",
//    new TextLoader.Options()
//    {
//        AllowQuoting = true,
//        Separators = new char[] { ',' },
//        DecimalMarker = '.'
//    }
//);

string[] righe = File.ReadAllLines("C:\\test\\Costo_portatili_nelle_Filippine.csv");
List<DatiIngresso> dati = new List<DatiIngresso>();
for (int i = 1; i < righe.Length; i++)
{
    string[] celle = righe[i].Split(',');

    Match infoDisco = Regex.Match(celle[7], @"([\d\.]+)\s*([TGM]B)\s*(\w*)");
    string dimensione = infoDisco.Groups[1].Value;
    string unitàMisura = infoDisco.Groups[2].Value;
    string tecnologia = infoDisco.Groups[3].Value;

    dati.Add(new DatiIngresso()
    {
        Marca = celle[1],
        Peso = float.Parse(celle[10].Replace("kg", "").Replace(".", ",")),
        Prezzo = float.Parse(celle[11].Replace(".", ",")) * 0.014f,
        Pollici = float.Parse(celle[3].Replace(".", ",")),
        Ram = int.Parse(celle[6].Replace("GB", "")),
        Disco = unitàMisura == "GB" ? float.Parse(dimensione) : float.Parse(dimensione) * 1024
    });
}

Console.WriteLine(dati.Count);

var dataset = cassetta.Data.LoadFromEnumerable(dati);

var ricetta = cassetta.Transforms.Text
    .FeaturizeText("MarcaN", "Marca")
    .Append(
        cassetta.Transforms.Concatenate(
            "Features",
            new string[] { "MarcaN", "Peso", "Pollici", "Ram", "Disco" }
        )
    )
    .Append(
        cassetta.Transforms.NormalizeMinMax("Features")
    )
    .Append(
        cassetta.Regression.Trainers.Sdca(
            labelColumnName: "Prezzo",
            featureColumnName: "Features",
            maximumNumberOfIterations: 100
        )
    );

var modello = ricetta.Fit(dataset);

cassetta.Model.Save(modello, dataset.Schema, "c:\\test\\prezzipc.mlnet");

var motore = cassetta.Model.CreatePredictionEngine<DatiIngresso, DatiUscita>(modello);

var risultato = motore.Predict(new DatiIngresso() {
    Marca = "Apple",
    Peso = 1,
    Ram = 8,
    Disco = 256,
    Pollici = 15
});

Console.WriteLine(risultato.Score);

Console.WriteLine("fatto.");