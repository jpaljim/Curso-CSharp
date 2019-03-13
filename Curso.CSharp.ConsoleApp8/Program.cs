using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.CSharp
{
    public static class ExtensionMetodos
    {
        public static string Capitalize(this string contenido)
        {
            string resultado = "";
            string[] palabras = contenido.Split(' ');

            foreach (var palabra in palabras)
            {
                resultado += resultado.Length > 0 ? " " : "";
                resultado += palabra[0].ToString().ToUpper();
                resultado += palabra.Substring(1, palabra.Length - 1).ToLower();
            }

            return resultado;
        }

        public static int CuentaLetraA(this string contenido)
        {
            int contador = 0;
            for (var i = 0; i < contenido.Length - 1; i++)
            {
                if (contenido[i] == 'a') contador++;
            }

            return contador;
        }

        public static int CuentaLetras(this string contenido, char letra)
        {
            int contador = 0;
            for (var i = 0; i < contenido.Length - 1; i++)
            {
                if (contenido[i] == letra) contador++;
            }

            return contador;
        }

        public static decimal ParteEntera(this decimal valor)
        {
            return Math.Truncate(valor);
        }

        public static decimal ParteDecimal(this decimal valor)
        {
            return (valor - Math.Truncate(valor));
        }

        public static decimal Entero<T>(this T valor)
        {
            return Math.Truncate(Convert.ToDecimal(valor));
        }

        public static bool EsNumero(this string contenido)
        {
            decimal valor = 0;
            return decimal.TryParse(contenido, out valor);
        }

        public static decimal? ToDecimal(this string contenido)
        {
            decimal valor = 0;

            if (decimal.TryParse(contenido, out valor)) return valor;
            else return null;
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
}



namespace Curso.CSharp.ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculadora<int, int> calculadora = new Calculadora<int, int>();
            Console.WriteLine("Suma 10 + 20: {0}", calculadora.Suma(10, 20));
            Calculadora<char, int> calculadora1 = new Calculadora<char, int>();
            Console.WriteLine("Suma '1' + 40: {0}", calculadora1.Suma('1', 40));
            Calculadora<string, string> calculadora2 = new Calculadora<string, string>();
            Console.WriteLine("Suma \"3200\" \"42\": {0}", calculadora2.Suma("3200", "42"));
            Console.WriteLine("Suma \"hola\" \"42\": {0}", calculadora2.Suma("hola", "42"));
            Console.WriteLine("Suma \"hola\" \"adios\": {0}", calculadora2.Suma("hola", "adios"));
            Console.WriteLine("Suma \"hola3200\" \"42\": {0}", calculadora2.Suma("hola3200", "42"));

            Console.ReadKey();

            decimal numero = 30.815154151M;
            int numero2 = 305415;
            Console.WriteLine("================================================");
            Console.WriteLine("Parte Entera: {0}", numero.Entero());
            Console.WriteLine("Parte Entera: {0}", numero2.Entero());
            Console.WriteLine("Parte Entera: {0}", numero.ParteEntera());
            Console.WriteLine("Parte Decimal: {0}", numero.ParteDecimal());

            string texto = "en un lugar de lA mancha de CUYO nombre NO quiero ...";
            Console.WriteLine("Numéro de letras O: {0}", texto.CuentaLetras('o'));
            Console.WriteLine("Frase: {0}", texto.Capitalize());

            Demo<decimal> demo = new Demo<decimal>();
            demo.SetValor(30M);
            demo.PintaValor();

            Console.ReadKey();
        }
    }

    class Demo<TValor>
    {
        private TValor valor;
        public TValor GetValor()
        {
            return valor;
        }
        public void SetValor(TValor value)
        {
            valor = value;
        }
        public void PintaValor()
        {
            Console.WriteLine("El tipo de valor es {0}", valor.GetType().ToString());
            Console.WriteLine("El valor es {0}.", valor);
        }
        public Demo() { }
        public Demo(TValor valor)
        {
            this.valor = valor;
        }
    }

    class Calculadora<TNum1, TNum2>
    {
        public decimal Suma(TNum1 num1, TNum2 num2)
        {
            decimal n1 = 0;
            decimal n2 = 0;

            try
            {
                n1 = (num1.ToString()).ConvertDecimal();
                n2 = (num2.ToString()).ConvertDecimal();
            }
            catch (Exception)
            {
            }

            return n1 + n2;
        }
    }
}