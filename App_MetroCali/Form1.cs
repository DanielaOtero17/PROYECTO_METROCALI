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

        private IDictionary<int, MIO> busDict = new Dictionary<int, MIO>();

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

        //puntos ZONAS
        List<PointLatLng> puntosEstaciones = new List<PointLatLng>();

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


            cb_elegir.Enabled = true;
            cb_elegir.Items.Add("ESTACIONES");
            cb_elegir.Items.Add("PARADAS EN LAS CALLES");
            cb_elegir.Items.Add("PATIOS");


            cbZonas.Enabled = true;
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

            filtradoEstacionesZonas.Items.Add("Estaciones ZONA 0");
            filtradoEstacionesZonas.Items.Add("Estaciones ZONA 1");
            filtradoEstacionesZonas.Items.Add("Estaciones ZONA 2");
            filtradoEstacionesZonas.Items.Add("Estaciones ZONA 3");
            filtradoEstacionesZonas.Items.Add("Estaciones ZONA 4");
            filtradoEstacionesZonas.Items.Add("Estaciones ZONA 5");
            filtradoEstacionesZonas.Items.Add("Estaciones ZONA 6");
            filtradoEstacionesZonas.Items.Add("Estaciones ZONA 7");
            filtradoEstacionesZonas.Items.Add("Estaciones ZONA 8");
  

            pbIMAGEN.Image = Image.FromFile(@"logoMio.JPG");
            //pboxFondoDeco.Image = Image.FromFile(@"fondo.PNG");

            lecturaParadas();
            separarListasDeParadas();

            leerZonasCiudad();
            separarZonas();

            lecturaDatagramas();
            //lecturaDatagramas2();
            //separarBUSES();


            markerOverlayMIO = new GMapOverlay("markadorMIO");
            progressBar1.Visible = false;
        }

        public void lecturaParadas() {

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
           
            filter();
            comprobarParadasEnMismaEstacion();
        }

        private void filter(){
            if (cb_elegir.Text.Equals("ESTACIONES") || cb_elegir.Text.Equals("PARADAS EN LAS CALLES") || cb_elegir.Text.Equals("PATIOS")){
                switch (cb_elegir.Text) {
                    case "":
                        MessageBox.Show("Por favor seleccione una opción.");
                        break;

                    case "ESTACIONES":
                        cb_elegir.Enabled = false;
                        mostrarMarcadores(ParadasEstaciones);
                        break;

                    case "PARADAS EN LAS CALLES":
                        cb_elegir.Enabled = false;
                        mostrarMarcadores(ParadasCalle);
                        break;

                    case "PATIOS":
                        cb_elegir.Enabled = false;
                        MessageBox.Show("Esta área se encuentra temporalmente fuera de servicio, por favor seleccione otra opción.");
                        break;
                }
            }
            else {
                MessageBox.Show("Error , esta opción no es valida");
            }
           
        }

        public void mostrarMarcadores(List<Stops> a) { 
            MessageBox.Show("Preparando para mostrar marcadores");
            int S = 0;
            markerOverlayParada = new GMapOverlay("markadorParada");
            for (int i = 0; i < a.Count(); i++){
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
                
                case "0 - CENTRO":
                    cbZonas.Enabled = false;
                    hacerPoligonoZonas(zona0, color);

                    
                    break;
                case "1 - UNIVERSIDADES":
                    cbZonas.Enabled = false;
                    hacerPoligonoZonas(zona1, color1);
                    break;
                case "2 - MENGA":
                    cbZonas.Enabled = false;
                    hacerPoligonoZonas(zona2, color2);
                    break;
                case "3 - PASO DEL COMERCIO":
                    cbZonas.Enabled = false;
                    hacerPoligonoZonas(zona3, color3);
                    break;
                case "4 - ANDRÉS SANÍN":
                    cbZonas.Enabled = false;
                    hacerPoligonoZonas(zona4, color4);
                    break;
                case "5 - NUEVO LATIR":
                    cbZonas.Enabled = false;
                    hacerPoligonoZonas(zona5, color5);
                    break;
                case "6 - CAÑAVERALEJO":
                    cbZonas.Enabled = false;
                    hacerPoligonoZonas(zona6, color6);
                    break;

                case "7 - SIMÓN BOLIVAR":
                    cbZonas.Enabled = false;
                    hacerPoligonoZonas(zona7, color7);
                    break;
                    cbZonas.Enabled = false;
                case "8 - CALIPSO":
                    cbZonas.Enabled = false;
                    hacerPoligonoZonas(zona8, color8);
                    break;  
                    
                case "MOSTRAR TODAS":
                    cbZonas.Enabled = false;
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

       
        public void hacerPoligonoEstaciones(List<Stops> a){
            List<PointLatLng> puntos = new List<PointLatLng>();
            GMapOverlay poligono = new GMapOverlay("Poligono");
           
            for (int i = 0; i < a.Count; i++){
                puntos.Add(new PointLatLng(a[i].DECIMALLATITUD, a[i].DECIMALLONGITUD));
            }

            GMapPolygon poligonoPuntos = new GMapPolygon(puntos, "Poligono");
            poligonoPuntos.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
            poligono.Polygons.Add(poligonoPuntos);
           
            gControl.Overlays.Add(poligono);
            //gControl.Zoom = gControl.Zoom + 1;
            //gControl.Zoom = gControl.Zoom - 1;
            puntosEstaciones = puntos;
            poligonoEstaciones = poligonoPuntos;

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
            poligonoPuntosAux = poligonoPuntos;
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
         
            while (line != null) {
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

        //metodo de prueba
        public void lecturaDatagramas2()
        {
            StreamReader lector = new StreamReader(@"DATAGRAMS4.txt");
            String line = lector.ReadLine();
            line = lector.ReadLine();

            while (line != null)
            {
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

                arregloDatagramas = line.Split(',');

                while (line != null && arregloDatagramas[11].Equals(bus.BUSID))
                {
                    arregloDatagramas = line.Split(',');
                    bus.LIST_LATITUDE.Add(arregloDatagramas[4]);
                    bus.LIST_LONGITUDE.Add(arregloDatagramas[5]);
                    line = lector.ReadLine();

                    if(line != null)
                    {
                    arregloDatagramas = line.Split(',');
                    }
                }
                Buses.Add(bus);
                Console.WriteLine(bus.BUSID);
                busDict.Add(Int32.Parse(bus.BUSID), bus);

            }

            lector.Close();

        }

        public Boolean ListExist(List<MIO> item)
        {

            return cola.Contains(item);

        }

      
        //public void ordenarCola()
        //{
          
        //    String hora = "";
        //    String minutos = "";
        //    String auxh = "";
        //    String auxm = "";

            

        //    for (int i = 0; i < Buses.Count; i++)
        //    {

        //        String[] data = Buses[i].DATAGRAMDATE.Split(' ');
        //        String[] data2 = data[1].Split('.');
        //        auxh = data2[0];
        //        auxm = data2[1];
        //        if(auxh.Equals(hora) && auxm.Equals(minutos))
        //        {
        //            cola.Last().Add(Buses[i]);
                   
        //        }
        //        else
        //        {
        //            cola.Enqueue(new List<MIO>());
        //            cola.Last().Add(Buses[i]);

        //            hora = auxh;
        //            minutos = auxm;
        //        }

        //    }

        //}
       
        public void BPuntosZonas_Click_1(object sender, EventArgs e){
            mostrarMarcadoresZonas();
        }

        public void BEliminar_Click(object sender, EventArgs e){
            timer1.Stop();
            cola.Clear();
            cbZonas.Enabled = true;
            cb_elegir.Enabled = true;
            cbZonas.SelectedIndex = -1;
            buscarRutasUsuarios.ResetText();
            cb_elegir.SelectedIndex = -1;
            filtradoEstacionesZonas.SelectedIndex = -1;
            removeMakers();
            label4.Text = "Hora del sistema";
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

        public MIO darBus()
        {
            if (busDict[Int32.Parse(buscarRutasUsuarios.Text)] != null)
            {
                return busDict[Int32.Parse(buscarRutasUsuarios.Text)];
            }
            else
            {
                return null;
            }
        }

        public void ordenarCola(String id) {

          
            String hora = "";
            String min = "";
            String[] auxi = id.Split(',');
            progressBar1.Visible = true;
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

            progressBar1.Visible = false;

        }


       public void MostrarMIOS_Click(object sender, EventArgs e)
        {
            //metodoHilo();
            /*lecturaLines();
            ordenarCola(filtrarMios());
            timer2.Start();*/
            if (buscarRutasUsuarios.Text.Equals("")){
                MessageBox.Show("Error, debe ingresar una ruta para buscar");

            }else {
                lecturaLines();
                ordenarCola(filtrarMios());
                timer2.Start();
            }
          

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

        int minutes = 35;
        int hour = 5;
        int seconds = 00;
        int day = 01;
        private void Timer1_Tick(object sender, EventArgs e) {

            label4.Text = DateTime.Parse("01/11/2018 " + hour + ":" + minutes + ":" + seconds).ToString();
            timer1.Enabled = true;
            timer1.Interval = 1;
            
            seconds++;

            if (seconds == 60 )
            {
                minutes++;
                seconds = 00;
            }
            if(minutes == 60)
            {
                hour++;
                minutes = 00;
            }
            if(hour == 25)
            {
                hour = 01;
                day++;

            }
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
        public void moverBus(object bus)
        {
            Bitmap markerMio = (Bitmap)Image.FromFile(@"iconoMio.png");

            MIO buss = (MIO) bus;
            //Console.WriteLine(buss.BUSID);

            double latitude = ordenarDecimal(buss.LATITUDE);
            double longitude = ordenarDecimal(buss.LONGITUDE);

            marker = new GMarkerGoogle(new PointLatLng(latitude, longitude), markerMio);

            markerOverlayMIO.Markers.Add(marker);
            marker.ToolTipText = buss.LINEID;
            gControl.Overlays.Add(markerOverlayMIO);

            for (int j = 1; j < buss.LIST_LATITUDE.Count - 1; j++)
            {
                while (!buss.LATITUDE.Equals(buss.LIST_LATITUDE[j]) && !buss.LONGITUDE.Equals(buss.LIST_LONGITUDE[j]))
                {
                    //Buses[i].moveBus(ordenarDecimal(Buses[i].LIST_LATITUDE[j]), ordenarDecimal(Buses[i].LIST_LONGITUDE[j]));
                    buss.moveBus2(buss.LIST_LATITUDE[j], buss.LIST_LONGITUDE[j]);
                    marker.Position = new GMap.NET.PointLatLng(ordenarDecimal(buss.LATITUDE), ordenarDecimal(buss.LONGITUDE));
                    //Thread.Sleep(1000);
                }
            }
            
        }

        public void moverUnBus(MIO bus)
        {
            ParameterizedThreadStart delegado = new ParameterizedThreadStart(moverBus);
            Thread hilo = new Thread(delegado);
            hilo.Start(bus);
        }

        public void metodoHilo()
        {
            ParameterizedThreadStart delegado = new ParameterizedThreadStart(moverBus);
            foreach (var item in busDict)
            {
                Thread hilo = new Thread(delegado);
                hilo.Start(item.Value);
                //hilo.Join();
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
            //metodoHilo();
            //moverBus(darBus());
            if (cola.Count>0){
                runProcess(cola.Dequeue());
                timer1.Start(); 
            }
            else{
                timer2.Stop();
            }

            //runProcess();
            //moverBus();

            timer2.Interval = 1000;

        }

        private void PbIMAGEN_Click(object sender, EventArgs e)
        {

        }

        private void ProgressBar1_Click(object sender, EventArgs e)
        {

        }


     
        public void filtrarEstacionesEnZonas(GMapPolygon poligonoPuntosZonas ) {
            GMapOverlay poligonoEstacion = new GMapOverlay("PoligonoEstacion");

            //ZONA 0
            GMapOverlay poligono0 = new GMapOverlay("Poligono");
            List<PointLatLng> puntosZona0 = new List<PointLatLng>();   
            for (int i = 0; i < zona0.Count; i++){
                puntosZona0.Add(new PointLatLng(zona0[i].latitud, zona0[i].longitud));
            }
            GMapPolygon poligonoZona0 = new GMapPolygon(puntosZona0, "Poligono");
            poligonoZona0.Fill = new SolidBrush(Color.FromArgb(50, Color.Black));
            poligono0.Polygons.Add(poligonoZona0);
           

            //ZONA 1
            GMapOverlay poligono1 = new GMapOverlay("Poligono");
            List<PointLatLng> puntosZona1 = new List<PointLatLng>();
            for (int i = 0; i < zona1.Count; i++){
                puntosZona1.Add(new PointLatLng(zona1[i].latitud, zona1[i].longitud));
            }
            GMapPolygon poligonoZona1 = new GMapPolygon(puntosZona1, "Poligono");
            poligonoZona1.Fill = new SolidBrush(Color.FromArgb(50, Color.Black));
            poligono1.Polygons.Add(poligonoZona1);
           

            //ZONA 2
            GMapOverlay poligono2 = new GMapOverlay("Poligono");
            List<PointLatLng> puntosZona2 = new List<PointLatLng>();
            for (int i = 0; i < zona2.Count; i++){
                puntosZona2.Add(new PointLatLng(zona2[i].latitud, zona2[i].longitud));
            }
            GMapPolygon poligonoZona2 = new GMapPolygon(puntosZona2, "Poligono");
            poligonoZona2.Fill = new SolidBrush(Color.FromArgb(50, Color.Black));
            poligono2.Polygons.Add(poligonoZona2);
            

            //ZONA 3
            GMapOverlay poligono3 = new GMapOverlay("Poligono");
            List<PointLatLng> puntosZona3 = new List<PointLatLng>();
            for (int i = 0; i < zona3.Count; i++){
                puntosZona3.Add(new PointLatLng(zona3[i].latitud, zona3[i].longitud));
            }
            GMapPolygon poligonoZona3 = new GMapPolygon(puntosZona3, "Poligono");
            poligonoZona3.Fill = new SolidBrush(Color.FromArgb(50, Color.Black));
            poligono3.Polygons.Add(poligonoZona3);
            
            //ZONA 4 
            GMapOverlay poligono4 = new GMapOverlay("Poligono");
            List<PointLatLng> puntosZona4 = new List<PointLatLng>();
            for (int i = 0; i < zona4.Count; i++){
                puntosZona4.Add(new PointLatLng(zona4[i].latitud, zona4[i].longitud));
            }
            GMapPolygon poligonoZona4 = new GMapPolygon(puntosZona4, "Poligono");
            poligonoZona4.Fill = new SolidBrush(Color.FromArgb(50, Color.Black));
            poligono4.Polygons.Add(poligonoZona4);

            //ZONA 5
            GMapOverlay poligono5 = new GMapOverlay("Poligono");
            List<PointLatLng> puntosZona5 = new List<PointLatLng>();
            for (int i = 0; i < zona5.Count; i++) {
                puntosZona5.Add(new PointLatLng(zona5[i].latitud, zona5[i].longitud));
            }
            GMapPolygon poligonoZona5 = new GMapPolygon(puntosZona5, "Poligono");
            poligonoZona5.Fill = new SolidBrush(Color.FromArgb(50, Color.Black));
            poligono5.Polygons.Add(poligonoZona5);

            //ZONA 6
            GMapOverlay poligono6 = new GMapOverlay("Poligono");
            List<PointLatLng> puntosZona6 = new List<PointLatLng>();
            for (int i = 0; i < zona6.Count; i++)
            {
                puntosZona6.Add(new PointLatLng(zona6[i].latitud, zona6[i].longitud));
            }
            GMapPolygon poligonoZona6 = new GMapPolygon(puntosZona6, "Poligono");
            poligonoZona6.Fill = new SolidBrush(Color.FromArgb(50, Color.Black));
            poligono6.Polygons.Add(poligonoZona6);

            //ZONA 7
            GMapOverlay poligono7 = new GMapOverlay("Poligono");
            List<PointLatLng> puntosZona7 = new List<PointLatLng>();
            for (int i = 0; i < zona7.Count; i++)
            {
                puntosZona7.Add(new PointLatLng(zona7[i].latitud, zona7[i].longitud));
            }
            GMapPolygon poligonoZona7 = new GMapPolygon(puntosZona7, "Poligono");
            poligonoZona7.Fill = new SolidBrush(Color.FromArgb(50, Color.Black));
            poligono7.Polygons.Add(poligonoZona7);

            //ZONA 8
            GMapOverlay poligono8 = new GMapOverlay("Poligono");
            List<PointLatLng> puntosZona8 = new List<PointLatLng>();
            for (int i = 0; i < zona8.Count; i++)
            {
                puntosZona8.Add(new PointLatLng(zona8[i].latitud, zona8[i].longitud));
            }
            GMapPolygon poligonoZona8= new GMapPolygon(puntosZona8, "Poligono");
            poligonoZona8.Fill = new SolidBrush(Color.FromArgb(50, Color.Black));
            poligono8.Polygons.Add(poligonoZona8);

            if (filtradoEstacionesZonas.Text.Equals("Estaciones ZONA 0"))
            {
                gControl.Overlays.Add(poligono0);
                List<PointLatLng> puntosEstaciones = new List<PointLatLng>();
                int i = 0;
                while (i < ParadasEstaciones.Count)
                {
                    puntosEstaciones.Add(new PointLatLng(ParadasEstaciones[i].DECIMALLATITUD, ParadasEstaciones[i].DECIMALLONGITUD));

                    markerOverlayZonas = new GMapOverlay("MarkadorEstacion");

                    if (poligonoZona0.IsInside(puntosEstaciones[i]))
                    {
                        PointLatLng PZ = puntosEstaciones[i];

                        marker = new GMarkerGoogle(PZ, GMarkerGoogleType.green);
                        markerOverlayZonas.Markers.Add(marker);
                        marker.ToolTipMode = MarkerTooltipMode.Always;


                        gControl.Overlays.Add(markerOverlayZonas);
                    }
                    i++;
                }


            }
            else if (filtradoEstacionesZonas.Text.Equals("Estaciones ZONA 1"))
            {
                gControl.Overlays.Add(poligono1);
                List<PointLatLng> puntosEstaciones = new List<PointLatLng>();
                int i = 0;
                while (i < ParadasEstaciones.Count)
                {
                    puntosEstaciones.Add(new PointLatLng(ParadasEstaciones[i].DECIMALLATITUD, ParadasEstaciones[i].DECIMALLONGITUD));

                    markerOverlayZonas = new GMapOverlay("MarkadorEstacion");

                    if (poligonoZona1.IsInside(puntosEstaciones[i]))
                    {
                        PointLatLng PZ = puntosEstaciones[i];

                        marker = new GMarkerGoogle(PZ, GMarkerGoogleType.green);
                        markerOverlayZonas.Markers.Add(marker);
                        marker.ToolTipMode = MarkerTooltipMode.Always;

                        gControl.Overlays.Add(markerOverlayZonas);
                    }
                    i++;
                }
            }
            else if (filtradoEstacionesZonas.Text.Equals("Estaciones ZONA 2"))
            {
                gControl.Overlays.Add(poligono2);
                List<PointLatLng> puntosEstaciones = new List<PointLatLng>();
                int i = 0;
                while (i < ParadasEstaciones.Count)
                {
                    puntosEstaciones.Add(new PointLatLng(ParadasEstaciones[i].DECIMALLATITUD, ParadasEstaciones[i].DECIMALLONGITUD));

                    markerOverlayZonas = new GMapOverlay("MarkadorEstacion");

                    if (poligonoZona2.IsInside(puntosEstaciones[i]))
                    {
                        PointLatLng PZ = puntosEstaciones[i];

                        marker = new GMarkerGoogle(PZ, GMarkerGoogleType.green);
                        markerOverlayZonas.Markers.Add(marker);
                        marker.ToolTipMode = MarkerTooltipMode.Always;

                        gControl.Overlays.Add(markerOverlayZonas);
                    }
                    i++;
                }
            }
            else if (filtradoEstacionesZonas.Text.Equals("Estaciones ZONA 3"))
            {
                gControl.Overlays.Add(poligono3);
                List<PointLatLng> puntosEstaciones = new List<PointLatLng>();
                int i = 0;
                while (i < ParadasEstaciones.Count)
                {
                    puntosEstaciones.Add(new PointLatLng(ParadasEstaciones[i].DECIMALLATITUD, ParadasEstaciones[i].DECIMALLONGITUD));

                    markerOverlayZonas = new GMapOverlay("MarkadorEstacion");

                    if (poligonoZona3.IsInside(puntosEstaciones[i]))
                    {
                        PointLatLng PZ = puntosEstaciones[i];

                        marker = new GMarkerGoogle(PZ, GMarkerGoogleType.green);
                        markerOverlayZonas.Markers.Add(marker);
                        marker.ToolTipMode = MarkerTooltipMode.Always;

                        gControl.Overlays.Add(markerOverlayZonas);
                    }
                    i++;
                }
            }
            else if (filtradoEstacionesZonas.Text.Equals("Estaciones ZONA 4"))
            {
                gControl.Overlays.Add(poligono4);
                List<PointLatLng> puntosEstaciones = new List<PointLatLng>();
                int i = 0;
                while (i < ParadasEstaciones.Count)
                {
                    puntosEstaciones.Add(new PointLatLng(ParadasEstaciones[i].DECIMALLATITUD, ParadasEstaciones[i].DECIMALLONGITUD));

                    markerOverlayZonas = new GMapOverlay("MarkadorEstacion");

                    if (poligonoZona4.IsInside(puntosEstaciones[i]))
                    {
                        PointLatLng PZ = puntosEstaciones[i];

                        marker = new GMarkerGoogle(PZ, GMarkerGoogleType.green);
                        markerOverlayZonas.Markers.Add(marker);
                        marker.ToolTipMode = MarkerTooltipMode.Always;

                        gControl.Overlays.Add(markerOverlayZonas);
                    }
                    i++;
                }
            }
            else if (filtradoEstacionesZonas.Text.Equals("Estaciones ZONA 5"))
            {
                gControl.Overlays.Add(poligono5);
                List<PointLatLng> puntosEstaciones = new List<PointLatLng>();
                int i = 0;
                while (i < ParadasEstaciones.Count)
                {
                    puntosEstaciones.Add(new PointLatLng(ParadasEstaciones[i].DECIMALLATITUD, ParadasEstaciones[i].DECIMALLONGITUD));

                    markerOverlayZonas = new GMapOverlay("MarkadorEstacion");

                    if (poligonoZona5.IsInside(puntosEstaciones[i]))
                    {
                        PointLatLng PZ = puntosEstaciones[i];

                        marker = new GMarkerGoogle(PZ, GMarkerGoogleType.green);
                        markerOverlayZonas.Markers.Add(marker);
                        marker.ToolTipMode = MarkerTooltipMode.Always;

                        gControl.Overlays.Add(markerOverlayZonas);
                    }
                    i++;
                }
            }
            else if (filtradoEstacionesZonas.Text.Equals("Estaciones ZONA 6"))
            {
                gControl.Overlays.Add(poligono6);
                List<PointLatLng> puntosEstaciones = new List<PointLatLng>();
                int i = 0;
                while (i < ParadasEstaciones.Count)
                {
                    puntosEstaciones.Add(new PointLatLng(ParadasEstaciones[i].DECIMALLATITUD, ParadasEstaciones[i].DECIMALLONGITUD));

                    markerOverlayZonas = new GMapOverlay("MarkadorEstacion");

                    if (poligonoZona6.IsInside(puntosEstaciones[i]))
                    {
                        PointLatLng PZ = puntosEstaciones[i];

                        marker = new GMarkerGoogle(PZ, GMarkerGoogleType.green);
                        markerOverlayZonas.Markers.Add(marker);
                        marker.ToolTipMode = MarkerTooltipMode.Always;

                        gControl.Overlays.Add(markerOverlayZonas);
                    }
                    i++;
                }
            }
            else if (filtradoEstacionesZonas.Text.Equals("Estaciones ZONA 7"))
            {
                gControl.Overlays.Add(poligono7);
                List<PointLatLng> puntosEstaciones = new List<PointLatLng>();
                int i = 0;
                while (i < ParadasEstaciones.Count)
                {
                    puntosEstaciones.Add(new PointLatLng(ParadasEstaciones[i].DECIMALLATITUD, ParadasEstaciones[i].DECIMALLONGITUD));

                    markerOverlayZonas = new GMapOverlay("MarkadorEstacion");

                    if (poligonoZona7.IsInside(puntosEstaciones[i]))
                    {
                        PointLatLng PZ = puntosEstaciones[i];

                        marker = new GMarkerGoogle(PZ, GMarkerGoogleType.green);
                        markerOverlayZonas.Markers.Add(marker);
                        marker.ToolTipMode = MarkerTooltipMode.Always;

                        gControl.Overlays.Add(markerOverlayZonas);
                    }
                    i++;
                }
            } else if (filtradoEstacionesZonas.Text.Equals("Estaciones ZONA 8")){
                gControl.Overlays.Add(poligono8);
                List<PointLatLng> puntosEstaciones = new List<PointLatLng>();
                int i = 0;
                while (i < ParadasEstaciones.Count)
                {
                    puntosEstaciones.Add(new PointLatLng(ParadasEstaciones[i].DECIMALLATITUD, ParadasEstaciones[i].DECIMALLONGITUD));

                    markerOverlayZonas = new GMapOverlay("MarkadorEstacion");

                    if (poligonoZona8.IsInside(puntosEstaciones[i]))
                    {
                        PointLatLng PZ = puntosEstaciones[i];

                        marker = new GMarkerGoogle(PZ, GMarkerGoogleType.green);
                        markerOverlayZonas.Markers.Add(marker);
                        marker.ToolTipMode = MarkerTooltipMode.Always;

                        gControl.Overlays.Add(markerOverlayZonas);
                    }
                    i++;
                }
            }
        }


      

      
        private void button2_Click_1(object sender, EventArgs e)
        {
        }

      
 
        private void LTitulo_Click(object sender, EventArgs e)
        {

        }

        private void pbIMAGEN_Click_1(object sender, EventArgs e)
        {

        }
        public static  List<PointLatLng> puntos = new List<PointLatLng>();
        GMapPolygon poligonoPuntosAux = new GMapPolygon(puntos, "Poligono");

        public static List<PointLatLng> puntos2 = new List<PointLatLng>();
        GMapPolygon poligonoEstaciones = new GMapPolygon(puntos2, "Poligono");

        private void filtradoEstacionesZonas_SelectedIndexChanged(object sender, EventArgs e){
            filtrarEstacionesEnZonas(poligonoPuntosAux);
          
        }




    }


}
