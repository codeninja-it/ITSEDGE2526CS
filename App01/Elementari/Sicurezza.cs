using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App01.Elementari
{
    public class Sicurezza
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string IdUtente { get; set; } = "admin";
        public DateTime Creazione { get; set; } = DateTime.Now;
        public string CheckSum()
        {
            return Id + IdUtente + Creazione.ToString("yyyyMMddHHmmss");
        }
    }
}
