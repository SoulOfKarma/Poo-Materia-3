using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotecaTeleCell
{
    public class PrePago: ContratoBase
    {
        /// <summary>
        /// Retorna o asigna el tipo de contrato prepago
        /// </summary>
        public ContratoPrepago Contrato { get; set; }

        /// <summary>
        /// Retorna el valor por minuto de voz en base al contrato
        /// </summary>
        public int ValorMinuto
        {
            get
            {
                int min = 0;
                switch (Contrato)
                {
                    case ContratoPrepago.MovilSocial:
                        min = 70;
                        break;
                    case ContratoPrepago.MovilInternet:
                        min = 60;
                        break;
                }

                return min;
            }
        }

        /// <summary>
        /// Retorna el valor por SMS adicional en base al contrato
        /// </summary>
        public int ValorSMS
        {
            get
            {
                int sms = 0;
                switch (Contrato)
                {
                    case ContratoPrepago.MovilSocial:
                        sms = 60;
                        break;
                    case ContratoPrepago.MovilInternet:
                        sms = 50;
                        break;
                }

                return sms;
            }
        }

        /// <summary>
        /// Retorna el valor por MB de navegación adicional en base al contrato
        /// </summary>
        public int ValorMB
        {
            get
            {
                return 60;
            }
        }

        /// <summary>
        /// constructor por defecto
        /// </summary>
        public PrePago()
        {
            this.Init();
        }

        /// <summary>
        /// Inicializa campos y propiedades
        /// </summary>
        private void Init()
        {
            Contrato = ContratoPrepago.MovilSocial;
        }

        /// <summary>
        /// Calcula el precio del contrato postpago
        /// </summary>
        /// <returns></returns>
        public new int PrecioContrato()
        {
            int precio = base.PrecioContrato(); /* Precio base de habilitación */

            return precio;
        }
    }
}
