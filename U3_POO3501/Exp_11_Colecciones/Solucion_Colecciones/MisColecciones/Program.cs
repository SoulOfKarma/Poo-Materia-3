using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Add
using System.Collections;
using BibliotecaPersonas;

namespace MisColecciones
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.WriteLine("1. Manejo ArrayList");
                Console.WriteLine("2. Manejo List");
                Console.WriteLine("3. Manejo Hashtable");
                Console.WriteLine("4. Salir");
                Console.Write("Ingrese su opción: ");
                if (int.TryParse(Console.ReadLine(), out opcion) && (opcion >= 1 && opcion <= 4))
                {
                    switch (opcion)
                    {
                        case 1:
                            ManejoArrayList();
                            break;
                        case 2:
                            ManejoList();
                            break;
                        case 3:
                            ManejoHashtable();
                            break;

                        default:
                            break;
                    }
                }
            } while (opcion != 4);

        }

        private static void ManejoHashtable()
        {
            Hashtable coleccionPersona = new Hashtable();
            int opcion = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("1.-Carga Personas.");
                Console.WriteLine("2.-Agregar Persona.");
                Console.WriteLine("3.-Insertar Persona.");
                Console.WriteLine("4.-Eliminar Persona.");
                Console.WriteLine("5.-Volver.");
                Console.Write("Ingrese su opción: ");
                if (int.TryParse(Console.ReadLine(), out opcion) && (opcion >= 1 && opcion <= 4))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("Ingrese cantidad de personas que creará (1-5): ");
                            int largo = 0;
                            if (int.TryParse(Console.ReadLine(), out largo) && (largo > 0 && largo <= 5))
                            {
                                for (int i = 0; i < largo; i++)
                                {
                                    Persona persona = new Persona();
                                    persona.Rut = i;
                                    persona.Apellido = string.Format("Apellido {0}", i);
                                    persona.Nombre = string.Format("Nombre {0}", i);
                                    coleccionPersona.Add(persona.Rut, persona);
                                }
                                MostrarHashtable(coleccionPersona);
                            }
                            else
                            {
                                Console.WriteLine("Debe ser un Número entre 1 y 5!!");
                            }
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.Write("\nIngrese RUT: ");
                            int rut = 0;
                            if (int.TryParse(Console.ReadLine(), out rut))
                            {
                                Persona persona = new Persona();
                                persona.Rut = rut;
                                Console.Write("\nIngrese Nombre: ");
                                persona.Nombre = Console.ReadLine();
                                Console.Write("\nIngrese Apellido: ");
                                persona.Apellido = Console.ReadLine();
                                coleccionPersona.Add(persona.Rut, persona);
                                MostrarHashtable(coleccionPersona);
                            }
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.Write("\nIngrese Posición: ");
                            int pos = 0;
                            if (int.TryParse(Console.ReadLine(), out pos) && (coleccionPersona.Count >= pos - 1))
                            {
                                Console.Write("\nIngrese RUT: ");
                                int newRut = 0;
                                if (int.TryParse(Console.ReadLine(), out newRut))
                                {
                                    //Continuar....
                                }
                            }
                            else
                            {
                                Console.WriteLine("Debe ser un Número y posición en Rango!!");
                            }
                            Console.ReadKey();
                            break;
                        case 4:
                            break;
                    }

                }
            } while (opcion != 5);

        }

        private static void MostrarHashtable(Hashtable coleccionPersona)
        {
            foreach (DictionaryEntry item in coleccionPersona)
            {
                Persona persona = new Persona();
                persona = (Persona)item.Value;
                Console.WriteLine("{0}   {1}    {2}", persona.Rut, persona.Nombre, persona.Apellido);
            }
        }

        private static void ManejoList()
        {
            int opc;
            List<int> lista = new List<int>();
            do
            {
                Console.Clear();
                Console.WriteLine("1.-Carga List.");
                Console.WriteLine("2.-Agregar Elemento.");
                Console.WriteLine("3.-Insertar Elemento.");
                Console.WriteLine("4.-Eliminar Elemento.");
                Console.WriteLine("5.-Eliminar por posición.");
                Console.WriteLine("6.-Volver.");
                Console.Write("Ingrese su opción: ");
                if (int.TryParse(Console.ReadLine(), out opc) && (opc >= 1 && opc <= 6))
                {
                    switch (opc)
                    {
                        case 1:
                            Console.Write("Ingrese tamaño de la colección (5-10): ");
                            int largo = 0;
                            if (int.TryParse(Console.ReadLine(), out largo) && (largo >= 5 && largo <= 10))
                            {
                                for (int i = 0; i < largo; i++)
                                {
                                    lista.Add((i + 1) * 10);
                                }
                                MostrarList(lista);
                            }
                            else
                            {
                                Console.WriteLine("Debe ser un Número entre 5 y 10!!");
                            }
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.Write("Ingrese nuevo número a la colección: ");
                            int nuevoNum = 0;
                            if (int.TryParse(Console.ReadLine(), out nuevoNum))
                            {
                                lista.Add(nuevoNum * 10);
                                MostrarList(lista);
                            }
                            else
                            {
                                Console.WriteLine("Debe ser un Número!!");
                            }
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.Write("Ingrese nuevo número a la colección: ");
                            int nuevoNum2;
                            if (int.TryParse(Console.ReadLine(), out nuevoNum2))
                            {
                                Console.Write("\nIngrese posición dónde insertar Nuevo número: ");
                                int pos = 0;
                                if (int.TryParse(Console.ReadLine(), out pos) && (lista.Count >= pos - 1))
                                {
                                    lista.Insert(pos - 1, nuevoNum2 * 10);
                                    MostrarList(lista);
                                }
                                else
                                {
                                    Console.WriteLine("Posición Incorrecta!!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Debe ser un Número!!");
                            }
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.Write("Ingrese número a eliminar de la colección: ");
                            int dropNum = 0;
                            if (int.TryParse(Console.ReadLine(), out dropNum))
                            {
                                if (lista.Contains(dropNum))
                                {
                                    lista.Remove(dropNum);
                                    Console.WriteLine("Número Eliminado con Exito!!");
                                    MostrarList(lista);
                                }
                                else
                                {
                                    Console.WriteLine("Elemento NO Existe en la Colección!!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Debe ser un Número!!");
                            }
                            Console.ReadKey();
                            break;
                        case 5:
                            Console.Write("\nIngrese posición del número a eliminar: ");
                            int posD = 0;
                            if (int.TryParse(Console.ReadLine(), out posD) && (lista.Count >= posD - 1))
                            {
                                lista.RemoveAt(posD - 1);
                                Console.WriteLine("Número Eliminado con Exito!!");
                                MostrarList(lista);
                            }
                            else
                            {
                                Console.WriteLine("Posición Incorrecta!!");
                            }
                            Console.ReadKey();
                            break;
                    }
                }
            } while (opc != 6);

        }

        private static void MostrarList(List<int> lista)
        {
            foreach (var varAux in lista)
            {
                Console.WriteLine(varAux);
            }
        }

        private static void ManejoArrayList()
        {
            int opc;
            ArrayList ejemArrayList = new ArrayList();
            do
            {
                Console.Clear();
                Console.WriteLine("\t\tAgregar Elementos al Arraylist.");
                Console.WriteLine("1.-Carga Arraylist.");
                Console.WriteLine("2.-Agregar Elemento.");
                Console.WriteLine("3.-Insertar Elemento.");
                Console.WriteLine("\n\n\t\tEliminar Elementos al Arraylist.");
                Console.WriteLine("4.-Eliminar Elemento.");
                Console.WriteLine("5.-Eliminar por posición.");
                Console.WriteLine("6.-Volver.");
                Console.Write("Ingrese su opción: ");
                if (int.TryParse(Console.ReadLine(), out opc) && (opc >= 1 && opc <= 6))
                {
                    switch (opc)
                    {
                        case 1:
                            Console.Write("Ingrese tamaño de la colección (5-10): ");
                            int largo;
                            if (int.TryParse(Console.ReadLine(), out largo) && (largo >= 5 && largo <= 10))
                            {
                                for (int i = 0; i < largo; i++)
                                {
                                    ejemArrayList.Add("Elemento " + i);
                                }
                                MostrarArrayList(ejemArrayList);
                            }
                            else
                            {
                                Console.WriteLine("Tamaño Erróneo 5-10!!");
                            }
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.Write("Ingrese un nuevo elemento: ");
                            ejemArrayList.Add(Console.ReadLine());
                            MostrarArrayList(ejemArrayList);
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.Write("Ingrese posición para el nuevo elemento: ");
                            int pos = int.Parse(Console.ReadLine());
                            if (ejemArrayList.Count >= pos)
                            {
                                Console.Write("Ingrese un nuevo elemento: ");
                                ejemArrayList.Insert(pos, Console.ReadLine());
                                MostrarArrayList(ejemArrayList);
                            }
                            else
                            {
                                Console.WriteLine("Posición No Existe en la Colección!!");
                            }
                            Console.ReadKey();
                            break;
                        case 4:
                            MostrarArrayList(ejemArrayList);
                            Console.Write("Ingrese elemento que desea eliminar: ");
                            string borrar = Console.ReadLine();
                            if (ejemArrayList.Contains(borrar))
                            {
                                ejemArrayList.Remove(borrar);
                                Console.WriteLine("Elemento Borrado!!");
                            }
                            else
                            {
                                Console.WriteLine("Elemento No Existe en la Colección!!");
                            }
                            MostrarArrayList(ejemArrayList);
                            Console.ReadKey();
                            break;
                        case 5:
                            Console.Write("Ingrese posición del elemento a borrar: ");
                            pos = int.Parse(Console.ReadLine());
                            if (ejemArrayList.Count >= pos)
                            {
                                ejemArrayList.RemoveAt(pos);
                                Console.WriteLine("Elemento Borrado!!");
                            }
                            else
                            {
                                Console.WriteLine("Elemento No Existe en la Colección!!");
                            }
                            MostrarArrayList(ejemArrayList);
                            Console.ReadKey();
                            break;
                        default:
                            break;
                    }
                }
            } while (opc != 6);
        }

        private static void MostrarArrayList(ArrayList ejemArrayList)
        {
            foreach (var varAux in ejemArrayList)
            {
                Console.WriteLine(varAux);
            }
        }
    }
}
