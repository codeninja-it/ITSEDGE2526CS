using App01.Elementari;
using System.Net.Http.Headers;

namespace App01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // uso sempre il solito concetto di buffer
            string comando = "";
            // entro in un ciclo con controllo in coda
            do
            {
                // pulisco lo schermo
                Console.Clear();
                if(comando == "")
                {
                    // saluto l'utente e gli spiego il da farsi
                    Presentazione();
                } else if (comando == "TAB")
                {
                    Console.Write("Numero della tabellina: ");
                    int numero = int.Parse( Console.ReadLine() );
                    Tabellina generatore = new Tabellina(numero);
                    Console.Write("Numero di ripetizioni: ");
                    int rep = int.Parse( Console.ReadLine() );
                    Console.WriteLine( generatore.Calcola(rep) );
                }

                // ascolto cosa mi dice
                Console.Write("Comando: ");
                comando = Console.ReadLine();
                // se vuole uscire esco sennò torno in cima
            } while (comando != "ESCI");
            


        }

        static void Presentazione()
        {
            Console.WriteLine("Benvenuto nel gestore scuola!");
            Console.WriteLine("Per procedere dimmi cosa vuoi fare");
            Console.WriteLine("TAB) Tabelline");
            Console.WriteLine("AGENDA) Apri l'agenda");
            Console.WriteLine("ESCI) Esci dal sistema");
        }


    }
}
