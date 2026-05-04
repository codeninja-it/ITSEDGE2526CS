namespace App06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // fondo il mio riconoscitore
            Riconoscitore riconoscitore = new Riconoscitore(3);
            // Problema: quando esco mi porto l'ombrello?
            // Proprietà:
            // 1. piove?
            // 2. le previsioni dicono che pioverà?
            // 3. dove sto andando è all'aperto?
            Console.WriteLine(riconoscitore);
            // in insegnamento
            // ora piove, le previsioni dicono pioggia e vado all'aperto
            riconoscitore.Impara(new double[] { 1.0, 1.0, 1.0 }, 1.0);
            Console.WriteLine(riconoscitore);
            // gli insegno quando non piove
            riconoscitore.Impara(new double[] { 0.0, 0.0, 0.0 }, 0.0);
            Console.WriteLine(riconoscitore);
            // gli insegno non piove, non pioverà e devo andare all'aperto
            riconoscitore.Impara(new double[] { 0.0, 0.0, 1.0 }, 0.0);
            Console.WriteLine(riconoscitore);

            // gli dico che se pioverà lo porto
            riconoscitore.Impara(new double[] { 0.0, 1.0, 1.0 }, 1.0);
            Console.WriteLine(riconoscitore);
            double scelta = riconoscitore.Decidi(riconoscitore.Predici(new double[] { 0.0, 0.0, 0.0 }));
            Console.WriteLine(scelta);
        }
    }
}
