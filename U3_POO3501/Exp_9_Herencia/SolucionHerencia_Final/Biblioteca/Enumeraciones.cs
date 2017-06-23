using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteca
{
    /// <summary>
    /// Representa el sexo de las personas
    /// </summary>
    public enum SexoPersona
    {
        Indeterminado = 0, Masculino = 1, Femenino = 2
    }
    /// <summary>
    ///Representa el Estado Civil de las Personas 
    /// </summary>
    public enum EstadoCivil
    {
        Indeterminado = 0, Soltero = 1, Casado = 2, Viudo = 3, Separado = 4
    }
    /// <summary>
    /// Representa los cargos disponibles para los trabajadores
    /// </summary>
    public enum CargoTrabajador
    {
        Indeterminado = 0, Gerente = 1, Subgerente = 2, Supervisor = 3, Encargado = 4, Obrero = 5
    }
    /// <summary>
    /// Representa los tipos de cliente
    /// </summary>
    public enum TipoCliente
    {
        Frecuente = 0, Ocasional = 1
    }

}
