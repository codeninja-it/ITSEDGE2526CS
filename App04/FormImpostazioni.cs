using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App04
{
    public partial class FormImpostazioni : Form
    {
        private readonly Impostazioni impostazioni;
        public FormImpostazioni(Impostazioni impostazioni)
        {
            this.impostazioni = impostazioni;
            InitializeComponent();
            trkArrotindamento.Value = impostazioni.Finestra;
            trkTratto.Value = impostazioni.Tratto;
            btnColore.BackColor = impostazioni.Colore;
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            impostazioni.Tratto = trkTratto.Value;
            impostazioni.Colore = btnColore.BackColor;
            impostazioni.Finestra = trkArrotindamento.Value;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnColore_Click(object sender, EventArgs e)
        {
            dlgColore.Color = btnColore.BackColor;
            DialogResult risultato = dlgColore.ShowDialog();
            if(risultato == DialogResult.OK)
            {
                btnColore.BackColor = dlgColore.Color;
            }
        }
    }
}
