namespace App04
{
    public partial class Form1 : Form
    {
        private Graphics paint;
        private Pen matita;
        private List<Point> ultimiPunti = new List<Point>();
        private Impostazioni impostazioni = new Impostazioni();

        public Form1()
        {
            InitializeComponent();
            pctImmagine.Image = new Bitmap(this.Width, this.Height);
            paint = Graphics.FromImage(pctImmagine.Image);
            paint.Clear(Color.White);
            matita = new Pen(impostazioni.Colore, impostazioni.Tratto);
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

                DisegnaLinea(attuale, impostazioni.Finestra);
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
            if (ultimiPunti.Count > 1)
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
                ultimiPunti.Add(puntoMedio);
            }
            else
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
            Livello nuovo = new Livello(this.Width, this.Height);
            lstLivelli.Items.Add(nuovo);
            lstLivelli.SelectedItem = nuovo;
            pctImmagine.Image = nuovo.Immagine;
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
                Livello nuovo = new Livello(immagineDaAprire);
                lstLivelli.Items.Add(nuovo);
                lstLivelli.SelectedItem = nuovo;
                pctImmagine.Image = nuovo.Immagine;
                paint = Graphics.FromImage(pctImmagine.Image);
            }
        }

        private void mnuSalva_Click(object sender, EventArgs e)
        {
            if (lstLivelli.SelectedItem == null)
                return;
            dlgSalva.Title = "Seleziona l'immagine da aprire";
            dlgSalva.Filter = "File JPG|*.jpg|File PNG|*.png|Tutti i files|*.*";
            DialogResult risultato = dlgSalva.ShowDialog();
            if (risultato == DialogResult.OK)
            {
                string percorso = dlgSalva.FileName;
                Livello selezionato = (Livello)lstLivelli.SelectedItem;
                selezionato.Salva(percorso);
            }
        }

        private void modificaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormImpostazioni nuovo = new FormImpostazioni(impostazioni);
            DialogResult risultato = nuovo.ShowDialog();
            if (risultato == DialogResult.OK)
            {
                // aggiornare la mia matita
                matita = new Pen(impostazioni.Colore, impostazioni.Tratto);
            }
        }

        private void mnuSostituisci_Click(object sender, EventArgs e)
        {
            ColoreDaA colori = new ColoreDaA(Color.Black, Color.White, 10, TipologiaSostituzione.Positiva);
            FrmSostituisci sostituisci = new FrmSostituisci(colori);
            DialogResult risultato = sostituisci.ShowDialog();
            if (risultato == DialogResult.OK)
            {
                Livello selezionato = (Livello)lstLivelli.SelectedItem;
                if (selezionato == null)
                    return;
                Livello nuovo = new Livello("Sostituzione colore", selezionato.Immagine);
                lstLivelli.Items.Add(nuovo);
                lstLivelli.SelectedItem = nuovo;
                int totali = nuovo.Immagine.Width * nuovo.Immagine.Height;
                int intercettati = 0;
                for (int x = 0; x < nuovo.Immagine.Width; x++)
                {
                    for (int y = 0; y < nuovo.Immagine.Height; y++)
                    {
                        Color singolo = nuovo.Immagine.GetPixel(x, y);
                        if (colori.ControlloCilindrico(singolo))
                        {
                            intercettati++;
                            nuovo.Immagine.SetPixel(x, y, colori.A);
                        }
                    }
                }
                float percentuale = (float)intercettati / (float)totali * 100.0f;
                MessageBox.Show($"il {percentuale:N2}% della superificie era positivo.");
                pctImmagine.Image = nuovo.Immagine;
                paint = Graphics.FromImage(pctImmagine.Image);
                pctImmagine.Refresh();
            }
        }

        private void lstLivelli_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstLivelli.SelectedItem == null)
                return;
            Livello selezionato = (Livello)lstLivelli.SelectedItem;
            pctImmagine.Image = selezionato.Immagine;
            paint = Graphics.FromImage(pctImmagine.Image);
            pctImmagine.Refresh();
        }
    }
}
