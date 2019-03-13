using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.CSharp.ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string nombre = "Javier Palomo Jiménez";
            //Lo que separa cada palabra es un espacio
            var array6 = nombre.Split(' ');

            //Recorremos un Array
            //for
            for(int i = 0; i < array6.Length; i++)
            {
                Console.WriteLine("{0}# {1}", i, array6[i]);
            }


            //foreach
            foreach (string palabra in array6)
            {
                Console.WriteLine("Valor: {0}", palabra);
            }
            Console.ReadKey();

            //

            //ARRAYS
            //Creamos un array de enteros con 10 posiciones de la 0 a la 9
            int[] array = new int[10];

            //otra forma, pero dandole valores iniciales
            int[] array1 = new int[] { 1, 85, 74, 1200, 0, -32, 14 };

            //mas corta, igual y más moderna que el 1
            int[] array2 = { 1, 85, 74, 1200, 0, -32, 14 };
            //podemos ponerle object o dynamic si vamos a tener varios tipos

            //array bidimensional, cada una de las comas es una dimension
            int[,] array3 = new int[10, 5];
            
            //array multidimensional
            int[,,] array4 = new int[10, 5, 1000];

            //Array Jagged es un array que en cada posicion tiene otro array
            int[][] array5 = new int[10][];
            array5[0] = new int[100];
            array5[1] = new int[6];
            array5[2] = new int[120];
            array5[3] = new int[] { 1, 85, 74, 1200, 0, -32 };

            array5[0][99] = 13000;
            array5[1][4] = 3100;

            //Asignamos el valor 32 que se almacena en la posic. 4
            array[4] = 32;

            //Leemos el contenido de la posición 4
            Console.WriteLine(array[4]);


           


            Console.ReadKey();
        }
    }
}
