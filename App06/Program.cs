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
            TabellinaDel5.Add(new Lezione() { informazioni = new double[] { .1 }, risultato = .5 });
            TabellinaDel5.Add(new Lezione() { informazioni = new double[] { .2 }, risultato = 1.0 });
            TabellinaDel5.Add(new Lezione() { informazioni = new double[] { .3 }, risultato = 1.5 });
            TabellinaDel5.Add(new Lezione() { informazioni = new double[] { .4 }, risultato = 2.0 });
            TabellinaDel5.Add(new Lezione() { informazioni = new double[] { .5 }, risultato = 2.5 });
            TabellinaDel5.Add(new Lezione() { informazioni = new double[] { .6 }, risultato = 3.0 });
            TabellinaDel5.Add(new Lezione() { informazioni = new double[] { .7 }, risultato = 3.5 });
            TabellinaDel5.Add(new Lezione() { informazioni = new double[] { .8 }, risultato = 4.0 });
            TabellinaDel5.Add(new Lezione() { informazioni = new double[] { .9 }, risultato = 4.5 });
            TabellinaDel5.Add(new Lezione() { informazioni = new double[] { 1.0 }, risultato = 5.0 });
            Riconoscitore studente = new Riconoscitore(1);

            foreach(Lezione singola in TabellinaDel5)
            {
                CicloInsegnamento(studente, singola, new double[] { .8 });
            }
        }

        static void CicloInsegnamento(Riconoscitore riconoscitore, Lezione lezione, double[] controllo)
        {
            for (int i = 0; i < 10000; i++)
            {
                riconoscitore.Impara(
                    lezione.informazioni, 
                    lezione.risultato, 
                    0.0001
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
