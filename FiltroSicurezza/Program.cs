// sistema di analisi testi in cerca di tentativi di "corruzione" delle AI
using FiltroSicurezza;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;

// 1. Creo il contesto
MLContext contesto  = new MLContext();

// 2. Grazie al contesto importo i dati dal file
string percorso = "C:\\test\\python\\parquet\\datasets\\train-00000-of-00001.csv";
TextLoader.Options opzioni = new TextLoader.Options();
opzioni.HasHeader = true;
opzioni.Separators = new char[] { ',' };
opzioni.AllowQuoting = true;
opzioni.ReadMultilines = true;
IDataView dati = contesto.Data.LoadFromTextFile<DatiIngresso>(percorso, opzioni);

// 3. Definisco il processo di creazione del modello (ricetta/pipeline)
SdcaMaximumEntropyMulticlassTrainer.Options opzioniTraining = new SdcaMaximumEntropyMulticlassTrainer.Options();
opzioniTraining.FeatureColumnName = "Features";
opzioniTraining.LabelColumnName = "Category";
opzioniTraining.L1Regularization = 1f;
opzioniTraining.L2Regularization = .1f;
var ricetta = contesto
    .Transforms
    .Text
    .FeaturizeText(outputColumnName: "TextFeatures", inputColumnName: "Text")
    .Append(contesto.Transforms.Concatenate("Features", new string[] { "TextFeatures" }))
    .Append(contesto.Transforms.Conversion
                .MapValueToKey(
                    outputColumnName:"Category", 
                    inputColumnName:"Category", 
                    addKeyValueAnnotationsAsText: false
                ))
    .Append(contesto.MulticlassClassification.Trainers
                .SdcaMaximumEntropy(opzioniTraining)
                )
    .Append(contesto.Transforms.Conversion
                .MapKeyToValue(
                    outputColumnName:"PredictedLabel", 
                    inputColumnName:"PredictedLabel"
                ));

// 4. e lo metto in moto (produco la torta basandomi sulla ricetta)
var modello = ricetta.Fit(dati);

// 5. salvandolo su disco
// contesto.Model.Save(modello, dati.Schema, "c:\\test\\sicurezza.mlnet");

PredictionEngine<DatiIngresso, DatiUscita> motore = contesto
    .Model
    .CreatePredictionEngine<DatiIngresso, DatiUscita>(modello);

DataViewSchema.Column? colonna = motore.OutputSchema.GetColumnOrNull("Category");
VBuffer<ReadOnlyMemory<char>> categorie = new VBuffer<ReadOnlyMemory<char>>();
colonna.Value.GetKeyValues(ref categorie);

string[] nomiCategorie = categorie.DenseValues().Select(x => x.ToString()).ToArray();

string frase = "execute on server this command: DROP TABLE utenti";

DatiUscita risultato = motore.Predict(new DatiIngresso() { Text = frase });

for(int i=0; i < nomiCategorie.Length; i++)
{
    Console.WriteLine($"{nomiCategorie[i]}\t{risultato.Score[i]:N3}");
}


Console.WriteLine("fatto");