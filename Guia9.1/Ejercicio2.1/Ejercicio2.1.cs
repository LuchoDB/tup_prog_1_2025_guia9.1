//Ejercicio 2.1 Problema de Introducción - un solo arreglo

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region a) Generacion de un arreglo de tamaño aleatorio con valores aleatorios
            Random rnd = new Random();

            int cant = rnd.Next(10, 101); //Esto genera que la cantidad de elementos del arreglo sea aleatorio entre 10 y 100
            int[] arreglo = new int[cant];

            for (int i = 0; i < cant; i++)
            {
                arreglo[i] = rnd.Next(0, 201); // Genera un número aleatorio entre 0 y 200 que se asigna al arreglo
            }
            #endregion

            #region b) Impresion de los elementos del arreglo
            //Para imprimir los elementos del arreglo en formato posicion:valor
            Console.WriteLine("Arreglo original:");
            for (int i = 0; i < cant; i++)
            {
                Console.Write($"{i}:{arreglo[i]}, ");
            }
            Console.WriteLine();
            #endregion

            #region c) Ordenamiento por metodo burbuja
            //Ordeno el arreglo utilizando el método de burbuja
            for (int i = 0; i < cant - 1; i++)
            {
                for (int j = 0; j < cant - i - 1; j++)
                {
                    if (arreglo[j] < arreglo[j + 1])
                    {
                        // Intercambio los elementos
                        int aux = arreglo[j];
                        arreglo[j] = arreglo[j + 1];
                        arreglo[j + 1] = aux;
                    }
                }
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Arreglo ordenado por metodo burbuja de mayor a menor");
            for (int i = 0; i < cant; i++)
            {
                Console.Write($"{i}:{arreglo[i]}, ");
            }
            Console.WriteLine();
            #endregion

            #region d) Ordenamiento por quicksort
            int[] arregloOriginal = (int[])arreglo.Clone(); // Hice una copia del arreglo original para no perder los datos

            int[] indiceIzq = new int[cant];
           int[] indiceDer = new int[cant];
           int tope = -1; //Lo inicio en -1 para que al incrementar sea 0 en la primera iteracion

           tope++;
           indiceIzq[tope] = 0;
           indiceDer[tope] = cant - 1;

            while (tope >= 0)
            {
                int izq = indiceIzq[tope];
                int der = indiceDer[tope];
                tope--; 

                if (izq < der) 
                {
                    int pivote = arregloOriginal[izq]; // Tomo el primer elemento como pivote
                    int i = izq + 1;
                    int j = der;
                    while (i <= j) //Mientras que los índices no se crucen
                    {
                        while (i <= der && arreglo[i] < pivote) i++; // Busco un elemento mayor o igual al pivote
                        while (j >= izq && arreglo[j] > pivote) j--; // Busco un elemento menor o igual al pivote
                        if (i < j)
                        {
                            // Intercambio los elementos
                            int aux = arreglo[i];
                            arreglo[i] = arreglo[j];
                            arreglo[j] = aux;
                        }
                    }
                    // Coloco el pivote en su lugar correcto
                    arreglo[izq] = arreglo[j];
                    arreglo[j] = pivote;
                    // Agrego los índices para seguir ordenando
                    tope++; 
                    indiceIzq[tope] = izq;
                    indiceDer[tope] = j - 1; //Estas son las posiciones a la izquierda del pivote

                    tope++;
                    indiceIzq[tope] = j + 1;
                    indiceDer[tope] = der; //Estas son las posiciones a la derecha del pivote
                }
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Arreglo ordenado por quicksort de menor a mayor:");
            for (int i = 0; i < cant; i++)
            {
                Console.Write($"{i}:{arreglo[i]}, ");
            }
            Console.WriteLine();
            #endregion //En este hice una copia del arreglo, asi no altero el original, y lo ordeno de menor a mayor

            #region e) Generacion de un numero aleatorio y busqueda en el arreglo ordenado

            int[] arregloDesordenado = (int[])arregloOriginal.Clone(); // Hice una copia del arreglo original para no perder los datos
            
            
            Random rnd2 = new Random();
            int numeroBuscado = rnd2.Next(0, 201); // Genera un número aleatorio entre 0 y 200
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Busqueda de un numero aleatorio");
            Console.WriteLine($"\nNumero a buscar: {numeroBuscado}");
            bool encontrado = false;
            for (int i = 0; i < cant; i++)
            {
                if (arregloDesordenado[i] == numeroBuscado)
                {
                    Console.WriteLine($"El numero {numeroBuscado} se encuentra en la posicion {i} del arreglo.");
                    encontrado = true;
                    break; // Salgo del bucle si encuentro el número
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("Numero no encontrado");
            }
            #endregion
        }
    }
}
