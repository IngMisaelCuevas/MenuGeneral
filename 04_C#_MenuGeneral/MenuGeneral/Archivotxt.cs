using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace MenuGeneral
{
    internal class Archivotxt
    {
        public static void MostarTxt(string nombreTxt)
        {
            if (File.Exists(nombreTxt))
            {
                string[] lineas = File.ReadAllLines(nombreTxt);
                foreach (string linea in lineas)
                {
                    Console.WriteLine(linea);
                }
            }
            else
            {
                Console.WriteLine("El archivo no existe");
            }
        }

        public static void MostrarCSV(string nombreCsv) 
        {
            string[] lineas = File.ReadAllLines(nombreCsv);
            foreach (string linea in lineas)
            {
                string[] celdas = linea.Split(',');
                foreach (string c in celdas)
                {
                    Console.WriteLine(c);
                }
            }
        }

        public static void EscrbirTxt(string ruta, bool sobreescribir, string codigo)
        {
            if (codigo.ToLower() != "utf7" && codigo.ToLower() != "utf8" && 
                codigo.ToLower() != "unicod" && codigo.ToLower() != "utf32" &&
                codigo.ToLower() != "ascii")
            {
                Console.WriteLine("Codificador incorrecto, debe ser (UTF7,UTF8,Unicod,UTF32,ASCII)");
                return;
            }
            Encoding encoding = Encoding.Default;
            switch (codigo)
            {
                case "utf7":
                    encoding = Encoding.UTF7;
                    break;
                case "utf8":
                    encoding = Encoding.UTF7;
                    break;
                case "unicod":
                    encoding = Encoding.UTF7;
                    break;
                case "utf32":
                    encoding = Encoding.UTF7;
                    break;
                case "ascii":
                    encoding = Encoding.UTF7;
                    break;
                default:
                    Console.WriteLine("Codificacion incorrecta");
                    break;
            }

            bool continuar = true;
            StreamWriter archivo = new StreamWriter(ruta, sobreescribir, encoding);
            while (continuar)
            {

                Console.Write("Ingresa nombre del alumno: ");
                string nombre = Console.ReadLine();

                Console.Write("Ingresa primer apellido del alumno: ");
                string primerApellido = Console.ReadLine();

                Console.Write("Ingresa segundo apellido del alumno: ");
                string segundoApellido = Console.ReadLine();

                Console.Write("Ingresa edad del alumno: ");
                int edad = int.Parse(Console.ReadLine());

                Console.Write("Ingresa esttado del alumno: ");
                string estado = Console.ReadLine();

                string datos = $"{nombre}, {primerApellido}, {segundoApellido},{edad}, {estado}";      

                archivo.WriteLine(datos);
                

                Console.WriteLine("¿Deseas registar otro alumno? s/n");
                string respuesta = Console.ReadLine(); 

                if (respuesta.ToLower() == "s")
                {
                    continuar = true;
                }
                else if(respuesta.ToLower() == "n")
                {
                    continuar= false;
                }
                else
                {
                    Console.WriteLine("Opcion incorrecta");
                    Console.ReadKey();
                    return;
                }

            }
            archivo.Close();
        }

        public static void Presentacion()
        {
            Console.WriteLine("Elije el tipo de archivo a mostrar \n" +
                "1) Archivos .txt \n" +
                "2) Archivos .csv \n");

            int opcion = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa ruta del archivo");
            string ruta = Console.ReadLine();

           if( opcion == 1)
            {
                MostarTxt(ruta);
            }
           else if( opcion == 2)
            {
                MostrarCSV(ruta);
            }
            else
            {
                Console.WriteLine("Opcion incorrecta");
                return;
            }

        }
    }
}
