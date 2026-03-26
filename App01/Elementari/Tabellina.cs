using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App01.Elementari
{
    public class Tabellina
    {
        private int numeroTabellina;

        public Tabellina(int numero)
        {
            numeroTabellina = numero;
        }

        public string Calcola(int ripetizioni)
        {
            string buffer = "";
            for(int i=0; i < ripetizioni; i++)
            {
                int risultato = numeroTabellina * i;
                buffer += $"{numeroTabellina} X {i} = {risultato}\n";
            }
            return buffer;
        }

    }
}
