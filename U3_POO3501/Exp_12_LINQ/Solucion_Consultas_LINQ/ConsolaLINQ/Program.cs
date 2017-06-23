using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsolaLINQ
{
    class Program
    {
        static List<int> numeros = new List<int>();
        static List<string> textos = new List<string>();

        static void Main(string[] args)
        {
            //Inicializo las listas
            numeros.AddRange(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            textos.AddRange(new string[]{"uno", "dos", "tres", "cuatro",
            "cinco", "seis", "siete", "ocho", "nueve"});

            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Ejemplo Select");
                Console.WriteLine("2. Ejemplo Where");
                Console.WriteLine("3. Ejemplo Count y Sum");
                Console.WriteLine("4. Ejemplo Min y Max");
                Console.WriteLine("5. Ejemplo Average");
                Console.WriteLine("6. Salir");
                Console.Write("Ingrese su opción: ");
                if (int.TryParse(Console.ReadLine(), out opcion) &&
                    (opcion >= 1 && opcion <= 6))
                {
                    switch (opcion)
                    {
                        case 1:
                            EjemploSelect();
                            Console.ReadKey();
                            break;
                        case 2:
                            EjemploWhere();
                            Console.ReadKey();
                            break;
                        case 3:
                            EjemploCountSum();
                            Console.ReadKey();
                            break;
                            /* Completar Case 4 y 5*/
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opción NO Existe!!!");
                }
            } while (opcion != 6);
        }

        private static void EjemploCountSum()
        {
            Console.Clear();
            Console.WriteLine("Funciones Count y Sum");
            var consulta1 = from n in numeros where n % 2 != 0 select n;
            Console.WriteLine("Números Impares: {0}", consulta1.Count());
            Console.WriteLine("Suma Impares: {0}", consulta1.Sum());
        }

        private static void EjemploWhere()
        {
            Console.Clear();
            Console.WriteLine("Números Pares");
            var consulta1 = from n in numeros where n % 2 == 0 select n;
            foreach (var item in consulta1)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();

            Console.WriteLine("Textos Mayores a 5 caracteres");
            foreach (string item in textos.Where(t => t.Length >= 5))
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
            Console.WriteLine("Textos Mayores a 4 caracteres en Mayúsculas");
            foreach (string item in textos.Where(t => t.Length >= 5).Select(t => t.ToUpper()))
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();            
        }

        private static void EjemploSelect()
        {
            Console.WriteLine("Consultas Select");
            /*Numeros*/
            Console.WriteLine("Números");
            var consulta1 = from n in numeros select n;
            foreach (var item in consulta1)
            {
                Console.Write("{0} ", item);
            }
            /*Textos*/
            Console.WriteLine("\nTextos");
            var consulta2 = from txt in textos select txt;
            foreach (var item in consulta2)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine("\nPresione una tecla para Continuar....");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Select con Transformación");
            Console.WriteLine("\n\tNúmeros Múltiplos");
            var consulta3 = from n in numeros select n * 10;
            foreach (var item in consulta3)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
            Console.WriteLine("\n\tTextos en Mayúscula");
            foreach (string item in textos.Select(t => t.ToUpper()))
            {
                Console.Write("{0} ", item);
            }
        }
    }
}
