using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodoSimplexM
{
    class GaussJordan
    {
        Pivote p = new Pivote();
        Ecuacion e = new Ecuacion();
        public void GaussJ(int columPivote, float[,]sistmEc, string[,] matriz)
        {
            float min;
            int fila;
            float[] d;

            min = p.resultdoMasChico(columPivote, sistmEc);
            fila = p.definirFila(columPivote, min, sistmEc);
            d = valores(columPivote, fila, sistmEc);
            operacion(fila, d, sistmEc, matriz);
            Console.WriteLine("Matriz despues de las Operaciones");
            Console.WriteLine();
            e.ImprimirMatriz(matriz);
        }

        public float[] valores(int columPivote, int fila, float[,] sistmEc)
        {
            float[] d = new float[sistmEc.GetLength(0)];
            for (int i = 1; i < sistmEc.GetLength(0); i++)
            {
                d[i] = sistmEc[i, columPivote];
            }
            return d;
        }

        public float[,] operacion(int fila, float[] elemPivote, float[,]sistmEc, string[,] matriz)
        {
            float a;
            for (int i = 0; i < elemPivote.Length; i++)
            {
                a = elemPivote[i];
                if (i != fila && a !=0)
                {
                    if (a<0)
                    {
                        Console.WriteLine($"Operacion a realizar : R{i - 1} + {-1 * a}(R{fila - 1})");
                    }
                    else
                    {
                        Console.WriteLine($"Operacion a realizar : R{i - 1}-{a}(R{fila - 1})");
                    }
                    for (int j = 1; j < sistmEc.GetLength(1); j++)
                    {
                        float operacion = (sistmEc[i, j] - a * sistmEc[fila, j]);
                        sistmEc[i, j] = operacion;
                        matriz[i, j] = $"[{operacion}]";
                    }
                }
            }
            return sistmEc;
        }
        
    }
}
