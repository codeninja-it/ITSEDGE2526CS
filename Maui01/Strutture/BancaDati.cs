using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Maui01.Strutture
{
    public class BancaDati
    {
        public List<Tavolo> tavoli { get; set; } = new List<Tavolo>();
        private readonly string percorso = Path.Combine(FileSystem.AppDataDirectory, "db.json");

        public BancaDati()
        {
            if (File.Exists(percorso))
            {
                BancaDati? copia = JsonSerializer.Deserialize<BancaDati>(File.ReadAllText(percorso));
                if(copia != null)
                {
                    this.tavoli = copia.tavoli;
                }
            }
        }

        public void Save()
        {
            File.WriteAllText(percorso, JsonSerializer.Serialize(this) );
        }
    }
}
