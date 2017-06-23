using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotecaTeleCell
{
    /// <summary>
    /// Represneta la información de un Contrato Base de Telefonía Móvil
    /// </summary>
    public class ContratoBase
    {
        #region Campos privados
        private int _numero;
        private DateTime _fechaContrato;
        private string _nombreTitular;
        #endregion


        #region Propiedades
        /// <summary>
        /// Retorna o asigna el número de la línea
        /// </summary>
        public int Numero
        {
            get { return _numero; }
            set
            {
                /* Extrae primer caracter */
                char digito = value.ToString()[0];

                /* Valida que este dentro de los carcateres esperados */
                switch (digito)
                {
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        _numero = value;
                        break;
                    default:
                        throw new ArgumentException("Número debe iniciar con 6, 7, 8 O 9");
                }
            }
        }

        /// <summary>
        /// Retorna o asigna la fecha del contrato
        /// </summary>
        public DateTime FechaContrato
        {
            get { return _fechaContrato; }
            set {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("Fecha de Contrato no puede ser mayor a la fecha actual");
                }
                else
                {
                    _fechaContrato = value;
                }
            }
        }

        /// <summary>
        /// Retorna o asigna el nombre del cliente titular
        /// </summary>
        public string NombreTitular
        {
            get { return _nombreTitular; }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Nombre no puede estar vacío");
                }
                else
                {
                    _nombreTitular = value;
                }
            }
        }

        /// <summary>
        /// Retorna o asigna indicador si cuenta con equipo propio
        /// </summary>
        public bool EquipoPropio { get; set; }

        /// <summary>
        /// Retorna o asigna el tipo de contrato.
        /// </summary>
        public TipoContrato Tipo { get; set; }
        #endregion

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public ContratoBase()
        {
            this.Init();
        }

        /// <summary>
        /// Inicializa campos y propiedades
        /// </summary>
        private void Init()
        {
            _numero = 0;
            _fechaContrato = DateTime.Now;
            _nombreTitular = string.Empty;
            EquipoPropio = false;
            Tipo = TipoContrato.Postpago;
        }

        /// <summary>
        /// Calcula el precio del contrato base
        /// </summary>
        /// <returns></returns>
        public int PrecioContrato()
        {
            int precio = 2990; /* Precio base de habilitación */

            /* Agrega un recargo base si no tiene equipo propio */
            if (!EquipoPropio)
            {
                switch (Tipo)
                {
                    case TipoContrato.Postpago:
                        precio += 990;
                        break;
                    case TipoContrato.Prepago:
                        precio += 1990;
                        break;
                }
            }
            return precio;
        }

    }
}
