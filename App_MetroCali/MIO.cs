﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_MetroCali
{
    public class MIO{

        public String EVENTTYPE { get; set; }
      
        public String STOPID { get; set; }
        public String ODOMETER { get; set; }
        public String LATITUDE { get; set; }
        public String LONGITUDE { get; set; }
        public String TASKID { get; set; }
        public String LINEID { get; set; }
        public String TRIPID { get; set; }
        public String DATAGRAMID { get; set; }
        public String DATAGRAMDATE { get; set; }
        public String BUSID { get; set; }
        int run { get; set; }

        public List<String> LIST_LATITUDE { get; set; }

        public List<String> LIST_LONGITUDE { get; set; }

        public List<String> ways { get; set; }

        public int index { get; set; }

     

        public MIO (String evt  ,String stop,String odo, String lat , String longi ,String task,String line , String trip,
            String dataG,String dataGraM ,String bus){

            EVENTTYPE = evt;
            
            STOPID = stop;
            ODOMETER = odo;
            LATITUDE = lat;
            LONGITUDE = longi;
            TASKID = task;
            LINEID = line;
            TRIPID = trip;
            DATAGRAMID = dataG;
            DATAGRAMDATE = dataGraM;
            BUSID = bus;


            LIST_LATITUDE = new List<String>();
            LIST_LONGITUDE = new List<String>();

            ways = new List<string>();
            ways.Add(LATITUDE + "," + LONGITUDE);
            run = 0;
           

        }

        public void addNewWay(String latitud, String longitud)
        {
            ways.Add(latitud + "," + longitud);
        }

        public void changeLocation()
        {

            if (run < ways.Count)
            {
                String[] info = ways[run].Split(',');

                this.LATITUDE = info[0];
                this.LONGITUDE = info[1];
                run++;
            }
            
            
        }

        public void moveBus(int x1, int y1)
        {
            int x = Int32.Parse(LATITUDE);
            int y = Int32.Parse(LONGITUDE);

            if (x != x1 && y != y1)
            {
                float deltaX = x1 - x;
                float deltaY = y1 - y;
                float angle = (float)Math.Atan2(deltaY, deltaX);

                double speedX = 0.000015 * Math.Cos(angle);
                double speedY = 0.000015 * Math.Sin(angle);

                x = (int)(x + speedX);
                LATITUDE = x.ToString();

                y = (int)(y + speedY);
                LONGITUDE = y.ToString();

            }

            //double dist = Math.Hypot(x - x1, y - y1);
            double dist = Math.Sqrt(Math.Pow(x - x1, 2) + Math.Pow(y - y1, 2));

            if (dist < 8)
            {
                x = x1;
                LATITUDE = x.ToString();
                y = y1;
                LONGITUDE = y.ToString();
            }
        }
    }
}
