using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App03
{
    public partial class FormContatto : Form
    {
        private readonly Contatto contatto;

        public FormContatto(Contatto contatto)
        {
            this.contatto = contatto;
            InitializeComponent();
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            contatto.Nome = "Gianni";
            Close();
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
