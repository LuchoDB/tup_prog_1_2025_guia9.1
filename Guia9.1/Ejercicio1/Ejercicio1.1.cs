using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    internal class Ejercicio1
    {
        static void Main(string[] args)
        {
            #region Carga de datos
            int[] datos = new int [100];
            int cant = 0;

            Console.WriteLine("Ingrese números enteros (o escriba 'fin' para terminar):");

            while (cant < 100)
            {
                string entrada = Console.ReadLine();
                if (entrada.ToLower() == "fin") //ToLower convierte la entrada a minúsculas para comparar
                    break;

                if (int.TryParse(entrada, out int numero)) // TryParse es para evitar excepciones si la entrada no es un número
                {
                    datos[cant] = numero;
                    cant++;
                }
                else
                {
                    Console.WriteLine("Entrada invalida. Por favor, ingrese un número entero o 'fin' para terminar.");
                }
            }
            if (cant == 0)
            {
                Console.WriteLine("No se ingresaron números.");
            }
            
            Console.WriteLine("Los números ingresados son:");
            for (int i = 0; i < cant; i++)
            {
                Console.WriteLine(datos[i]);
            }
            #endregion

            #region Procesamiento de datos
            int suma = 0;
            int mayor = datos[0], menor = datos[0];
            int posMayor = 0, posMenor = 0;

            for (int i = 0; i < cant; i++)
            {
                suma += datos[i];
                if (datos[i] > mayor)
                {
                    mayor = datos[i];
                    posMayor = i;
                }
                if (datos[i] < menor)
                {
                    menor = datos[i];
                    posMenor = i;
                }
            }
            #endregion

            #region Promedio y resultados
            double promedio = (double)suma / cant;

            if (cant <= 0)
            {
                Console.WriteLine("No se ingresaron números.");
                return; // Salimos del programa si no hay números
            }
            else
            {
                Console.WriteLine($"La suma de los elementos ingresados es: {suma}");
                Console.WriteLine($"El promedio de los elementos ingresados es: {promedio}");
                Console.WriteLine($"El mayor elemento es: {mayor} en la posición (subindice) {posMayor}");
                Console.WriteLine($"El menor elemento es: {menor} en la posición (subindice) {posMenor}");
            }
                #endregion
        }
    }
}
