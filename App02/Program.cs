using System.Text.Json;

namespace App02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Contatto> rubrica = new List<Contatto>();
            do
            {
                Console.Clear();
                string comando = Chiedi("Inserisci un comando: ");

                if(comando == "EXIT")
                    break;

                switch (comando)
                {
                    case "ADD":
                        rubrica.Add(
                            new Contatto
                            {
                                Nome = Chiedi("Nome: "),
                                Cognome = Chiedi("Cognome: "),
                                Numero = Chiedi("Numero: "),
                                Email = Chiedi("Email: ")
                            }
                        );
                        break;

                    case "REMOVE":
                        //int daRimuovere = int.Parse(Chiedi("Dammi il numero di quello da rimuovere: "));
                        //rubrica.RemoveAt(daRimuovere);
                        string chi = Chiedi("Dammi il nome o cognome di chi vuoi rimuovere: ");
                        rubrica.RemoveAll(c => c.Nome == chi || c.Cognome == chi);
                        break;

                    case "SAVE":
                        string fileName = Chiedi("Dammi il nome del file: ");
                        File.WriteAllText(fileName, JsonSerializer.Serialize(rubrica));
                        break;

                    case "LOAD":
                        string pathFile = Chiedi("Dammi il nome del file: ");
                        if (File.Exists(pathFile))
                        {
                            string buffer = File.ReadAllText(pathFile);
                            rubrica = JsonSerializer.Deserialize< List<Contatto> >(buffer);
                        } else
                        {
                            Chiedi("File non trovato, premi invio per continuare...");
                        }
                        break;

                    default:
                        foreach(Contatto singolo in rubrica)
                        {
                            Console.WriteLine(singolo);
                        }
                        break;
                }

            } while (true);
        }

        internal static string Chiedi(string domanda)
        {
            Console.Write(domanda);
            return Console.ReadLine();
        }
    }
}
