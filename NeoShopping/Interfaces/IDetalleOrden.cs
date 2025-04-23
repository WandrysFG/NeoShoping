using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoShopping.Interfaces
{
    public interface IDetalleOrden
    {
        int IdDetalle { get; set; }
        int IdOrden { get; set; }
        int IdProducto { get; set; }
        int Cantidad { get; set; }
        decimal PrecioUnitario { get; set; }
        decimal Subtotal { get; }

        string MostrarInformacion();
    }
}

