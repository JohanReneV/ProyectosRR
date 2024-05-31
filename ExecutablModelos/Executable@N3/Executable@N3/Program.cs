using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executable_N3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----- Executable para resolver por el Método Simplex (Minimización) -----");
            Console.WriteLine("----- Jhojan Rene Vera-Bairon -----");
            Console.WriteLine();

            Console.Write("Ingrese el número de restricciones: ");
            int numRestrictions = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el número de variables: ");
            int numVariables = int.Parse(Console.ReadLine());

            // Número de filas y columnas del tableau
            int numRows = numRestrictions + 1;
            int numCols = numVariables + numRestrictions + 1;

            double[,] tableau = new double[numRows, numCols];

            // Ingresar coeficientes de las restricciones
            for (int i = 0; i < numRestrictions; i++)
            {
                Console.WriteLine($"Restricción {i + 1}:");
                for (int j = 0; j < numVariables; j++)
                {
                    Console.Write($"Coeficiente de x{j + 1}: ");
                    tableau[i, j] = double.Parse(Console.ReadLine());
                }
                // Coeficientes de las variables de holgura
                for (int j = numVariables; j < numCols - 1; j++)
                {
                    tableau[i, j] = (j - numVariables == i) ? 1 : 0;
                }
                Console.Write("Término independiente: ");
                tableau[i, numCols - 1] = double.Parse(Console.ReadLine());
            }

            // Ingresar coeficientes de la función objetivo
            Console.WriteLine("Función objetivo:");
            for (int j = 0; j < numVariables; j++)
            {
                Console.Write($"Coeficiente de x{j + 1}: ");
                tableau[numRows - 1, j] = double.Parse(Console.ReadLine()) * -1; // Multiplicar por -1 para maximizar
            }

            // Coeficientes de las variables de holgura en la función objetivo
            for (int j = numVariables; j < numCols; j++)
            {
                tableau[numRows - 1, j] = 0;
            }

            Console.WriteLine("\nTabla inicial:");
            PrintTableau(tableau);

            // Ejecutar método Simplex
            Simplex(tableau);


            Console.ReadLine();
        }

        // Método Simplex para resolver el problema
        static void Simplex(double[,] tableau)
        {
            int numRows = tableau.GetLength(0);
            int numCols = tableau.GetLength(1);

            while (true)
            {
                int pivotCol = -1;
                double minVal = 0;
                for (int j = 0; j < numCols - 1; j++)
                {
                    if (tableau[numRows - 1, j] < minVal)
                    {
                        minVal = tableau[numRows - 1, j];
                        pivotCol = j;
                    }
                }

                if (pivotCol == -1)
                    break;

                int pivotRow = -1;
                double minRatio = double.PositiveInfinity;
                for (int i = 0; i < numRows - 1; i++)
                {
                    if (tableau[i, pivotCol] > 0)
                    {
                        double ratio = tableau[i, numCols - 1] / tableau[i, pivotCol];
                        if (ratio < minRatio)
                        {
                            minRatio = ratio;
                            pivotRow = i;
                        }
                    }
                }

                Pivot(tableau, pivotRow, pivotCol);

                Console.WriteLine($"\nPivote: Fila {pivotRow + 1}, Columna {pivotCol + 1}");
                PrintTableau(tableau);
            }

            Console.WriteLine("\nSolución óptima:");
            PrintTableau(tableau);
        }

        // Método para realizar la operación de pivote
        static void Pivot(double[,] tableau, int pivotRow, int pivotCol)
        {
            double pivotValue = tableau[pivotRow, pivotCol];

            // Dividir la fila pivote por el valor pivote
            for (int j = 0; j < tableau.GetLength(1); j++)
            {
                tableau[pivotRow, j] /= pivotValue;
            }

            // Restar múltiplos de la fila pivote de las otras filas
            for (int i = 0; i < tableau.GetLength(0); i++)
            {
                if (i != pivotRow)
                {
                    double multiplier = tableau[i, pivotCol];
                    for (int j = 0; j < tableau.GetLength(1); j++)
                    {
                        tableau[i, j] -= multiplier * tableau[pivotRow, j];
                    }
                }
            }
        }

        // Método para imprimir el tableau
        static void PrintTableau(double[,] tableau)
        {
            for (int i = 0; i < tableau.GetLength(0); i++)
            {
                for (int j = 0; j < tableau.GetLength(1); j++)
                {
                    Console.Write($"{tableau[i, j],10:F2} ");
                }
                Console.WriteLine();
            }
        }
    }
}
    
