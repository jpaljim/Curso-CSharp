using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Curso.HTML.WebApplication1
{
    public partial class pinta_ficha : System.Web.UI.Page
    {
        public Cliente Cliente { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Cliente = new Cliente();


            //Acceso a los datos del formulario enviado en modo get, usamos el QueryString
            //La información que viene de un formulario es texto, da igual que sea number o fecha o lo que sea, siempre texto
            //Cliente.ID = HttpContext.Current.Request.QueryString["identificador"];

            //Acceso a los datos del formulario enviado en modo post, usamos el Form
            //La información que viene de un formulario es texto, da igual que sea number o fecha o lo que sea, siempre texto
            //Cliente.ID = HttpContext.Current.Request.Form["identificador"];

            //Cuando se envia en get o post (usar params), en params hay mas cosas ademas de los datos del formulario
            Cliente.ID = HttpContext.Current.Request.Params["identificador"];
            Cliente.Empresa = HttpContext.Current.Request.Params["empresa"];
            Cliente.Contacto = HttpContext.Current.Request.Params["contacto"];
            Cliente.Cargo = HttpContext.Current.Request.Params["cargo"];
            Cliente.Direccion = HttpContext.Current.Request.Params["direccion"];
            Cliente.Provincia = HttpContext.Current.Request.Params["provincia"];
            Cliente.Pais = HttpContext.Current.Request.Params["pais"];
        }
    }

    public class Cliente
    {
        public string ID { get; set; }
        public string Empresa { get; set; }
        public string Contacto { get; set; }
        public string Cargo { get; set; }
        public string Direccion { get; set; }
        public string Provincia { get; set; }
        public string Pais { get; set; }
    }
}