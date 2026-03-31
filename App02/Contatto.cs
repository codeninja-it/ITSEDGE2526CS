using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App02
{
    public class Contatto
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Numero { get; set; }
        public string Email { get; set; }
        public string ToString()
        {
            return $"{Nome} {Cognome}:\t{Numero}\t - \t{Email}";
        }
    }
}
