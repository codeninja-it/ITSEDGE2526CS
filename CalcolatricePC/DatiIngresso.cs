using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcolatricePC
{
    public class DatiIngresso
    {
        [LoadColumn(3), ColumnName("Inches")]
        public float Inches { get; set; }
        [LoadColumn(6), ColumnName("Ram")]
        public float Ram { get; set; }
        [LoadColumn(7), ColumnName("Memory")]
        public float Memory { get; set; }
        [LoadColumn(10), ColumnName("Weight")]
        public float Weight { get; set; }
        [LoadColumn(11), ColumnName("Price")]
        public float Price { get; set; }
    }
}
