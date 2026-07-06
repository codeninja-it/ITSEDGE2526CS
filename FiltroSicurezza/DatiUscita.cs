using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiltroSicurezza
{
    public class DatiUscita
    {
        [ColumnName("Text")]
        public string Text { get; set; }
        [ColumnName("Features")]
        public float[] Feature { get; set; }
        [ColumnName("PredictedLabel")]
        public string PredictedLabel { get; set; }
        [ColumnName("Score")]
        public float[] Score { get; set; }
    }
}
