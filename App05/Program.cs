using App05.Dati;
using App05.Dati.Strutture;
using App05.Servizi;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using System.Net;
using System.Text;
using System.Text.Json;

namespace App05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BancaDati db = new BancaDati();
            ServerFile fs = new ServerFile("wwwroot", "index.htm");
            
            // costruisco il server
            HttpListener serverWeb = new HttpListener();
            // lo imposto
            serverWeb.Prefixes.Add("http://localhost:8080/");

            // e solo dopo! lo attivo!
            serverWeb.Start();
            Console.WriteLine("Server accesso su http://localhost:8080/");
            // ed inizio ad ascoltare
            while (true)
            {
                HttpListenerContext chiamata = serverWeb.GetContext();
                // recupero il comando
                string comando = fs.TrovaComando(chiamata.Request.RawUrl);
                // recuper i parametri
                List<string> parametri = fs.TrovaParametri(chiamata.Request.RawUrl);
                // e li valuto
                switch (comando)
                {
                    case "file": // l'utente mi chide un file statico
                        // recupero il contenuto se c'è
                        byte[] contenuto = fs.RestituisciFile(parametri);
                        if (contenuto.Length == 0)
                        {
                            chiamata.Response.StatusCode = 404;
                            chiamata.Response.Close();
                        }
                        else
                        {
                            chiamata.Response.Headers.Add("Content-Type", "text/html");
                            chiamata.Response.OutputStream.Write(contenuto, 0, contenuto.Length);
                            chiamata.Response.Close();
                        }
                        break;

                    case "in": // se l'utente mi chiama "/in/[0:nome]/[1:cognome]/[2:telefono]"
                        if(parametri.Count == 3)
                        {
                            Contatto nuovo = new Contatto()
                            {
                                Nome = parametri[0],
                                Cognome = parametri[1],
                                Telefono = parametri[2],
                            };
                            db.Contatti.Add(nuovo);
                            db.SaveChanges();
                            string risposta = $"Il contatto {parametri[0]} {parametri[1]} è stato inserito!";
                            chiamata.Response.OutputStream.Write(Encoding.UTF8.GetBytes(risposta));
                            chiamata.Response.Close();
                        }
                        else
                        {
                            chiamata.Response.StatusCode = 404;
                            chiamata.Response.Close();
                        }                        
                        break;

                    case "out": // quando l'utente mi chiede di restituire tutti i dati collezionati
                        List<Contatto> daEsportare = db
                                                        .Contatti
                                                        .Include(c => c.Tipo)
                                                        .OrderBy(c => c.Cognome)
                                                        .ToList();
                        string buffer = JsonSerializer.Serialize(daEsportare);
                        byte[] daInviare = Encoding.UTF8.GetBytes(buffer);
                        chiamata.Response.Headers.Add("Content-Type", "application/json");
                        chiamata.Response.OutputStream.Write(daInviare);
                        chiamata.Response.Close();
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
