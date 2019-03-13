using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.CSharpConsole.AppEjercicios2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Clientes que hayan pedido 10 unidades o más de cualquier producto
           
            var q22 = DataLists.ListaPedidos
                .GroupJoin(DataLists.ListaLineasPedido,
                //Los unimos para relacionar los datos de una tabla con la otra
                    p => p.Id,//tabla de la que parto
                    l => l.IdPedido,//tabla con la que hago el join
                    (pedido, lineas) =>
                        new
                        {
                            cliente = pedido.IdCliente,
                            pedido = pedido.Id,
                            cantidad = lineas.Sum(r => r.Cantidad)
                        })
                        .Where(r => r.cantidad > 10)
                        .ToList();

            foreach (var i in q22)
            {
                Console.WriteLine("Pedido: {0} - Cantidad: {1}", i.cliente, i.cantidad );
            }



            //Listado de Pedidos con el importe total
            var q21 = DataLists.ListaLineasPedido
                .GroupBy(l => l.IdPedido)
                .Select(g => new {
                    Identificador = g.Key,
                    Importe = g.Sum(r => r.Cantidad * DataLists.ListaProductos
                        .Where(p => p.Id == r.IdProducto)
                        .Select(p => p.Precio)
                        .FirstOrDefault())
                })
                .ToList();

            foreach (var i in q21)
            {
                Console.WriteLine("ID Pedido: {0} - Importe: {1}",
                    i.Identificador.ToString().PadLeft(3),
                    i.Importe.ToString("N2").PadLeft(6));
            }

            Console.ReadKey();


            var q20 = DataLists.ListaLineasPedido
                .GroupBy(l => l.IdPedido)
                .Select(r => new { Identificador = r.Key, Pedidos = r })
                .ToList();

            foreach (var i in q20)
            {
                Console.WriteLine("ID Pedido: {0} - Importe: {1}",
                    i.Identificador.ToString().PadLeft(3),
                    i.Pedidos.Sum(r => r.Cantidad * DataLists.ListaProductos
                        .Where(p => p.Id == r.IdProducto)
                        .Select(p => p.Precio)
                        .FirstOrDefault()).ToString("N2").PadLeft(6));
            }

            Console.ReadKey();

            //Nombre del cliente que más pedidos ha realizado
            var q16 = DataLists.ListaClientes
                .Where(r => r.Id == (DataLists.ListaPedidos
                    .GroupBy(p => p.IdCliente)
                    .Select(c => new { Identificador = c.Key, Pedidos = c.Count() })
                    .OrderByDescending(o => o.Pedidos)
                    .FirstOrDefault()).Identificador)
                .FirstOrDefault();

            var q17 = (from c in DataLists.ListaClientes
                       where c.Id == (from p in DataLists.ListaPedidos
                                      group p by p.IdCliente into g
                                      orderby g.Count() descending
                                      select g.Key).FirstOrDefault()
                       select c)
                      .FirstOrDefault();


            Console.WriteLine("{0} - {1}", q17.Id, q17.Nombre);
            Console.ReadKey();


            //Número de Pedidos por Cliente
            var q14 = DataLists.ListaPedidos.GroupBy(p => p.IdCliente)
                .Select(c => new {
                    Identificador = c.Key,
                    Pedidos = c.Count()
                })
                .ToList();

            var q15 = from p in DataLists.ListaPedidos
                      group p by p.IdCliente into c
                      select new { Identificador = c.Key, Pedidos = c.Count() };

            foreach (var i in q14)
            {
                Console.WriteLine("ID Cliente {0} - {1} pedidos", i.Identificador, i.Pedidos);
            }

            Console.ReadKey();

            //Búscar el producto de mayor precio
            var q13 = DataLists.ListaProductos
                .Where(r => r.Precio == DataLists.ListaProductos.Select(s => s.Precio).Max())
                .FirstOrDefault();

            Console.WriteLine("{0} {1}", q13.Descripcion, q13.Precio.ToString("N2"));
            Console.ReadKey();

            var q12b = (from c in DataLists.ListaProductos
                        where c.Precio == (from r in DataLists.ListaProductos select r.Precio).Max()
                        select c).FirstOrDefault();


            //Consultas con Where
            var q9 = DataLists.ListaProductos
                .Where(r => r.Descripcion.Contains("cuaderno"))
                .ToList();

            var q10 = DataLists.ListaProductos
                .Where(r => r.Descripcion.StartsWith("cuaderno"))
                .ToList();

            var q11 = DataLists.ListaProductos
                .Where(r => r.Descripcion.EndsWith("cuaderno"))
                .ToList();

            var q12 = from c in DataLists.ListaProductos
                      where c.Descripcion.Contains("cuaderno")
                      select c;


            //Cosulta nombre e identificador del cliente
            var q7 = DataLists.ListaClientes
                .Select(r => new { NombreCompleto = r.Nombre, Identificador = r.Id })
                .ToList();

            var q8 = from c in DataLists.ListaClientes
                     select new { c.Nombre, c.Id };

            foreach (var i in q7)
            {
                Console.WriteLine("{0}# {1}",
                    i.Identificador, i.NombreCompleto);
            }

            Console.ReadKey();


            //Número de Clientes nacidos ente 1980 y 1990
            var q5 = DataLists.ListaClientes
                .Where(r => r.FechaNac.Year >= 1980 && r.FechaNac.Year <= 1990)
                .Count();

            var q6 = (from c in DataLists.ListaClientes
                      where c.FechaNac.Year >= 1980 && c.FechaNac.Year <= 1990
                      select c).Count();

            Console.WriteLine("Número de Registros {0}", q6);
            Console.ReadKey();

            //Búsqueda filtrada
            var q3 = DataLists.ListaClientes
                .Where(r => r.Id == 2)
                .FirstOrDefault();

            var q4 = from c in DataLists.ListaClientes
                     where c.Id == 2
                     select c;

            if (q3 != null)
            {
                Console.WriteLine("{0}# {1} - Fecha de Nacimiento {2}",
                    q3.Id, q3.Nombre, q3.FechaNac.ToShortDateString());
            }

            Console.ReadKey();



            //Lista Completa de Clientes
            var q1 = DataLists.ListaClientes.ToList();

            var q2 = from c in DataLists.ListaClientes
                     select c;


            foreach (Cliente i in q1)
            {
                Console.WriteLine("{0}# {1} - Fecha de Nacimiento {2}",
                    i.Id, i.Nombre, i.FechaNac.ToShortDateString());
            }

            Console.ReadKey();
        }
    }

    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNac { get; set; }
    }

    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
    }

    public class Pedido
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaPedido { get; set; }
    }

    public class LineaPedido
    {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
    }

    public static class DataLists
    {
        private static List<Cliente> _listaClientes = new List<Cliente>() {
            new Cliente { Id = 1,   Nombre = "Carlos Gonzalez Rodriguez",   FechaNac = new DateTime(1980, 10, 10) },
            new Cliente { Id = 2,   Nombre = "Luis Gomez Fernandez",        FechaNac = new DateTime(1961, 4, 20) },
            new Cliente { Id = 3,   Nombre = "Ana Lopez Diaz ",             FechaNac = new DateTime(1947, 1, 15) },
            new Cliente { Id = 4,   Nombre = "Fernando Martinez Perez",     FechaNac = new DateTime(1981, 8, 5) },
            new Cliente { Id = 5,   Nombre = "Lucia Garcia Sanchez",        FechaNac = new DateTime(1973, 11, 3) }
        };

        private static List<Producto> _listaProductos = new List<Producto>()
        {
            new Producto { Id = 1,      Descripcion = "Boligrafo",          Precio = 0.35f },
            new Producto { Id = 2,      Descripcion = "Cuaderno grande",    Precio = 1.5f },
            new Producto { Id = 3,      Descripcion = "Cuaderno pequeño",   Precio = 1 },
            new Producto { Id = 4,      Descripcion = "Folios 500 uds.",    Precio = 3.55f },
            new Producto { Id = 5,      Descripcion = "Grapadora",          Precio = 5.25f },
            new Producto { Id = 6,      Descripcion = "Tijeras",            Precio = 2 },
            new Producto { Id = 7,      Descripcion = "Cinta adhesiva",     Precio = 1.10f },
            new Producto { Id = 8,      Descripcion = "Rotulador",          Precio = 0.75f },
            new Producto { Id = 9,      Descripcion = "Mochila escolar",    Precio = 12.90f },
            new Producto { Id = 10,     Descripcion = "Pegamento barra",    Precio = 1.15f },
            new Producto { Id = 11,     Descripcion = "Lapicero",           Precio = 0.55f },
            new Producto { Id = 12,     Descripcion = "Grapas",             Precio = 0.90f }
        };

        private static List<Pedido> _listaPedidos = new List<Pedido>()
        {
            new Pedido { Id = 1,     IdCliente = 1,  FechaPedido = new DateTime(2013, 10, 1) },
            new Pedido { Id = 2,     IdCliente = 1,  FechaPedido = new DateTime(2013, 10, 8) },
            new Pedido { Id = 3,     IdCliente = 1,  FechaPedido = new DateTime(2013, 10, 12) },
            new Pedido { Id = 4,     IdCliente = 1,  FechaPedido = new DateTime(2013, 11, 5) },
            new Pedido { Id = 5,     IdCliente = 2,  FechaPedido = new DateTime(2013, 10, 4) },
            new Pedido { Id = 6,     IdCliente = 3,  FechaPedido = new DateTime(2013, 7, 9) },
            new Pedido { Id = 7,     IdCliente = 3,  FechaPedido = new DateTime(2013, 10, 1) },
            new Pedido { Id = 8,     IdCliente = 3,  FechaPedido = new DateTime(2013, 11, 8) },
            new Pedido { Id = 9,     IdCliente = 3,  FechaPedido = new DateTime(2013, 11, 22) },
            new Pedido { Id = 10,    IdCliente = 3,  FechaPedido = new DateTime(2013, 11, 29) },
            new Pedido { Id = 11,    IdCliente = 4,  FechaPedido = new DateTime(2013, 10, 19) },
            new Pedido { Id = 12,    IdCliente = 4,  FechaPedido = new DateTime(2013, 11, 11) }
        };

        private static List<LineaPedido> _listaLineasPedido = new List<LineaPedido>()
        {
            new LineaPedido() { Id = 1,  IdPedido = 1,  IdProducto = 1,     Cantidad = 9 },
            new LineaPedido() { Id = 2,  IdPedido = 1,  IdProducto = 3,     Cantidad = 7 },
            new LineaPedido() { Id = 3,  IdPedido = 1,  IdProducto = 5,     Cantidad = 2 },
            new LineaPedido() { Id = 4,  IdPedido = 1,  IdProducto = 7,     Cantidad = 2 },
            new LineaPedido() { Id = 5,  IdPedido = 2,  IdProducto = 9,     Cantidad = 1 },
            new LineaPedido() { Id = 6,  IdPedido = 2,  IdProducto = 11,    Cantidad = 15 },
            new LineaPedido() { Id = 7,  IdPedido = 3,  IdProducto = 12,    Cantidad = 2 },
            new LineaPedido() { Id = 8,  IdPedido = 3,  IdProducto = 1,     Cantidad = 4 },
            new LineaPedido() { Id = 9,  IdPedido = 4,  IdProducto = 2,     Cantidad = 3 },
            new LineaPedido() { Id = 10, IdPedido = 5,  IdProducto = 4,     Cantidad = 2 },
            new LineaPedido() { Id = 11, IdPedido = 6,  IdProducto = 1,     Cantidad = 20 },
            new LineaPedido() { Id = 12, IdPedido = 6,  IdProducto = 2,     Cantidad = 7 },
            new LineaPedido() { Id = 13, IdPedido = 7,  IdProducto = 1,     Cantidad = 4 },
            new LineaPedido() { Id = 14, IdPedido = 7,  IdProducto = 2,     Cantidad = 10 },
            new LineaPedido() { Id = 15, IdPedido = 7,  IdProducto = 11,    Cantidad = 2 },
            new LineaPedido() { Id = 16, IdPedido = 8,  IdProducto = 12,    Cantidad = 2 },
            new LineaPedido() { Id = 17, IdPedido = 8,  IdProducto = 3,     Cantidad = 9 },
            new LineaPedido() { Id = 18, IdPedido = 9,  IdProducto = 5,     Cantidad = 11 },
            new LineaPedido() { Id = 19, IdPedido = 9,  IdProducto = 6,     Cantidad = 9 },
            new LineaPedido() { Id = 20, IdPedido = 9,  IdProducto = 1,     Cantidad = 4 },
            new LineaPedido() { Id = 21, IdPedido = 10, IdProducto = 2,     Cantidad = 7 },
            new LineaPedido() { Id = 22, IdPedido = 10, IdProducto = 3,     Cantidad = 2 },
            new LineaPedido() { Id = 23, IdPedido = 10, IdProducto = 11,    Cantidad = 10 },
            new LineaPedido() { Id = 24, IdPedido = 11, IdProducto = 12,    Cantidad = 2 },
            new LineaPedido() { Id = 25, IdPedido = 12, IdProducto = 1,     Cantidad = 20 }
        };

        // Propiedades de los elementos privados
        public static List<Cliente> ListaClientes { get { return _listaClientes; } }
        public static List<Producto> ListaProductos { get { return _listaProductos; } }
        public static List<Pedido> ListaPedidos { get { return _listaPedidos; } }
        public static List<LineaPedido> ListaLineasPedido { get { return _listaLineasPedido; } }
    }
}