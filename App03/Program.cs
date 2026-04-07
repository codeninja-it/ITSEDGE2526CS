using System.Text.Json;

namespace App03
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            List<Contatto> rubrica = new List<Contatto>();

            if(File.Exists("rubrica.json"))
            {
                string buffer = File.ReadAllText("rubrica.json");
                rubrica = JsonSerializer.Deserialize< List<Contatto> >(buffer);
            }

            Application.Run(   new Form1(rubrica) );

            File.WriteAllText("rubrica.json", JsonSerializer.Serialize(rubrica) );
        }
    }
}