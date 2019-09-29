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

namespace App_MetroCali
{
    public partial class Form1 : Form
    {

        GMarkerGoogle marker;
        GMapOverlay markerOverlayParada;
        GMapOverlay markerOverlayMIO;
        GMapOverlay markerOverlayZonas;

        double latitudCali = 3.42158;
        double longitudCali = -76.5205;

        List<Stops> Paradas = new List<Stops>();
        List<Stops> ParadasEstaciones = new List<Stops>();
        List<Stops> ParadasCalle = new List<Stops>();
        List<ZONA> Zonas = new List<ZONA>();

        List<MIO> Buses = new List<MIO>();
        List<MIO> cantidadBuses = new List<MIO>();

        List<ZONA> zona0 = new List<ZONA>();
        List<ZONA> zona1 = new List<ZONA>();
        List<ZONA> zona2 = new List<ZONA>();
        List<ZONA> zona3 = new List<ZONA>();
        List<ZONA> zona4 = new List<ZONA>();
        List<ZONA> zona5 = new List<ZONA>();
        List<ZONA> zona6 = new List<ZONA>();
        List<ZONA> zona7 = new List<ZONA>();



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e){
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

            cbZonas.Items.Add("0");
            cbZonas.Items.Add("1");
            cbZonas.Items.Add("2");
            cbZonas.Items.Add("3");
            cbZonas.Items.Add("4");
            cbZonas.Items.Add("5");
            cbZonas.Items.Add("6");
            cbZonas.Items.Add("7");

            pbIMAGEN.Image = Image.FromFile(@"logoMio.JPG");


            lecturaParadas();
            separarListasDeParadas();

            leerZonasCiudad();
            separarZonas();

            lecturaDatagramas();
            separarBUSES();

            markerOverlayMIO = new GMapOverlay("markadorMIO");
            Bitmap markerMio = (Bitmap)Image.FromFile(@"iconoMio.png");
            marker = new GMarkerGoogle(new PointLatLng(3.4372201, -76.5224991), markerMio);
            markerOverlayMIO.Markers.Add(marker);

            marker.ToolTipMode = MarkerTooltipMode.Always;
            marker.ToolTipText = String.Format("Este es el mio");
            gControl.Overlays.Add(markerOverlayMIO);
        }

        public void lecturaParadas()
        {

            StreamReader lector = new StreamReader(@"STOPS.txt");
            String line = lector.ReadLine();
            int i = 0;
            while (line != null)
            {
                String[] arregloString = line.Split(',');
                String STOPID = arregloString[0];
                String PLANVERSIONID = arregloString[1];
                String SHORTNAME = arregloString[2];
                String LONGNAME = arregloString[3];
                String GPS_X = arregloString[4];
                String GPS_y = arregloString[5];
                double DECIMALLONGITUD = double.Parse(arregloString[6], CultureInfo.InvariantCulture);
                double DECIMALLATITUD = double.Parse(arregloString[7], CultureInfo.InvariantCulture);
                Stops parada = new Stops(STOPID, PLANVERSIONID, SHORTNAME, LONGNAME, GPS_X, GPS_y, DECIMALLONGITUD, DECIMALLATITUD);
                Paradas.Add(parada);
                i++;
                line = lector.ReadLine();
            }
            lector.Close();
        }


        public void separarListasDeParadas()
        {
            for (int i = 0; i < Paradas.Count; i++)
            {
                if (retornarLista()[i].STOPID.Substring(0, 1).Equals("6"))
                {
                    ParadasEstaciones.Add(Paradas[i]);
                    //Console.WriteLine("ESTACION : "+ParadasEstaciones[i].LONGNAME);
                }
                else if (retornarLista()[i].STOPID.Substring(0, 1).Equals("5"))
                {
                    ParadasCalle.Add(Paradas[i]);
                    // Console.WriteLine("CALLE : "+ParadasCalle[i].LONGNAME);
                }
            }
        }


        public List<Stops> retornarLista(){
            return Paradas;
        }

        private void GControl_Load(object sender, EventArgs e) { }

        private void Bguardar_Click(object sender, EventArgs e){
            filter();
        }

        private void filter(){
            switch (cb_elegir.Text)
            {
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

        public void mostrarMarcadores(List<Stops> a) { 
            MessageBox.Show("Preparando para mostrar marcadores");
            int S = 0;
            markerOverlayParada = new GMapOverlay("markadorParada");
            for (int i = 0; i < a.Count(); i++)
            {
                marker = new GMarkerGoogle(new PointLatLng(a[S].DECIMALLATITUD, a[S].DECIMALLONGITUD), GMarkerGoogleType.red);

                markerOverlayParada.Markers.Add(marker);
                marker.ToolTipMode = MarkerTooltipMode.Always;
                marker.ToolTipText = String.Format("Parada:" + a[S].SHORTNAME);

                Console.WriteLine(S);
                S++;
            }
            gControl.Overlays.Add(markerOverlayParada);
            Console.WriteLine(a.Count());
        }

        private void Cb_elegir_SelectedIndexChanged(object sender, EventArgs e) { }

        private void GControl_Load_1(object sender, EventArgs e) { }

        private void Button1_Click(object sender, EventArgs e) { 
            seleccionZona();
        }

        public void leerZonasCiudad(){
            StreamReader lector = new StreamReader(@"ZONAS.txt");
            String line = lector.ReadLine();
            int i = 0;
            while (line != null)
            {
                String[] arregloZonas = line.Split(',');
                String nom = arregloZonas[0];
                String lat = arregloZonas[1];
                String longi = arregloZonas[2];
                double latitud = double.Parse(lat, CultureInfo.InvariantCulture);
                double longitud = double.Parse(longi, CultureInfo.InvariantCulture);
                ZONA zone = new ZONA(nom, latitud, longitud);
                Zonas.Add(zone);
                i++;
                line = lector.ReadLine();
            }
            lector.Close();
        }

        public void mostrarLista(){
            for (int i = 0; i < zona0.Count; i++){
                MessageBox.Show(zona0[i].longitud + " " + zona0[i].latitud);
            }
        }

        public void mostrarMarcadoresZonas(){
            markerOverlayZonas = new GMapOverlay("MarkadorZona");
            for (int i = 0; i < Zonas.Count(); i++)
            {
                marker = new GMarkerGoogle(new PointLatLng(Zonas[i].latitud, Zonas[i].longitud), GMarkerGoogleType.green);
                markerOverlayZonas.Markers.Add(marker);
                marker.ToolTipMode = MarkerTooltipMode.Always;
                Console.WriteLine(i);
            }
            gControl.Overlays.Add(markerOverlayZonas);
        }

        public void seleccionZona(){
            switch (cbZonas.Text)
            {
                case "":
                    MessageBox.Show("Debe seleccionar un numero de zona");
                    break;
                case "0":
                    hacerPoligonoZonas(zona0);
                    break;
                case "1":
                    hacerPoligonoZonas(zona1);
                    break;
                case "2":
                    hacerPoligonoZonas(zona2);
                    break;
                case "3":
                    hacerPoligonoZonas(zona3);
                    break;
                case "4":
                    hacerPoligonoZonas(zona4);
                    break;
                case "5":
                    hacerPoligonoZonas(zona5);
                    break;
                case "6":
                    hacerPoligonoZonas(zona6);
                    break;
                case "7":
                    hacerPoligonoZonas(zona7);
                    break;
            }
        }

        public void separarZonas(){
            for (int i = 0; i < Zonas.Count; i++)
            {
                if (i < 4)
                {
                    zona0.Add(Zonas[i]);
                }
                else if (i >= 4 && i < 7)
                {
                    zona1.Add(Zonas[i]);
                }
                else if (i >= 7 && i < 10)
                {
                    zona2.Add(Zonas[i]);
                }
                else if (i >= 10 && i < 14)
                {
                    zona3.Add(Zonas[i]);
                }
                else if (i >= 14 && i < 21)
                {
                    zona4.Add(Zonas[i]);
                }
                else if (i >= 21 && i < 23)
                {
                    zona5.Add(Zonas[i]);
                }
                else if (i >= 23 && i < 27)
                {
                    zona6.Add(Zonas[i]);
                }
                else if (i >= 27 && i < 29)
                {
                    zona7.Add(Zonas[i]);
                }
            }

        }

        public void hacerPoligonoZonas(List<ZONA> a){
            GMapOverlay poligono = new GMapOverlay("Poligono");
            List<PointLatLng> puntos = new List<PointLatLng>();
            for (int i = 0; i < a.Count; i++)
            {
                puntos.Add(new PointLatLng(a[i].latitud, a[i].longitud));
            }
            GMapPolygon poligonoPuntos = new GMapPolygon(puntos, "Poligono");
            poligono.Polygons.Add(poligonoPuntos);
            gControl.Overlays.Add(poligono);
            gControl.Zoom = gControl.Zoom + 1;
            gControl.Zoom = gControl.Zoom - 1;
        }


        private void removeMakers(){
            if (gControl.Overlays.Count > 0)
            {
                gControl.Overlays.Clear();
                gControl.Refresh();
            }
        }

        public void lecturaDatagramas(){
            StreamReader lector = new StreamReader(@"DATAGRAMS.txt");
            String line = lector.ReadLine();
            int i = 0;
            while (line != null)
            {
                String[] arregloDatagramas = line.Split(',');

                String EVENTTYPE = arregloDatagramas[0];
                String REGISTERDATE = arregloDatagramas[1];
                String STOPID = arregloDatagramas[2];
                String ODOMETER = arregloDatagramas[3];

                String LATITUDE = arregloDatagramas[4];
                String LONGITUDE = arregloDatagramas[5];

                String TASKID = arregloDatagramas[6];
                String LINEID = arregloDatagramas[7];
                String TRIPID = arregloDatagramas[8];

                String DATAGRAMID = arregloDatagramas[9];
                String DATAGRAMDATE = arregloDatagramas[10];
                String BUSID = arregloDatagramas[11];

                MIO bus = new MIO(EVENTTYPE, REGISTERDATE, STOPID, ODOMETER, LATITUDE, LONGITUDE, TASKID, LINEID, TRIPID, DATAGRAMID, DATAGRAMDATE, BUSID);
                Buses.Add(bus);
                i++;
                line = lector.ReadLine();
            }
            lector.Close();

        }


        public void separarBUSES(){
            for (int i = 0; i < Buses.Count; i++)
            {
                if (!Buses[i].BUSID.Equals(Buses[i + 1].BUSID))
                {
                    cantidadBuses.Add(Buses[i]);
                    Console.WriteLine(cantidadBuses[i].BUSID);
                }
                else if (Buses[i].BUSID.Equals(Buses[i + 1].BUSID))
                {
                    i = Buses.Count();
                }

            }

        }

        public void generarBloquesDEinfoCadaMio(){
         for(int i = 0;i< cantidadBuses.Count; i++){
                for(int j = 0; j < Buses.Count; j++) {
                    if (cantidadBuses[i].BUSID.Equals(Buses[j].BUSID)){

                    }
                }
            }

        }

        private void BPuntosZonas_Click_1(object sender, EventArgs e){
            mostrarMarcadoresZonas();
        }

        private void BEliminar_Click(object sender, EventArgs e){
            removeMakers();
        }
    }

}
