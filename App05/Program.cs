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
                Console.WriteLine(chiamata);
                if(chiamata.Request.RawUrl == "/")
                {
                    // qui inviamo la home page
                    Stream flusso = chiamata.Response.OutputStream;

                    byte[] buffer = Encoding.UTF8.GetBytes("Benvenuto nel nostro sistema online!");

                    flusso.Write(buffer);
                    flusso.Close();
                } else
                {
                    // altrimenti diremo all'utente 404
                    chiamata.Response.StatusCode = 404;
                    chiamata.Response.Close();
                }
            }
            
        }
    }
}
