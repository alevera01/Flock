using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Domain
{
    [Serializable]
    public class Datos
    {

        public int cantidad { get; set; }
        public int total { get; set; }
        public int inicio { get; set; }
        public Parametros parametros { get; set; }
        public IList<Provincias> provincias { get; set; }

       }
    [Serializable]
    public class Parametros
    {
        public string nombre { get; set; }
      
    }
    [Serializable]
    public class Provincias {
        public string id { get; set; }
        public string nombre { get; set; }
        public CentroIde centroide{ get; set; }

}
    [Serializable]
    public class CentroIde
    {
 
        public decimal lat { get; set; }
        public decimal lon { get; set; }



    }
}