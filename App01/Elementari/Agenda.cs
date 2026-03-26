using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App01.Elementari
{
    internal class Agenda
    {
        internal string Nome { get; set; }
        internal List<Appuntamento> appuntamenti { get; set; }

        internal void Aggiungi(Appuntamento nuovo)
        {
            appuntamenti.Add(nuovo);
        }

        internal void Rimuovi(Appuntamento daTogliere)
        {
            appuntamenti.Remove(daTogliere);
        }

        internal void Stampa()
        {
            foreach(Appuntamento singolo in appuntamenti)
            {
                Console.WriteLine(singolo);
            }
        }
    }   

}
