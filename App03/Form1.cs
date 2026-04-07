namespace App03
{
    public partial class Form1 : Form
    {
        private readonly List<Contatto> rubrica;
        private bool inCancellazione = false;

        public Form1(List<Contatto> rubrica)
        {
            this.rubrica = rubrica;
            InitializeComponent();
            lstContatti.Items.AddRange(rubrica.ToArray());
        }

        private void btnApri_Click(object sender, EventArgs e)
        {
            Contatto nuovo = new Contatto();
            FormContatto nuovaFinestra = new FormContatto(nuovo);
            DialogResult risultato = nuovaFinestra.ShowDialog();
            if (risultato == DialogResult.OK)
            {
                rubrica.Add(nuovo);
                lstContatti.Items.Add(nuovo);
            }
        }

        private void lstContatti_SelectedValueChanged(object sender, EventArgs e)
        {
            // se l'utente ha selezionato qualcosa
            if (lstContatti.SelectedItem != null)
            {
                // ad ogni modo scopro cosa ha selezionato
                Contatto selezionato = (Contatto)lstContatti.SelectedItem;
                // poi mi chiedo cosa vuole fare
                if (inCancellazione)
                { // se lo vuole cancellare?
                    // gli chiedo conferma
                    DialogResult risposta = MessageBox.Show(
                            "Sei sicuro?",
                            "Cancellazione contatto...",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                    // e nel caso me la dia procedo
                    if (risposta == DialogResult.Yes)
                        rubrica.Remove(selezionato);
                }
                else
                { // se invece lo vuole solo modificare?
                    FormContatto modifica = new FormContatto(selezionato);
                    // glielo consento tramite il formContatto
                    modifica.ShowDialog();
                }
                // e in entrambi i casi
                // dopo che l'utente ha fatto quello che deve
                // svuoto la lista a schermo
                lstContatti.Items.Clear();
                // e ricarico tutto
                lstContatti.Items.AddRange(rubrica.ToArray());
            }
        }

        private void lstContatti_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                inCancellazione = true;
        }

        private void lstContatti_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control)
                inCancellazione = false;
        }
    }
}
