using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Maui03
{
    public class Orologio
    {
        private int attesa;
        private Action callback;
        private bool inFunzione;

        public Orologio(int attesa)
        {
            this.attesa = attesa;
        }

        public void Start(Action callback)
        {
            this.callback = callback;
            inFunzione = true;
            Ciclo();
        }

        private void Ciclo()
        {
            Thread.Sleep(attesa);
            callback();
            if (inFunzione)
                Ciclo();
        }

        public void Stop() { 
            inFunzione = false;
        }
    }
}
