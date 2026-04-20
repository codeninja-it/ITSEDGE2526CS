using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace App04
{
    public class ColoreDaA
    {
        public Color Da { get; set; }
        public float Tolleranza { get; set; }
        public Color A { get; set; }
        public float LimSu => Da.GetHue() + Tolleranza;
        public float LimGiù => Da.GetHue() - Tolleranza;
        public TipologiaSostituzione Tipo { get; set; }
        public ColoreDaA(Color da, Color a, float tolleranza, TipologiaSostituzione tipoSostituzione)
        {
            Da = da;
            Tolleranza = tolleranza;
            A = a;
            Tipo = tipoSostituzione;
        }

        public bool ControlloCubico(Color daControllare)
        {
            return daControllare.R == Da.R && 
                    daControllare.G == Da.G && 
                    daControllare.B == Da.B;
        }

        public bool ControlloCilindrico(Color daControllare)
        {
            float tinta = daControllare.GetHue();
            bool risultato = tinta >= LimGiù && tinta <= LimSu;

            return Tipo == TipologiaSostituzione.Positiva ? risultato : !risultato;
        }

    }
}
