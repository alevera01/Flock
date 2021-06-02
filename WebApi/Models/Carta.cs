using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApi.Models
{
    public class Carta
    {
        


        public string Pcia { get; set; }
        public List<SelectListItem> Provincias { get; set; }
        public Decimal Lat { get; set; }
        public Decimal Lon { get; set; }

    }
}