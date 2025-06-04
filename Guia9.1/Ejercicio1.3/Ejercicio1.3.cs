using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] vector = new int[30];

            for (int i = 0; i < 30; i++) 
            {
                Console.WriteLine($"Ingrese un numero para la posicion {i}");
                int n = Convert.ToInt32(Console.ReadLine());
                vector[i] = n;
            }

            int cant = 30;
            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                int posicionAleatoria = random.Next(0, cant);
                int numeroSeleccionado = vector[posicionAleatoria];
                Console.WriteLine($"{i+1}° numero seleccionado: {numeroSeleccionado}");

                vector[posicionAleatoria] = vector[cant - 1]; // Reemplaza el número seleccionado con el último número del vector
                cant--; // Reduce la cantidad de números restantes
            }
        }
    }
}
