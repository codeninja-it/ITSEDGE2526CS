using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App05.Servizi
{
    public class ServerFile
    {
        private readonly string percorsoBase;
        private readonly string paginaBase;

        public ServerFile(string percorsoWww = "wwwroot", string nomeDefault = "index.htm")
        {
            // c:\prova\server.exe => c:\prova\ + wwwroot => c:\prova\wwwroot
            percorsoBase = Path.Combine(Environment.CurrentDirectory, percorsoWww);
            paginaBase = nomeDefault;
        }

        public string TrovaComando(string url)
        {
            //  url => /file/cartella/documento.txt
            string[] pezzi = url.Split("/");
            if (pezzi.Length < 2)
                return "file";
            
            string comando = pezzi[1];
            if (comando == "")
                return "file";

            return comando;
        }

        public List<string> TrovaParametri(string url)
        {
            string[] pezzi = url.Split("/");
            if (pezzi.Length < 2 && pezzi[2] == "")
                return new List<string>() { paginaBase };
            List<string> parametri = new List<string>();
            for(int i=2; i < pezzi.Length; i++)
            {
                if (pezzi[i] != "" && pezzi[i] != "." && pezzi[i] != "..")
                    parametri.Add(pezzi[i]);
            }
            if(parametri.Count > 0)
                return parametri;
            return new List<string>() { paginaBase };
        }

        public byte[] RestituisciFile(List<string> parametri)
        {
            string nomeFile = Path.Combine(parametri.ToArray());
            string doveCercarlo = Path.Combine(percorsoBase, nomeFile);
            if (File.Exists(doveCercarlo))
            {
                return File.ReadAllBytes(doveCercarlo);
            } else
            {
                return new byte[0];
            }
        }
    }
}
