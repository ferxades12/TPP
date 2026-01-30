using System;

namespace extensores;

/// <summary>
/// Un método extensor es estático y se define dentro de una clase estática
/// </summary>
public static class Extensores
{

    //¿Qué indica el this?
    public static string Encriptar(this string mensaje, int clave)
    {
        return CifradoCesar(mensaje, clave);
    }

    public static string Desencriptar(this string message, int clave)
    {
        return CifradoCesar(message, -clave);
    }

    private static string CifradoCesar(string mensaje, int desplazamiento)
    {
        /*
            Versión simplificada del Cifrado César:
                https://es.wikipedia.org/wiki/Cifrado_C%C3%A9sar
        */
        var buffer = mensaje.ToCharArray();
        for (int i = 0; i < buffer.Length; i++)
        {
            buffer[i] = (char)(buffer[i] + desplazamiento);
        }
        return new string(buffer);
    }

    public static int ContarVocales(this string mensaje)
    {
        int count = 0;
        string vocals = "aeiouAEIOU";

        foreach(char letter in mensaje)
        {
            if (vocals.Contains(letter))
            {
                count++;
            }
        }

        return count;
    }


    public static int Minimo(this int[] param)
    {
        int min = int.MaxValue;

        foreach(int d in param)
        {
            if(d < min) min = d;
        }

        return min;
    }

    public static double Media(this double[] param)
    {
        double media = 0;

        foreach(double d in param)
        {
            media += d;
        }

        return media / param.Length;
    }
}
