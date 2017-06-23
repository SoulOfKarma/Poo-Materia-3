using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteca
{
    /// <summary>
    /// Representa la información de un cliente
    /// </summary>
    public class Cliente : Persona
    {
        /// <summary>
        /// Retorna o asigna el descuento
        /// </summary>
        public float Descuento { get; set; }

        /// <summary>
        /// Retorna o asigna el tipo de cliente
        /// </summary>
        public TipoCliente Tipo { get; set; }


        #region Constructores
        public Cliente()
        {
            this.Init();
        }
        /// <summary>
        /// Constructor sobrecargado para asignar nombres y apellidos al Cliente
        /// </summary>
        /// <param name="nombres">string con que se asigna nombres al cliente</param>
        /// <param name="apellidos">string con que se asigna apellidos al cliente</param>
        public Cliente(string nombres, string apellidos)
            : base(nombres, apellidos)
        {
            /*Necesaria para inicializar cliente, 
             * ya que reutiliza el constructor base*/
            this.Init();
        }
        /// <summary>
        /// Inicializa campos y propiedades
        /// </summary>
        private void Init()
        {
            Descuento = 0;
            Tipo = TipoCliente.Ocasional;
        } 
        #endregion
        /// <summary>
        /// Mostrar todos los datos del cliente (considerando los datos de persona)
        /// </summary>
        /// <returns></returns>
        public new string ObtenerInformacion()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ObtenerInformacion());
            sb.Append(string.Format("Tipo Cliente: {0}\n", Tipo));
            sb.Append(string.Format("Descuento: {0}\n", Descuento));

            return sb.ToString(); ;
        }
    }
}
