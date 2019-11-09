using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using System.Windows.Forms;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using System.IO;
using GMap.NET;

namespace App_MetroCali
{
    public class Hilo
    {

        public MIO mios;
        private Form1 ventana;

        private String x;
        private String y;
        private Boolean continuar;

        public Hilo(MIO mio, Form1 forma, String x, String y)
        {
            mios = mio;
            ventana = forma;
            this.x = x;
            this.y = y;
            continuar = true;
        }

        public void run()
        {

            //MessageBox.Show("entrando ");

            while (continuar)
            {

                mios.moveBus(Int32.Parse(x), Int32.Parse(y));

                if (mios.LATITUDE.Equals(x) && mios.LONGITUDE.Equals(y))
                {
                    continuar = false;
                }

                //mios.changeLocation();

                //double latitud = ventana.ordenarDecimal(mios.LATITUDE);
                //double longitud = ventana.ordenarDecimal(mios.LONGITUDE);


                //ventana.markerOverlayMIO.Markers[i].Position = new PointLatLng(latitud, longitud);

                
                try
                {
                    Thread.Sleep(100);
                }
                catch (ThreadInterruptedException e)
                {

                }
                //ventana.gControl.Refresh();
            }
        }

        public static void main(String[] args)
        {

           

        }


    }
}



    
