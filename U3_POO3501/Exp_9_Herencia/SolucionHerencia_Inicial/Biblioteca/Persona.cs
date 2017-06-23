using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteca
{
    /// <summary>
    /// Representa la información de una Persona
    /// </summary>
    public class Persona
    {
        private string _nombres;
        private string _apellidos;

        /// <summary>
        /// Retorna o asigna los Nombres de la Persona
        /// </summary>
        public string Nombres
        {
            get { return _nombres; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Nombre no puede estar vacío");
                }
                else
                {
                    _nombres = value;
                }
            }
        }

        /// <summary>
        /// Retorna o asigna los Apellidos de la Persona
        /// </summary>
        public string Apellidos
        {
            get { return _apellidos; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Apellido no puede estar vacío");
                }
                else
                {

                    _apellidos = value;
                }
            }
        }

        /// <summary>
        /// Retorna o asigna el sexo de la persona
        /// </summary>
        public SexoPersona Sexo { get; set; }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Persona()
        {
            Init();
        }

        /// <summary>
        /// Inicializa los campos y propiedades de la clase
        /// </summary>
        private void Init()
        {
            _nombres = string.Empty;
            _apellidos = string.Empty;
        }

    }
}
