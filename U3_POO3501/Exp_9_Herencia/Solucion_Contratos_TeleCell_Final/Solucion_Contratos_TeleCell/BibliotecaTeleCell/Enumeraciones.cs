using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotecaTeleCell
{
    /// <summary>
    /// Representa los Tipos de Contrato Móvil
    /// </summary>
    public enum TipoContrato
    {
        Postpago = 0, Prepago = 1
    }

    /// <summary>
    /// Representa los tipos de contrato postpago
    /// </summary>
    public enum ContratoPostpago
    {
        MultimediaSocial = 0, MultimediaFull = 1, MultimediaLTE = 2
    }

    /// <summary>
    /// Representa los tipos de contrato prepago
    /// </summary>
    public enum ContratoPrepago
    {
        MovilSocial = 0, MovilInternet = 1
    }
}
