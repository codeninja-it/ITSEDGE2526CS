using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Maui01.Strutture
{
    public class BancaDati
    {
        public List<Tavolo> tavoli { get; set; } = new List<Tavolo>();
        public List<Piatto> piatti { get; set; } = new List<Piatto>();

        private static readonly string percorso = Path.Combine(FileSystem.AppDataDirectory, "db.json");

        public static BancaDati Load()
        {
            if (File.Exists(percorso))
            {
                BancaDati? copia = JsonSerializer.Deserialize<BancaDati>( File.ReadAllText(percorso) );
                if (copia != null)
                    return copia; 
            }
            return new BancaDati();
        }

        public void Save()
        {
            File.WriteAllText(percorso, JsonSerializer.Serialize(this) );
        }
    }
}
