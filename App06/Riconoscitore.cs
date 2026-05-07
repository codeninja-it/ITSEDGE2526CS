using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App06
{
    public class Riconoscitore
    {
        // l'array dei ricordi
        public double[] ricordo;
        // l'ancora che mi tiene legato alla mia idea
        public double pregiudizio;

        public Riconoscitore(int proprietà) {
            // quando la nostra AI nasce
            // partiamo con una base deserta
            ricordo = new double[proprietà];
            pregiudizio = 0;
            Random random = new Random();
            // e nei primi mesi di vita impara causalmente
            for (int i = 0; i < proprietà; i++)
            {
                ricordo[i] = (random.NextDouble() * 2) - 1;
            }
            // e sviluppa un suo pregiudizio
            pregiudizio = (random.NextDouble() * 2) - 1;
        }

        // quando qualcuno gli chiederà
        // cosa ne pensa di una certa situazione
        public double Predici(double[] domanda)
        {
            // basandosi sul pregiudizio
            double idea = pregiudizio;
            // per ogni proprietà che conosce
            for (int i = 0; i < ricordo.Length; i++)
            {
                // e pesandola sui suoi ricordi
                idea += domanda[i] * ricordo[i];
            }
            // produrrà una predizione
            return idea;
        }

        // la sua decisione basata sulla predizione
        // sarà sempre binaria, o sì o no
        public double Decidi(double valore)
        {
            if (valore >= 0)
                return 1.0;
            else
                return 0.0;
        }

        public void Impara(double[] informazione, double risultato, double fiducia = 0.001)
        {
            // quando imparo
            // parto da quello che sò
            double predizione = Predici(informazione);
            // controllo se è differente da quello che mi viene detto
            double errore = risultato - predizione;
            // decido quanto ne sono confidente
            double confidenza = errore * fiducia;
            // e se è uguale
            if(errore == 0)
            {
                // smetto di ascoltare
                return;
            } 
            // altrimenti approfondisco il mio ricordo
            for (int i = 0; i < ricordo.Length; i++)
            {
                // calcolo quanto mi insegna questa informazione
                double insegnamento = informazione[i] * confidenza;
                // e lo aggiungo al mio ricordo
                ricordo[i] += insegnamento;
            }
            // spostando il mio pregiudizio sull'attuale confidenza
            pregiudizio += confidenza;
        }

        public override string ToString()
        {
            return $"{pregiudizio}: [{string.Join(", ", ricordo)}]";
        }
    }
}
