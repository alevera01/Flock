using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Web.Http;
using System.IO;
using Newtonsoft.Json;
using WebApi.Domain;
using WebApi.Models;
using System.Text;

namespace WebApi.Controllers
{/// <summary>
/// 
/// </summary>
    public class CartaGeograficaController : Controller
    {
        // GET: CartaGeografica
        public ActionResult Index()
        {
            Carta model = new Carta();

            model.Provincias = new List<SelectListItem>()
                        {
                                new SelectListItem()
                                {
                                    Text = "Buenos Aires",
                                    Value = "Buenos Aires"
                                },
                                new SelectListItem()
                                {
                                    Text = "Cordoba",
                                    Value = "Cordoba"
                                },
                                new SelectListItem()
                                {
                                    Text = "Chubut",
                                    Value = "Chubut"
                                },
                                new SelectListItem()
                                {
                                    Text = "Corrientes",
                                    Value = "Corrientes"
                                },
                                new SelectListItem()
                                {
                                    Text = "Mendoza",
                                    Value = "Mendoza"
                                }
                        };
            Utilidades.Logger.Info("Acceso Vista Carta Geografica");
            return View(model);
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult ObtenerDatos(Carta model)
        {
            var url = $"http://localhost:57379/api/Default/ObtenerDatos/{model.Pcia}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "application/text";
            {


                try
                {
                    using (WebResponse response = request.GetResponse())
                    {
                        Stream receiveStream = response.GetResponseStream();

                        // Pipes the stream to a higher level stream reader with the required encoding format.
                        StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                       
                       string Retorno = readStream.ReadToEnd();
                       string[] datos = JsonConvert.DeserializeObject<string[]>(Retorno);
                        ViewBag.Latitud = datos[0];
                        ViewBag.Longitud = datos[1];
                        Utilidades.Logger.Info("Acceso Web Api Datos Cartograficos:" + datos[0] + " " + datos[1]);
                        return View("DatosGeograficos");
                    }

                }
                catch (Exception ex)
                {
                    Utilidades.Logger.Fatal("Error accediendo a Acceso Web Api Datos Cartograficos:" );
                    return View("Error");
 
                }

            }
 
        }
    }
}