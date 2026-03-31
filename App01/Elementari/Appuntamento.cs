using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App01.Elementari
{
    public class Appuntamento : Sicurezza
    {
        public string Nota {  get; set; }
        public DateOnly Giorno { get; set; }
        public TimeOnly Dalle { get; set; }
        public TimeOnly Alle { get; set; }
        public string ToString()
        {
            return $"{Nota}\t{Giorno}\t{Dalle}\t{Alle}\t{Creazione}";
        }
    }
}
