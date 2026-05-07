namespace App06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] quelloCheVoglioSapere = new double[] { -1, 0.8, 0.5 };
            List<Lezione> Corso = new List<Lezione>();
            Corso.Add(new Lezione() { 
                informazioni = new double[] { 1, 1, 1 }, 
                risultato = 1 
            });
            Corso.Add(new Lezione()
            {
                informazioni = new double[] { -1, -1, -1 },
                risultato = -1
            });
            Corso.Add(new Lezione()
            {
                informazioni = new double[] { -1, 1, 1 },
                risultato = 1
            });
            Corso.Add(new Lezione()
            {
                informazioni = new double[] { -1, 1, -1 },
                risultato = -1
            });

            // fondo il mio riconoscitore
            Riconoscitore riconoscitore = new Riconoscitore(3);
            // Problema: quando esco mi porto l'ombrello?
            // Proprietà:
            // 1. piove?
            // 2. le previsioni dicono che pioverà?
            // 3. dove sto andando è all'aperto?
            Console.WriteLine(riconoscitore);

            // svolgo il corso
            foreach (Lezione lezione in Corso)
            {
                CicloInsegnamento(riconoscitore, lezione, quelloCheVoglioSapere);
            }

            // nuovo corso, nuovo studente!
            List<Lezione> TabellinaDel5 = new List<Lezione>();
            TabellinaDel5.Add(new Lezione() { informazioni = new double[] { 1, 5 }, risultato = 5 });
            TabellinaDel5.Add(new Lezione() { informazioni = new double[] { 2, 5 }, risultato = 10 });
            TabellinaDel5.Add(new Lezione() { informazioni = new double[] { 3, 5 }, risultato = 15 });
            TabellinaDel5.Add(new Lezione() { informazioni = new double[] { 4, 5 }, risultato = 20 });
            TabellinaDel5.Add(new Lezione() { informazioni = new double[] { 5, 5 }, risultato = 25 });
            TabellinaDel5.Add(new Lezione() { informazioni = new double[] { 50, 5 }, risultato = 250 });
            TabellinaDel5.Add(new Lezione() { informazioni = new double[] { 100, 5 }, risultato = 500 });
            Riconoscitore studente = new Riconoscitore(2);

            foreach(Lezione singola in TabellinaDel5)
            {
                studente.Impara(singola.informazioni, singola.risultato, 0.1);
                Console.WriteLine(studente);
                Console.WriteLine("Quanto fa 5x10 ? " + studente.Predici(new double[] { 10, 5 }));
            }
        }

        static void CicloInsegnamento(Riconoscitore riconoscitore, Lezione lezione, double[] controllo)
        {
            for (int i = 0; i < 30000; i++)
            {
                riconoscitore.Impara(
                    lezione.informazioni, 
                    lezione.risultato, 
                    0.001
                );
                if (i % 1000 == 0)
                {
                    Console.WriteLine(riconoscitore);
                }
            }
            Console.WriteLine("In merito alla domanda:\t" + riconoscitore.Predici(controllo) + "\n\n");
        }

    }
}
