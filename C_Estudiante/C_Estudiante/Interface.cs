using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Estudiante
{
    class Interface
    {

        public static void SolicitarDatosEstudiante(out string codigo,out int edad, out double nota1, out double nota2, out double nota3, out double nota4, out double nota5)
        {
            codigo = ValidadorNota.ValidarCodigo("Ingrese Codigo:  ");
            edad = ValidadorNota.ValidarEdad("Ingrese edad:  ");

            nota1 = ValidadorNota.LeerNota("Ingrese la primera nota del estudiante: ");
            nota2 = ValidadorNota.LeerNota("Ingrese la segunda nota del estudiante: ");
            nota3 = ValidadorNota.LeerNota("Ingrese la tercera nota del estudiante: ");

            Console.WriteLine("-----------------------------------");

            nota4 = ValidadorNota.LeerNota("Ingrese la cuarta nota del estudiante: ");
            nota5 = ValidadorNota.LeerNota("Ingrese la quinta nota del estudiante: ");
        }



        public static void MostrarDetallesEstudiante(Estudiante estudiante, Curso curso)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Código: {estudiante.Codigo}");
            Console.WriteLine($"Edad: {estudiante.Edad}");
            Console.WriteLine($"Nota 70 %: {estudiante.CalcularNota70()}");
            Console.WriteLine($"Nota 30 %: {estudiante.CalcularNota30()}");
            Console.WriteLine($"Nota Final : {estudiante.CalcularNotaF()}");
            Console.WriteLine("---------------------------------");

            
            Console.WriteLine($"Resultado del estudiante :  {curso.VerificarAprobacion()}");
        }

        public static void MostrarDetallesCurso(Curso curso)
        {
            Console.WriteLine($"----------Detalles del Curso-----------------");
            Console.WriteLine($"Cantidad de Estudiantes: {curso.Estudiantes.Length}");

            int aprobados = 0;
            int reprobados = 0;
            double promedio70 = 0;
            double promedio30 = 0;

            // Mostrar información de cada estudiante en el curso
            for (int i = 0; i < curso.Estudiantes.Length; i++)
            {
                Console.WriteLine("----Estudiante-- " + (i+1));
                MostrarDetallesEstudiante(curso.Estudiantes[i], curso);

                // Calcular promedio del 70%
                promedio70 += curso.Estudiantes[i].CalcularNota70();

                // Calcular promedio del 30%
                promedio30 += curso.Estudiantes[i].CalcularNota30();

                // Verificar aprobación
                if (curso.Estudiantes[i].CalcularNotaF() >= curso.NotaAprobacion)
                {
                    aprobados++;
                }
                else
                {
                    reprobados++;
                }
            }

            // Calcular promedios finales
            promedio70 /= curso.Estudiantes.Length;
            promedio30 /= curso.Estudiantes.Length;

            // Mostrar resumen del curso
            Console.WriteLine("\nResumen del Curso:");
            Console.WriteLine($"Promedio del 70% del Curso: {promedio70}");
            Console.WriteLine($"Promedio del 30% del Curso: {promedio30}");
            Console.WriteLine("Promedio de Edad: " + curso.CalcularEdadPromedio());
            Console.WriteLine("La Edad mayor es: " + curso.ObtenerMayorEdad());
            Console.WriteLine("La Mayor nota es: " + curso.ObtenerMayorNotayMenor().Item1);
            Console.WriteLine("La Menor nota es: " + curso.ObtenerMayorNotayMenor().Item2);
            Console.WriteLine($"Promedio Total del Curso: {curso.CalcularPromedioCurso()}");
            Console.WriteLine("Cantidad de estudiantes aprobados " + aprobados);
            Console.WriteLine("Cantidad de estudiantes Reprobados " + reprobados);

        }
    }
}
