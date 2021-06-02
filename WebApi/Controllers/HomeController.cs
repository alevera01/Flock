using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()

        {

           ViewBag.Title = "Home Page";
            Utilidades.Logger.Fatal("Inicio de aplicacion.");
            return View();
        }
    }
}
