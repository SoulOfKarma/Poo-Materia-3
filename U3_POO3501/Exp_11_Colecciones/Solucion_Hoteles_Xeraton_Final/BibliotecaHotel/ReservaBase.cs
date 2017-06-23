using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotecaHotel
{
    public class ReservaBase
    {
        public int Numero { get; set; }
        public DateTime FechaReserva { get; set; }
        public DateTime InicioReserva { get; set; }
        public DateTime TerminoReserva { get; set; }
        public TipoReserva Tipo { get; set; }
        public TipoHabitacion Habitacion { get; set; }

        public int PrecioBase 
        {
            get
            {
                int precio = 0;
                switch (Habitacion)
                {
                    case TipoHabitacion.Single:
                        precio = 25990;
                        break;
                    case TipoHabitacion.Doble:
                        precio = 39990;
                        break;
                    case TipoHabitacion.Suite:
                        precio = 75990;
                        break;
                }

                return precio;
            }
        }


        public ReservaBase()
        {
            this.Init();
        }

        private void Init()
        {
            Numero = 0;
            FechaReserva = DateTime.Now;
            InicioReserva = DateTime.Now;
            TerminoReserva = DateTime.Now;
            Tipo = TipoReserva.Normal;
            Habitacion = TipoHabitacion.Single;
        }

        protected int DiferenciaFechas(DateTime mayor, DateTime menor)
        {
            TimeSpan span = mayor - menor;
            return span.Days;
        }
    }
}
