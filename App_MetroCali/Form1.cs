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
using System.Threading;


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
        int indexBus = 0;

        List<Stops> Paradas = new List<Stops>();
        List<Stops> ParadasEstaciones = new List<Stops>();
        List<Stops> ParadasCalle = new List<Stops>();
        List<ZONA> Zonas = new List<ZONA>();

        public List<MIO> Buses = new List<MIO>();
        List<MIO> cantidadBuses = new List<MIO>();

        List<ZONA> zona0 = new List<ZONA>();
        List<ZONA> zona1 = new List<ZONA>();
        List<ZONA> zona2 = new List<ZONA>();
        List<ZONA> zona3 = new List<ZONA>();
        List<ZONA> zona4 = new List<ZONA>();
        List<ZONA> zona5 = new List<ZONA>();
        List<ZONA> zona6 = new List<ZONA>();
        List<ZONA> zona7 = new List<ZONA>();
        List<ZONA> zona8 = new List<ZONA>();


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
            cbZonas.Items.Add("8");

            pbIMAGEN.Image = Image.FromFile(@"logoMio.JPG");
            pboxFondoDeco.Image = Image.FromFile(@"fondo.PNG");


            leerZonasCiudad();
            separarZonas();

            lecturaDatagramas();
            //separarBUSES();

            
            markerOverlayMIO = new GMapOverlay("markadorMIO");
           /* Bitmap markerMio = (Bitmap)Image.FromFile(@"iconoMio.png");
            marker = new GMarkerGoogle(new PointLatLng(Double.Parse(bus.LIST_LATITUDE[0]), Double.Parse(bus.LIST_LONGITUDE[0])), markerMio);
            markerOverlayMIO.Markers.Add(marker);

           // marker.ToolTipMode = MarkerTooltipMode.Always;
           marker.ToolTipText = String.Format("Este es el mio");
            gControl.Overlays.Add(markerOverlayMIO);*/
        }

        public void lecturaParadas()
        {

            StreamReader lector = new StreamReader(@"STOPS2.txt");
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
                //Console.WriteLine(parada.SHORTNAME);
            }
            lector.Close();
        }

     

        public void separarListasDeParadas(){
            for (int i = 0; i < Paradas.Count; i++)
            {

                if (Paradas[i].LONGNAME.Contains("Kr ") || Paradas[i].LONGNAME.Contains("Cl ") || Paradas[i].LONGNAME.Contains("entre"))
                {
                    ParadasCalle.Add(Paradas[i]);
                    //Console.WriteLine("ESTACION : "+ParadasEstaciones[i].LONGNAME);
                }
                else if (Paradas[i].LONGNAME.Contains("Patio"))
                {
                    //ParadasCalle.Add(Paradas[i]);
                    //Console.WriteLine("CALLE : "+ParadasCalle[i].LONGNAME);
                }
                else
                {
                    ParadasEstaciones.Add(Paradas[i]);
                }
            }
        }


        public List<Stops> retornarLista(){
            return Paradas;
        }

        public GMapControl returnControl()
        {
            return gControl;
        }
        private void GControl_Load(object sender, EventArgs e) { }

        private void Bguardar_Click(object sender, EventArgs e){
            lecturaParadas();
            separarListasDeParadas();
            filter();
            comprobarParadasEnMismaEstacion();
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

                //Console.WriteLine(S);
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
                    Color color = Color.FromArgb(50, Color.Blue);
                    hacerPoligonoZonas(zona0, color);
                    
                    break;
                case "1":
                    Color color1 = Color.FromArgb(50, Color.Yellow);
                    hacerPoligonoZonas(zona1, color1);
                    break;
                case "2":
                    Color color2 = Color.FromArgb(50, Color.Red);
                    hacerPoligonoZonas(zona2, color2);
                    break;
                case "3":
                    Color color3 = Color.FromArgb(50, Color.Black);
                    hacerPoligonoZonas(zona3, color3);
                    break;
                case "4":
                    Color color4 = Color.FromArgb(50, Color.Green);
                    hacerPoligonoZonas(zona4, color4);
                    break;
                case "5":
                    Color color5 = Color.FromArgb(50, Color.Gray);
                    hacerPoligonoZonas(zona5, color5);
                    break;
                case "6":
                    Color color6 = Color.FromArgb(50, Color.Aquamarine);
                    hacerPoligonoZonas(zona6, color6);
                    break;

                case "7":
                    Color color7 = Color.FromArgb(50, Color.Brown);
                    hacerPoligonoZonas(zona7, color7);
                    break;

                    case "8":
                    Color color8 = Color.FromArgb(50, Color.DarkMagenta);
                    hacerPoligonoZonas(zona8, color8);
                    break;
            }
        }

        public void separarZonas(){
            for (int i = 0; i < Zonas.Count; i++)
            {
                if (i < 14)
                {
                    zona0.Add(Zonas[i]);
                }
                else if (i >= 14 && i < 42)
                {
                    zona1.Add(Zonas[i]);
                }
                else if (i >= 42 && i < 69)
                {
                    zona2.Add(Zonas[i]);
                }
                else if (i >= 69 && i < 78)
                {
                    zona3.Add(Zonas[i]);
                }
                else if (i >= 78 && i < 93)
                {
                    zona4.Add(Zonas[i]);
                }
                else if (i >= 93 && i < 113)
                {
                    zona5.Add(Zonas[i]);
                }
                else if (i >=114 && i <135)
                {
                    zona6.Add(Zonas[i]);
                }
                else if (i >= 135 && i < 150){
                    zona7.Add(Zonas[i]);

                }else if (i >= 150 && i < 158){
                     zona8.Add(Zonas[i]);
                    }
            }

        }

        public void comprobarParadasEnMismaEstacion()
        {
            List<Stops> listaAux = new List<Stops>();
            String name = ParadasEstaciones[0].SHORTNAME;
            for (int i = 0; i < ParadasEstaciones.Count; i++)
            {

                if (ParadasEstaciones[i].SHORTNAME.Substring(0, ParadasEstaciones[i].SHORTNAME.Length-2).Equals(name.Substring(0, name.Length-2)))
                {
                    listaAux.Add(ParadasEstaciones[i]);
                    //Console.WriteLine(ParadasEstaciones[i].SHORTNAME);
                }
                else
                {
                    hacerPoligonoEstaciones(listaAux);
                    name = ParadasEstaciones[i].SHORTNAME;
                    listaAux.Clear();
                    listaAux.Add(ParadasEstaciones[i]);
                }
                //hacerPoligonoEstaciones(listaAux);
            }

            //hacerPoligonoEstaciones(listaAux);

        }

        public void hacerPoligonoEstaciones(List<Stops> a)
        {
            GMapOverlay poligono = new GMapOverlay("Poligono");
            List<PointLatLng> puntos = new List<PointLatLng>();
            for (int i = 0; i < a.Count; i++)
            {
                puntos.Add(new PointLatLng(a[i].DECIMALLATITUD, a[i].DECIMALLONGITUD));
            }

            GMapPolygon poligonoPuntos = new GMapPolygon(puntos, "Poligono");
            poligonoPuntos.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
            poligono.Polygons.Add(poligonoPuntos);
           
            gControl.Overlays.Add(poligono);
            gControl.Zoom = gControl.Zoom + 1;
            gControl.Zoom = gControl.Zoom - 1;
        }

        public void hacerPoligonoZonas(List<ZONA> a , Color color){
            GMapOverlay poligono = new GMapOverlay("Poligono");
            List<PointLatLng> puntos = new List<PointLatLng>();
            for (int i = 0; i < a.Count; i++)
            {
                
                puntos.Add(new PointLatLng(a[i].latitud, a[i].longitud));
                
            }
            GMapPolygon poligonoPuntos = new GMapPolygon(puntos, "Poligono");
            poligono.Polygons.Add(poligonoPuntos);
            poligonoPuntos.Fill = new SolidBrush(Color.FromArgb(50, color));
            gControl.Overlays.Add(poligono);
            gControl.Zoom = gControl.Zoom + 1;
            gControl.Zoom = gControl.Zoom - 1;

            
        }

        public void removeMakers(){
            if (gControl.Overlays.Count > 0)
            {
                gControl.Overlays.Clear();
                gControl.Refresh();
            }
        }

        public void lecturaDatagramas(){
            StreamReader lector = new StreamReader(@"DATAGRAMS.txt");
            String line = lector.ReadLine();
            line = lector.ReadLine();
            int i = 0;
            
            while (line != null)
            {
                String[] arregloDatagramas = line.Split(',');
 
                String EVENTTYPE = arregloDatagramas[0];
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

                MIO bus = new MIO(EVENTTYPE, STOPID, ODOMETER, LATITUDE, LONGITUDE, TASKID, LINEID, TRIPID, DATAGRAMID, DATAGRAMDATE, BUSID);

               
                if (busExist(bus))
                {
                    
                  //  MessageBox.Show("index " + index + " , bus:" + bus.BUSID);
                    Buses[bus.index].addNewWay(LATITUDE, LONGITUDE);
                    
                }
                else
                {
                    int index = Buses.Count;
                    bus.index = index;
                    Buses.Add(bus);
                   
                    
                  //  MessageBox.Show("bus " + bus.BUSID);
                }
                   
                i++;
                line = lector.ReadLine();
            }
            lector.Close();

        }


        public void BPuntosZonas_Click_1(object sender, EventArgs e){
            mostrarMarcadoresZonas();
        }

        public void BEliminar_Click(object sender, EventArgs e){
            removeMakers();
        }

        public Boolean busExist(MIO idBus)
        {
            for(int i=0; i < Buses.Count(); i++)
            {
                if (Buses[i].BUSID.Equals(idBus.BUSID))
                {
                    indexBus = i;
                    return true;
                }
            }

            return false;
        }

        public double ordenarDecimal(String num)
        {

            double aux = double.Parse(num, CultureInfo.InvariantCulture);

            double result = aux / 10000000;

            return result;

        }

     /*   public void movement(MIO busesito,int i)
        {
            double latitude = ordenarDecimal(busesito.LATITUDE);
            double longitude = ordenarDecimal(busesito.LONGITUDE);

                busesito.changeLocation();

              latitude = ordenarDecimal(busesito.LATITUDE);
              longitude = ordenarDecimal(busesito.LONGITUDE);

             //   Thread.Sleep(1000);

            Bitmap markerMio = (Bitmap)Image.FromFile(@"iconoMio.png");
            marker = new GMarkerGoogle(new PointLatLng(latitude, longitude), markerMio);
            markerOverlayMIO.Markers.Add(marker);
           
            gControl.Overlays[i].Markers[i].Position = new PointLatLng(latitude, longitude);
        }*/
        public void runProcess()
        {
           // MessageBox.Show("Total buses: " + Buses.Count );

            for (int i=0; i < Buses.Count; i++)
               {
                //MIO aux = Buses[i];
                //  String[] loc = aux.ways[j].Split(',');

                    double latitude = ordenarDecimal(Buses[i].LATITUDE);
                    double longitude = ordenarDecimal(Buses[i].LONGITUDE);
                    Bitmap markerMio = (Bitmap)Image.FromFile(@"iconoMio.png");

                    marker = new GMarkerGoogle(new PointLatLng(latitude, longitude), markerMio);
                    markerOverlayMIO.Markers.Add(marker);
                    marker.ToolTipMode = MarkerTooltipMode.Always;
                    marker.ToolTipText = String.Format(Buses[i].BUSID);

                    // MessageBox.Show("indice bus:  " + i);               
                
            }
            MessageBox.Show("marcadores agregados y serán mostrados. ");
            gControl.Overlays.Add(markerOverlayMIO);
            gControl.Zoom = gControl.Zoom + 1;
            gControl.Zoom = gControl.Zoom - 1;


        }
     
        public void MostrarMIOS_Click(object sender, EventArgs e)
        {

            runProcess();
            Hilo hilo = new Hilo(Buses,this);
            
            hilo.run();                             
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {

          /*  for(int i=0; i<Buses.Count; i++)
            {
                {
                    if (Buses[i].LATITUDE.Equals("-1") == false)
                        movement(Buses[i], i);
                }
            }*/
            
        }
    }

}
