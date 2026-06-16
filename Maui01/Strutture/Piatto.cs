using System;
using System.Collections.Generic;
using System.Text;

namespace Maui01.Strutture
{
    public class Piatto
    {
        public string Id { get; set; } = new Guid().ToString();
        public string Nome { get; set; } = string.Empty;
        public double Prezzo { get; set; } = 5;
    }
}
