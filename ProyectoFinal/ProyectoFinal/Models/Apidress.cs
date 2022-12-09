using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinal.Models
{
    public class Apidress
    {
        public static string plantilaapi ="http://{0}/{1}/{2}";
        public static string ipadress = "192.168.56.1";
        public static string restapi = "prad/V2";
        public static string getphp = "GET.php";
        public static string postphp = "POST.php";
        public static string putphp = "PUT.php";
        public static string deletephp = "DELETE.php?Id=";
        private static string EndpointList = "GET.php";
        private static string EndpointCreate= "POST.php";

        public static string getservices = string.Format(plantilaapi, ipadress, restapi,getphp);
        public static string postservices = string.Format(plantilaapi, ipadress, restapi, postphp);
        public static string putservices = string.Format(plantilaapi, ipadress, restapi, putphp);
        public static string deleteservices = string.Format(plantilaapi, ipadress, restapi, deletephp);
    }
}
