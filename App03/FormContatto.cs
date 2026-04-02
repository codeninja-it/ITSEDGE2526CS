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
            txtNome.Text = contatto.Nome;
            txtCognome.Text = contatto.Cognome;
            txtEmail.Text = contatto.Email;
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            contatto.Nome = txtNome.Text;
            contatto.Cognome = txtCognome.Text;
            contatto.Email = txtEmail.Text;
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
