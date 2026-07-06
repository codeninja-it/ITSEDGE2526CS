// sistema di analisi testi in cerca di tentativi di "corruzione" delle AI
using FiltroSicurezza;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms.Text;

// 0. definisco i percorsi utili
string percorsoDati = "C:\\test\\python\\parquet\\datasets\\train-00000-of-00001.csv";
string percorsoModello = "c:\\test\\sicurezza.mlnet";

// 1. Creo il contesto e un modello vuoto
MLContext contesto  = new MLContext();
ITransformer modello;

if (!File.Exists(percorsoModello)) {
    // 2. Grazie al contesto importo i dati dal file
    TextLoader.Options opzioni = new TextLoader.Options();
    opzioni.HasHeader = true;
    opzioni.Separators = new char[] { ',' };
    opzioni.AllowQuoting = true;
    opzioni.ReadMultilines = true;
    IDataView dati = contesto.Data.LoadFromTextFile<DatiIngresso>(percorsoDati, opzioni);

    // 3. Definisco il processo di creazione del modello (ricetta/pipeline)
    // 3.1. impostando i parametri di training
    SdcaMaximumEntropyMulticlassTrainer.Options opzioniTraining = new SdcaMaximumEntropyMulticlassTrainer.Options();
    opzioniTraining.FeatureColumnName = "Features";
    opzioniTraining.LabelColumnName = "Category";
    opzioniTraining.L1Regularization = .1f;
    opzioniTraining.L2Regularization = .01f;
    opzioniTraining.Shuffle = true;
    // 3.2. ed i parametri inerenti all'importazione del test su base NLP
    TextFeaturizingEstimator.Options opzioniTesto = new TextFeaturizingEstimator.Options()
    {
        WordFeatureExtractor = new WordBagEstimator.Options() { NgramLength = 2, UseAllLengths = true },
        CharFeatureExtractor = new WordBagEstimator.Options() { NgramLength = 3, UseAllLengths = false }
    };
    var ricetta = contesto
    .Transforms
    .Text
    .FeaturizeText("Features", opzioniTesto, "Text")
    .Append(contesto.Transforms.Conversion
                .MapValueToKey(
                    outputColumnName: "Category",
                    inputColumnName: "Category",
                    addKeyValueAnnotationsAsText: false
                ))
    .AppendCacheCheckpoint(contesto)
    .Append(contesto.MulticlassClassification.Trainers
                .SdcaMaximumEntropy(opzioniTraining)
                )
    .Append(contesto.Transforms.Conversion
                .MapKeyToValue(
                    outputColumnName: "PredictedLabel",
                    inputColumnName: "PredictedLabel"
                ));

    // 4. e lo metto in moto (produco la torta basandomi sulla ricetta)
    modello = ricetta.Fit(dati);
    // 5. salvandolo su disco
    contesto.Model.Save(modello, dati.Schema, "c:\\test\\sicurezza.mlnet");
} else
{
    // 5.1. leggendolo da disco
    modello = contesto.Model.Load("c:\\test\\sicurezza.mlnet", out _);
}

// 6. ne creo un motore di utilizzo (lo istanzio)
PredictionEngine<DatiIngresso, DatiUscita> motore = contesto
    .Model
    .CreatePredictionEngine<DatiIngresso, DatiUscita>(modello);

// 7. me ne faccio dare la struttura interna
DataViewSchema.Column? colonna = motore.OutputSchema.GetColumnOrNull("Category");
VBuffer<ReadOnlyMemory<char>> categorie = new VBuffer<ReadOnlyMemory<char>>();
colonna.Value.GetKeyValues(ref categorie);
string[] nomiCategorie = categorie.DenseValues().Select(x => x.ToString()).ToArray();

// 8. ed inizio il ciclo per la gestione delle analisi
Console.Clear();
string? frase = "";
do
{
    Console.Write("Frase: ");
    frase = Console.ReadLine();
    if(frase != null)
    {
        Console.Clear();
        Console.WriteLine($"Frase: {frase}");
        DatiUscita risultato = motore.Predict(new DatiIngresso() { Text = frase });

        var punteggi = nomiCategorie
            .Zip(risultato.Score)
            .OrderByDescending(x => x.Second)
            .Take(10)
            .ToDictionary(x => x.First, x => x.Second);

        foreach(var voce in punteggi)
        {
            Console.WriteLine($"{voce.Value:P2}\t{voce.Key}");
        }
    }
} while (frase != "");
Console.WriteLine("Addio!!!");