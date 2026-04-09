namespace App04
{
    public partial class Form1 : Form
    {
        private Graphics paint;
        private Pen matita;
        private List<Point> ultimiPunti = new List<Point>();

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

                DisegnaLinea(attuale);
            }
            else
            {
                ultimiPunti.Clear();
            }
        }

        private void DisegnaLinea(Point b, int finestra = 2)
        {
            // se ho almeno un punto
            // devo calcolare il punto medio di tutti i precedenti
            // ed è lui che deve essere registrato
            if(ultimiPunti.Count > 1)
            {
                // ne calcolo la media
                Point puntoMedio = new Point(
                    (ultimiPunti.Sum(p => p.X) + b.X) / (ultimiPunti.Count + 1), 
                    (ultimiPunti.Sum(p => p.Y) + b.Y) / (ultimiPunti.Count + 1)
                );
                // per disegnare la mia linea devo usare
                // il punto medio e da quello che avevo calcolato la volta scorsa
                //Point precedenteMedio = ultimiPunti[ultimiPunti.Count - 1];
                //Point precedenteMedio = ultimiPunti[-1];
                Point precedenteMedio = ultimiPunti.Last();
                paint.DrawLine(matita, precedenteMedio, puntoMedio);
                pctImmagine.Invalidate();
                // e se ho oltrepassato gli elementi da registrare
                // per evitare di finire in cavitazione
                // ammazzo il più vecchio
                if (ultimiPunti.Count > finestra)
                    ultimiPunti.RemoveAt(0);
                // e alla fine tengo memoria di quello nuovo
                ultimiPunti.Add( puntoMedio );
            } else
            {
                // registro b perchè non posso calcolare alcun punto medio
                ultimiPunti.Add(b);
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

        private void mnuApri_Click(object sender, EventArgs e)
        {
            dlgApri.Title = "Seleziona l'immagine da aprire";
            dlgApri.Filter = "File JPG|*.jpg|File PNG|*.png|Tutti i files|*.*";
            DialogResult risultato = dlgApri.ShowDialog();
            if (risultato == DialogResult.OK)
            {
                string immagineDaAprire = dlgApri.FileName;
                pctImmagine.Image = new Bitmap(immagineDaAprire);
                paint = Graphics.FromImage(pctImmagine.Image);
            }
        }

        private void mnuSalva_Click(object sender, EventArgs e)
        {
            dlgSalva.Title = "Seleziona l'immagine da aprire";
            dlgSalva.Filter = "File JPG|*.jpg|File PNG|*.png|Tutti i files|*.*";
            DialogResult risultato = dlgSalva.ShowDialog();
            if(risultato == DialogResult.OK)
            {
                string percorso = dlgSalva.FileName;
                pctImmagine.Image.Save(percorso);
            }
        }
    }
}
