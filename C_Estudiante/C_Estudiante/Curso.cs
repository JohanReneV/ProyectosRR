using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Estudiante
{
    public class Curso
    {
        public Estudiante[] Estudiantes;
        public double NotaAprobacion;

        public Curso(Estudiante[] estudiantes)
        {
            Estudiantes = estudiantes;
            NotaAprobacion = 3;
        }

        public string VerificarAprobacion()
        {
            StringBuilder resultado = new StringBuilder();

            foreach (var estudiante in Estudiantes)
            {
                //if (estudiante == null)
                //{
                //    resultado.AppendLine("No se ha establecido un estudiante para el curso.");
                //}
                //else
                {
                    double notaFinal = estudiante.CalcularNotaF();

                    if (notaFinal >= NotaAprobacion)
                    {
                        resultado.AppendLine($"{estudiante.Codigo} ha aprobado el curso con una nota final de {notaFinal}.");
                    }
                    else
                    {
                        resultado.AppendLine($"{estudiante.Codigo} no ha aprobado el curso. La nota final obtenida es {notaFinal}.");
                    }
                }
            }

            return resultado.ToString();
        }

        public double CalcularPromedioCurso()
        {
            if (Estudiantes == null || Estudiantes.Length == 0)
            {
                return 0;
            }

            double sumaPromedios70 = 0;
            double sumaPromedios30 = 0;

            foreach (var estudiante in Estudiantes)
            {
                sumaPromedios70 += estudiante.CalcularNota70();
                sumaPromedios30 += estudiante.CalcularNota30();
            }

            double promedio70 = sumaPromedios70 / Estudiantes.Length;
            double promedio30 = sumaPromedios30 / Estudiantes.Length;   

            // Devolver el promedio total del curso
            return (promedio70 * 0.7) + (promedio30 * 0.3);
        }

        //Calcular edad promedio
        public int CalcularEdadPromedio()
        {
            if (Estudiantes == null || Estudiantes.Length == 0)
            {
                return 0;
            }

            int sumaDeEdades = 0;

            foreach (var estudiante in Estudiantes)
            {
                sumaDeEdades += estudiante.Edad;
            }

            return sumaDeEdades / Estudiantes.Length;
        }
        //Calcular Edad Mayor
        public int ObtenerMayorEdad()
        {
            if (Estudiantes == null || Estudiantes.Length == 0)
            {
                return 0;
            }

            int mayorEdad = Estudiantes[0].Edad;

            foreach (var estudiante in Estudiantes)
            {
                if (estudiante.Edad > mayorEdad)
                {
                    mayorEdad = estudiante.Edad;
                }
            }
            return mayorEdad;
        }


        public (double,double) ObtenerMayorNotayMenor()
        {
            if (Estudiantes == null || Estudiantes.Length == 0)
            {
                return (0, 0);
            }

            double mayorNota = Estudiantes[0].CalcularNotaF();
            double menorNota = Estudiantes[0].CalcularNotaF();

            foreach (var estudiante in Estudiantes)
            {
                double notaFinal = estudiante.CalcularNotaF();

                if (notaFinal > mayorNota)
                {
                    mayorNota = notaFinal;
                }

                if (notaFinal < menorNota)
                {
                    menorNota = notaFinal;
                }
            }

            return (mayorNota, menorNota);
        }
    }   
}


