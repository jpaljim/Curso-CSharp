using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.CSharp.ConsoleAppEjercicios
{
    class Program
    {
        static void Main(string[] args)
        {
            //Objetos.Ejercicio1();
            //Herencia.Ejercicio1();
            Herencia.Ejercicio2();
            Console.ReadKey();
        }
    }

    public static class Arrays
    {
        //Calculo de la letra NIF o NIE
        public static void Ejercicio1()
        {
            string[] letras = new string[] { "T", "R", "W", "A", "G", "M", "Y", "F", "P", "D", "X", "B", "N", "J", "Z", "S", "Q", "V", "H", "L", "C", "K", "E", "T" };

            Console.Write("Número DNI: ");
            string dni = Console.ReadLine();
            int numero;

            if (dni.Length <= 8)
            {
                if (dni.Length < 8) dni = dni.PadLeft(8, '0');

                switch (dni[0].ToString().ToUpper())
                {
                    case "X":
                        dni = dni.Substring(1, 7);
                        Console.WriteLine(int.TryParse(dni, out numero)
                            ? "El NIE es X" + numero.ToString() + letras[numero % 23]
                            : "Error al procesar el NIE");
                        break;
                    case "Y":
                        dni = dni.Substring(1, 7);
                        Console.WriteLine(int.TryParse(dni, out numero)
                            ? "El NIE es Y" + numero.ToString() + letras[(10000000 + numero) % 23]
                            : "Error al procesar el NIE");
                        break;
                    case "Z":
                        dni = dni.Substring(1, 7);
                        Console.WriteLine(int.TryParse(dni, out numero)
                            ? "El NIE es Z" + numero.ToString() + letras[(20000000 + numero) % 23]
                            : "Error al procesar el NIE");
                        break;
                    default:
                        Console.WriteLine(int.TryParse(dni, out numero)
                            ? "El NIF es " + numero.ToString() + letras[numero % 23]
                            : "Error al procesar el NIF");
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Error: El DNI tiene más de 8 caracteres.");
            }
        }

        //Rellenamos un array con 100 números aleatorios
        //Retorna Suma Total, Media, Suma Pares, Suma Impares, Min y Max
        public static void Ejercicio2()
        {
            int[] array = new int[100];
            Random rnd = new Random();
            long pares = 0;
            long impares = 0;

            for (var i = 0; i < 100; i++)
            {
                int numero = rnd.Next(100);

                if (numero % 2 == 0) pares += (long)numero;
                else impares += numero;

                array[i] = numero;
            }

            Console.Clear();
            Console.WriteLine("Suma Total:".PadRight(20, ' ') + array.Sum().ToString("N0").PadLeft(10, ' '));
            Console.WriteLine("Media:".PadRight(20, ' ') + array.Average().ToString("N0").PadLeft(10, ' '));
            Console.WriteLine("Suma Pares:".PadRight(20, ' ') + pares.ToString("N0").PadLeft(10, ' '));
            Console.WriteLine("Suma Impares:".PadRight(20, ' ') + impares.ToString("N0").PadLeft(10, ' '));
            Console.WriteLine("Min:".PadRight(20, ' ') + array.Min().ToString("N0").PadLeft(10, ' '));
            Console.WriteLine("Max:".PadRight(20, ' ') + array.Max().ToString("N0").PadLeft(10, ' '));
        }

        //Repite el ejercicio anterior con un Do-While
        public static void Ejercicio3()
        {
            int[] array = new int[100];
            Random rnd = new Random();
            long pares = 0;
            long impares = 0;
            int contador = 0;

            do
            {
                int numero = rnd.Next(100);

                if (numero % 2 == 0) pares += (long)numero;
                else impares += numero;

                array[contador] = numero;

                contador++;
            } while (contador < 100);

            Console.Clear();
            Console.WriteLine("Suma Total:".PadRight(20, ' ') + array.Sum().ToString("N0").PadLeft(10, ' '));
            Console.WriteLine("Media:".PadRight(20, ' ') + array.Average().ToString("N0").PadLeft(10, ' '));
            Console.WriteLine("Suma Pares:".PadRight(20, ' ') + pares.ToString("N0").PadLeft(10, ' '));
            Console.WriteLine("Suma Impares:".PadRight(20, ' ') + impares.ToString("N0").PadLeft(10, ' '));
            Console.WriteLine("Min:".PadRight(20, ' ') + array.Min().ToString("N0").PadLeft(10, ' '));
            Console.WriteLine("Max:".PadRight(20, ' ') + array.Max().ToString("N0").PadLeft(10, ' '));






        }
    }
    public static class Repeticion
    {
        //Pinta los número paras del 50 al 150
        public static void Ejercicio1()
        {
            for (var i = 50; i < 151; i += 2)
            {
                Console.WriteLine("{0}", i);
            }
        }

        //Pinta los número impares del 1000 al 500
        public static void Ejercicio2()
        {
            for (var i = 999; i > 499; i -= 2)
            {
                Console.WriteLine("{0}", i);
            }
        }

        //Pinta números del 0 al 100 de 5 en 5
        public static void Ejercicio3()
        {
            for (var i = 0; i <= 100; i += 5)
            {
                Console.WriteLine("{0}", i);
            }
        }

        //Pinta números del 100 al 0 de 10 en 10
        public static void Ejercicio4()
        {
            for (var i = 100; i >= 0; i -= 10)
            {
                Console.WriteLine("{0}", i);
            }
        }
    }

    public static class Interfaces
    {
        //Creamos la Interfaz IVehiculo 
        //Dos o tres propiedades (velocidad, color, marca) y el método PintarDatos()

        //Creamos las clases Coche (ruedas), Barco (cubiertas) y Avión(motores) implementando IVehiculo 
        //con una propiedad expecifica para cada clases.

        //Implementa PintarDatos utilizando propiedades comunes y expecificas.

        //Implementa el método para la IVehiculo en cada uno de los objetos.
        public static void Ejercicio1()
        {
            IVehiculo vehiculo = new Coche() { Velocidad = "240km/h", Color = "Azul", Marca = "Audi", Ruedas = 4 };
            IVehiculo vehiculo1 = new Barco() { Velocidad = "240km/h", Color = "Azul", Marca = "Audi", Cubiertas = 2 };
            IVehiculo vehiculo2 = new Avion() { Velocidad = "240km/h", Color = "Azul", Marca = "Audi", Motores = 2 };

            Coche coche = new Coche() { Velocidad = "240km/h", Color = "Azul", Marca = "Audi", Ruedas = 4 };
            Barco barco = new Barco() { Velocidad = "240km/h", Color = "Azul", Marca = "Audi", Cubiertas = 2 };
            Avion avion = new Avion() { Velocidad = "240km/h", Color = "Azul", Marca = "Audi", Motores = 2 };

            vehiculo.PintarDatos();
            vehiculo1.PintarDatos();
            vehiculo2.PintarDatos();

            coche.PintarDatos();
            barco.PintarDatos();
            avion.PintarDatos();
        }
    }
    public interface IVehiculo
    {
        string Velocidad { get; set; }
        string Color { get; set; }
        string Marca { get; set; }
        void PintarDatos();
    }
    public class Coche : IVehiculo
    {
        public string Velocidad { get; set; }
        public string Color { get; set; }
        public string Marca { get; set; }
        public int Ruedas { get; set; }

        public void PintarDatos()
        {
            Console.WriteLine("FICHA DEL COCHE");
            Console.WriteLine("===================================================");
            Console.WriteLine("Velocidad: {0}", Velocidad);
            Console.WriteLine("Color: {0}", Color);
            Console.WriteLine("Marca: {0}", Marca);
            Console.WriteLine("Ruedas: {0}", Ruedas);
        }

        void IVehiculo.PintarDatos()
        {
            Console.WriteLine("FICHA DEL VEHICULO (COCHE)");
            Console.WriteLine("===================================================");
            Console.WriteLine("Velocidad: {0}", Velocidad);
            Console.WriteLine("Color: {0}", Color);
            Console.WriteLine("Marca: {0}", Marca);
            Console.WriteLine("Ruedas: {0}", Ruedas);
        }
    }
    public class Barco : IVehiculo
    {
        public string Velocidad { get; set; }
        public string Color { get; set; }
        public string Marca { get; set; }
        public int Cubiertas { get; set; }

        public void PintarDatos()
        {
            Console.WriteLine("FICHA DEL BARCO");
            Console.WriteLine("===================================================");
            Console.WriteLine("Velocidad: {0}", Velocidad);
            Console.WriteLine("Color: {0}", Color);
            Console.WriteLine("Marca: {0}", Marca);
            Console.WriteLine("Cubiertas: {0}", Cubiertas);
        }

        void IVehiculo.PintarDatos()
        {
            Console.WriteLine("FICHA DEL VEHICULO (BARCO)");
            Console.WriteLine("===================================================");
            Console.WriteLine("Velocidad: {0}", Velocidad);
            Console.WriteLine("Color: {0}", Color);
            Console.WriteLine("Marca: {0}", Marca);
            Console.WriteLine("Cubiertas: {0}", Cubiertas);
        }
    }
    public class Avion : IVehiculo
    {
        public string Velocidad { get; set; }
        public string Color { get; set; }
        public string Marca { get; set; }
        public int Motores { get; set; }

        public void PintarDatos()
        {
            Console.WriteLine("FICHA DEL AVIÓN");
            Console.WriteLine("===================================================");
            Console.WriteLine("Velocidad: {0}", Velocidad);
            Console.WriteLine("Color: {0}", Color);
            Console.WriteLine("Marca: {0}", Marca);
            Console.WriteLine("Motores: {0}", Motores);
        }

        void IVehiculo.PintarDatos()
        {
            Console.WriteLine("FICHA DEL VEHICULO (AVIÓN)");
            Console.WriteLine("===================================================");
            Console.WriteLine("Velocidad: {0}", Velocidad);
            Console.WriteLine("Color: {0}", Color);
            Console.WriteLine("Marca: {0}", Marca);
            Console.WriteLine("Motores: {0}", Motores);
        }
    }


    public static class Herencia
    {
        //Creamos un nuevo Objeto que hereda de ArrayList
        //Sobreescribimos y sellamo ToString() para que retorne en número de elementos
        //Sobreescribimos el método Add() para añadir siempre en la posición 0
        //La intención es cambiar el funcionamiento de estos dos métodos que vienen predefinidos
        public static void Ejercicio1()
        {
            MiArrayList array = new MiArrayList();

            array.Add("uno");
            array.Add("dos");
            array.Add("tres");
            array.Add("cuatro");
            array.Add("cinco");

            foreach (var item in array)
            {
                Console.WriteLine(">> {0}", item);
            }

            Console.WriteLine(array.ToString());
        }


        //Formas
        public static void Ejercicio2()
        {
            TrabajarFormas trabajar = new TrabajarFormas();
            trabajar.CalcularArea(new Cuadrado() { Lado = 20 });
            trabajar.CalcularArea(new Rectangulo() { Base = 20, Altura = 40 });
            trabajar.CalcularArea(new Triangulo() { Base = 28.52M, Altura = 32.15M });
            trabajar.CalcularArea(new Circulo() { Radio = 72 });
        }
    }

    //================================================
    public class MiArrayList : ArrayList
    {
        public override int Add(object value)
        {
            base.Add("");
            for (var i = this.Count - 1; i > 0; i--)
            {
                this[i] = (string)this[i - 1];
            }
            this[0] = value;

            return 0;
        }

        public sealed override string ToString()
        {
            return "Numero de elementos " + this.Count.ToString() + ".";
        }
    }


    //=============================================

    public class TrabajarFormas
    {
        public void CalcularArea<T>(T obj)
        {
            string forma = obj.GetType().Name;
          

            try
            {   //Tambien se puede preguntar if(forma == "Cuadrado" || forma == "Rectangulo"...)
                if(obj is Forma)//Pregunto si se puede transformar en tipo Forma
                {
                    //con el as lo transformo
                    Forma objeto = obj as Forma;
                    objeto.CalcularArea();
                    //El N2 es para cifras decimales
                    Console.WriteLine("El Área del {0} es {1} metros.", forma, objeto.Area.ToString("N2"));
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Forma no válida, introduce un Cuadrado, Rentángulo, Triángulo o Círculo");
            }

            
        }
    }

    public abstract class Forma
    {
        public decimal Area { get; set; }

        public abstract void CalcularArea();
        
    }

    //Cuadrado -> Lado (decimal) //Lado x Lado
    //Rectángulo -> Base y Altura (decimal) // Base x Altura
    //Triángulo -> Base y Altura (decimal) //(Base x altura) / 2
    //Círculo -> Radio (decimal) //PI x r2

    public class Cuadrado : Forma
    {
        public decimal Lado { get; set; }
        public override void CalcularArea()
        {
             Area = Lado * Lado;
        }
    }

    public class Rectangulo : Forma
    {
        public decimal Base { get; set; }
        public decimal Altura { get; set; }

        public override void CalcularArea()
        {
            Area = Base * Altura;
        }
    }

    public class Triangulo : Forma
    {
        public decimal Base { get; set; }
        public decimal Altura { get; set; }

        public override void CalcularArea()
        {
            Area = (Base * Altura) / 2;
        }
    }

    public class Circulo : Forma
    {
        public decimal Radio { get; set; }

        public override void CalcularArea()
        {
            Area = (decimal)Math.PI * Radio * Radio;
        }
    }


    public static class Objetos
    {
        public static void Ejercicio1()
        {
            Info info = new Info();
            //info.Procesar<int>(40);
            //info.Procesar<decimal>(400.5451538347M);
            //info.Procesar<string>("458151.12145");
            //info.Procesar<string>("hola");
            //info.Procesar<string>("Cantidad1458252");
            //info.Procesar<string>("145; 82; 52; 1458; 145.652");
            //info.Procesar<List<string>>(new List<string>() { "hola", "32", "1452" });
            //info.Procesar<List<int>>(new List<int>() { 30, 7841, 0, 51, 32, 5411 });

            Console.WriteLine("Suma {0}", info.Valor);
            Console.WriteLine("Entero {0}", info.Entero);
            Console.WriteLine("Decimal {0}", info.Decimal);
            Console.WriteLine("Max {0}", info.Max);
            Console.WriteLine("Min {0}", info.Min);
            Console.WriteLine("Media {0}", info.Media);
            Console.WriteLine("Elementos {0}", info.ElementosProcesados);
        }
    }


    public static class ExtesionMetodos
    {
        public static decimal ParteEntera(this decimal valor)
        {
            return Math.Truncate(valor);
        }
        public static decimal ParteDecimal(this decimal valor)
        {
            return (valor - Math.Truncate(valor));
        }
        public static decimal ConvertDecimal(this string contenido)
        {
            decimal valor = 0;
            string numeros = "";

            foreach (var chr in contenido.ToCharArray())
            {
                if ("0123456789".Contains(chr.ToString())) numeros += chr.ToString();
            }

            if (decimal.TryParse(numeros, out valor)) return valor;
            else return 0;
        }
    }

    public class Info
    {
        //Equivalente a la suma de todos los elementos
        public decimal Valor { get; set; }

        public decimal Entero { get; set; }
        public decimal Decimal { get; set; }

        public decimal Min { get; set; }
        public decimal Max { get; set; }
        public decimal Media { get; set; }
        public int ElementosProcesados { get; set; }

        public bool Procesar<T>(T obj)
        {
            if (obj.GetType().Namespace == "System.Collections"
                || obj.GetType().Namespace == "System.Collections.Generic")
            {
                IEnumerable array = obj as IEnumerable;

                if (array != null)
                {
                    List<decimal> lista = new List<decimal>();

                    foreach (var item in array)
                    {
                        lista.Add(item.ToString().ConvertDecimal());
                    }

                    this.Valor = lista.Sum();
                    this.Entero = lista.Sum().ParteEntera();
                    this.Decimal = lista.Sum().ParteDecimal();
                    this.Max = lista.Max();
                    this.Min = lista.Min();
                    this.Media = lista.Average();
                    this.ElementosProcesados = lista.Count();
                }
                else
                {
                    Console.WriteLine("No se puede procesar");
                }
            }
            else
            {
                try
                {
                    decimal n1 = obj.ToString().ConvertDecimal();

                    this.Valor = n1;
                    this.Entero = n1.ParteEntera();
                    this.Decimal = n1.ParteDecimal();
                    this.Max = n1;
                    this.Min = n1;
                    this.Media = n1;
                    this.ElementosProcesados = 1;
                }
                catch (Exception)
                {
                }
            }

            return true;
        }
    }

}