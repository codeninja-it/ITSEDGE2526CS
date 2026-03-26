using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App01.Elementari
{
    internal class Appuntamento
    {
        internal string Nota {  get; set; }
        internal DateOnly Giorno { get; set; }
        internal TimeOnly Dalle { get; set; }
        internal TimeOnly Alle { get; set; }
    }
}
