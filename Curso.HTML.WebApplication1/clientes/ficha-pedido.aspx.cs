using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Curso.HTML.WebApplication1.Models;

namespace Curso.HTML.WebApplication1.clientes
{
    public partial class ficha_pedido : System.Web.UI.Page
    {
        public Orders pedido { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(HttpContext.Current.Request.Params["id"]);
            Northwind db = new Northwind();
            //cuando lazyloadingenabled esta en false los elementos virtuales que son queryable no se ejecutan
            //db.Configuration.LazyLoadingEnabled = false;

            pedido = db.Orders
                .Where(i => i.OrderID == id)
                .FirstOrDefault();
        }
    }
}