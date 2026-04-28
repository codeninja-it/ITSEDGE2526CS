using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App05.Dati.Strutture
{
    [Table("Contatti")]
    public class Contatto : Sicurezza
    {
        [Key] public int Id { get; set; }
        [Required] public string Nome { get; set; } = string.Empty;
        [Required] public string Cognome { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<Gruppo> Gruppi { get; set; } = new List<Gruppo>();
        public Tipo? Tipo { get; set; }
    }
}
