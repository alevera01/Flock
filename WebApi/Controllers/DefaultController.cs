using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.IO;
using Newtonsoft.Json;
using WebApi.Domain;
using System.Net.Http;
using WebApi.Modificadores;
namespace WebApi.Controllers
{
    public class DefaultController : ApiController
    {
        /// <summary>
        /// Api que busca el usuario y pwd de la base y los valida.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [BasicAuthentication]
        [Route("api/Default/Login/")]
        public string Login()
        {
            return ("Web Api Log in");
        }



        // GET: api/Default/5
        /// <summary>
        /// Api que dada una provincia devuelve los datos de longitud y latitud de la misma
        /// </summary>
        /// <param name="provincia"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Default/ObtenerDatos/{provincia}")]
        public string[] GetElements(string provincia)
        {
            var url = $"https://apis.datos.gob.ar/georef/api/provincias?nombre={provincia}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
             
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();

                            Datos datos = JsonConvert.DeserializeObject<Datos>(responseBody);
                          
                            return new string[] {"Lat:" + datos.provincias[0].centroide.lat, "Lon:" + datos.provincias[0].centroide.lon };
                       //     return JsonConvert.SerializeObject(datos.provincias[0].centroide);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }
   
    }
}
