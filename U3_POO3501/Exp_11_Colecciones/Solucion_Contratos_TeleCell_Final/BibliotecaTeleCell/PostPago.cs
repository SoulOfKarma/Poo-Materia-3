using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotecaTeleCell
{
    public class PostPago : ContratoBase
    {
        /// <summary>
        /// Retorna o asigna el tipo de contrato postpago
        /// </summary>
        public ContratoPostpago Contrato { get; set; }

        /// <summary>
        /// Retorna el precio en base al contrato
        /// </summary>
        public int Precio
        {
            get
            {
                int precio = 0;
                switch (Contrato)
                {
                    case ContratoPostpago.MultimediaSocial:
                        precio = 19990;
                        break;
                    case ContratoPostpago.MultimediaFull:
                        precio = 25990;
                        break;
                    case ContratoPostpago.MultimediaLTE:
                        precio = 29990;
                        break;
                }

                return precio;
            }
        }

        /// <summary>
        /// Retorna los MB de navegación en base al contrato
        /// </summary>
        public int MBInternet
        {
            get
            {
                int mb = 0;
                switch (Contrato)
                {
                    case ContratoPostpago.MultimediaSocial:
                        mb = 1200;
                        break;
                    case ContratoPostpago.MultimediaFull:
                        mb = 1800;
                        break;
                    case ContratoPostpago.MultimediaLTE:
                        mb = 2400;
                        break;
                }

                return mb;
            }
        }

        /// <summary>
        /// Retorna los minutos de conversación en base al contrato
        /// </summary>
        public int Minutos
        {
            get
            {
                int min = 0;
                switch (Contrato)
                {
                    case ContratoPostpago.MultimediaSocial:
                        min = 150;
                        break;
                    case ContratoPostpago.MultimediaFull:
                        min = 250;
                        break;
                    case ContratoPostpago.MultimediaLTE:
                        min = 500;
                        break;
                }

                return min;
            }
        }

        /// <summary>
        /// Retorna la cantiadad de SMS en base al contrato
        /// </summary>
        public int SMS
        {
            get
            {
                int sms = 0;
                switch (Contrato)
                {
                    case ContratoPostpago.MultimediaSocial:
                        sms = 100;
                        break;
                    case ContratoPostpago.MultimediaFull:
                    case ContratoPostpago.MultimediaLTE:
                        sms = 500;
                        break;
                }

                return sms;
            }
        }

        /// <summary>
        /// Retorna el valor por minuto de voz adicional en base al contrato
        /// </summary>
        public int MinutoAdicional
        {
            get
            {
                int min = 0;
                switch (Contrato)
                {
                    case ContratoPostpago.MultimediaSocial:
                        min = 100;
                        break;
                    case ContratoPostpago.MultimediaFull:
                        min = 70;
                        break;
                    case ContratoPostpago.MultimediaLTE:
                        min = 60;
                        break;
                }

                return min;
            }
        }

        /// <summary>
        /// Retorna el valor por SMS adicional en base al contrato
        /// </summary>
        public int SMSAdicional
        {
            get
            {
                return 50;
            }
        }

        /// <summary>
        /// Retorna el valor por MB de navegación adicional en base al contrato
        /// </summary>
        public int MBAdicional
        {
            get
            {
                return 60;
            }
        }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public PostPago()
        {
            this.Init();
        }

        /// <summary>
        /// Inicializa campos y propiedades
        /// </summary>
        private void Init()
        {
            Contrato = ContratoPostpago.MultimediaFull;
        }

        /// <summary>
        /// Calcula el precio del contrato postpago
        /// </summary>
        /// <returns></returns>
        public new int PrecioContrato()
        {
            int precio = base.PrecioContrato(); /* Precio base de habilitación */

            precio += Precio; /* Precio por contrato postpago */

            return precio;
        }

    }
}
