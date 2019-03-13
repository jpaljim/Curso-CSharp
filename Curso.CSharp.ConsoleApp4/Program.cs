using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.CSharp.ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            int b = 0;

            try
            {
                Calcula(100, 0);
                int c = a / b;
                Console.WriteLine("Valor de C: {0}", c);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Valor de A: {0}", a);
                Console.WriteLine("Valor de B: {0}", b);
                Console.WriteLine("Error, no se puede dividir por cero.");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Finaliza el Main");
            Console.ReadKey();
        }

        static void Calcula(int a, int b)
        {
            try
            {
                int c = a / b;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Calcula: {0}", ex.Message);
                //Lo manda al try de arriba porque la llamada a calcula esta en 
                //el try catch de arriba
                //Entra por el Exception y no por el DivideByZeroException
                throw (new DivideByZeroException("Error al dividir por Cero en el método Calcula()"));
            }
            finally
            {
                Console.WriteLine("Finaliza el método Calcula()");
            }
        }
    }
}
