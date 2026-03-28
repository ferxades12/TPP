namespace MasterWorkerEj;

class MasterWorker
{
    // A través de 2 arrays de enteros (el tamaño del 2º es <= al del 1º)
    // Calcular el número de ocurrencias del 2º array en el primero.
    // Suponer que tendrá un máximo de 30 hilos
    // Ejemplo:
    // { 2, 2, 1, 3, 2, 2, 1, 2, 1, 2, 2, 1 } y { 2, 2, 1}
    // Resultado: 3

    static void Main()
    {
        short[] v1 = new short[] { 2, 2, 1, 3, 2, 2, 1, 2, 1, 2, 2, 1 };
        short[] v2 = new short[] { 2, 2, 1 };

        int numeroHilos = v1.Length / v2.Length;
        Console.Write(CalcularOcurrencias(v1, v2, numeroHilos));

        //Probarlo posteriormente con dos aleatorios.
        //short[] v1 = CrearVectorAleatorio(1000, 0, 4);
        //short[] v2 = CrearVectorAleatorio(2, 0, 4);
    }

    public static short[] CrearVectorAleatorio(int numElementos, short menor, short mayor)
    {
        short[] vector = new short[numElementos];
        Random random = new Random();
        for (int i = 0; i < numElementos; i++)
            vector[i] = (short)random.Next(menor, mayor + 1);
        return vector;
    }

    public static double CalcularOcurrencias(short[] v1, short[] v2, int numeroHilos)
    {
        Thread[] hilos = new Thread[numeroHilos];
        double ocurrenciasTotal = 0;

        for (int i = 0; i < hilos.Length; i++)
        {
            int start = i * (v1.Length / numeroHilos);
            int final = (i + 1) * (v1.Length / numeroHilos) - 1;
            hilos[i] = new Thread(() =>
            {
                int contador = 0;
                int ocurrencias = 0;

                for (int j = start; j <= final; j++)
                {
                    if (v1[j] == v2[contador])
                    {
                        contador++;
                        if (contador == v2.Length)
                        {
                            contador = 0;
                            ocurrencias++;
                        }
                    }
                    else
                    {
                        contador = 0;
                    }
                }
                ocurrenciasTotal += ocurrencias;
            });

            hilos[i].Start();
        }

        for (int i = 0; i < hilos.Length; i++)
        {
            hilos[i].Join();
        }
        return ocurrenciasTotal;
    }
}
