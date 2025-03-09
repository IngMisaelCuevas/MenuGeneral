using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuGeneral
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool menu = true;

            while (menu)
            {
                Console.Clear();
                Console.WriteLine(
                    "1) Cadenas \n" +
                    "2) Número Mayor \n" +
                    "3) Tipo Oración \n" +
                    "4) Poliza \n" +
                    "5) Leer Archivos \n" +
                    "6) Escribir Archivos \n" +
                    "7) ISR \n" +
                    "f) Termina \n");

                Console.WriteLine("Elige el número de la opción");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Arreglos.Cadenas();
                        Console.ReadKey();
                        break;

                    case "2":
                        Arreglos.Enteros();
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.WriteLine("Ingresa una oración");
                        string oracion = Console.ReadLine();
                        string nuevaOracion = Arreglos.ConvierteATipoOracion(oracion);
                        Console.WriteLine(nuevaOracion);
                        Console.ReadKey();
                        break;

                    case "4":
                        Poliza.Presentacion();
                        Console.ReadKey();
                        break;
                    case "5":
                        Archivotxt.Presentacion();
                        Console.ReadKey();
                        break;

                    case "6":
                        Console.WriteLine("Ingresa ruta del archivo");
                        string ruta = Console.ReadLine();

                        Console.WriteLine("¿Desea sobreescribir el archivo? s/n");
                        string respuesta = Console.ReadLine();

                        if (respuesta != "s" && respuesta != "n")
                        {
                            Console.WriteLine("Respuesta incorrecta");
                            Console.ReadKey();
                            break;
                            
                        }
                        bool sobreescribir = respuesta.ToLower() == "s" ? false : true;

                        Console.WriteLine("¿Ingrese codificacion (UTF7,UTF8,Unicod,UTF32,ASCII)");
                        string codificacion = Console.ReadLine(); 

                        Archivotxt.EscrbirTxt(ruta, sobreescribir, codificacion);
                        Console.ReadKey();
                        break;

                    case "7":
                        ISR.Presentacion();
                        Console.ReadKey();
                        break;

                    case "8":
                        Console.WriteLine("Usted selecciónó la opción 8");
                        break;
                    case "9":
                        Console.WriteLine("Usted selecciónó la opción 9");
                        break;
                    case "10":
                        Console.WriteLine("Usted selecciónó la opción 10");
                        break;
                    case "11":
                        Console.WriteLine("Usted selecciónó la opción 11");
                        break;
                    case "12":
                        Console.WriteLine("Usted selecciónó la opción 12");
                        break;
                    case "13":
                        Console.WriteLine("Usted selecciónó la opción 13");
                        break;
                    case "14":
                        Console.WriteLine("Usted selecciónó la opción 14");
                        break;
                    case "15":
                        Console.WriteLine("Usted selecciónó la opción 15");
                        break;
                    case "f":
                        Console.WriteLine("Terminando");
                        menu = false;
                        Console.ReadKey();
                        break;
                    default : 
                        Console.WriteLine("Respuesta incorrecta");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
