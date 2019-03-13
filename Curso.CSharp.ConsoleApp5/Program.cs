using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.CSharp.ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Alumno alumno = new Alumno();
            //alumno.FichaCompleta += Alumno_FichaCompleta;
            alumno.FichaCompleta2 += Alumno_FichaCompleta2;

            alumno.FichaCompleta += (sender, e) =>
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("La ficha del Alumno esta completa.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Se complento al rellenar {0}", e);

                Console.WriteLine("Nombre Completo: {0} {1}", ((Alumno)sender).Nombre, ((Alumno)sender).Apellidos);
            };

            alumno.MenorEdad += (sender, e) =>
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("El Alumno es menor de Edad.");
                Console.ForegroundColor = ConsoleColor.White;
            };

            alumno.Modifica += (sender, e) =>
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Cambia {0}  por {1}", e.Anterior, e.Nuevo);
                Console.ForegroundColor = ConsoleColor.White;
            };

            Console.Write("Edad: ");
            alumno.Edad = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nombre: ");
            alumno.Nombre = Console.ReadLine();
            Console.Write("Apellidos: ");
            alumno.Apellidos = Console.ReadLine();

            Console.Write("Nombre: ");
            alumno.Nombre = Console.ReadLine();

            Console.WriteLine("Fin del Programa.");
            Console.ReadKey();
        }

        private static void Alumno_FichaCompleta2(object sender, string nombreCompleto, int edad)
        {
            Console.WriteLine("La ficha de {0} esta completa.", nombreCompleto);
        }

        private static void Alumno_FichaCompleta(object sender, string e)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("La ficha del Alumno esta completa.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Se complento al rellenar {0}", e);

            Console.WriteLine("Nombre Completo: {0} {1}", ((Alumno)sender).Nombre, ((Alumno)sender).Apellidos);
        }
    }

    //Crear Evento - Usuario Menor de Edad
    //Crear Evento - Cuando se modifica un dato
    public class Alumno
    {
        public delegate void EventoPersonalizado(object sender, string nombreCompleto, int edad);

        //Eventos con el delegate genérico
        public event EventHandler<string> FichaCompleta;
        public event EventHandler<Valores> Modifica;
        public event EventHandler<int> MenorEdad;

        //Eventos con delegados personalizados
        public event EventoPersonalizado FichaCompleta2;


        private bool completa = false;
        private string nombre;
        private string apellidos;
        private int edad;

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (completa && nombre != value) Modifica?.Invoke(this, new Valores() { Anterior = nombre, Nuevo = value });

                nombre = value;

                if (nombre != null && apellidos != null && nombre != "" && apellidos != "" && edad != 0)
                {
                    completa = true;
                    FichaCompleta?.Invoke(this, "Nombre");
                    FichaCompleta2?.Invoke(this, nombre + " " + apellidos, edad);
                }
            }
        }

        public string Apellidos
        {
            get { return apellidos; }
            set
            {
                if (completa && apellidos != value) Modifica?.Invoke(this, new Valores() { Anterior = apellidos, Nuevo = value });

                apellidos = value;

                if (nombre != null && apellidos != null && nombre != "" && apellidos != "" && edad != 0)
                {
                    completa = true;
                    if (FichaCompleta != null) FichaCompleta(this, "Apellidos");
                    FichaCompleta2?.Invoke(this, nombre + " " + apellidos, edad);
                }
            }
        }

        public int Edad
        {
            get { return edad; }
            set
            {
                if (completa && edad != value) Modifica?.Invoke(this, new Valores() { Anterior = edad.ToString(), Nuevo = value.ToString() });

                edad = value;

                if (nombre != null && apellidos != null && nombre != "" && apellidos != "" && edad != 0)
                {
                    completa = true;
                    if (FichaCompleta != null) FichaCompleta(this, "Edad");
                    FichaCompleta2?.Invoke(this, nombre + " " + apellidos, edad);
                }

                if (edad > 0 && edad < 18) MenorEdad?.Invoke(this, edad);
            }
        }

    }

    public class Valores
    {
        public string Anterior { get; set; }
        public string Nuevo { get; set; }
    }
}