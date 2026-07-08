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
        Weight = float.Parse(celle[10].Replace("kg", "").Replace(".", ",")),
        Price = float.Parse(celle[11].Replace(".", ",")) * 0.014f,
        Inches = float.Parse(celle[3].Replace(".", ",")),
        Ram = int.Parse(celle[6].Replace("GB", "")),
        Memory = unitàMisura == "GB" ? float.Parse(dimensione) : float.Parse(dimensione) * 1024
    });
}

Console.WriteLine(dati.Count);

var dataset = cassetta.Data.LoadFromEnumerable(dati);


//var ricetta = cassetta.Transforms.Text
//    .FeaturizeText("CompanyN", "Company")
//    .Append(cassetta.Transforms.Text.FeaturizeText("TypeNameN", "TypeName"))
//    .Append(cassetta.Transforms.Text.FeaturizeText("CpuN", "Cpu"))
//    .Append(cassetta.Transforms.Text.FeaturizeText("RamN", "Ram"))
//    .Append(cassetta.Transforms.Text.FeaturizeText("InchesN", "Inches"))
//    .Append(cassetta.Transforms.Text.FeaturizeText("WeightN", "Weight"))
//    .Append(cassetta.Transforms.Text.FeaturizeText("MemoryN", "Memory"))
//    .Append(cassetta.Transforms.Text.FeaturizeText("GpuN", "Gpu"))
//    .Append(cassetta.Transforms.Text.FeaturizeText("OpSysN", "OpSys"))
//    .Append(cassetta.Transforms.Concatenate(
//        "Feature",
//        new string[] {
//            "CompanyN", "TypeNameN", "InchesN", "CpuN",
//            "RamN", "MemoryN", "GpuN", "OpSysN", "WeightN"
//        }
//    ))
//    .Append(
//        cassetta.Regression.Trainers.Sdca(
//            new SdcaRegressionTrainer.Options()
//            {
//                LabelColumnName = "Price",
//                FeatureColumnName = "Feature",
//                MaximumNumberOfIterations = 100
//            }
//        )
//    );

//var modello = ricetta.Fit(dati);

//cassetta.Model.Save(modello, dati.Schema, "C:\\test\\prezzipc.mlnet");

Console.WriteLine("fatto.");