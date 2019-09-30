﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_MetroCali
{
    public class MIO{

        public String EVENTTYPE { get; set; }
        public String REGISTERDATE { get; set; }
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

        public List<String> LIST_LATITUDE { get; set; }

        public List<String> LIST_LONGITUDE { get; set; }

        public List<String> ways { get; set; }

        public MIO (String evt , String regis ,String stop,String odo, String lat , String longi ,String task,String line , String trip,
            String dataG,String dataGraM ,String bus){

            EVENTTYPE = evt;
            REGISTERDATE = regis;
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

        }

        public void addNewWay(String latitud, String longitud)
        {
            ways.Add(latitud + "," + longitud);
        }

        public void changeLocation(String lat,String longi)
        {
            this.LATITUDE = lat;
            this.LONGITUDE = longi;
        }
    }
}
