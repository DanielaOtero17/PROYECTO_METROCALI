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


        public void separarListasDeParadas()
        {
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

        private void GControl_Load(object sender, EventArgs e)
        {

        }

        private void Bguardar_Click(object sender, EventArgs e)
        {

        }

        private void filter()
        {
            switch{
            case ""


            }
        }
        private void Cb_elegir_SelectedIndexChanged(object sender, EventArgs e)
        {
            
          
        }
    }
}
