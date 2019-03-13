using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.CSharp.ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            //No genéricos
            ArrayList array = new ArrayList();

            //array.Add("Javier");
            //array.Add("borja");
            //array.Add("alberto");
            //array.Add("Nacho");
            //array.Add("MARÍA");
            //array.Add("Inés");

            //array.Add(100);
            //array.Add(30);
            //array.Add(185);
            //array.Add(2010);
            //array.Add(500);
            //array.Add(3);

            array.Add(new Alumno() { Nombre = "Javier", Edad = 22});
            array.Add(new Alumno() { Nombre = "María", Edad = 20 });
            array.Add(new Alumno() { Nombre = "María", Edad = 22 });
            array.Add(new Alumno() { Nombre = "Inés", Edad =  21});
            array.Add(new Alumno() { Nombre = "Alberto", Edad = 24 });
            array.Add(new Alumno() { Nombre = "Borja", Edad =  37});
        
            


            array.Sort(new OrdenarAlumno());

            foreach(var item in array)
            {
                //Hay que parsearlos a tipos Alumno porque son object y no podemos mostrar las propiedades de los object
                Console.WriteLine("{0} - {1}", ((Alumno)item).Nombre, ((Alumno)item).Edad);
            }

            Console.ReadKey();

            //Puedo añadir en cualquier posición cualquier tipo de elemento, no está tipada, son object
            array.Add(34);
            array.Add(new Alumno() { Nombre = "Javier", Edad = 22 });
            
            //Añade cada uno de los elementos de una colección en una posicion distinta
            array.AddRange(new int[] { 34, 124, 85, 31 });
            
            //Vacia toda la colección
            //array.Clear();

            //Elimina ese dato en específico
            //array.Remove(34);
            
            //Elimina lo que haya en la posición 1
            //array.RemoveAt(1);

            //======================================================
            Hashtable dictonary = new Hashtable();
            dictonary.Add("ja", "Javier");
            dictonary.Add("in", "Inés");
            dictonary.Add("na", "Nacho");
            dictonary.Add("al", "Alberto");

            dictonary["ja"] = "Antonia";

            foreach (var i in dictonary.Keys)
            {
                Console.WriteLine("{0}", dictonary[i]);
            }
            
            //============================================================
            //Genéricos
            List<string> list = new List<string>();
            Dictionary<int, string> dictonary2 = new Dictionary<int, string>();


            Queue<string> queue = new Queue<string>();

            //Añadir nuevo elemento
            queue.Enqueue("valor");

            //Eliminar elemento de la posición 0 
            string eliminado = queue.Dequeue();

            Stack<string> stack = new Stack<string>();

            //Añadir elemento
            stack.Push("valor");

            //Eliminar elemento de la posición 0 y lo retorna
            //string eliminado2 = stack.Pop();

            //Retorno de elemento posicion 0 sin eliminar
            string elemento = stack.Peek();


            SortedList<int, string> sortlist = new SortedList<int, string>();
        }

        class Alumno
        {
            public string Nombre { get; set; }
            public int Edad { get; set; }
        }

        public class OrdenarNombre : IComparer
        {
            public int Compare(object x, object y)
            {
                Alumno alumnoX = (Alumno)x;
                Alumno alumnoY = (Alumno)y;

               return (new CaseInsensitiveComparer()).Compare(alumnoX.Nombre, alumnoY.Nombre);
            }
        }

        public class OrdenarEdad : IComparer
        {
            public int Compare(object x, object y)
            {
                Alumno alumnoX = (Alumno)x;
                Alumno alumnoY = (Alumno)y;

                //Como no hay CaseInsensitive porque son números, no lo ponemos
                return alumnoX.Edad.CompareTo(alumnoY.Edad);
            }
        }

        public class OrdenarAlumno : IComparer
        {
            public int Compare(object x, object y)
            {
                Alumno alumnoX = (Alumno)x;
                Alumno alumnoY = (Alumno)y;

                //Si los nombres de los alumnos son iguales, me lo ordenas por edad, si no(si son nombres distintos) me los ordenas por nombre
                if (alumnoX.Nombre.CompareTo(alumnoY.Nombre) == 0) return alumnoX.Edad.CompareTo(alumnoY.Edad);
                else return (new CaseInsensitiveComparer()).Compare(alumnoX.Nombre, alumnoY.Nombre);

            }
           
            
        }
    }
}
