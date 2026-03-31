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
                        int daRimuovere = int.Parse(Chiedi("Dammi il numero di quello da rimuovere: "));
                        rubrica.RemoveAt(daRimuovere);
                        break;

                    case "SAVE":
                        string fileName = Chiedi("Dammi il nome del file: ");
                        File.WriteAllText(fileName, JsonSerializer.Serialize(rubrica));
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
