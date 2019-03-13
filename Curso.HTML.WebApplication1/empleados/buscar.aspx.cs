using ConsoleApp1.Models;
using Curso.HTML.WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Curso.HTML.WebApplication1.empleados
{
    public partial class buscar : System.Web.UI.Page
    {
        public List<string> Ciudades { get; set; }
        public List<string> Paises { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ModelNorthwind db = new ModelNorthwind();

            Ciudades = db.Employees.Select(r => r.City).Distinct().ToList();
            Paises = db.Employees.Select(r => r.Country).Distinct().ToList();
        }
    }
}