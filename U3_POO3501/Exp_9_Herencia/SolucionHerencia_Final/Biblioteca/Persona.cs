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
        /// Retorna o asigna el estado civil de la persona
        /// </summary>
        public EstadoCivil Estado_Civil { get; set; }
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Persona()
        {
            Init();
        }

        public Persona(string nombre, string apellido)
        {            
            _nombres = nombre;
            _apellidos = apellido;
            
        }

        /// <summary>
        /// Inicializa los campos y propiedades de la clase
        /// </summary>
        private void Init()
        {
            _nombres = string.Empty;
            _apellidos = string.Empty;

        }
        /// <summary>
        /// Mostrar datos de una persona
        /// </summary>
        /// <returns></returns>
        public string ObtenerInformacion()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format("Nombres: {0}\n", Nombres));
            sb.Append(string.Format("Apellidos: {0}\n", Apellidos));
            sb.Append(string.Format("Sexo: {0}\n", Sexo));
            sb.Append(string.Format("Estado Civil: {0}\n", Estado_Civil));

            return sb.ToString();
        }
    }
}
