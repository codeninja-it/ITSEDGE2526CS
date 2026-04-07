namespace App04
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.BackgroundImage = new Bitmap(this.Width, this.Height);

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                lblCoordinate.Text = $" {e.X} : {e.Y} ";
                Bitmap sfondo = (Bitmap)this.BackgroundImage;
                sfondo.SetPixel(e.X, e.Y, Color.Black);
                this.Invalidate();
            }                
        }
    }
}
