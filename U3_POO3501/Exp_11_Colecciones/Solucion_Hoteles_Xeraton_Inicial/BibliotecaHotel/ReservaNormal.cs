using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotecaHotel
{
    public class ReservaNormal : ReservaBase, IReserva
    {
        /// <summary>
        /// Informa si la reservación es cancelable a la fecha de hoy.
        /// </summary>
        public bool EsCancelable
        {
            get
            {
                if (DiferenciaFechas(InicioReserva, DateTime.Now) >= 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Retorna descuento basado en la fecha de reservación.
        /// </summary>
        public int DescuentoReserva
        {
            get
            {
                if (DiferenciaFechas(InicioReserva, FechaReserva) >= 5)
                {
                    return (int)(PrecioBase * 0.1);
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Retorna descuento basado en los dias de estadía.
        /// </summary>
        public int DescuentoEstadia
        {
            get
            {
                if (DiferenciaFechas(TerminoReserva, InicioReserva) >= 7)
                {
                    return (int)(PrecioBase * 0.07);
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Informa el valor final de la reserva considerando precio base y descuentos.
        /// </summary>
        /// <returns></returns>
        public int CalcularValor()
        {
            return PrecioBase - DescuentoReserva - DescuentoEstadia;
        }

    }
}
