using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Estudiante
{
    public class Estudiante
    {
        public string Codigo;
        public double Nota1, Nota2, Nota3, Nota4, Nota5;
        public int Edad;


        public Estudiante()
        {
        }


        public double CalcularNota70()
        {
            return (Nota1 * 0.2) + (Nota2 * 0.25) + (Nota3 * 0.25);
        }

        public double CalcularNota30()
        {
            return (Nota4 * 0.2) + (Nota5 * 0.1);
        }

        public double CalcularNotaF()
        {
            return CalcularNota70() + CalcularNota30();
        }
    }

}

