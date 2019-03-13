using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Curso.CSharp.ConsoleApp10.Models;
using System.Data;
using System.Data.SqlClient;

namespace Curso.CSharp.ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            ModelNorthwind db = new ModelNorthwind();

            //Consulta con ADO.NET
            //=======================================================================
            //
            // a. Creamos una cadena de conexión

            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
            csb.DataSource = "LOCALHOST";
            csb.InitialCatalog = "NORTHWIND";
            csb.UserID = "";
            csb.Password = "";
            csb.IntegratedSecurity = true;

            string cadenaConexion = csb.ToString();

            // b. Creamos un objeto de conexión

            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            // c. Creamos un objeto Comando

            SqlCommand cm = new SqlCommand();
            cm.Connection = cn;
            cm.CommandText = "SELECT * FROM dbo.Customers WHERE Country = 'Spain'";

            //Utilizamos ExecuteNonQuery() para INSERT, UPDATE, DELETE
            //Retirna un int con el número de registro afectados, -1 Error
            //cm.ExecuteNonQuery();

            //Utilizamos ExecuteReader() para SELECT
            SqlDataReader reader = cm.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("{0} {1}",
                        reader["CompanyName"].ToString(), reader["Country"].ToString());
                }

                reader.Close();
            }
            else
            {
                Console.WriteLine("No se han encontrado registros.");
            }

            cm.Dispose();
            cn.Close();
            cn.Dispose();

            Console.ReadKey();


            //Eliminar un registro
            var region3 = db.Region.Where(r => r.RegionID == 10).FirstOrDefault();
            db.Region.Remove(region3);

            db.SaveChanges();

            Console.WriteLine("Registro Eliminado Correctamente.");
            Console.ReadKey();

            //Modificar un registro
            var region2 = db.Region.Where(r => r.RegionID == 10).FirstOrDefault();
            region2.RegionDescription = region2.RegionDescription.Trim() + "aaaaaaEl inframundo";

            db.SaveChanges();

            Console.WriteLine("Registro Modificado Correctamente.");
            Console.ReadKey();

            //Insertar un registro
            Region region = new Region();
            region.RegionID = 10;
            region.RegionDescription = "Triangulo de las Bermudas";

            db.Region.Add(region);
            db.SaveChanges();

            Console.WriteLine("Registro Insertado Correctamente.");
            Console.ReadKey();

            //LINQPad5

            //Demo SQLQuery
            var e1 = db.Customers.ToList();
            var e1b = db.Customers.SqlQuery("SELECT * FROM Customers");

            var e2 = db.Customers.Where(r => r.Country == "Mexico").ToList();
            var e2b = db.Customers.SqlQuery("SELECT * FROM Customers WHERE Country = 'Mexico'");


            //Empleados con clientes que viven en su misma ciudad
            var EmpleadosClientes = db.Employees
                .Select(r => new {
                    r.FirstName,
                    r.LastName,
                    r.City,
                    clientes = db.Customers.Where(c => c.City == r.City).ToList()
                })
                .Where(r => r.clientes.Count() > 0)
                .ToList();


            foreach (var empleado in EmpleadosClientes)
            {
                Console.WriteLine("{0} {1} - {2}", empleado.FirstName, empleado.LastName, empleado.City);
                Console.WriteLine("===========================================================");
                foreach (var cliente in empleado.clientes)
                {
                    Console.WriteLine("  {0}", cliente.CompanyName);
                }

                Console.WriteLine("");
                Console.WriteLine("");
            }
            Console.ReadKey();

            //Empleados y número de productos diferentes vendidos
            //Pendiente de Revisión


            //Clientes que no han comprado nada
            var clientesOut = db.Customers
                .Where(r => !r.Orders.Any())
                .Select(r => r.CompanyName)
                .ToList();

            var clientesOut2 = db.Customers
                .Where(r => r.Orders.Count() == 0)
                .Select(r => r.CompanyName)
                .ToList();

            foreach (var cliente in clientesOut)
            {
                Console.WriteLine("{0}", cliente);
            }
            Console.ReadKey();

            //Nombre y Apellidos de empleados que llevan trabajando más timepo que el empleado
            //más antiguo de Londres
            var empleados4 = db.Employees
                .Where(r => r.City != "London" &&
                    r.HireDate < db.Employees.Where(s => s.City == "London").Min(s => s.HireDate))
                .Select(r => new { r.LastName, r.FirstName })
                .ToList();

            foreach (var empleado in empleados4)
            {
                Console.WriteLine("{0} {1}", empleado.FirstName, empleado.LastName);
            }
            Console.ReadKey();


            //Fecha de incorporación del empleado más antiguo de Londres
            var fecha2 = db.Employees
                .Where(r => r.City == "London")
                .Min(r => r.HireDate);

            var fecha3 = db.Employees
                .Where(r => r.City == "London")
                .Select(r => r.HireDate)
                .Min();

            var fecha4 = db.Employees
                .Where(r => r.City == "London")
                .OrderBy(r => r.HireDate)
                .FirstOrDefault().HireDate;

            //Empleado con 50 años o más
            DateTime fecha = DateTime.Now.AddYears(-50);

            var empleadosMayores = db.Employees
                .Where(r => r.BirthDate < fecha).ToList();

            foreach (var empleado in empleadosMayores)
            {
                Console.WriteLine("{0} {1}", empleado.FirstName, empleado.LastName);
            }
            Console.ReadKey();


            //Empleados que ha tramitado pedidos con destino España
            var empleados = db.Employees
                .Join(db.Orders,
                    e => e.EmployeeID,
                    o => o.EmployeeID,
                    (e, o) => new { e.FirstName, e.LastName, o.ShipCountry })
                .Where(r => r.ShipCountry == "Spain")
                .Distinct()
                .ToList();

            foreach (var empleado in empleados)
            {
                Console.WriteLine("{0} {1}", empleado.FirstName, empleado.LastName);
            }
            Console.ReadKey();










            //Número de clientes por pais con SubSelect
            var paises = db.Customers
                .Select(r => r.Country)
                .Distinct()
                .ToList();

            foreach (var pais in paises)
            {
                Console.WriteLine("País: {0} - {1} clientes",
                    pais,
                    db.Customers.Where(r => r.Country == pais).Count());
            }
            Console.ReadKey();

            //Número de clientes por pais con GroupBy
            var clientes2 = db.Customers
                .GroupBy(r => r.Country)
                .Select(r => new { pais = r.Key, clientes = r.Count() })
                .ToList();

            foreach (var cliente in clientes2)
            {
                Console.WriteLine("País: {0} - {1} clientes", cliente.pais, cliente.clientes);
            }
            Console.ReadKey();

            //Listado de Clientes
            var clientes = db.Customers
                .Where(r => r.Country == "Mexico")
                .ToList();

            foreach (var cliente in clientes)
            {
                Console.WriteLine("{0}# - {1} - {2} ({3})",
                    cliente.CustomerID, cliente.CompanyName, cliente.City, cliente.Country);
            }
            Console.WriteLine("{0} registros recuperados", clientes.Count());

            Console.ReadKey();
        }
    }
}