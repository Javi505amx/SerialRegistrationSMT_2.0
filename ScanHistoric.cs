using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SerialRegistrationSMT_2._0
{
    public class ScanHistoric
    {
        public static string userLogin;
        public static string loginDate;
        public static string loginTime;
        public static string longDateTime = ScanHistoric.loginDate + ScanHistoric.loginTime;
    }
}