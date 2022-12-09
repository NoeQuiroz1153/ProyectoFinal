using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Models
{
    public static class Cntrolcrud
    {
        

        public async static Task<List<Models.Alumno>> GetAlumnos()
        {
            List<Models.Alumno> listalumnos = new List<Models.Alumno>();

            using (HttpClient clientrequest = new HttpClient())
            {
                var response = await clientrequest.GetAsync(Apidress.getservices);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    listalumnos = JsonConvert.DeserializeObject<List<Models.Alumno>>(content);
                  
                }

            }
            return listalumnos;
        }


        public async static Task<int> CreateAlumno(Models.Alumno alumno)
        {
            string jsonobj =JsonConvert.SerializeObject(alumno);
            StringContent contenido = new StringContent(jsonobj,Encoding.UTF8,"application/json");

            HttpResponseMessage response = null;
            using (HttpClient clientrequest = new HttpClient())
            {
                response = await clientrequest.PostAsync(Apidress.postservices,contenido);
                if(response.IsSuccessStatusCode)
                {
                    var resultado = response.Content.ReadAsStringAsync().Result;
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

        }



        public async static Task EliminaAlumnos(int id)
        {
           

            var clientrequest = new HttpClient();
           
            {
                var hhtresponse = await clientrequest.DeleteAsync(Apidress.deleteservices + id);
                if (hhtresponse.IsSuccessStatusCode)
                {
                    var resultado = hhtresponse.Content.ReadAsStringAsync();
                    
                }
               
            }

        }


        public async static Task<int> EditarAlumnos(Models.Alumno alumno)
        {
            string jsonobj = JsonConvert.SerializeObject(alumno);
            StringContent contenido = new StringContent(jsonobj, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            using (HttpClient clientrequest = new HttpClient())
            {
                response = await clientrequest.PutAsync(Apidress.putservices, contenido);
                if (response.IsSuccessStatusCode)
                {
                    var resultado = response.Content.ReadAsStringAsync().Result;
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

        }








    }
}
