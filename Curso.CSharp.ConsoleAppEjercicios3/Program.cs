using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.CSharp.ConsoleAppEjercicios3
{
    class Program
    {
        static void Main(string[] args)
        {
            Tareas tareas = new Tareas();

            tareas.FinCalcular += (sender, e) =>
            {
                Console.WriteLine("Suma 1: {0}", e);
            };

            tareas.FinCalcular2 += (sender, e) =>
            {
                Console.WriteLine("Suma 2: {0}", e);
            };

            tareas.FinCalcular3 += (sender, e) =>
            {
                Console.WriteLine("Suma 3: {0}", e);
            };

            tareas.IniciarAsync();

            
            Console.ReadKey();
        }
    }


    public class Tareas
    {
        public event EventHandler<decimal> FinCalcular;
        public event EventHandler<decimal> FinCalcular2;
        public event EventHandler<decimal> FinCalcular3;


        public async Task IniciarAsync()
        {
            await PedidosTotal();

            Parallel.Invoke(
            () => { CalcularAsync(); },
            () => { Calcular2Async(); },
            () => { Calcular3Parallel(); });
        }

        public async Task<decimal> CalcularAsync()
        {
            
            return await Task.Run(() =>
            {
                var lista = Enumerable.Range(0, 200000);
                decimal suma = 0;
                foreach(var item in lista)
                {
                    suma += item;
                }
                

                FinCalcular?.Invoke(this, suma);

                return suma;
            });
        }

        //IGUAL QUE EL ANTERIOR
        public  async Task<decimal> Calcular2Async()
        {

            Task<decimal> tarea1 = Task.Run(() =>
            {
                var lista = Enumerable.Range(1000, 3000);
                decimal suma = 0;
                foreach (var item in lista)
                {
                    suma += item;
                }
               

                FinCalcular2?.Invoke(this, suma);
                return suma;

            });
            
            return await tarea1;
        }

        public async Task<decimal> Calcular3Parallel()
        {

            return await Task.Run(() =>
            {
                var lista = Enumerable.Range(0, 200000);
                decimal suma = 0;
                var paralelo = from d in lista.AsParallel()
                               where d % 2 == 0
                               select d;


                Parallel.ForEach(lista, (num) => { suma += num; });
                                
                FinCalcular3?.Invoke(this, suma);

                return suma;
            });
        }

        public async Task<Dictionary<int, decimal>> PedidosTotal()
        {

            return await Task.Run(() => {
                //Diccionario con IdPedido y Coste Total del pedido
                //Esta en order details
                Models.ModelNorthwind db = new Models.ModelNorthwind();
                Dictionary<int, decimal> datos = new Dictionary<int, decimal>();


                var query = db.Order_Details.AsParallel()
                    .GroupBy(g => g.OrderID)
                    .Select(r => new
                    {
                        IdPedido = r.Key,
                        Total = r.AsParallel().Sum(x => x.Quantity * x.UnitPrice)
                    }) 
                    //.ToDictionary(f => f.IdPedido, f => f.Total); al hacer esto no tenemos que recorrer
                    //debajo la lista con el foreach para meterlo dentro del diccionario, asi lo mete directamente
                    .ToList();

                foreach (var item in query)
                {
                    datos.Add(item.IdPedido, item.Total);
                }

                foreach (var pedido in datos)
                {
                    Console.WriteLine("Pedido numero {0} - Total: {1}", pedido.Key, pedido.Value.ToString("N2"));
                }

                return datos;

            });
            
        }

    }
    
}
