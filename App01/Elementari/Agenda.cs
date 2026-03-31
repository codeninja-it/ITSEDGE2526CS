using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App01.Elementari
{
    public class Agenda : Sicurezza
    {
        public string Nome { get; set; }
        public List<Appuntamento> appuntamenti { get; set; }
        public Agenda(string nome)
        {
            Nome = nome;
            appuntamenti = new List<Appuntamento>();
        }

        internal void Aggiungi(Appuntamento nuovo)
        {
            appuntamenti.Add(nuovo);
        }

        internal void Rimuovi(Appuntamento daTogliere)
        {
            appuntamenti.Remove(daTogliere);
        }

        internal string Stampa()
        {
            string buffer = "";
            foreach(Appuntamento singolo in appuntamenti)
            {
                buffer += singolo.ToString() + Environment.NewLine;
            }
            return buffer;
        }

        internal void Salva()
        {
            JsonSerializerOptions opzioni = new JsonSerializerOptions();
            opzioni.WriteIndented = true;
            string json = JsonSerializer.Serialize(this, opzioni);
            string nomeFile = "Agenda_" + Creazione.ToString("yyMMdd") + ".json";
            File.WriteAllText(nomeFile, json);
        }
    }   

}
