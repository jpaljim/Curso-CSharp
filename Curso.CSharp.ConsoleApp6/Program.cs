using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.CSharp.ConsoleApp6
{
    public enum FuenteDatos { DB, Internet }

    class Program
    {
        static FuenteDatos fuentedatos = FuenteDatos.Internet;

        static void Main(string[] args)
        {
            Prueba prueba = new Prueba();
            prueba.Numero = 100;

            IA interfaceA = prueba;
            interfaceA.Numero = 200;

            IB interfaceB = prueba;
            interfaceB.Numero = 300;

            Console.WriteLine(prueba.Numero);
            Console.WriteLine(interfaceA.Numero);
            Console.WriteLine(interfaceB.Numero);

            Console.ReadKey();

            Demo demo = new Demo { Numero = 100, Nombre = "Borja" };
            demo.PintaNumero();

            IDemo demo2 = new Demo { Numero = 100, Nombre = "Borja" };
            demo2.PintaNumero();

            Console.ReadKey();

            //==============================================================

            IAlumno a = new AlumnoAPIRest();

            AlumnoDB alumnoDB;
            AlumnoAPIRest alumnoApi;

            Console.WriteLine("Tipo: {0}", a.GetType().ToString());
            Console.WriteLine("Tipo: {0}", typeof(AlumnoAPIRest).ToString());
            if (a.GetType() == typeof(AlumnoAPIRest))
            {
                alumnoApi = (AlumnoAPIRest)a;
            }
            else if (a.GetType() == typeof(AlumnoDB))
            {
                alumnoDB = (AlumnoDB)a;
            }

            Console.WriteLine("Fin Demo");
            Console.ReadKey();

            //Aplicación Poliformica utilizando Factorias
            //==============================================================
            IAlumno alumno1 = CrearObjetoAlumno(fuentedatos);

            alumno1.CargarDatos();
            Console.WriteLine("Nombre: {0}", alumno1.Nombre);
            Console.WriteLine("Apellidos: {0}", alumno1.Apellidos);
            Console.WriteLine("Edad: {0}", alumno1.Edad);

            Console.ReadKey();

            //Aplicación Uniformica
            //==============================================================
            AlumnoDB alumno = new AlumnoDB();

            alumno.CargarDatos();
            Console.WriteLine("Nombre: {0}", alumno.Nombre);
            Console.WriteLine("Apellidos: {0}", alumno.Apellidos);
            Console.WriteLine("Edad: {0}", alumno.Edad);

            //Podemos usar miembros no comunes
            Console.WriteLine("Conectado: {0}", alumno.Conectado);

            Console.ReadKey();
        }

        static IAlumno CrearObjetoAlumno(FuenteDatos fuente)
        {
            switch (fuente)
            {
                case FuenteDatos.DB:
                    return new AlumnoDB();
                case FuenteDatos.Internet:
                    return new AlumnoAPIRest();
                default:
                    return new AlumnoDB();
            }
        }
    }

    public interface IAlumno
    {
        string Nombre { get; set; }
        string Apellidos { get; set; }
        int Edad { get; set; }

        void CargarDatos();
        void LimpiarDatos();
    }
    public class AlumnoDB : IAlumno
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public bool Conectado { get; set; }

        public void ConectarDB()
        {
            Conectado = true;
        }
        public void DesconectarDB()
        {
            Conectado = false;
        }
        public void CargarDatos()
        {
            //Simulamos la conexión a una base de datos y cargamos los mismo.
            ConectarDB();

            Nombre = "Borja";
            Apellidos = "Cabeza";
            Edad = 45;
        }
        public void LimpiarDatos()
        {
            Nombre = "";
            Apellidos = "";
            Edad = 0;

            //Simulamos la desconexión de la base de datos.
            DesconectarDB();
        }
    }
    public class AlumnoAPIRest : IAlumno
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public string EndPoint { get; set; }
        public string APIKey { get; set; }

        public void CargarDatos()
        {
            Nombre = "Ana";
            Apellidos = "Cabeza";
            Edad = 45;
        }
        public void LimpiarDatos()
        {
            Nombre = "";
            Apellidos = "";
            Edad = 0;
        }
    }

    public interface IDemo
    {
        int Numero { get; set; }
        void PintaNumero();
    }

    public class Demo : IDemo
    {
        public string Nombre { get; set; }
        public int Numero { get; set; }
        public void PintaNumero()
        {
            Console.WriteLine("El número introducido por {0} es {1}.", Nombre, Numero);
        }
        void IDemo.PintaNumero()
        {
            Console.WriteLine("El número es {0}.", Numero);
        }
    }


    public interface IA
    {
        int Numero { get; set; }
    }

    public interface IB
    {
        int Numero { get; set; }
    }

    public class Prueba : IA, IB
    {
        int IA.Numero { get; set; }

        int IB.Numero { get; set; }

        public int Numero { get; set; }
    }
}