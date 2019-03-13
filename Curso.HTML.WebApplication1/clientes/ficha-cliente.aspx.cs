using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Curso.HTML.WebApplication1.Models;


namespace Curso.HTML.WebApplication1.clientes
{
    public partial class ficha_cliente : System.Web.UI.Page
    {
        public Customers cliente { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = HttpContext.Current.Request.Params["identificador"];
            Northwind db = new Northwind();
            //cuando lazyloadingenabled esta en false los elementos virtuales que son queryable no se ejecutan
            //db.Configuration.LazyLoadingEnabled = false;

            cliente = db.Customers
                .Where(i => i.CustomerID == id)
                .FirstOrDefault();

           

        }
    }

    
}