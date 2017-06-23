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

        /// <summary>
        /// Retorna el conteo de elementos para el tipo de contrato indicado.
        /// </summary>
        /// <param name="tipo">TipoContrato que se desea consultar</param>
        /// <returns></returns>
        public int ContarPorTipoContrato(TipoContrato tipo)
        {
            int contar = 0;
            foreach (ContratoBase item in this)
            {
                if (item.Tipo == tipo)
                {
                    contar++;
                }
            }

            return contar;
        }

        /// <summary>
        /// Busca un contrato por su numero de línea. Si el contrato no se encuentra, 
        /// se retorna null.
        /// </summary>
        /// <param name="numero">Int con el número de línea del contrato a buscar</param>
        /// <returns></returns>
        public ContratoBase BuscarPorNumero(int numero)
        {
            foreach (ContratoBase item in this)
            {
                if (item.Numero == numero)
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// Retorna la suma de los precios finales de todos los 
        /// contratos Pospago.
        /// </summary>
        /// <returns></returns>
        public int SumarPrecioPostpago()
        {
            int suma = 0;
            foreach (ContratoBase item in this)
            {
                if (item.Tipo == TipoContrato.Postpago)
                {
                    suma += ((PostPago)item).PrecioContrato();
                }
            }

            return suma;
        }

        /// <summary>
        /// Retorna el precio final promedio de los contratos Postpago.
        /// </summary>
        /// <returns></returns>
        public double PromedioPrecioPostpago()
        {
            try
            {
                double promedio = 
                    (double)SumarPrecioPostpago() / 
                    (double)ContarPorTipoContrato(TipoContrato.Postpago);

                return promedio;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
