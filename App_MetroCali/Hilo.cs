using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace App_MetroCali
{
    public class Hilo
    {

        public MIO mio;

        public String longitude;

        public String latitude;

        public Boolean continuar;

        public Hilo(MIO mio, String longitude, String latitude)
        {
            this.mio = mio;
            this.latitude = longitude;
            this.latitude = latitude;

            continuar = true;
        }

        public void detenerHilo()
        {
            continuar = false;
        }

        public void run()
        {
            while (continuar)
            {
                mio.moveBus(latitude, longitude);

                //condicion de parada del hilo
                if (true)
                {
                    detenerHilo();
                }

                Thread.Sleep(50);

            }
        }

    }
}
