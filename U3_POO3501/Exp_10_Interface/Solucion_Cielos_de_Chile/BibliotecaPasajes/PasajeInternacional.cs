using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotecaPasajes
{
    /// <summary>
    /// Representa la información de los pasajes Internacionales
    /// </summary>
    public class PasajeInternacional: PasajeAereo, IPasaje
    {
        /// <summary>
        /// Retorna o asigna el Pasaporte del pasajero
        /// </summary>
        public string Pasaporte { get; set; }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public PasajeInternacional()
        {
            this.Init();
        }

        /// <summary>
        /// Inicializa campos y propiedades
        /// </summary>
        private void Init()
        {
            Pasaporte = string.Empty;
        }

        /// <summary>
        /// Indica si el pasaje es o no chequeable
        /// </summary>
        public bool EsChequeable
        {
            get
            {
                TimeSpan span = FechaVuelo - DateTime.Now;

                if (span.TotalDays <= 2)
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
            return FechaVuelo.AddHours(-3).ToString("HH:mm");
        }
    }
}
