using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Estudiante
{
    public static class ValidadorNota 
    {


        public static double LeerNota(string mensaje)
        {
            while (true)
            {
                try
                {
                    Console.Write(mensaje);
                    string input = Console.ReadLine();
                    double nota = double.Parse(input);

                    if (EsNotaValida(nota))
                    {
                        return nota;
                    }
                    else
                    {
                        Console.WriteLine("Por favor, ingrese un número válido en el rango de 0 a 5.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("El número ingresado es demasiado grande o demasiado pequeño.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Ha ocurrido un error inesperado.");
                }
            }
        }



        private static bool EsNotaValida(double nota)
        {
            return nota >= 0 && nota <= 5;
        }


        public static string ValidarCodigo(string mensaje)
        {
            while (true)
            {
                try
                {
                    Console.Write(mensaje);
                    string codigo = Console.ReadLine();

                    // Verificar que el código tenga exactamente 5 espacios
                    if (codigo.Length !=5)
                    {
                        throw new NotaInvalidaException("El código debe tener exactamente 5 caracteres ");
                    }

                    // Si el código es válido, devolverlo
                    return codigo;
                }
                catch (NotaInvalidaException ex)
                {
                    // Lanzar la excepción para que sea capturada en la función que llama a ValidarCodigo
                    throw ex;
                }
                catch (Exception)
                {
                    Console.WriteLine("Ha ocurrido un error inesperado al validar el código.");
                }
            }
        }


        public static int ValidarEdad(string mensaje)
        {
            while (true)
            {
                try
                {
                    Console.Write(mensaje);
                    string input = Console.ReadLine();

                    // Try to parse the input as an integer
                    if (!int.TryParse(input, out int edad))
                    {
                        throw new NotaInvalidaException("La entrada debe ser un número entero.");
                    }

                    // Validate that the age is between 0 and 100
                    if (edad < 0 || edad > 100)
                    {
                        throw new NotaInvalidaException("La edad debe estar entre 0 y 100.");
                    }

                    // If the input is valid, return the age
                    return edad;
                }
                catch (NotaInvalidaException ex)
                {
                    // Re-throw the exception to be caught in the calling function
                    throw ex;
                }
                catch (Exception)
                {
                    Console.WriteLine("Ha ocurrido un error inesperado al validar la edad.");
                }
            }
        }

        public static int CantidadCursos()
        {
            int cantidadCursos;
            do
            {
                try
                {
                    Console.Write("Cantidad de cursos: ");
                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out cantidadCursos) || cantidadCursos <= 0)
                    {
                        throw new NotaInvalidaException("Por favor, ingrese un valor numérico válido mayor que cero.");
                    }

                    // La entrada es un número válido y mayor que cero
                    break;
                }
                catch (NotaInvalidaException  ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error general: {ex.Message}");
                }
            } while (true);

            return cantidadCursos;
        }

        public static int CantidadEstudiantes()
        {
            int cantidadEstudiantes;
            do
            {
                try
                {
                    Console.Write("Cantidad de Estudiantes: ");
                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out cantidadEstudiantes) || cantidadEstudiantes <= 0)
                    {
                        throw new NotaInvalidaException("Por favor, ingrese un valor numérico válido mayor que cero.");
                    }

                    // La entrada es un número válido y mayor que cero
                    break;
                }
                catch (NotaInvalidaException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error general: {ex.Message}");
                }
            } while (true);

            return cantidadEstudiantes;
        }
    }



}
