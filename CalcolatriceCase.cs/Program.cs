// dichiaro l'uso di ML.Net e creo una cassetta degli attrezzi
using CalcolatriceCase;
using Microsoft.ML;
using System.Text.RegularExpressions;
MLContext cassetta = new MLContext();

string[] righe = File.ReadAllLines("C:\\test\\Real estate list.csv");
List<Ingresso> dati = new List<Ingresso>();
for (int i = 1; i < righe.Length; i++)
{
    string[] celle = righe[i].Split(';');

    dati.Add(new Ingresso()
    {
        Area = celle[2],
        Prezzo = float.Parse(celle[3]),
        Letti = float.Parse(celle[4]),
        Bagni = float.Parse(celle[5]),
        Superficie = float.Parse(celle[6]) * 0.0929f,
        Tipo = celle[7],
        Piscina = int.Parse(celle[8]),
    });
}

Console.WriteLine(dati.Count);

var dataset = cassetta.Data.LoadFromEnumerable(dati);

var ricetta = cassetta.Transforms.Text
    .FeaturizeText("AreaN", "Area")
    .Append(
        cassetta.Transforms.Text.FeaturizeText("TipoN", "Tipo")
    )
    .Append(
        cassetta.Transforms.Concatenate(
            "Features",
            new string[] { "AreaN", "TipoN", "Letti", "Bagni", "Superficie", "Piscina" }
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

var motore = cassetta.Model.CreatePredictionEngine<Ingresso, Uscita>(modello);

var risultato = motore.Predict(new Ingresso()
{
    Area = "Central",
    Bagni = 2,
    Letti = 3,
    Piscina = 0,
    Superficie = 100
});

Console.WriteLine(risultato.Score);

Console.WriteLine("fatto.");