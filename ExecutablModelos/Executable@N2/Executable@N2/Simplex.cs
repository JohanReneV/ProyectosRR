using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executable_N2
{
    class Simplex
    {
        private double[,] tableau; // Tableau de simplex
        private int numRows;
        private int numCols;

        public Simplex(double[,] tableau)
        {
            this.tableau = tableau;
            numRows = tableau.GetLength(0);
            numCols = tableau.GetLength(1);
        }

        // Método para resolver el problema
        public void Solve()
        {
            while (true)
            {
                // Encontrar la columna pivote (más negativo en la última fila)
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

                // Si no hay valores negativos en la última fila, terminamos
                if (pivotCol == -1)
                    break;

                // Encontrar la fila pivote usando la razón mínima
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

                // Realizar la operación de pivote
                Pivot(pivotRow, pivotCol);
            }

            // Mostrar la solución óptima
            PrintSolution();
        }

        // Método para realizar la operación de pivote
        private void Pivot(int pivotRow, int pivotCol)
        {
            double pivotValue = tableau[pivotRow, pivotCol];

            // Dividir la fila pivote por el valor pivote
            for (int j = 0; j < numCols; j++)
            {
                tableau[pivotRow, j] /= pivotValue;
            }

            // Restar múltiplos de la fila pivote de las otras filas
            for (int i = 0; i < numRows; i++)
            {
                if (i != pivotRow)
                {
                    double multiplier = tableau[i, pivotCol];
                    for (int j = 0; j < numCols; j++)
                    {
                        tableau[i, j] -= multiplier * tableau[pivotRow, j];
                    }
                }
            }
        }

        // Método para imprimir la solución
        private void PrintSolution()
        {
            Console.WriteLine("Solución óptima:");
            for (int i = 0; i < numRows - 1; i++)
            {
                Console.WriteLine($"x{i + 1} = {tableau[i, numCols - 1]}");
            }
            Console.WriteLine($"Valor óptimo: {tableau[numRows - 1, numCols - 1]}");
        }
    }
}

