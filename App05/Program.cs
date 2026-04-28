using App05.Dati;
using App05.Dati.Strutture;
using System.Net;
using System.Text;

namespace App05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BancaDati db = new BancaDati();
            
            // costruisco il server
            HttpListener serverWeb = new HttpListener();
            // lo imposto
            serverWeb.Prefixes.Add("http://localhost:8080/");

            // e solo dopo! lo attivo!
            serverWeb.Start();

            while (true)
            {
                HttpListenerContext chiamata = serverWeb.GetContext();
                switch (chiamata.Request.RawUrl)
                {
                    case "/file":
                        // basandomi su cosa so
                        string nomeFile = "prova.txt";
                        string cartellaPubblica = "wwwroot";
                        string posizioneEseguibile = Environment.CurrentDirectory;
                        // calcolo il percorso del file da spedire
                        string percorsoFile = Path.Combine(posizioneEseguibile, cartellaPubblica, nomeFile);
                        if (!File.Exists(percorsoFile))
                        {
                            chiamata.Response.StatusCode = 404;
                            chiamata.Response.Close();
                        } else
                        {
                            byte[] buffer = File.ReadAllBytes(percorsoFile);
                            chiamata.Response.OutputStream.Write(buffer, 0, buffer.Length);
                            chiamata.Response.Close();
                        }

                        break;
                    case "/in":
                        break;
                    case "/out":
                        break;
                    default: // se non ho traguardato nessuno dei precedenti... ...404.
                        chiamata.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        chiamata.Response.Close();
                        break;

                }
                
            }
            
        }
    }
}
