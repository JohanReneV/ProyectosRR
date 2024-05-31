using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodoSimplexM
{
    class Ecuacion
    {
        public string [,] CrearMatriz(int d, int f, int c)
        {
            int xsubind = 1;
            int hsubind = 1;
            string[,] matriz = new string[f, c];
            for (int i = 1; i < f; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (j==c-1)
                    {
                        matriz[i, j] = $"[b{i}]";
                    }
                    else
                    {
                        matriz[0, j] = $"[x{j - 1}]";
                        matriz[i, j] = $"[a{i},{j}]";
                        if (j-1>d)
                        {
                            matriz[0, j] = $"[h{j - d - 1}]";
                        }
                    }
                }
                matriz[i, 0] = $"[h{i - 1}]";
            }
            matriz[0, 0] = "    ";
            matriz[1, 0] = $"[Z]";
            matriz[0, 1] = $"[Z]";
            matriz[0, c - 1] = "[Sol]";
            return matriz;
        }

        public float[,] EstablecerMatriz(int d, int f, int c, string[,]matriz,char operc)
        {
            float[,] sistmaEc = new float[f, c];
            //llena el formulario con los coeficientes de usuario
            for (int i = 1; i < f; i++)
            {
                for (int j = 1; j < c; j++)
                {
                    string x;
                    if (j==c-1)
                    {
                        Console.WriteLine($"¿Cual es la solucin de la posicion b{i}?");
                        x = Console.ReadLine();
                        sistmaEc[i, j] = int.Parse(x);
                        matriz[i, j] = $"[{x}]";
                    }
                    else
                    {
                        if (j-1>d)
                        {
                            if (i>0 && j== i+d)
                            {
                                if (operc == 'm' )
                                {
                                    Console.WriteLine($"¿Esta restriccion 'R{i - 1}' es menor que (p), o mayor que (n)?");
                                    char opc = char.Parse(Console.ReadLine());
                                    switch (opc)
                                    {
                                        case 'p':
                                            sistmaEc[i, j] = 1;
                                            matriz[i, j] = "[1]";
                                            break;
                                        case 'n':
                                            sistmaEc[i, j] = -1;
                                            matriz[i, j] = "[-1]";
                                            break;
                                    }
                                }
                                else
                                {
                                    sistmaEc[i, j] = 1;
                                    matriz[i, j] = "[1]";
                                }
                            }
                            else
                            {
                                sistmaEc[i, j] = 0;
                                matriz[i, j] = "[0]";
                            }
                        }
                        else
                        {
                            Console.WriteLine($"¿Cual es el coeficiente de tu variable en la posicion a{i},{j}?");
                            x = Console.ReadLine();
                            sistmaEc[i, j] = int.Parse(x);
                            matriz[i, j] = $"[{x}]";
                        }
                    }
                    ImprimirMatriz(matriz);
                }
            }
            return sistmaEc;
        }

        public void ImprimirMatriz(string[,] matriz)
        {
            int fila = matriz.GetLength(0);
            int columna = matriz.GetLength(1);
            for (int i = 0; i < fila; i++)
            {
                for (int j = 0; j < columna; j++)
                {
                    Console.Write(string.Format("{0}", matriz[i, j]));//imprime tablero con formato cuadrado
                }
                Console.Write(Environment.NewLine + Environment.NewLine);//imprime table con formato cuadrado
            }
        }


        public bool Solucion(int filas, int columnas, int restriccion, float[,] a)
        {
            int contUno = 0;
            int contCero = 0;
            bool finalizado = false;
            for (int i = 1; i < filas; i++)
            {
                for (int j = 1; j < columnas; j++)
                {
                    if (a[i,j]==1)
                    {
                        contUno++;
                    }
                    else if (a[i,j]==0)
                    {
                        contCero++;
                    }
                }
            }
            filas--;
            columnas--;
            int total = filas * columnas;
            int sumCont = contUno + contCero;
            if (sumCont == total)
            {
                finalizado = true;
            }
            return finalizado;
        }

        public void MostrarSolucion(int d, float[,] ec, string[,] mat)
        {
            for (int i = 0; i < ec.GetLength(0); i++)
            {
                for (int j = 0; j <= d; j++)
                {
                    if (ec[i,j]==1)
                    {
                        Console.WriteLine($"La Solucion de {mat[i, 0]} es : {ec[i, ec.GetLength(1) - 1]}");
                    }
                }
            }
        }
    }
}
