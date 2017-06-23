using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotecaHotel
{
    public class ReservaCollection: List<ReservaBase>
    {
        public ReservaCollection()
        {
        }

        /// <summary>
        /// Contabiliza las reservas por tipo de reserva
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public int ContarPorTipoReserva(TipoReserva tipo)
        {
            int contador = 0;
            foreach (ReservaBase item in this)
            {
                if (item.Tipo == tipo)
                {
                    contador++;
                }
            }

            return contador;
        }

        /// <summary>
        /// Busca la mayor fecha de reserva en la colección
        /// </summary>
        /// <returns></returns>
        public DateTime MayorFechaReserva()
        {
            DateTime mayor = new DateTime(1900, 1, 1);
            foreach (ReservaBase item in this)
            {
                if (item.FechaReserva > mayor)
                {
                    mayor = item.FechaReserva;
                }
            }

            return mayor;
        }

        /// <summary>
        /// Busca la menor fecha de reserva en la colección
        /// </summary>
        /// <returns></returns>
        public DateTime MenorFechaReserva()
        {
            DateTime menor = new DateTime(2099, 1, 1);
            foreach (ReservaBase item in this)
            {
                if (item.FechaReserva < menor)
                {
                    menor = item.FechaReserva;
                }
            }

            return menor;
        }

        /// <summary>
        /// Retorna una lista de los números de reserva por tipo de habitación
        /// </summary>
        /// <param name="habitacion"></param>
        /// <returns></returns>
        public List<int> NumerosReservaPorTipoHabitacion(TipoHabitacion habitacion)
        {
            List<int> numeros = new List<int>();
            foreach (ReservaBase item in this)
            {
                if (item.Habitacion == habitacion)
                {
                    numeros.Add(item.Numero);
                }
            }

            return numeros;
        }

        /// <summary>
        /// Calcula el precio promedio final de las reservas por tipo de reserva
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public double PromedioPrecioPorTipoReserva(TipoReserva tipo)
        {
            int suma = 0;
            int contador = 0;

            foreach (ReservaBase item in this)
            {
                if (item.Tipo == tipo)
                {
                    suma += ((IReserva)item).CalcularValor();
                    contador++;
                }
            }

            if (contador > 0)
            {
                return (double)suma / (double)contador;
            }
            else
            {
                return 0;
            }
        }

    }
}
