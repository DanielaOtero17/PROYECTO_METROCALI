using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_MetroCali
{
    public class Stops
    {
        public String STOPID { get; set; }
        public String PLANVERSIONID { get; set; }
        public String SHORTNAME { get; set; }
        public String LONGNAME { get; set; }
        public String GPS_X { get; set; }
        public String GPS_y { get; set; }
        public double DECIMALLONGITUD { get; set; }
        public double DECIMALLATITUD { get; set; }

        public Stops(string sTOPID, string pLANVERSIONID, string sHORTNAME, string lONGNAME, string gPS_X, string gPS_y, double dECIMALLONGITUD, double dECIMALLATITUD)
        {
            STOPID = sTOPID;
            PLANVERSIONID = pLANVERSIONID;
            SHORTNAME = sHORTNAME;
            LONGNAME = lONGNAME;
            GPS_X = gPS_X;
            GPS_y = gPS_y;
            DECIMALLONGITUD = dECIMALLONGITUD;
            DECIMALLATITUD = dECIMALLATITUD;
        }
    }
}
