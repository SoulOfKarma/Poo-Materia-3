using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotecaPasajes
{
    /// <summary>
    /// Respresenta el contrato de pasajes para chequeo y hora de presentación
    /// </summary>
    public interface IPasaje
    {
        bool EsChequeable { get; }

        string CalcularHoraPresentacion();

    }
}
