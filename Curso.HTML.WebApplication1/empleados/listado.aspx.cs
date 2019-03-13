using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Curso.HTML.WebApplication1.Models;

namespace Curso.HTML.WebApplication1.empleados
{
    public partial class listado : System.Web.UI.Page
    {
        public List<Employees> Empleados { get; set; }

        private string nombre;
        private string ciudad;
        private string pais;

        protected void Page_Load(object sender, EventArgs e)
        {
            nombre = HttpContext.Current.Request.Params["nombre"];
            ciudad = HttpContext.Current.Request.Params["ciudad"];
            pais = HttpContext.Current.Request.Params["pais"];

            Consulta2();
        }

        //Consulta utilizando SqlQuery()
        protected void Consulta1()
        {
            Northwind db = new Northwind();
            string sql = "";

            if (nombre != null && nombre != "") sql += "(FirstName LIKE '%" + nombre + "%' OR LastName LIKE '%" + nombre + "%')";
            if (ciudad != "all") sql += (sql != "" ? " AND " : "") + "City = '" + ciudad + "'";
            if (pais != "all") sql += (sql != "" ? " AND " : "") + "Country = '" + pais + "'";

            sql = "SELECT * FROM Employees" + (sql != "" ? " WHERE " + sql : "");

            Empleados = db.Employees.SqlQuery(sql).ToList();
        }

        //Consulta utilizando métodos de LINQ
        protected void Consulta2()
        {
            Northwind db = new Northwind();

            int modo = 0;
            if (nombre != null && nombre != "") modo += 10;
            if (ciudad != "all") modo += 100;
            if (pais != "all") modo += 1000;

            switch (modo)
            {
                //Ningun datos
                case 0:
                    Empleados = db.Employees.ToList();
                    break;
                //Solo nombre
                case 10:
                    Empleados = db.Employees.Where(r => r.FirstName.Contains(nombre) || r.LastName.Contains(nombre)).ToList();
                    break;
                //Solo ciudad
                case 100:
                    Empleados = db.Employees.Where(r => r.City == ciudad).ToList();
                    break;
                //Solo País
                case 1000:
                    Empleados = db.Employees.Where(r => r.Country == pais).ToList();
                    break;
                //Nombre y ciudad
                case 110:
                    Empleados = db.Employees.Where(r => (r.FirstName.Contains(nombre) || r.LastName.Contains(nombre)) && r.City == ciudad).ToList();
                    break;
                //Nombre y País
                case 1010:
                    Empleados = db.Employees.Where(r => (r.FirstName.Contains(nombre) || r.LastName.Contains(nombre)) && r.Country == pais).ToList();
                    break;
                //Ciudad y País
                case 1100:
                    Empleados = db.Employees.Where(r => r.Country == pais && r.City == ciudad).ToList();
                    break;
                //Nombre, ciudad y país
                case 1110:
                    Empleados = db.Employees.Where(r => (r.FirstName.Contains(nombre) || r.LastName.Contains(nombre)) && r.City == ciudad && r.Country == pais).ToList();
                    break;
            }
        }
    }
}