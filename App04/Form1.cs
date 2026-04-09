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
            this.BackgroundImage = new Bitmap(this.Width, this.Height);
            paint = Graphics.FromImage(this.BackgroundImage);
            paint.Clear(Color.White);
            matita = new Pen(Brushes.MediumSeaGreen, 3);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                if (precedente == null)
                {
                    precedente = e.Location;
                    return;
                }

                Point attuale = e.Location;
                paint.DrawLine(matita, precedente.Value, attuale);
                precedente = attuale;
                this.Invalidate();
            } else
            {
                precedente = null;
            }            
        }
    }
}
