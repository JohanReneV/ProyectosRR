using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Estudiante
{
    class CalcularNotas
    {
        public static double CalcularNota70(double nota1, double nota2, double nota3)
        {

            // Verificar que las notas estén en el rango válido (0-5)
            if (nota1 < 0 || nota1 > 5 || nota2 < 0 || nota2 > 5 || nota3 < 0 || nota3 > 5)
            {
                throw new ArgumentException("Las notas deben estar en el rango de 0 a 5.");
            }


            double nota70 = (nota1 * 0.2) + (nota2 * 0.25) + (nota3 * 0.25);
            // Calcular y retornar la nota del 70
            return nota70;
        }

        public static double CalcularNota30(double nota4, double nota5)
        {
            // Verificar que las notas estén en el rango válido (0-5)
            if (nota4 < 0 || nota4 > 5 || nota5 < 0 || nota5 > 5 )
            {
                throw new ArgumentException("Las notas deben estar en el rango de 0 a 5.");
            }

            double nota30 = (nota4 * 0.2) + (nota5 * 0.1);
            // Calcular y retornar la nota del 30
            return nota30;
        }


        //private bool EsNumeroValido(double valor){
        //    return valor >= 0 && valor <= 5;
        //}
    }
}
