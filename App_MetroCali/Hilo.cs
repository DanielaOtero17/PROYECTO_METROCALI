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
                
                 for (int i = 0; i < ventana.Buses.Count; i++) {
                   // MessageBox.Show(" ejecutando " + i);
                    ventana.Buses[i].changeLocation();

                    double latitud = ventana.ordenarDecimal(ventana.Buses[i].LATITUDE);
                    double longitud = ventana.ordenarDecimal(ventana.Buses[i].LONGITUDE);

                 //   Console.Write(i + "");
                    ventana.gControl.Overlays[0].Markers[i].Position = new PointLatLng(latitud, longitud);
                   ventana.gControl.Zoom = ventana.gControl.Zoom + 0.1;
                    ventana.gControl.Zoom = ventana.gControl.Zoom - 0.1;
                }


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


    }
}



    
