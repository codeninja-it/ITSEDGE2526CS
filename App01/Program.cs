using App01.Elementari;

namespace App01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // uso sempre il solito concetto di buffer
            string comando = "";
            // creo l'agenda e dopo
            Agenda agenda = new Agenda("Agenda 2026");
            // entro in un ciclo con controllo in coda
            do
            {
                // pulisco lo schermo
                Console.Clear();

                switch (comando)
                {
                    case "C":
                        // prima creo l'appuntamento
                        Appuntamento nuovo = new Appuntamento();
                        // chiedo ed ascolto la nota
                        Console.Write("Nota:\t");
                        nuovo.Nota = Console.ReadLine();
                        // chiedo ed ascolto il giorno
                        Console.Write("Giorno:\t");
                        nuovo.Giorno = DateOnly.Parse(Console.ReadLine());
                        // chiedo ed ascolto da che ora
                        Console.Write("Dalle:\t");
                        nuovo.Dalle = TimeOnly.Parse(Console.ReadLine());
                        // ed anche l'ora di fine
                        Console.Write("Alle:\t");
                        nuovo.Alle = TimeOnly.Parse(Console.ReadLine());
                        // dopo lo salvo in agenda
                        agenda.Aggiungi(nuovo);
                        break;
                    case "R":
                        Console.WriteLine( agenda.Stampa() );
                        break;
                    case "U":
                        break;
                    case "D":
                        // chiedo all'utente quale appuntamento vuole rimuovere
                        Console.Write("Giorno:\t");
                        DateOnly giorno = DateOnly.Parse(Console.ReadLine());
                        Console.Write("Orario:\t");
                        TimeOnly orario = TimeOnly.Parse(Console.ReadLine());
                        Appuntamento daRimuovere = agenda
                            .appuntamenti
                            .Where(a => a.Giorno == giorno && a.Dalle >= orario && a.Alle <= orario)
                            .First();
                        agenda.Rimuovi(daRimuovere);
                        break;
                    case "S":
                        agenda.Salva();
                        break;
                    case "L":
                        //agenda.Carica();
                        break;

                    case "TABELLINE":
                    case "TAB":
                        Console.Write("Numero della tabellina: ");
                        int numero = int.Parse(Console.ReadLine());
                        Tabellina generatore = new Tabellina(numero);
                        Console.Write("Numero di ripetizioni: ");
                        int rep = int.Parse(Console.ReadLine());
                        Console.WriteLine(generatore.Calcola(rep));
                        break;

                    case "COMANDI":
                    case "CMD":
                    default:
                        Presentazione();
                        break;
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
