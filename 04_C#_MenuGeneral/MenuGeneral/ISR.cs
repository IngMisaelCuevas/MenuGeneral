using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using System.IO;
using System.Timers;

namespace MenuGeneral
{
    internal class ISR
    {
        public static decimal[,] CargarTabla(string ruta)
        {
            string[] tabla = File.ReadAllLines(ruta);

            decimal [,] tablaISR = new decimal[tabla.Length, 6];

            for(int i = 0; i < tabla.Length; i++)
            {
                string[] celdas = tabla[i].Split(',');
                for(int j = 0; j < celdas.Length; j++)
                {
                    tablaISR[i, j] = Convert.ToDecimal(celdas[j]);
                }
            }

            return tablaISR;
        }

        public static decimal Calcular(decimal sueldoMensual)
        {
            decimal sueldoQuincenal = sueldoMensual / 2;

            decimal[,] tabla = CargarTabla(@"D:\misae\Documentos\Bootcamp\Practicas Bootcam\Semana 2 C#\Día 3\ISR.csv");

            decimal impuesto = 0;

            for(int i = 0;i < tabla.GetLength(0); i++)
            {
                decimal limInf = tabla[i, 1];
                decimal limSup = tabla[i, 2];

                if(sueldoQuincenal >= limInf && sueldoQuincenal <= limSup)
                {
                    decimal cuotaFija = tabla[i, 3];
                    decimal porExcLimInf = tabla[i, 4];
                    decimal subsidio = tabla[i, 5];
                    decimal excedente = ((sueldoQuincenal - limInf) * porExcLimInf)/100;
                    impuesto = cuotaFija + excedente - subsidio;
                    break;
                }
            }

            return Math.Round(impuesto, 2);
        }

        public static void Presentacion()
        {
            Console.WriteLine("Ingresa sueldo mensual");
            decimal sueldoMensual =  decimal.Parse(Console.ReadLine());

            decimal impuesto = Calcular(sueldoMensual);

            Console.WriteLine($"El impuesto es: {impuesto.ToString("C2")}");
        }


    }
}
