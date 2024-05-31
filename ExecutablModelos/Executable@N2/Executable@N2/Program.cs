using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executable_N2
{
    class Program
    {
        static void Main(string[] args)
        {

            // Funcion 3x1+5x2
            // Restricciones
            // 2𝑥1+3𝑥2 ≤ 100
            // 4𝑥1+𝑥2  ≤ 80​

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

            Console.WriteLine("Ingrese los coeficientes de las restricciones (incluyendo las variables de holgura y el término independiente):");
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

            Console.WriteLine("Ingrese los coeficientes de la función objetivo (use valores negativos si está maximizando):");
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

            Simplex simplex = new Simplex(tableau);
            simplex.Solve();

            Console.ReadLine();
        }

    }
    
}
