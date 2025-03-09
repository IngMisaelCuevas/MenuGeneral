using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace MenuGeneral
{
    internal class Arreglos
    {
        public static void Cadenas()
        {
            Console.Write("Proporciona tu nombre completo: ");
            string nombre = Console.ReadLine();

            string[] partesNombre = nombre.Split(' ');

            Console.WriteLine("\nHola ");
            for (int i = 0; i < partesNombre.Length; i++)
            {
                Console.WriteLine(partesNombre[i]);
            }

            Console.WriteLine("\nApellido Vertical");
            char[] letras = partesNombre[1].ToCharArray();

            foreach (char c in letras)
            {
                Console.WriteLine(c);
            }
        } 

        public static void Enteros()
        {
            Console.WriteLine("Vas a proporcionar 5 números enteros");
            Console.Write("1er numero: ");
            int n1 = int.Parse(Console.ReadLine());
            Console.Write("2do numero: ");
            int n2 = int.Parse(Console.ReadLine());
            Console.Write("3er numero: ");
            int n3 = int.Parse(Console.ReadLine());
            Console.Write("4to numero: ");
            int n4 = int.Parse(Console.ReadLine());
            Console.Write("5to numero: ");
            int n5 = int.Parse(Console.ReadLine());

            int[] arregloDeNumeros = {n1, n2, n3, n4, n5};
            int numeroMayor = arregloDeNumeros[0];

            foreach(int i in arregloDeNumeros)
            {
                numeroMayor = numeroMayor > i ? numeroMayor : i;
            } 
            

            Console.WriteLine($"El valor máximo es: {numeroMayor}");
        }

        public static string ConvierteATipoOracion(string oracion)
        {
            
            string nuevaOracion = oracion.ToLower();

            char[] caracteres = nuevaOracion.ToCharArray();

            if (caracteres[0] != ' ')
            {
                caracteres[0] = char.ToUpper(caracteres[0]);
            }

            for ( int i = 0; i < caracteres.Length; i++)
            {
                if (caracteres[i].Equals(' ') && caracteres[i+1] != ' ')
                {
                    caracteres[i+1] = char.ToUpper(caracteres[i+1]);
                }
            }
            nuevaOracion = new string(caracteres);
            return nuevaOracion;
        }
    }
}
