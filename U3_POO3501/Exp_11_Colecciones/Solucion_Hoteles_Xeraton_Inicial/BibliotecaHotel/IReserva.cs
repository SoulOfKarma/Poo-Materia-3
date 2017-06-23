using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotecaHotel
{
    public interface IReserva
    {
        bool EsCancelable { get; }
        int DescuentoReserva { get; }
        int DescuentoEstadia{ get; }
        int CalcularValor();
    }
}
