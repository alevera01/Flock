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
namespace WebApi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [System.Web.Mvc.HttpPost]

        public ActionResult Login(USUARIOS objUser)
        {
            var url = $"http://localhost:57379/api/Default/Login/";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            var tokendecode= System.Text.Encoding.UTF8.GetBytes(objUser.USUARIO + ":" + objUser.PASSWORD);
            string Token = System.Convert.ToBase64String(tokendecode);
            request.Headers.Set(HttpRequestHeader.Authorization, "Basic " + Token);
            {


                try
                {
                    using (WebResponse response = request.GetResponse())
                    {
                        ViewBag.Usuario = objUser.USUARIO;
                        Utilidades.Logger.Info("Login-Correcto.  User " + objUser.USUARIO);

                        return View(objUser);

                    }
                    
                }
                catch (Exception ex)
                {
                    Utilidades.Logger.Fatal("Login:Credenciales Ingresadas Incorrectas:");

                    return View("Error");
                }

            }
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View("Index");
        }
    }
}
