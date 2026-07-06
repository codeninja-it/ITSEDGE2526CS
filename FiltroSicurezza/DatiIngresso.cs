using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiltroSicurezza
{
    public class DatiIngresso
    {
        [LoadColumn(0)]
        [ColumnName("Text")]
        public string Text {  get; set; }
        [LoadColumn(2)]
        [ColumnName("Category")]
        public string Category { get; set; }
    }
}
