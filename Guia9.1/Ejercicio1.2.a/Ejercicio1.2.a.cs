//Aca uso variables auxiliares para los alumnos con la nota mayor y menor

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

            #region Resultados y quien supera el promedio
            string nombreMayor = nombres[posMayor];
            int libretaMayor = libretas[posMayor];
            double notaMayorAux = notas[posMayor];

            string nombreMenor = nombres[posMenor];
            int libretaMenor = libretas[posMenor];
            double notaMenorAux = notas[posMenor];

            Console.WriteLine($"Alumno con mayor nota: {nombreMayor}.Libreta N°: {libretaMayor}. Su nota es: {notaMayorAux}");
            Console.WriteLine($"Alumno con menor nota: {nombreMenor}.Libreta N°: {libretaMenor}. Su nota es: {notaMenorAux}");

            string[] nombresSuperanPromedio = new string[100];
            int[] libretasSuperanPromedio = new int[100];
            double[] notasSuperanPromedio = new double[100];
            int cantidadSuperanPromedio = 0;

            for (int i = 0; i < cantidad; i++)
            {
                if (notas[i] > promedio)
                {
                    nombresSuperanPromedio[cantidadSuperanPromedio] = nombres[i];
                    libretasSuperanPromedio[cantidadSuperanPromedio] = libretas[i];
                    notasSuperanPromedio[cantidadSuperanPromedio] = notas[i];
                    cantidadSuperanPromedio++;
                }
            }

            if (cantidadSuperanPromedio > 0)
            {
                Console.WriteLine("Alumnos que superan el promedio:");
                for (int i = 0; i < cantidadSuperanPromedio; i++)
                {
                    Console.WriteLine($"Nombre: {nombresSuperanPromedio[i]}, Libreta: {libretasSuperanPromedio[i]}, Nota: {notasSuperanPromedio[i]}");
                }
            }
            else
            {
                Console.WriteLine("Ningún alumno supera el promedio.");
            }
            #endregion
        }
    }
}
