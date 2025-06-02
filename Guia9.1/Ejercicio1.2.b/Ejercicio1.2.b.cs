//Aca guardo solo los alumnos con la nota mayor y menor, si son iguales, solo guardo uno

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nombres = new string[100];
            int[] libretas = new int[100];
            double[] notas = new double[100];

            int cantidad = 0;
            #region Carga de datos
            Console.WriteLine("Ingrese los datos de los alumnos (ingrese -1 para salir");

            while (cantidad < 100)
            {
                Console.Write($"Ingrese el numero de libreta del alumno: {cantidad + 1}");
                string entrada = Console.ReadLine();

                if (int.TryParse(entrada, out int libreta))/*int.TryParse es para convertir convertir una cadea a un numero entero
                    entrada es un string ingresados y out int libreta es una variable creada en la cual voy a guardar el valor de entrada
                    Si la entrada es un numero, se guardara, sino, no*/
                {
                    if (libreta == -1)
                        break;

                    libretas[cantidad] = libreta;
                    Console.Write("Ingrese el nombre del alumno: ");
                    nombres[cantidad] = Console.ReadLine();
                    Console.Write("Ingrese la nota del alumno: ");
                    string notaEntrada = Console.ReadLine();
                    if (double.TryParse(notaEntrada, out double nota)) // Convertir la entrada a un número decimal
                    {
                        notas[cantidad] = nota;
                        cantidad++;
                    }
                    else
                    {
                        Console.WriteLine("Entrada invalida. Por favor, ingrese una nota válida.");
                    }
                }
                else
                {
                    Console.WriteLine("Numero de libreta equivocado. Por favor, ingrese un número de libreta válido.");
                }
            }

            if (cantidad == 0)
            {
                Console.WriteLine("No se ingresaron datos de alumnos.");
                return; // Si no se ingresaron datos, se sale del programa
            }
            #endregion

            #region Procesamiento de datos
            double suma = 0;
            for (int i = 0; i < cantidad; i++)
            {
                suma += notas[i];
            }
            double promedio = suma / cantidad;
            Console.WriteLine($"El promedio de las notas es: {promedio:F2}");

            double notaMayor = notas[0];
            double notaMenor = notas[0];
            int posMayor = 0, posMenor = 0;
            for (int i = 1; i < cantidad; i++)
            {
                if (notas[i] > notaMayor)
                {
                    notaMayor = notas[i];
                    posMayor = i;
                }
                if (notas[i] < notaMenor)
                {
                    notaMenor = notas[i];
                    posMenor = i;
                }
            }
            #endregion

            #region Resultados
            string[] filtroNombre = new string[2];
            int[] filtroLibreta = new int[2];
            double[] filtroNota = new double[2];

            if (posMayor == posMenor)
            {
                filtroNombre[0] = nombres[posMayor]; // Si el alumno con la nota mayor es el mismo que el de la nota menor
                filtroLibreta[0] = libretas[posMayor]; 
                filtroNota[0] = notas[posMayor];
                cantidad = 1; // Solo un alumno tiene la misma nota mayor y menor
            }
            else
            {
                filtroNombre[0] = nombres[posMayor];
                filtroLibreta[0] = libretas[posMayor];
                filtroNota[0] = notas[posMayor];

                filtroNombre[1] = nombres[posMenor];
                filtroLibreta[1] = libretas[posMenor];
                filtroNota[1] = notas[posMenor];
                cantidad = 2; // Dos alumnos tienen notas diferentes
            }

            for (int i = 0; i < cantidad; i++) // Mostrar los resultados filtrados
            {
                Console.WriteLine($"Alumno: {filtroNombre[i]}, Libreta: {filtroLibreta[i]}, Nota: {filtroNota[i]}");
            }
            #endregion

        }
    }
}
