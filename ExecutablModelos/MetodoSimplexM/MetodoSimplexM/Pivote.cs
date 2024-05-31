using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodoSimplexM
{
    class Pivote
    {
        public float BuscarValor(float[,] sistmaEc, char opcion,int desicion)
        {
            float valor = 0;
            float valX = sistmaEc[1, 1];
            float varY = sistmaEc[1, 2];
            string coordinate = "X";

            switch (opcion)
            {
                case 'M':
                    foreach(float number in sistmaEc) 
                    {
                        if (coordinate == "X")//Encontrar el valor mas pequeño coordenada X
                        {
                            if (number < valX)
                            {
                                valX = number;
                                coordinate = "Y";
                            }
                        }
                        else if (coordinate == "Y")//Encontrar el valor mas pequeño coordenada Y
                        {
                            if (number < varY)
                            {
                                varY = number;
                                coordinate = "X";
                            }
                        }
                    }
                    if (valX < varY)//Definir cual es el valor mas chico de todo el arreglo
                    {
                        valor = valX;
                    }
                    else
                    {
                        valor = varY;
                    }
                    Console.WriteLine($"El elemento mas chico de la Matriz es : {valor}");
                    break;
                case 'm':
                    float max = sistmaEc[1, 1];
                    for (int f = 1; f < sistmaEc.GetLength(0); f++)
                    {
                        for (int c = 0; c < desicion+2; c++)
                        {
                            if (max < sistmaEc[f,c])
                            {
                                max = sistmaEc[f, c];
                                valor = max;
                            }
                        }
                    }
                    Console.WriteLine($"El Elemento mas grande de la matriz es : {valor}");
                    break;
            }
            return valor;
        }

        public int DefinirColumnaPivote(float valor, float[,] sistmaEc)
        {
            int columnaPivote = 0;
            int contador = 0;
            float b = 0;
            float a = 0;
            for (int i = 1; i < sistmaEc.GetLength(0); i++)
            {
                for (int j = 0; j < sistmaEc.GetLength(1); j++)
                {
                    if (sistmaEc[i,j] == valor)
                    {
                        contador++;
                        if (contador>1)
                        {
                            Console.WriteLine($"El numero {valor} fue encontrado en mas de una ocacion...");
                            b = resultdoMasChico(j, sistmaEc);
                            if (b<a)
                            {
                                columnaPivote = j;
                            }
                        }
                        else
                        {
                            columnaPivote = j; //Aun falta considerar que pasa si un mismo valor se encuentra en diferente posicion de la misma columna
                            a = resultdoMasChico(j, sistmaEc);
                        }
                    }
                }
            }
            Console.WriteLine($"Por lo tanto, la columna pivote es X{columnaPivote - 1}");
            return columnaPivote;
        }

        public float DefinirElementoPivote(int columPivote, float[,]sistmaEc, string[,] matriz)
        {
            float elemPivote = 0;
            float min;
            int fila;
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Definimos cual sera nuestro elemento pivote.....");
            min = resultdoMasChico(columPivote, sistmaEc);
            fila = definirFila(columPivote, min, sistmaEc);

            //Encontrar el elemento Pivote

            Ecuacion e = new Ecuacion();
            elemPivote = sistmaEc[fila, columPivote];
            if (elemPivote>1)
            {
                Console.WriteLine($"Entonces, el elemento pivote es : {elemPivote}");
                Console.WriteLine($"Pero, {elemPivote} es mayor que '1' por lo tanto, se divide el elemento pivote entre si mismo.");
                Console.WriteLine($"Esto afectara a toda la fila {fila}");
                Console.WriteLine("");
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("");
                establecerPivote(elemPivote, fila, sistmaEc, matriz);
                Console.WriteLine($"Por lo tanto, el elemento pivote se encuentra en h{fila-1},x{columPivote-1}");
                Console.WriteLine($"matriz despues de la operacion 'R{fila-1} / {elemPivote}");
                e.ImprimirMatriz(matriz);
            }
            else
            {
                Console.WriteLine($"La columna pivote es X{columPivote-1}");
                Console.WriteLine($"Entonces, el elemento pivote es : {elemPivote}");
                e.ImprimirMatriz(matriz);
            }
            return elemPivote;
        }

        public int definirFila(int columnPivote, float min, float[,] sistmEc)
        {
            int f = 0;
            int sol = sistmEc.GetLength(1) - 1;
            for (int fila = 1; fila < sistmEc.GetLength(0); fila++)
            {
                if (sistmEc[fila,sol]/sistmEc[fila,columnPivote]==min)
                {
                    f = fila;
                    break;
                }
            }
            return f;
        }

        public float resultdoMasChico(int ColumPivote, float[,] sistmEC)
        {
            int sol = sistmEC.GetLength(1)- 1;
            int filas = sistmEC.GetLength(0);
            float[] resultados = new float[sistmEC.GetLength(0)];
            Console.WriteLine("");
            Console.WriteLine("Dividir los elementos de la columna pivote entre la columna solucion");
            for (int i = 1; i < filas; i++)
            {
                if (sistmEC[i,ColumPivote]<0 || sistmEC[i,ColumPivote]>0)
                {
                    if (sistmEC[i,sol]==0)
                    {
                        resultados[i] = 0;
                    }
                    else
                    {
                        float dato = (sistmEC[i, sol] / sistmEC[i, ColumPivote]);
                        Console.WriteLine($"{sistmEC[i, sol]}/ {sistmEC[i, ColumPivote]}={dato}");
                        resultados[i] = dato;//Almacenar el resultado de las diviciones
                    }
                }
            }
            Console.WriteLine("");
            //definir el resultado mas chico del arreglo de resultado
            float min = resultados.Where(x => x > 0).Min();
            Console.WriteLine($"El resultado mas chico y mayor que cero de las divisiones es : {min}");

            return min;
        }
        
        public void establecerPivote(float pivote, int fila, float[,] sistmEc, string[,] matriz)
        {
            for (int columna = 0; columna < sistmEc.GetLength(1); columna++)
            {
                if (sistmEc[fila,columna]%pivote ==0)
                {
                    float resultado = sistmEc[fila, columna] / pivote;
                    sistmEc[fila, columna] = resultado;
                    matriz[fila, columna] = $"[{resultado.ToString()}]";
                }
                else
                {
                    float resultado = sistmEc[fila, columna] / pivote;
                    sistmEc[fila, columna] = resultado;
                    matriz[fila, columna] = $"[{resultado.ToString()}]";
                }
            }
        }
    }
}
