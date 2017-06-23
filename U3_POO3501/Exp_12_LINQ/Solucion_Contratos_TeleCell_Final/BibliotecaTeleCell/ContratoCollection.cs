using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotecaTeleCell
{
    /// <summary>
    /// Representa la colección de contratos
    /// </summary>
    public class ContratoCollection: List<ContratoBase>
    {
        public int ContarPorTipoContrato(TipoContrato tipo)
        {
            return this.Count(c => c.Tipo == tipo);
        }

        public List<int> ObtenerNumerosEquipoPropio()
        {
            return this.Where(c => c.EquipoPropio).Select(c => c.Numero).ToList<int>();
        }

        public List<string> ObtenerNombresPorFecha(DateTime inicio, DateTime termino)
        {
            return this.Where(c => c.FechaContrato >= inicio && c.FechaContrato <= termino).Select(c => c.NombreTitular).ToList<string>();
        }

        public double PrecioPromedioPostPago()
        {
            return this.Where(c => c.Tipo == TipoContrato.Postpago).Average(c => ((PostPago)c).PrecioContrato());
        }

        public List<DateTime> FechasPostPagoMenorValor()
        {
            int menor = this.Where(c => (c is PostPago)).Min(c => ((PostPago)c).PrecioContrato());

            return this.Where(c => (c is PostPago) && ((PostPago)c).PrecioContrato() == menor).Select(c => c.FechaContrato).ToList<DateTime>();
        }
    }
}
