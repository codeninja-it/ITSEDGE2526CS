using System.Net;
using System.Text;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace App07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HttpListener telefono = new HttpListener();
            telefono.Prefixes.Add("http://localhost:8080/");
            telefono.Start();

            string wwwroot = Path.Combine(Environment.CurrentDirectory, "wwwroot");

            if(!Directory.Exists(wwwroot))
                Directory.CreateDirectory(wwwroot);

            do
            {
                HttpListenerContext linea = telefono.GetContext();
                string[] pezzi = linea.Request.RawUrl.Split("/");
                string paginaRichiesta = wwwroot;
                foreach(string pezzo in pezzi)
                {
                    if(pezzo != "" && pezzo != "." && pezzo != "..")
                    {
                        paginaRichiesta = Path.Combine(paginaRichiesta, pezzo);
                    }
                }

                if (!File.Exists(paginaRichiesta))
                {
                    linea.Response.OutputStream.Write(Encoding.UTF8.GetBytes("File non presente sul server"));
                    linea.Response.StatusCode = 404;
                    linea.Response.Close();
                    continue;
                }
                else
                {
                    string contenuto = File.ReadAllText(paginaRichiesta);
                    ScriptEngine interprete = Python.CreateEngine();
                    interprete.Execute(contenuto);
                }


            } while(true);

        }
    }
}
