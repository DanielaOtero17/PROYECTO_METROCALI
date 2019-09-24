using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using System.IO;
using System.Globalization;

namespace App_MetroCali{
    public partial class Form1 : Form{

        GMarkerGoogle marker;
        GMapOverlay markerOverlay;
        double latitudCali = 3.42158;
        double longitudCali = -76.5205;

        int i = 0;
        List<Stops> Paradas = new List<Stops>();
        List<Stops> ParadasEstaciones = new List<Stops>();
        List<Stops> ParadasCalle = new List<Stops>();
      

        public Form1(){
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gControl.DragButton = MouseButtons.Left;
            gControl.CanDragMap = true;
            gControl.MapProvider = GMapProviders.GoogleMap;
            gControl.Position = new PointLatLng(latitudCali, longitudCali);
            gControl.MinZoom = 0;
            gControl.MaxZoom = 24;
            gControl.Zoom = 18;
            gControl.AutoScroll = true;

            cb_elegir.Items.Add("ESTACIONES");
            cb_elegir.Items.Add("PARADAS EN LAS CALLES");
            cb_elegir.Items.Add("PATIOS");

            lecturaParadas();

            markerOverlay = new GMapOverlay("Marcador");
            Bitmap markerMio = (Bitmap)Image.FromFile(@"iconoMio.png");
            marker = new GMarkerGoogle(new PointLatLng(3.4372201, -76.5224991), markerMio);
            markerOverlay.Markers.Add(marker);

            marker.ToolTipMode = MarkerTooltipMode.Always;
            marker.ToolTipText = String.Format("Este es el mio");
            gControl.Overlays.Add(markerOverlay);
        }

        public void lecturaParadas(){

            StreamReader lector = new StreamReader(@"STOPS.txt");
            String line = lector.ReadLine();
        

             while (line != null){

                String[] arregloString = line.Split(',');
              
                String STOPID = arregloString[0];
                String PLANVERSIONID = arregloString[1];
                String SHORTNAME = arregloString[2];
                String LONGNAME = arregloString[3];
                String GPS_X = arregloString[4];
                String GPS_y = arregloString[5];
                double DECIMALLONGITUD = double.Parse(arregloString[6],CultureInfo.InvariantCulture);
                double DECIMALLATITUD = double.Parse(arregloString[7], CultureInfo.InvariantCulture);

                Stops parada = new Stops(STOPID, PLANVERSIONID, SHORTNAME, LONGNAME, GPS_X, GPS_y, DECIMALLONGITUD, DECIMALLATITUD);
                Paradas.Add(parada);

                i++;
                line = lector.ReadLine();
               
            }
             lector.Close();

          }

        public void separarListasDeParadas() {
            for(int i = 0; i< Paradas.Count; i++)
            {
                if (retornarLista()[i].STOPID.Substring(0, 1).Equals("6"))
                {
                    ParadasEstaciones.Add(Paradas[i]);
                }
                else if(retornarLista()[i].STOPID.Substring(0,1).Equals("5"))
                {
                    ParadasCalle.Add(Paradas[i]);
                }
            }
        }


        public List<Stops> retornarLista() {
         return Paradas;
        }

        private void GControl_Load(object sender, EventArgs e){}

        private void Bguardar_Click(object sender, EventArgs e){
            filter();
        }

        private void filter(){
            switch (cb_elegir.Text){
                case "":
                    MessageBox.Show("Por favor seleccione una opción.");
                    break;

                case "ESTACIONES":
                    mostrarMarcadores(ParadasEstaciones);
                    break;

                case "PARADAS EN LAS CALLES":
                    mostrarMarcadores(ParadasCalle);
                    break;

                case "PATIOS":
                    MessageBox.Show("Esta área se encuentra temporalmente fuera de servicio, por favor seleccione otra opción.");
                    break;
            }  
        }

        public void mostrarMarcadores(List<Stops> a){
            for(int i =0; i<a.Count(); i++){
                marker = new GMarkerGoogle(new PointLatLng(a[i].DECIMALLATITUD, a[i].DECIMALLONGITUD),GMarkerGoogleType.red);
                markerOverlay.Markers.Add(marker);

                marker.ToolTipMode = MarkerTooltipMode.Always;
                marker.ToolTipText = String.Format("Parada:" + a[i].SHORTNAME);
                gControl.Overlays.Add(markerOverlay);

            }


        }

        private void Cb_elegir_SelectedIndexChanged(object sender, EventArgs e){}

        private void GControl_Load_1(object sender, EventArgs e)
        {
           

        }

        
    }
}
