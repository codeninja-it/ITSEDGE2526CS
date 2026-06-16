using System;
using System.Collections.Generic;
using System.Text;

namespace Maui01.Strutture
{
    public class Tavolo
    {
        public string Id { get; set; } = new Guid().ToString();
        public string Nome { get; set; } = string.Empty;
        public int Posti { get; set; } = 4;
    }
}
