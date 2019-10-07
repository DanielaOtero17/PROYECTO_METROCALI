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

        public MIO mio;

        private List<MIO> mios;
        private Form1 ventana;

        public Hilo(List<MIO> mio, Form1 forma)
        {
            mios = mio;
            ventana = forma;
        }

        public void run()
        {

            MessageBox.Show("entrando ");

            while (true)
            {
                //MessageBox.Show(" ejecutando ");
                 for (int i = 0; i < 1; i++) {

                ventana.Buses[i].changeLocation();

                    double latitud = ventana.ordenarDecimal(ventana.Buses[i].LATITUDE);
                    double longitud = ventana.ordenarDecimal(ventana.Buses[i].LONGITUDE);

                    Console.Write(i + "");
                    ventana.gControl.Overlays[i].Markers[i].Position = new PointLatLng(latitud, longitud);
                }


                try
                {
                    Thread.Sleep(1000);
                }
                catch (ThreadInterruptedException e)
                {
                    // TODO Auto-generated catch block


                }
            }
        }


    }
}



    
