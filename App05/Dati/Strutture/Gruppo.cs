using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App05.Dati.Strutture
{
    [Table("Gruppi")]
    public class Gruppo : Sicurezza
    {
        [Key] public int Id { get; set; }
        [Required] public string Nome { get; set; } = string.Empty;
        public string Descrizione { get; set; } = string.Empty;
        public List<Contatto> Contatti { get; set; } = new List<Contatto>();
    }
}
