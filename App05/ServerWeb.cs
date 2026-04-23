using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App05
{
    public class ServerWeb
    {
        private readonly HttpListener telefono;
        public bool online => telefono.IsListening;

        public ServerWeb(string indirizzo)
        {
            telefono = new HttpListener();
            telefono.Prefixes.Add(indirizzo);
            telefono.Start();

        }


    }
}
