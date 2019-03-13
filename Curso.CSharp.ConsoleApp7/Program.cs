using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.CSharp.ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {

            Demo2 demo2 = new Demo2();
            demo2.Metodo2(10);

            Console.ReadKey();
        }
    }

    public abstract class DemoAbstract
    {
        public abstract void Metodo();
        public abstract void Metodo2(int numero);

        public bool Comprobar(int numero)
        {
            return true;
        }
    }

    public class Demo : DemoAbstract
    {
        public string Nombre { get; set; }
        public sealed override void Metodo()
        {

        }
        public override void Metodo2(int numero)
        {
            Console.WriteLine("Método 2 de la clase DEMO");
        }

        public virtual void Metodo3()
        {

        }
        public Demo()
        {

        }
        public Demo(string Nombre)
        {
            this.Nombre = Nombre;
        }
    }

    public class Demo2 : Demo
    {
        public override void Metodo2(int numero)
        {
            Console.WriteLine("Método 2 de la clase DEMO2");
            base.Metodo2(numero);
        }

        public sealed override void Metodo3()
        {
            base.Metodo3();
        }
    }
}