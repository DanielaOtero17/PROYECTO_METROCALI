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
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.IO;

namespace App_MetroCali
{
    public partial class Form1 : Form
    {

        GMarkerGoogle marker;
        GMapOverlay markerOverlay;


        List<Stops> Paradas = new List<Stops>();
        List<Stops> ParadasEstaciones = new List<Stops>();
        List<Stops> ParadasCalle = new List<Stops>();
        double latitudCali = 3.42158;
        double longitudCali = -76.5205;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e){
            gControl.DragButton = MouseButtons.Left;
            gControl.CanDragMap = true;
            gControl.MapProvider = GMapProviders.GoogleMap;
            gControl.Position = new GMap.NET.PointLatLng(latitudCali, longitudCali);
            gControl.MinZoom = 0;
            gControl.MaxZoom = 24;
            gControl.Zoom = 18;
            gControl.AutoScroll = true;

           cb_elegir.Items.Add("ESTACIONES");
           cb_elegir.Items.Add("PARADAS EN LAS CALLES");
           cb_elegir.Items.Add("PATIOS");

            //lecturaParadas();

            markerOverlay = new GMapOverlay("Marcador");
            Bitmap markerMio = (Bitmap)Image.FromFile(@"iconoMio.png");
            marker = new GMarkerGoogle(new PointLatLng(3.4372201,-76.5224991), markerMio);
            markerOverlay.Markers.Add(marker);

            marker.ToolTipMode = MarkerTooltipMode.Always;
            marker.ToolTipText = String.Format("Este es el mio");
            gControl.Overlays.Add(markerOverlay);
        }

           public void lecturaParadas(){
            StreamReader lector = new StreamReader(@"STOPS.txt");
            String line = lector.ReadLine();

            while(line != null){
                String[] arregloString = line.Split(',');

                String STOPID = arregloString[0];
                String PLANVERSIONID = arregloString[1];
                String SHORTNAME = arregloString[2];
                String LONGNAME = arregloString[3];
                String GPS_X = arregloString[4];
                String GPS_Y = arregloString[5];
                String longi = arregloString[6];
                String lat = arregloString[7];

                Stops parada = new Stops(STOPID, PLANVERSIONID, SHORTNAME, LONGNAME, GPS_X, GPS_Y, longi, lat);

            }
           }

        public void separarListasDeParadas()
        {
            for(int i = 0; i< Paradas.Count; i++)
            {

            }
        }

        public List<Stops> retornarLista() {
         return Paradas;
        }

        private void GControl_Load(object sender, EventArgs e)
        {

        }
    }
}
