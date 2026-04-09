using System;
using System.Diagnostics;
using activity10;

namespace activity10
{
    public class Program
    {
        static void Main(string[] args)
        {
            const int value = 7000;
            const int maximoHilos = 50;
            Stopwatch stopWatch = new Stopwatch();

            for (int numeroHilos = 1; numeroHilos <= maximoHilos; numeroHilos++)
            {
                for (int numEx = 0; numEx < 15; numEx++)
                {
                    Master master = new Master(value, numeroHilos);

                    stopWatch.Restart();
                    double resultado = master.ComputeNumTimesGreaterThan();
                    stopWatch.Stop();

                    MostrarLinea(Console.Out, numeroHilos, stopWatch.ElapsedTicks, resultado);

                    GC.Collect();
                    GC.WaitForFullGCComplete();
                }
            }
        }

        static void MostrarLinea(
            TextWriter stream,
            string numHilosCabecera,
            string ticksCabecera,
            string resultadoCabecera
        )
        {
            stream.WriteLine("{0};{1};{2}", numHilosCabecera, ticksCabecera, resultadoCabecera);
        }

        static void MostrarLinea(TextWriter stream, int numHilos, long ticks, double resultado)
        {
            stream.WriteLine("{0};{1:N0};{2:N2}", numHilos, ticks, resultado);
        }
    }
}
