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
    public partial class Form1 : Form {

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

             List<ZONA> zona0 = new List<ZONA>();
             List<ZONA> zona1 = new List<ZONA>();
             List<ZONA> zona2 = new List<ZONA>();
             List<ZONA> zona3 = new List<ZONA>();
             List<ZONA> zona4 = new List<ZONA>();
             List<ZONA> zona5 = new List<ZONA>();
             List<ZONA> zona6 = new List<ZONA>();
             List<ZONA> zona7 = new List<ZONA>();

       

        public Form1(){
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

              /*markerOverlayMIO = new GMapOverlay("markadorMIO");
              Bitmap markerMio = (Bitmap)Image.FromFile(@"iconoMio.png");
              marker = new GMarkerGoogle(new PointLatLng(3.4372201, -76.5224991), markerMio);
              markerOverlayMIO.Markers.Add(marker);

            marker.ToolTipMode = MarkerTooltipMode.Always;
            marker.ToolTipText = String.Format("Este es el mio");
            gControl.Overlays.Add(markerOverlayMIO);*/

            
            
        }
        
            public void lecturaParadas(){

            StreamReader lector = new StreamReader(@"STOPS.txt");
            String line = lector.ReadLine();
            int i = 0;
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
            for(int i = 0; i< Paradas.Count; i++){
                if (retornarLista()[i].STOPID.Substring(0, 1).Equals("6")){
                    ParadasEstaciones.Add(Paradas[i]);
                    //Console.WriteLine("ESTACION : "+ParadasEstaciones[i].LONGNAME);
                }else if(retornarLista()[i].STOPID.Substring(0,1).Equals("5")){
                    ParadasCalle.Add(Paradas[i]);
                    // Console.WriteLine("CALLE : "+ParadasCalle[i].LONGNAME);
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

            MessageBox.Show("Preparando para mostrar marcadores");
            int  S = 0;
             markerOverlayParada = new GMapOverlay("markadorParada");
            for (int i =0; i<a.Count(); i++) { 
               marker = new GMarkerGoogle(new PointLatLng(a[S].DECIMALLATITUD, a[S].DECIMALLONGITUD),GMarkerGoogleType.red);
               
               markerOverlayParada.Markers.Add(marker);
               marker.ToolTipMode = MarkerTooltipMode.Always;
                 marker.ToolTipText = String.Format("Parada:" + a[S].SHORTNAME);
                 
                 Console.WriteLine(S);
                 S++;
               }
            gControl.Overlays.Add(markerOverlayParada);
            Console.WriteLine(a.Count());
        }
        
    
        private void Cb_elegir_SelectedIndexChanged(object sender, EventArgs e){}

        private void GControl_Load_1(object sender, EventArgs e){}



        private void Button1_Click(object sender, EventArgs e){
            leerZonasCiudad();
           // mostrarMarcadoresZonas();
            separarZonas();
            seleccionZona();
          
        }

        public void leerZonasCiudad(){

            StreamReader lector = new StreamReader(@"ZONAS.txt");
            String line = lector.ReadLine();
            int i = 0;
            Console.WriteLine(line);
            while (line != null){

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

          public void mostrarMarcadoresZonas(){

            markerOverlayZonas = new GMapOverlay("MarkadorZona");
            for (int i = 0; i < Zonas.Count(); i++){
               
                marker = new GMarkerGoogle(new PointLatLng(Zonas[i].latitud, Zonas[i].longitud), GMarkerGoogleType.green);
                
                markerOverlayZonas.Markers.Add(marker);
                marker.ToolTipMode = MarkerTooltipMode.Always;
                Console.WriteLine(i);
            
            }
            gControl.Overlays.Add(markerOverlayZonas);
        }

        public void seleccionZona(){
             switch (cbZonas.Text){
                case "":
                    MessageBox.Show("Debe seleccionar un numero de zona");
                break;
                case "0" :
                    hacerPoligonoZonas(zona0);
                break ;
                case "1": 
                    hacerPoligonoZonas(zona1);
                 break ;
                 case "2": 
                    hacerPoligonoZonas(zona2);
                 break ;
                 case "3": 
                    hacerPoligonoZonas(zona3);
                 break ;
                 case "4": 
                    hacerPoligonoZonas(zona4);
                 break ;
                 case "5": 
                    hacerPoligonoZonas(zona5);
                 break ;
                 case "6": 
                    hacerPoligonoZonas(zona6);
                 break ;
                case "7": 
                    hacerPoligonoZonas(zona7);
                 break ;
              }
        }

        public void separarZonas (){
              for( int i = 0; i<Zonas.Count; i++){
                
                if(Zonas[i].nombreZONA.Equals("CENTRO(ZONA 0)")){
 
                    zona0.Add(Zonas[i]);

               }else if (Zonas[i].nombreZONA.Equals("UNIVERSIDADES(ZONA 1)")){
                 
                    zona1.Add(Zonas[i]);

               }else if (Zonas[i].nombreZONA.Equals("MENGA(ZONA 2)"))  {
                   
                     zona2.Add(Zonas[i]);

               }else if(Zonas[i].nombreZONA.Equals("PASO DEL COMERCIO(ZONA 3)")) {
                    
                     zona3.Add(Zonas[i]);

               }else if(Zonas[i].nombreZONA.Equals("ANDRÉS SANÍN(ZONA 4)")) {
                    
                     zona4.Add(Zonas[i]);    

                }else if(Zonas[i].nombreZONA.Equals("NUEVO LATIR(ZONA 5)")) {
                   
                     zona5.Add(Zonas[i]);
                    
                }else if(Zonas[i].nombreZONA.Equals("CAÑAVERALEJO(ZONA 6)")) {
                   
                     zona6.Add(Zonas[i]);    

                }else if(Zonas[i].nombreZONA.Equals("CALIPSO-SIMÓN BOLIVAR(ZONA 7)")) {
                    
                     zona7.Add(Zonas[i]);    
                }
            }

        }


        public void hacerPoligonoZonas(List<ZONA>a ){
            
            GMapOverlay poligono = new GMapOverlay("Poligono");
            List<PointLatLng> puntos = new List<PointLatLng>();
            for(int i = 0; i < a.Count; i++){
                 //MessageBox.Show("ZONA"+a[i].nombreZONA+"LONGITUD"+a[i].longitud);
                puntos.Add(new PointLatLng(a[i].latitud , a[i].longitud));
            }
            GMapPolygon poligonoPuntos = new GMapPolygon(puntos,"Poligono");
            poligono.Polygons.Add(poligonoPuntos);
            gControl.Overlays.Add(poligono);
            gControl.Zoom = gControl.Zoom+1;
            gControl.Zoom = gControl.Zoom-1;

        }


           private void removeMakers() {
                
            if(gControl.Overlays.Count > 0){
                 gControl.Overlays.Clear();
                 gControl.Refresh();
            
             }
           
            }   

        private void BEliminar_Click(object sender, EventArgs e){
            removeMakers();
        }


    }

}
