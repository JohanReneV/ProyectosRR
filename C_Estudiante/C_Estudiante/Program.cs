using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Estudiante
{
    class Program
    {
        static void Main(string[] args)
        {
            int cantidadCursos = ValidadorNota.CantidadCursos();
            Curso[] cursos = new Curso[cantidadCursos];

            for (int j = 0; j < cantidadCursos; j++)
            {
                int cantidadEstudiantes = ValidadorNota.CantidadEstudiantes();
                Estudiante[] estudiantes = new Estudiante[cantidadEstudiantes];

                for (int i = 0; i < cantidadEstudiantes; i++)
                {
                    do
                    {
                        try
                        {
                            // Utilizar la clase InterfazUsuario para solicitar los datos del estudiante
                            Interface.SolicitarDatosEstudiante(out string codigo, out int edad, out double nota1, out double nota2, out double nota3, out double nota4, out double nota5); ;

                            // Crear una instancia de la clase Estudiante con los datos proporcionados
                            Estudiante estudiante = new Estudiante
                            {
                                Codigo = codigo,
                                Edad = edad,
                                Nota1 = nota1,
                                Nota2 = nota2,
                                Nota3 = nota3,
                                Nota4 = nota4,
                                Nota5 = nota5,
                            };

                            // Almacenar el estudiante en el arreglo
                            estudiantes[i] = estudiante;

                            // Romper el bucle ya que los datos son válidos
                            break;
                        }
                        catch (NotaInvalidaException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                            Console.WriteLine("Por favor, Volver a ingresar datos.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error general: {ex.Message}");
                        }
                    } while (true); // El bucle se ejecutará hasta que se proporcionen valores válidos
                }

                // Crear una instancia de la clase Curso con los estudiantes proporcionados
                Curso curso = new Curso(estudiantes);

                // Mostrar información de todos los estudiantes en el curso actual
                //Console.WriteLine($"\nInformación de todos los estudiantes en el Curso {j + 1}:");
                //for (int i = 0; i < cantidadEstudiantes; i++)
                //{
                //    Console.WriteLine("......Estudiante....... " + (i + 1));
                //    Interface.MostrarDetallesEstudiante(estudiantes[i], curso);
                //}

                // Almacenar el curso en el arreglo de cursos
                cursos[j] = curso;
            }

            Console.WriteLine("-----------------------------------------------------------------------------------");
            // Mostrar información de todos los cursos
            for (int j = 0; j < cantidadCursos; j++)
            {
                Console.WriteLine("-----Informacion del curso----- " + (j+1));
                Interface.MostrarDetallesCurso(cursos[j]);
            }

            Console.ReadKey(); // Esperar a que el usuario presione una tecla antes de cerrar la aplicación
        }
    }
}
