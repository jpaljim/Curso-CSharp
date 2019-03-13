using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Curso.CSharp.ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {
            Tareas.DemoParalelo2();
            Console.ReadKey();


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Inicio del Programa.");
            Console.ForegroundColor = ConsoleColor.White;
            Tareas.ComenzarAsync();
            Tareas.MasTareas();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Fin del Programa.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
    }

    public static class Tareas
    {
        public static double[] array = new double[50000000];

        public static async Task<bool> ComenzarAsync()
        {
            Task<string> tarea7 = Task.Run<string>(() => {
                Console.WriteLine("Inicio TAREA7");
                Thread.Sleep(10000);
                Console.WriteLine("Fin TAREA7");

                return DateTime.Now.ToShortDateString();
            });

            Console.WriteLine("Fecha: {0}", await tarea7);

            Task tarea4 = Task.Factory.StartNew((o) => { Test2(o.ToString()); }, "Borja");

            Task tarea5 = Task.Run(() => {
                Console.WriteLine("Inicio TAREA5");
                Thread.Sleep(5000);
                Console.WriteLine("Fin TAREA5");
            });

            tarea5.Wait(1500);

            return true;
        }

        public static void MasTareas()
        {
            Task tarea1 = new Task(new Action(Test));

            Task tarea2 = new Task(delegate {
                Console.WriteLine("Inicio TAREA2");
                Thread.Sleep(10000);
                Console.WriteLine("Fin TAREA2");
            });

            Task tarea3 = new Task(() => {
                Console.WriteLine("Inicio TAREA3");
                Console.WriteLine("Fin TAREA3");
            });

            Task[] array = new Task[] { tarea1, tarea2, tarea3 };

            tarea1.Start();
            tarea2.Start();
            tarea3.Start();

            Task.WaitAny(array);

            string nombre = "Lucia";
            Task tarea6 = Task.Run(() => { Test2(nombre); });
        }

        public static void Test()
        {
            Console.WriteLine("Inicio TEST");
            Console.WriteLine("Fin TEST");
        }

        public static void Test2(string nombre)
        {
            Console.WriteLine("Inicio TEST");
            Console.WriteLine("El nombre es " + nombre);
            Console.WriteLine("Fin TEST");
        }

        public static void DemoParalelo()
        {
            DateTime fecha1 = DateTime.Now;

            for (var i = 0; i < 50000000; i++)
            {
                array[i] = Math.Sqrt(i);
            }

            DateTime fecha2 = DateTime.Now;

            Parallel.For(0, 50000000, i => {
                array[i] = Math.Sqrt(i);
            });

            DateTime fecha3 = DateTime.Now;

            Console.WriteLine("Tiempo del FOR {0} ms.", fecha2.Subtract(fecha1).Milliseconds);
            Console.WriteLine("Tiempo del Parallel.FOR {0} ms.", fecha3.Subtract(fecha2).Milliseconds);
        }

        public static void DemoParalelo2()
        {
            var datos = Enumerable.Range(0, 2000000);

            DateTime fecha1 = DateTime.Now;
            var sw = Stopwatch.StartNew();

            var lista = from d in datos
                        where d % 10 == 0
                        select d;

            decimal suma = 0;
            foreach (var numero in lista)
            {
                suma = HacerAlgo(numero, suma);
            }
            Console.WriteLine("Tarea 1: {0}", sw.Elapsed.TotalMilliseconds);


            DateTime fecha2 = DateTime.Now;
            sw = Stopwatch.StartNew();

            var lista2 = from d in datos.AsParallel()
                         where d % 10 == 0
                         select d;

            decimal suma2 = 0;
            Parallel.For(0, lista.Count() - 1, numero => {
                suma2 = HacerAlgo(numero, suma2);
            });
            Console.WriteLine("Tarea 2: {0}", sw.Elapsed.TotalMilliseconds);


            DateTime fecha3 = DateTime.Now;
            sw = Stopwatch.StartNew();

            var lista3 = from d in datos.AsParallel()
                         where d % 10 == 0
                         select d;

            decimal suma3 = 0;
            Parallel.ForEach(lista3, (num) => { suma3 += num; });
            Console.WriteLine("Tarea 3: {0}", sw.Elapsed.TotalMilliseconds);


            DateTime fecha4 = DateTime.Now;

            Console.WriteLine("Suma 1: {0}", suma);
            Console.WriteLine("Suma 2: {0}", suma2);
            Console.WriteLine("Suma 3: {0}", suma3);

            Console.WriteLine("Tiempo del FOR {0} ms.", fecha2.Subtract(fecha1).Milliseconds);
            Console.WriteLine("Tiempo del Parallel.FOR {0} ms.", fecha3.Subtract(fecha2).Milliseconds);
            Console.WriteLine("Tiempo del Parallel.FOREACH {0} ms.", fecha4.Subtract(fecha3).Milliseconds);
        }

        public static decimal HacerAlgo(int numero, decimal suma)
        {
            return ((decimal)numero + suma);
        }
    }

    public class Alumno
    { }
}