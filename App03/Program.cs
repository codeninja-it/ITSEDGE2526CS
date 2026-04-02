namespace App03
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            List<Contatto> rubrica = new List<Contatto>();

            Application.Run(   new Form1(rubrica)  );
        }
    }
}