using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.CSharp.ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            Alumno alumno= new Alumno();
            alumno.Edad = 45;
            alumno.NombreCompleto = "Francisco de Borja Cabeza Rozas";

            

            Console.WriteLine("Nombre: {0}", alumno.Nombre);
            Console.WriteLine("Apellidos: {0}", alumno.Apellidos);
            Console.WriteLine("Edad: {0}", alumno.Edad);
            Console.ReadKey();

            //====================================================

            //Parametros por valor o referencia
            int num1 = 10;
            int num2 = 10;

            Console.WriteLine("Num1: {0} - Num2: {1}", num1, num2);
            ProcesaNumero(num1, ref num2);
            Console.WriteLine("Num1: {0} - Num2: {1}", num1, num2);
            Console.ReadKey();


            //===========================
            byte retorno = 0;
            
            Console.WriteLine("Resultado: {0} - Valor: {1}", Conversor(80, out retorno),retorno);
            Console.ReadKey();

            //string valor = "Hola"; el TryParse me va a devolver false
            string valor = "1459";
            int numero = 0;
            bool resultado;

            resultado = Int32.TryParse(valor, out numero);

            Console.WriteLine("Resultado: {0} - Valor: {1}", resultado, numero);
            Console.ReadKey();

            //=======================================


            int a = 0;//maximo 255
            long b = 325;


            //Conversión explícita
            //Para las explicitas tambien tenemos el metodo convert
            a = Convert.ToInt32(b);
            Console.WriteLine("Valor de a: {0}", a);


            a = (int)b;//sale 45 porque coge los primeros 8 bits
                         //que es lo que cabe en un sbyte
            
            Console.WriteLine("Valor de a: {0}", a);

            //Conversión implícita porque el int cabe en el long
            b = a;
            Console.WriteLine("Valor de b: {0}", b);

            Console.ReadKey();


        }
        //=========================================================
        //parametros de ref
        static void ProcesaNumero(int a, ref int b)
        {
            //ambos son modificados pero como el a no es de referencia
            //No cambia cuando se le llama fuera(en el main)
            a = 30;
            b = 30;
        }



        //==========================================================

        //Decimal
        static bool Conversor(decimal n, out byte r)
        {
            try
            {
                r = Convert.ToByte(n);
                return true;
            }
            catch (Exception)
            {
                r = 0;
                return false;
            }
            
        }

        //int
        static bool Conversor(int n, out byte r)
        {
            return byte.TryParse(n.ToString(), out r);
        }

        //double
        static bool Conversor(double n, out byte r)
        {
            return byte.TryParse(n.ToString(), out r);
        }
    }

    
    //=========================================================

    //PROPIEDADES
    public class Alumno
    {
        private int edad;
        private string apellidos;
        private string nombre;

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                if (value.Length < 3) nombre = "No válido";
                else nombre = value;
            }
        }

        public string Apellidos
        {
            //Forma corta es igual que el get del de nombre pero mas corto
            get => nombre;

            set
            {
                if (value.Length > 15) apellidos = "No válido";
                else apellidos = value;
            }
        }


        public int Edad
        {
            get
            {
                return edad;
            }
            set
            {
                if (value < 0 || value > 120) edad = 0;
                else edad = value;
            }
        }

        public string NombreCompleto
        {
            get
            {
                return nombre + " " + apellidos;
            }

            set
            {
                var datos = value.Split(' ');

                if(datos.Length >= 3)
                {
                    apellidos = datos[datos.Length - 2] + " " + datos[datos.Length - 1];

                    nombre = "";
                    for (var i = 0; i < datos.Length -2; i++)
                    {
                        nombre += nombre.Length == 0 ? datos[i] : " " + datos[i];
                    }
                }
            }
        }

        //==============================================================

        //Constructor
        public Alumno ()
        {
            Inicializa("", "");
        }

 

        //Sobrecarga de métodos
        public Alumno(string Nombre, string Apellidos)
        {
            Inicializa(Nombre, Apellidos);
        }

        
        public Alumno(string Nombre, string Apellidos, int Edad)
        {
            Inicializa(Nombre, Apellidos, Edad);
        }

        //Cuando hay sobrecarga de métodos invocamos a este metodo privado
        //De manera que no hay que ir modificando los 3, solo este.
        //Tenemos el parámetro opcional p que si no se lo damos sería -1
        private void Inicializa(string v1, string v2, int p = -1)
        {
            Nombre = v1;
            Apellidos = v2;
            Edad = p;
        }


        //===============================================================
        //Destructor
        ~Alumno()
        {
            Nombre = null;
            Apellidos = null;
            edad = 0;
        }

    }


}
