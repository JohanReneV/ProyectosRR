using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodoSimplexM
{
    class Program
    {
        static void Main(string[] args)
        {
            int columnas = 1; //Dato del cual dependen las columnas de la Matriz
            int desicion;
            int filas = 1; //Dato del cual dependen las filas de la Matriz
            int restriccion;
            int clmSol;
            bool finalizado;
            char opcion;


            float[,] sistmaEc;
            string[,] matriz;
            float valor;
            int columPivote;


            Console.WriteLine("-----EXECUTABLE PARA SOLUCIONAR POR EL METODO SIMPLES (MAXIMIZAR Y MINIMIZAR)-------");
            Console.WriteLine("----- Jhojan Rene Vera-Bairon -----");
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine("¿Cuantas variables de desicion hay?");
            desicion = int.Parse(Console.ReadLine());
            clmSol = desicion + 2;
            columnas += desicion;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine("¿Cuantas restricciones hay?");
            restriccion = int.Parse(Console.ReadLine());
            filas += restriccion;
            columnas += filas + 1;
            filas++;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine("¿Maximizar (M) o Minimizar (m) la funcion objetivo?");
            opcion = char.Parse(Console.ReadLine());


            Ecuacion e = new Ecuacion();
            Pivote p = new Pivote();
            GaussJordan g = new GaussJordan();


            matriz = e.CrearMatriz(desicion, filas, columnas);
            sistmaEc = e.EstablecerMatriz(desicion, filas, columnas, matriz, opcion);
            finalizado = e.Solucion(filas, clmSol, restriccion, sistmaEc);
            Console.Clear();


            //repite el proceso hasta que exista la matriz unidad

            while (finalizado == false) 
            {
                valor = p.BuscarValor(sistmaEc, opcion, desicion);
                columPivote = p.DefinirColumnaPivote(valor,sistmaEc);
                p.DefinirElementoPivote(columPivote, sistmaEc, matriz);
                g.GaussJ(columPivote, sistmaEc, matriz);
                finalizado = e.Solucion(filas, clmSol, restriccion, sistmaEc);
            }

            e.MostrarSolucion(desicion, sistmaEc, matriz);
            Console.ReadKey();
        }
    }
}
