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
    public partial class FrmSostituisci : Form
    {
        private readonly ColoreDaA setColori;
        public FrmSostituisci(ColoreDaA colori)
        {
            InitializeComponent();
            setColori = colori;
            btnDa.BackColor = setColori.Da;
            btnA.BackColor = setColori.A;
            trkTolleranza.Value = (int)colori.Tolleranza;
            chkPositivo.Checked = setColori.Tipo == TipologiaSostituzione.Positiva;
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnApplica_Click(object sender, EventArgs e)
        {
            setColori.Tolleranza = trkTolleranza.Value;
            setColori.Da = btnDa.BackColor;
            setColori.A = btnA.BackColor;
            setColori.Tipo = chkPositivo.Checked ? TipologiaSostituzione.Positiva : TipologiaSostituzione.Negativa;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnDa_Click(object sender, EventArgs e)
        {
            dlgColore.Color = btnDa.BackColor;
            DialogResult risultato = dlgColore.ShowDialog();
            if (risultato == DialogResult.OK)
            {
                btnDa.BackColor = dlgColore.Color;
            }
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            dlgColore.Color = btnA.BackColor;
            DialogResult risultato = dlgColore.ShowDialog();
            if (risultato == DialogResult.OK)
            {
                btnA.BackColor = dlgColore.Color;
            }
        }
    }
}
