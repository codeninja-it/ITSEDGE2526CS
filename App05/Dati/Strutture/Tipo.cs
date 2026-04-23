using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App05.Dati.Strutture
{
    [Table("Tipi")]
    public class Tipo
    {
        [Key] public int Id { get; set; }
        [Required] public string Nome { get; set; } = string.Empty;
        public List<Contatto> Contatti = new List<Contatto>();
    }
}
