using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_MetroCali
{
    public class Stops
    {
        private String STOPID { get; set; }
        private String PLANVERSIONID { get; set; }
        private String SHORTNAME { get; set; }
        private String LONGNAME { get; set; }
        private String GPS_X { get; set; }
        private String GPS_y { get; set; }
        private double DECIMALLONGITUD { get; set; }
        private double DECIMALLATITUD { get; set; }

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
