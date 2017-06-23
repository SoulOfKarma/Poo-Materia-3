using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biblioteca;

namespace ClienteConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            UsoHerencia();
            UsoPolimorfismo();
        }
        /// <summary>
        /// Ejemplifica el uso de polimorfismo sobre las clases heredadas
        /// </summary>
        private static void UsoPolimorfismo()
        {
            //Instancia de Trabajador
            Trabajador otroTrabajador = new Trabajador();
            otroTrabajador.Nombres = "Alicia Marion";
            otroTrabajador.Apellidos = "Verdugo Randall";
            otroTrabajador.Cargo = CargoTrabajador.Encargado;
            //Instancia de Cliente
            Cliente otroCliente = new Cliente("Esteban Aliro","Wall Grillo");
            otroCliente.Tipo = TipoCliente.Frecuente;
            //Utiliza el objeto Trabajador y Cliente como Persona
            MostrarInformacionPersona(otroTrabajador);
            MostrarInformacionPersona(otroCliente);
        }

        private static void MostrarInformacionPersona(Persona persona)
        {
            Console.Clear();
            Console.WriteLine(persona.ObtenerInformacion());
            Pausa();
        }

        private static void UsoHerencia()
        {
            //Instancia de Trabajador
            Trabajador trabajador = new Trabajador();
            trabajador.Nombres = "Enerio Benigno";
            trabajador.Apellidos = "Campos Isla";
            trabajador.Cargo = CargoTrabajador.Gerente;
            Console.WriteLine(trabajador.ObtenerInformacion());

            //Instancia del Cliente
            Cliente cliente = new Cliente("Jacinta Melania","Arce Rungio");
            cliente.Tipo = TipoCliente.Ocasional;
            Console.WriteLine(cliente.ObtenerInformacion());

            Pausa();
        }

        private static void Pausa()
        {
            Console.ReadLine();
        }


    }
}
