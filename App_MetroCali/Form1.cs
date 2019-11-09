﻿using GMap.NET.MapProviders;
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
        public GMapOverlay markerOverlayMIO { get; set; }
        GMapOverlay markerOverlayZonas;
       
        double latitudCali = 3.42158;
        double longitudCali = -76.5205;
        int indexBus = 0;

        List<Stops> Paradas = new List<Stops>();
        List<Stops> ParadasEstaciones = new List<Stops>();
        List<Stops> ParadasCalle = new List<Stops>();
        List<ZONA> Zonas = new List<ZONA>();

        List<GMapOverlay> ListaPoligonos = new List <GMapOverlay>();


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

        List<String> lines = new List <String>();

        Queue<List<MIO>> cola = new Queue<List<MIO>>();


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


            cbZonas.Items.Add("0 - CENTRO");
            cbZonas.Items.Add("1 - UNIVERSIDADES");
            cbZonas.Items.Add("2 - MENGA");
            cbZonas.Items.Add("3 - PASO DEL COMERCIO");
            cbZonas.Items.Add("4 - ANDRÉS SANÍN");
            cbZonas.Items.Add("5 - NUEVO LATIR");
            cbZonas.Items.Add("6 - CAÑAVERALEJO");
            cbZonas.Items.Add("7 - SIMÓN BOLIVAR");
            cbZonas.Items.Add("8 - CALIPSO");
            cbZonas.Items.Add("MOSTRAR TODAS");

            pbIMAGEN.Image = Image.FromFile(@"logoMio.JPG");
            //pboxFondoDeco.Image = Image.FromFile(@"fondo.PNG");


            leerZonasCiudad();
            separarZonas();

            //lecturaDatagramas();
            lecturaDatagramas2();
            //separarBUSES();


            markerOverlayMIO = new GMapOverlay("markadorMIO");
            progressBar1.Visible = false;
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
               //var point = new PointLatLng(a[S].DECIMALLATITUD, a[S].DECIMALLONGITUD);
                //Bitmap markerParada = (Bitmap)Image.FromFile(@"MIO.png");
                //marker = new GMarkerGoogle(point, markerParada);



                markerOverlayParada.Markers.Add(marker);
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                marker.ToolTipText = String.Format("PARADA: " + a[S].LONGNAME + "\n" + "ID " + a[S].STOPID + "\n" + "LATITUD: " + a[S].DECIMALLATITUD + "\n" + "LONGITUD: " + a[S].DECIMALLONGITUD);
                marker.ToolTip.TextPadding = new Size(10, 20);
                marker.ToolTip.Fill = Brushes.AntiqueWhite;
                //Console.WriteLine(S);
                S++;
            }
            gControl.Overlays.Add(markerOverlayParada);
            Console.WriteLine(a.Count());
        }

        private void Cb_elegir_SelectedIndexChanged(object sender, EventArgs e) { }

        private void GControl_Load_1(object sender, EventArgs e) {

         }

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
            Color color = Color.FromArgb(50, Color.Blue);
            Color color1 = Color.FromArgb(50, Color.Yellow);
            Color color2 = Color.FromArgb(50, Color.Red);
            Color color3 = Color.FromArgb(50, Color.Black);
            Color color4 = Color.FromArgb(50, Color.Green);
            Color color5 = Color.FromArgb(50, Color.Gray);
            Color color6 = Color.FromArgb(50, Color.Aquamarine);
            Color color7 = Color.FromArgb(50, Color.Brown);
            Color color8 = Color.FromArgb(50, Color.DarkMagenta);
            switch (cbZonas.Text)
            {
                case "":
                    MessageBox.Show("Debe seleccionar un numero de zona");
                    break;
                case "0 - CENTRO":
                    hacerPoligonoZonas(zona0, color);

                    
                    break;
                case "1 - UNIVERSIDADES":
                   
                    hacerPoligonoZonas(zona1, color1);
                    break;
                case "2 - MENGA":
                   
                    hacerPoligonoZonas(zona2, color2);
                    break;
                case "3 - PASO DEL COMERCIO":
                   
                    hacerPoligonoZonas(zona3, color3);
                    break;
                case "4 - ANDRÉS SANÍN":
                   
                    hacerPoligonoZonas(zona4, color4);
                    break;
                case "5 - NUEVO LATIR":
                   
                    hacerPoligonoZonas(zona5, color5);
                    break;
                case "6 - CAÑAVERALEJO":
                   
                    hacerPoligonoZonas(zona6, color6);
                    break;

                case "7 - SIMÓN BOLIVAR":
                   
                    hacerPoligonoZonas(zona7, color7);
                    break;

                    case "8 - CALIPSO":
                    
                    hacerPoligonoZonas(zona8, color8);
                    break;  
                    
                case "MOSTRAR TODAS":
                    hacerPoligonoZonas(zona0, color);
                    hacerPoligonoZonas(zona1, color1);
                    hacerPoligonoZonas(zona2, color2);
                    hacerPoligonoZonas(zona3, color3);
                    hacerPoligonoZonas(zona4, color4);
                    hacerPoligonoZonas(zona5, color5);
                    hacerPoligonoZonas(zona6, color6);
                    hacerPoligonoZonas(zona7, color7);
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

        public int orientacion(Stops p, Stops q, Stops r)
        {
            double val = (q.DECIMALLATITUD - p.DECIMALLATITUD) * (r.DECIMALLONGITUD - q.DECIMALLONGITUD) -(q.DECIMALLONGITUD - p.DECIMALLONGITUD) * (r.DECIMALLATITUD - q.DECIMALLATITUD);

            if(val == 0)
            {
                return 0;
            }

            return (val > 0) ? 1 : 2;
        }

        public List<Stops> convexHull(List<Stops> lista, int n)
        {
            //if (n < 3) return;

            List<Stops> hull = new List<Stops>();
            int l = 0;

            for (int i = 1; i < n; i++)
            {
                if(lista[i].DECIMALLONGITUD < lista[l].DECIMALLONGITUD)
                {
                    l = i;
                }
            }

            int p = l, q;

            do
            {
                hull.Add(lista[p]);

                q = (p + 1) % n;

                for (int i = 0; i < n; i++)
                {
       
                    if (orientacion(lista[p], lista[i], lista[q])== 2)
                        q = i;
                }
                p = q;
            } while (p != l);

            //lista = hull;
            return hull;
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
                    //convexHull(listaAux, listaAux.Count);
                    hacerPoligonoEstaciones(convexHull(listaAux, listaAux.Count));
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
            //gControl.Zoom = gControl.Zoom + 1;
            //gControl.Zoom = gControl.Zoom - 1;
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

        //Aquí se guarda la información de los buses, en la lista de buses.
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
                Buses.Add(bus);

        
                i++;
                line = lector.ReadLine();
            }
            lector.Close();

        }

<<<<<<< HEAD
        public void lecturaDatagramas2()
        {
            StreamReader lector = new StreamReader(@"DATAGRAMS4.txt");
            String line = lector.ReadLine();
            line = lector.ReadLine();

            MIO bus = new MIO("", "", "", "", "", "", "", "", "", "", "");

            String[] arregloDatagramas = line.Split(',');

            bus.EVENTTYPE = arregloDatagramas[0];
            bus.STOPID = arregloDatagramas[2];
            bus.ODOMETER = arregloDatagramas[3];

            bus.LATITUDE = arregloDatagramas[4];
            bus.LONGITUDE = arregloDatagramas[5];
            bus.LIST_LATITUDE.Add(arregloDatagramas[4]);
            bus.LIST_LONGITUDE.Add(arregloDatagramas[5]);

            bus.TASKID = arregloDatagramas[6];
            bus.LINEID = arregloDatagramas[7];
            bus.TRIPID = arregloDatagramas[8];

            bus.DATAGRAMID = arregloDatagramas[9];
            bus.DATAGRAMDATE = arregloDatagramas[10];
            bus.BUSID = arregloDatagramas[11];

            line = lector.ReadLine();
            while (line != null)
            {
                arregloDatagramas = line.Split(',');
                bus.LIST_LATITUDE.Add(arregloDatagramas[4]);
                bus.LIST_LONGITUDE.Add(arregloDatagramas[5]);
                line = lector.ReadLine();
            }

            Buses.Add(bus);
            lector.Close();

        }

        public Boolean ListExist(List<MIO> item)
        {

            return cola.Contains(item);

        }

      
        public void ordenarCola()
        {
          
            String hora = "";
            String minutos = "";
            String auxh = "";
            String auxm = "";

            

            for (int i = 0; i < Buses.Count; i++)
            {

                String[] data = Buses[i].DATAGRAMDATE.Split(' ');
                String[] data2 = data[1].Split('.');
                auxh = data2[0];
                auxm = data2[1];
                if(auxh.Equals(hora) && auxm.Equals(minutos))
                {
                    cola.Last().Add(Buses[i]);
                   
                }
                else
                {
                    cola.Enqueue(new List<MIO>());
                    cola.Last().Add(Buses[i]);

                    hora = auxh;
                    minutos = auxm;
                }

            }

        }
=======
>>>>>>> e34c876f42a829860ef928ce6c256d9bc918d038

        
       
        public void BPuntosZonas_Click_1(object sender, EventArgs e){
            mostrarMarcadoresZonas();
        }

        public void BEliminar_Click(object sender, EventArgs e){
            timer2.Stop();
            cola.Clear();
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

        public void ordenarCola(String id) {

          
            String hora = "";
            String min = "";
            String[] auxi = id.Split(',');
            progressBar1.Increment(-Buses.Count);
            progressBar1.Maximum = Buses.Count;
            for (int a=0; a < Buses.Count; a++)
            {

                if (Buses[a].LINEID.Equals(auxi[0]))
                {
                    Buses[a].id = auxi[1];

                    String[] data = Buses[a].DATAGRAMDATE.Split(' ');
                    String[] data2 = data[1].Split('.');

                    
                    String auxh = data2[0];
                    String auxm = data[1];

                    if (auxh == hora && auxm == min)
                    {
                        cola.Last().Add(Buses[a]);
                    }
                    else {
                        cola.Enqueue(new List<MIO>());
                        cola.Last().Add(Buses[a]);
                        hora = auxh;
                        min = auxm;
                    }
                    

                }
                progressBar1.Increment(1);

            }

        }


       public void MostrarMIOS_Click(object sender, EventArgs e)
        {

            lecturaLines();
            ordenarCola(filtrarMios());
            timer2.Start();

        }

        private void PboxFondoDeco_Click(object sender, EventArgs e)
        {

        }

        private void cbZonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            seleccionZona();
        }
        
        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //  
            label4.Text = DateTime.Parse("01/11/2018 05:35").ToString();
            timer1.Enabled = true;
            timer1.Interval = 10;
           
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        public void lecturaLines() {
            StreamReader lector = new StreamReader(@"lines.txt");
            String line = lector.ReadLine();
            int i = 0;

            while (line != null){
                lines.Add(line);
                i++;
                line = lector.ReadLine();
            }

            lector.Close();
           
        }


        public String filtrarMios() {

            String lineId = "";
            int i = 0;

            List<String> linesPos3 = new List <String>();
            List<String> linesPos1 = new List<String>();
         
            for (int j = 0; j < lines.Count; j++){
              
                String[] arreglo = lines[j].Split(',');
                linesPos3.Add(arreglo[2]);
                linesPos1.Add(arreglo[0]);

            }

        
            while (i<linesPos3.Count ){

                if (buscarRutasUsuarios.Text.Equals(linesPos3[i], StringComparison.InvariantCultureIgnoreCase)){
                   
                    lineId = linesPos1[i] + "," + linesPos3[i];
                    MessageBox.Show("El line id de la "+buscarRutasUsuarios.Text + " ES :"+ linesPos1[i]);
                    i = linesPos3.Count;
                  
                }
                
                    i++;  
            }
            return lineId;

        }

        public void runProcess(List<MIO> bus)
        {

            Bitmap markerMio = (Bitmap)Image.FromFile(@"iconoMio.png");


            for (int j = 0; j < bus.Count; j++)
            {
                double latitude = ordenarDecimal(bus[j].LATITUDE);
                double longitude = ordenarDecimal(bus[j].LONGITUDE);

                marker = new GMarkerGoogle(new PointLatLng(latitude, longitude), markerMio);

                markerOverlayMIO.Markers.Add(marker);

                marker.ToolTipMode = MarkerTooltipMode.Always;
                marker.ToolTipText = String.Format(bus[j].id);

            }

            gControl.Overlays.Add(markerOverlayMIO);
            gControl.Zoom = gControl.Zoom + 0.1;
            gControl.Zoom = gControl.Zoom - 0.1;

        }

        public void moverBus()
        {
            Bitmap markerMio = (Bitmap)Image.FromFile(@"iconoMio.png");

            for (int i = 0; i<Buses.Count; i++)
            {
                for(int j = 0; j<Buses[i].LIST_LATITUDE.Count; j++)
                {
                    double latitude = ordenarDecimal(Buses[i].LIST_LATITUDE[j]);
                    double longitude = ordenarDecimal(Buses[i].LIST_LONGITUDE[j]);

                    marker = new GMarkerGoogle(new PointLatLng(latitude, longitude), markerMio);

                    markerOverlayMIO.Markers.Add(marker);
                    gControl.Overlays.Add(markerOverlayMIO);
                    //marker.ToolTipMode = MarkerTooltipMode.Always;

                    //Buses[i].moveBus(Int32.Parse(Buses[i].LIST_LATITUDE[i]), Int32.Parse(Buses[i].LIST_LONGITUDE[i]));
                    Hilo hilo = new Hilo(Buses[i], this, Buses[i].LIST_LATITUDE[j], Buses[i].LIST_LONGITUDE[j]);
                    Thread hilo1 = new Thread(hilo.run);
                    //hilo1.Start
                    //markerOverlayMIO.Clear();
                }
                //gControl.Overlays.Add(markerOverlayMIO);
                //markerOverlayMIO.Clear();
            }
        }


        private void button1_Click_1(object sender, EventArgs e){

            lecturaLines();
            ordenarCola(filtrarMios());
            timer2.Start();
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            markerOverlayMIO.Clear();
            if (cola.Count>0){
                runProcess(cola.Dequeue());
                timer1.Start(); 
            }
            else{
                timer2.Stop();
            }

<<<<<<< HEAD
            //runProcess();
            moverBus();
          
=======
            timer2.Interval = 1000;
>>>>>>> e34c876f42a829860ef928ce6c256d9bc918d038
        }

        private void PbIMAGEN_Click(object sender, EventArgs e)
        {

        }

        private void ProgressBar1_Click(object sender, EventArgs e)
        {

        }


       /* public void filtrarEstacionesEnZonas(GMapPolygon poligono){
            int i = 0;
            List<PointLatLng> puntos = new List<PointLatLng>();
            List<Stops> paradasFiltradas = new List<Stops>();
            while (i < ParadasEstaciones.Count){
                puntos.Add(new PointLatLng(ParadasEstaciones[i].DECIMALLATITUD, ParadasEstaciones[i].DECIMALLATITUD));
                if (poligono.IsInside(puntos[i])){
                    paradasFiltradas.Add(ParadasEstaciones[i]);
                    mostrarMarcadores(paradasFiltradas);
                }
                i++;
            }
           

        }*/

      
        private void button2_Click_1(object sender, EventArgs e)
        {

        }

      
 
        private void LTitulo_Click(object sender, EventArgs e)
        {

        }
    }


}
