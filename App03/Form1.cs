namespace App03
{
    public partial class Form1 : Form
    {
        private readonly List<Contatto> rubrica;

        public Form1(List<Contatto> rubrica)
        {
            this.rubrica = rubrica;
            InitializeComponent();
        }

        private void btnApri_Click(object sender, EventArgs e)
        {
            Contatto nuovo = new Contatto();
            FormContatto nuovaFinestra = new FormContatto(nuovo);
            nuovaFinestra.ShowDialog();
        }
    }
}
