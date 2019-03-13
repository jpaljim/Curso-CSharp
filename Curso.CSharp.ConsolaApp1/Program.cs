using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.CSharp.ConsolaApp1
{
    public delegate void Notificacion(string mensaje);

    //Empiezan en 0
    public enum TipoAlumno : int
    {
        Prescolar = 100, Primarios, FP,
        Universidad
    };

    class Program
    {
        

        static void Main(string[] args)
        {
            Tools.Operadores();

            Notificacion notificacion = MetodoPrueba;
            notificacion("Prueba de Delegados");


            
            Notificacion notificacion2 = delegate (string m)
            {
                Console.WriteLine("Notificación: {0}", m);
            };

            /*funcion anónima(sin nombre), el parametro qeu se le pasa a la funcion anonima se llama mensaje
             * lo que hace es escribir el mensaje que se le indique cuando se le llame debajo*/
            Notificacion notificacion3 = mensaje =>
            {
                Console.WriteLine("Info: {0}", mensaje);
            };

            notificacion3("Prueba de delegados");


            Console.ReadKey();

            //========================================================

            //C# 7
            Alumno alumno = new Alumno() {
                Nombre = "Javier",
                Apellidos = "Palomo Jiménez",
                Edad = 22,
                Tipo = TipoAlumno.Primarios
            };

            //C# 5
            Alumno alumno2 = new Alumno();
            alumno2.Nombre = "Borja";
            alumno2.Apellidos = "Cabeza";
            alumno2.Edad = 45;

            //El compilador analiza el tipo de dato y le pone
            //el adecuado en este caso de tipo Alumno
            var alumno3 = new Alumno()
            {
                Nombre = "Javier",
                Apellidos = "Palomo Jiménez",
                Edad = 22
            };
            object alumno4 = new Alumno()
            {
                Nombre = "Javier",
                Apellidos = "Palomo Jiménez",
                Edad = 22
            };
            dynamic alumno5 = new Alumno()
            {
                Nombre = "Javier",
                Apellidos = "Palomo Jiménez",
                Edad = 22
            };

            //Como el alumno 4 es object hay que convertirlo a tipo Alumno
            //Porque no se puede acceder a las propiedades de los object
            Console.WriteLine("Nombre:{0}", ((Alumno)alumno4).Nombre);
            Console.WriteLine("Apellidos:{0}", ((Alumno)alumno4).Apellidos);
            Console.WriteLine("Edad:{0}", ((Alumno)alumno4).Edad);

            Console.WriteLine("Nombre:{0}", alumno.Nombre);
            Console.WriteLine("Apellidos:{0}", alumno.Apellidos);
            Console.WriteLine("Edad:{0}", alumno.Edad);
            Console.WriteLine("Tipo:{0}", alumno.Tipo);
            Console.WriteLine("Tipo:{0}", (int)alumno.Tipo);

            //No se comprueban si las propiedades existen hasta que se ejectuan
            //Console.WriteLine("Nombre:{0}", alumno5.FirstNombre);
            //Console.WriteLine("Apellidos:{0}", alumno5.SegundosApellidos);
            //Console.WriteLine("Edad:{0}", alumno5.FechaDeNac);


            Console.ReadKey();

            
        }
        public static void MetodoPrueba(string m)
        {
            Console.Clear();
            Console.WriteLine("Mensaje: {0}", m);
        }


        public static class Tools
        {
            public static void Operadores()
            {
                int a = 10;
                int b = 30;

                b /= a;


                Console.Clear();
                Console.WriteLine("Resultado: {0}",a);
                Console.WriteLine("Resultado: {0}",++a);
                Console.WriteLine("Resultado: {0}", a);
                Console.ReadKey();
            }
        }
 
    }


    public class Alumno
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public TipoAlumno Tipo { get; set; }

        /*ejecuta acciones pero no devuelve nada porque devuelve void*/
        public void Imprimir() 
        {
            
        }
    }

    
}

