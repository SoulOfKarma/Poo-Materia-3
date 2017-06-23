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
            //int contador = 0;
            //foreach (ReservaBase item in this)
            //{
            //    if (item.Tipo == tipo)
            //    {
            //        contador++;
            //    }
            //}

            //return contador;

            return this.Count(r => r.Tipo == tipo);

        }

        /// <summary>
        /// Busca la mayor fecha de reserva en la colección
        /// </summary>
        /// <returns></returns>
        public DateTime MayorFechaReserva()
        {
            #region SinLINQ
            //DateTime mayor = new DateTime(1900, 1, 1);
            //foreach (ReservaBase item in this)
            //{
            //    if (item.FechaReserva > mayor)
            //    {
            //        mayor = item.FechaReserva;
            //    }
            //}

            //return mayor; 
            #endregion

            return this.Max(r => r.FechaReserva);
        }

        /// <summary>
        /// Busca la menor fecha de reserva en la colección
        /// </summary>
        /// <returns></returns>
        public DateTime MenorFechaReserva()
        {
            #region SinLINQ
            //DateTime menor = new DateTime(2099, 1, 1);
            //foreach (ReservaBase item in this)
            //{
            //    if (item.FechaReserva < menor)
            //    {
            //        menor = item.FechaReserva;
            //    }
            //}

            //return menor; 
            #endregion

            return this.Min(r => r.FechaReserva);
        }

        /// <summary>
        /// Retorna una lista de los números de reserva por tipo de habitación
        /// </summary>
        /// <param name="habitacion"></param>
        /// <returns></returns>
        public List<int> NumerosReservaPorTipoHabitacion(TipoHabitacion habitacion)
        {
            #region SinLINQ
            //List<int> numeros = new List<int>();
            //foreach (ReservaBase item in this)
            //{
            //    if (item.Habitacion == habitacion)
            //    {
            //        numeros.Add(item.Numero);
            //    }
            //}

            //return numeros; 
            #endregion

            return 
                this.Where(r => r.Habitacion == 
                    habitacion).Select(r => r.Numero).ToList<int>();
        }

        /// <summary>
        /// Calcula el precio promedio final de las reservas por tipo de reserva
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public double PromedioPrecioPorTipoReserva(TipoReserva tipo)
        {
            #region SinLINQ
            //int suma = 0;
            //int contador = 0;

            //foreach (ReservaBase item in this)
            //{
            //    if (item.Tipo == tipo)
            //    {
            //        suma += ((IReserva)item).CalcularValor();
            //        contador++;
            //    }
            //}

            //if (contador > 0)
            //{
            //    return (double)suma / (double)contador;
            //}
            //else
            //{
            //    return 0;
            //} 
            #endregion

            if (this.Count(r => r.Tipo == tipo) > 0)
            {
                return 
                    this.Where(r => r.Tipo == tipo).Average(r => ((IReserva)r).CalcularValor());
            }
            else
            {
                return 0;
            }
        }

    }
}
