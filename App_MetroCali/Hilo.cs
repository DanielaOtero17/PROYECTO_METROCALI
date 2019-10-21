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

        public Hilo(MIO mio, Form1 forma)
        {
            mios = mio;
            ventana = forma;
        }

        public void run(int i)
        {

            MessageBox.Show("entrando ");

            while (true)
            {
                
                    mios.changeLocation();

                    double latitud = ventana.ordenarDecimal(mios.LATITUDE);
                    double longitud = ventana.ordenarDecimal(mios.LONGITUDE);

               
                    ventana.markerOverlayMIO.Markers[i].Position = new PointLatLng(latitud, longitud);

                ventana.gControl.Refresh();
                try
                {
                    Thread.Sleep(100);
                }
                catch (ThreadInterruptedException e)
                {
                    // TODO Auto-generated catch block


                }
            }
        }

        public static void main(String[] args)
        {

           

        }


    }
}



    
