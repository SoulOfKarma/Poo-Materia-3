using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotecaPasajes
{
    /// <summary>
    /// Representa la información de los pasajes Nacionales
    /// </summary>
    public class PasajeNacional : PasajeAereo, IPasaje
    {
        /// <summary>
        /// Retorna o asigna el Rut del pasajero
        /// </summary>
        public string Rut { get; set; }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public PasajeNacional()
        {
            this.Init();
        }

        /// <summary>
        /// Inicializa campos y propiedades
        /// </summary>
        private void Init()
        {
            Rut = string.Empty;
        }

        /// <summary>
        /// Indica si el pasaje es o no chequeable
        /// </summary>
        public bool EsChequeable
        {
            get 
            {
                TimeSpan span = FechaVuelo - DateTime.Now;

                if (span.TotalDays <= 3)
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
        /// Retorna la hora de presentación en aeropuerto
        /// </summary>
        /// <returns></returns>
        public string CalcularHoraPresentacion()
        {
            return FechaVuelo.AddHours(-2).ToString("HH:mm");
        }
    }
}
