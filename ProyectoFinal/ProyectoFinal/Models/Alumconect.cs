using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net;

namespace ProyectoFinal.Models
{
    public class Alumconect
    {
        Uri urlDB = new Uri("http://192.168.56.1");
        Uri urlDBGET = new Uri("http://192.168.56.1/prad/V2/GET.php");
        //Uri urlDBPOST = new Uri(http://192.168.56.1/prad/V2/POST.php");
        //Uri urlDBPUT = new Uri(http://192.168.56.1/prad/V2/PUT.php");
        //Uri urlDBDELETE = new Uri(http://192.168.56.1/prad/V2/DELETE.php");

        //consulta la API



        public async Task<T> GetAlumno<T>(string stParams)
        {
            string requestUri = "/prad/V2/GET.php";

            var alumno = new HttpClient();
            alumno.BaseAddress = urlDB;

            HttpResponseMessage response = await alumno.GetAsync($"{ requestUri}{ stParams}");

            if(response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                return default(T);
            }


        }


        public async Task<T> DeleteAlumno<T>(string stParams)
        {
            string requestUri = "/prad/V2/DELETE.php";

            var alumno = new HttpClient();
            alumno.BaseAddress = urlDB;

            HttpResponseMessage response = await alumno.GetAsync($"{ requestUri}{ stParams}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                return default(T);
            }


        }



        //public async static Task<List<Models.Alumno>> GetAlumno()
        //{
        //    List<Models.Alumno> listalumno = new List<Models.Alumno>();
        //    try
        //    {



        //    using(HttpClient clientrequest = new HttpClient())
        //    {
        //        var response = await clientrequest.GetAsync(Apidress.getservices);
        //        if(response.IsSuccessStatusCode)
        //        {
        //            var cont= response.Content.ReadAsStringAsync().ToString();
        //            listalumno = JsonConvert.DeserializeObject<List<Models.Alumno>>(cont);
        //        }
        //    }
        //    return listalumno;
        //    }


        //    catch (Exception ex)
        //    {
        //        ex.ToString();
        //        return listalumno;
        //    }
        //}
    }
}
