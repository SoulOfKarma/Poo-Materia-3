using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotecaPersonas
{
    public class Persona
    {
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public int Rut { get; set; }

        public Persona()
        {
            this.Init();
        }

        private void Init()
        {
            Apellido = string.Empty;
            Nombre = string.Empty;
            Rut = 0;
        }
    }
}
