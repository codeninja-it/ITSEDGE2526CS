using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Google.Crypto.Tink.Signature;

namespace Maui01.Strutture
{
    public class Comanda
    {
        public string Id { get; set; } = new Guid().ToString();
        public Tavolo tavolo { get; set; }
        public Piatto piatto { get; set; }
        public DateTime quando { get; set; }
        public bool pronto { get; set; }
    }
}
