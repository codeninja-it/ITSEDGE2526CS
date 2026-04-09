namespace App04
{
    public partial class Form1 : Form
    {
        private Graphics paint;
        private Pen matita;
        private Point? precedente;

        public Form1()
        {
            InitializeComponent();
            pctImmagine.Image = new Bitmap(this.Width, this.Height);
            paint = Graphics.FromImage(pctImmagine.Image);
            paint.Clear(Color.White);
            matita = new Pen(Brushes.MediumSeaGreen, 3);
        }

        private void PctImmagine_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int altezzaSchermo = pctImmagine.Height;
                int altezzaImmagine = pctImmagine.Image.Height;
                float rapportoH = (float)altezzaImmagine / (float)altezzaSchermo;
                float rapportoW = (float)pctImmagine.Image.Width / (float)pctImmagine.Width;
                Point attuale = new Point((int)(e.X * rapportoW), (int)(e.Y * rapportoH));

                if (precedente == null)
                {
                    precedente = attuale;
                    return;
                }

                paint.DrawLine(matita, precedente.Value, attuale);
                precedente = attuale;
                pctImmagine.Invalidate();
            }
            else
            {
                precedente = null;
            }
        }

        private void mnuEsci_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mnuNuovo_Click(object sender, EventArgs e)
        {
            pctImmagine.Image = new Bitmap(this.Width, this.Height);
            paint = Graphics.FromImage(pctImmagine.Image);
            paint.Clear(Color.White);
            pctImmagine.Invalidate();
        }
    }
}
