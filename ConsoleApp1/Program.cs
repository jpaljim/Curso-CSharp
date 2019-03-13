using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ConsoleApp1.Models;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Demo demo = new Demo();
            demo.Comenzar();
            Console.ReadKey();
        }
    }

    public class Demo
    {
        //TODO Realiza una llamada al método asíncrono para buscar un producto
        //TODO Realiza una llamada al método síncrono para buscar un producto
        public async Task Comenzar()
        {
            await BuscaProductoAsync("Chai");
            BuscaProducto("Chai");


        }

        //TODO Crear un método asíncrono BuscarProductoAsync que retorna una lista de Productos
        //TODO El método tiene un parámetro de tipo string con el nombre del producto a buscar

        //TODO Opcionalmente añade el espacio de nombres System.Data.Entity y finaliza la sentencia
        //     de LINQ con AsQueryable().ToListAsync()

        //LA FIRMA DEL MÉTODO NO ES CORRECTA, SOLAMENTE ORIENTATIVA
        public async Task<List<Products>> BuscaProductoAsync(string nombre)
        {

            return await Task.Run(() =>
            {

                ModelNorthwind db = new ModelNorthwind();
                List<Products> lista = new List<Products>();

                var query = db.Products.AsParallel()
                    .Where(r => r.ProductName == nombre)
                    .ToList();


                foreach (var item in query)
                {
                    Console.WriteLine("Producto asincrono {0} - {1} {2} euros", nombre, item.ProductID, item.UnitPrice.Value.ToString("N2"));

                }

                return query;

            });


        }




        //TODO Crear un método sincrono que implemente la misma lógica del método asíncrono
        //TODO Reutiliza el código del método asíncrono realizando una llamada al mismo para resolver
        //     la búsqueda del producto.

        //LA FIRMA DEL MÉTODO NO ES CORRECTA, SOLAMENTE ORIENTATIVA
        public List<Products> BuscaProducto(string nombre)
        {
            return BuscaProductoAsync(nombre).Result;

        }
    }
}