using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteca
{
    /// <summary>
    /// Representa la información de un trabajador
    /// </summary>
    public class Trabajador: Persona
    {
        /// <summary>
        /// Retorna o asigna el sueldo
        /// </summary>
        public int Sueldo { get; set; }

        /// <summary>
        /// Retorna o asigna el cargo del trabajador
        /// </summary>
        public CargoTrabajador Cargo { get; set; }

        /// <summary>
        /// constructor por defecto
        /// </summary>
        public Trabajador()
        {
            this.Init();
        }

        /// <summary>
        /// Inicializa campos y propiedades
        /// </summary>
        private void Init()
        {
            Sueldo = 0;
            Cargo = CargoTrabajador.Obrero;
        }

        public new string ObtenerInformacion()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ObtenerInformacion());
            sb.Append(string.Format("Cargo: {0}\n", Cargo));
            sb.Append(string.Format("Sueldo: {0}\n", Sueldo));

            return sb.ToString(); ;
        }
    }
}
