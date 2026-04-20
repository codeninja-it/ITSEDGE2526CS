using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App04
{
    public class Livello
    {
        public string Nome { get; set; }
        public Bitmap Immagine { get; set; }

        public Livello(int altezza = 100, int larghezza = 100)
        {
            Nome = "Nuovo Livello";
            Immagine = new Bitmap(altezza, larghezza);
        }

        public Livello(string percorso)
        {
            Nome = Path.GetFileName(percorso);
            Immagine = new Bitmap(percorso);
        }

        public Livello(string nome, string percorso)
        {
            Nome = nome;
            Immagine = new Bitmap(percorso);
        }

        public Livello(string nome, Bitmap immagine)
        {
            Nome = nome;
            Immagine = new Bitmap(immagine);
        }

        public void Salva(string percorso)
        {
            Immagine.Save(percorso);
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
