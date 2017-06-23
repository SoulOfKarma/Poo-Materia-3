using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotecaPasajes
{
    /// <summary>
    /// Representa la información base de los pasajes aéreos
    /// </summary>
    public class PasajeAereo
    {
        /// <summary>
        /// Retorna o asigna el número de vuelo
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Retorna o asigna la Fecha y Hora del Vuelo
        /// </summary>
        public DateTime FechaVuelo { get; set; }
        
        /// <summary>
        /// Retorna o asigna el tipo de pasaje
        /// </summary>
        public TipoPasaje Tipo { get; set; }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public PasajeAereo()
        {
            this.Init();
        }

        /// <summary>
        /// Inicializa campos y propiedades
        /// </summary>
        private void Init()
        {
            Numero = string.Empty;
            FechaVuelo = DateTime.Now;
            Tipo = TipoPasaje.Nacional;
        }

    }
}
