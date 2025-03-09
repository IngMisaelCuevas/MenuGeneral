using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuGeneral
{
    internal class Poliza
    {
        public static PolizaResultado Calcular(
            DateTime fechaInicio,
            string tipoPeriodo,
            int cantPeriodo,
            decimal sumaAsegurada,
            DateTime fechaNacimiento,
            string genero)
        {

            decimal[,] tablaFactor = new decimal[,]
            {
                {0, 20, 0, 0.05m },
                {21, 30, 0, 0.1m },
                {31, 40, 0, 0.4m },
                {41, 50, 0, 0.5m },
                {51, 60, 0, 0.65m },
                {61, 120, 0, 0.85m},
                {0, 20, 1, 0.05m },
                {21, 30, 1, 0.1m },
                {31, 40, 1, 0.4m },
                {41, 50, 1, 0.55m },
                {51, 60, 1, 0.7m },
                {61, 120, 1, 0.9m}
            };

            //EDAD
            DateTime fechaActual = DateTime.Now;
            int edad = fechaActual.Year - fechaNacimiento.Year;

            if(fechaActual.Month < fechaNacimiento.Month || 
                (fechaActual.Month == fechaNacimiento.Month && fechaActual.Day < fechaNacimiento.Day))
            {
                edad -= 1;
            }

            //GENERO
            int idGenero = genero.ToLower() == "masculino" ? 1 : 0;

            //FACTOR
            decimal? factor = null;

            for (int i = 0; i < tablaFactor.GetLength(0); i++)
            {
                int rangoInicial = (int) tablaFactor[i, 0];
                int rangoFinal = (int) tablaFactor[i, 1];
                int identificadorGenero = (int) tablaFactor[i, 2];

                if(rangoInicial <= edad && rangoFinal >= edad && identificadorGenero == idGenero)
                {
                    factor = tablaFactor[i, 3];
                    break;
                }
            }

            //FECHA TERMINO Y PRIMA
            DateTime fechaTermino = new DateTime();
            decimal? prima = null;
            switch (tipoPeriodo)
            {
                case "años":
                case "año":
                    fechaTermino = fechaInicio.AddYears(cantPeriodo);
                    //prima = sumaAsegurada * factor *((cantPeriodo*365)/360m);
                    break;

                case "meses":
                case "mes":
                    fechaTermino = fechaInicio.AddMonths(cantPeriodo);
                    //prima = sumaAsegurada * factor * ((cantPeriodo * 30) / 360m);
                    break;

                case "dias":
                case "dia":
                    fechaTermino = fechaInicio.AddDays(cantPeriodo);
                    //prima = sumaAsegurada * factor * (cantPeriodo / 360m);
                    break;

                default:
                    Console.WriteLine("Periodo no valido, usa años, meses o dias");
                    break;
            }

            TimeSpan ts = fechaTermino.Subtract(fechaInicio);
            prima = sumaAsegurada * factor * ((ts.Days) / 360m);

            double primaDouble = Convert.ToDouble(prima);
            

            //RETURN
            PolizaResultado PR = new PolizaResultado();
            PR.Prima = Math.Round(primaDouble); ;
            PR.FechaTermino = fechaTermino;
            return PR;
        }

        public static void Presentacion()
        {
            //INICIO DE VIGENCIA
            Console.WriteLine("Proporciona la fecha de inicio de Vigencia:");
            string sfecha = Console.ReadLine();
            DateTime fechaInicio;

            try
            {
                fechaInicio = DateTime.Parse(sfecha);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }


            Console.WriteLine("Proporciona para cuanto tiempo requieres la póliza (ejemplo 2 años):");
            string tiempo = Console.ReadLine();

            string[] partesTiempo = tiempo.Split(' ');

            int cantPeriodo = int.Parse(partesTiempo[0]);
            string tipoPeriodo = partesTiempo[1];

            Console.WriteLine("Proporciona la suma asegurada:");
            decimal sumaAsegurada = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Proporciona la fecha de Nacimiento del  asegurado:");
            DateTime fechaNacimiento = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Proporciona el género del asegurado:");
            string genero = Console.ReadLine();

            PolizaResultado pr = Calcular(fechaInicio, tipoPeriodo, cantPeriodo, sumaAsegurada, fechaNacimiento, genero);

            Console.WriteLine($"La Póliza vencerá el : {pr.FechaTermino}");
            Console.WriteLine($"La prima a pagar es de {pr.Prima?.ToString("C2")}");
        }
    }
}
