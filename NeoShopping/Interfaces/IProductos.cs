using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoShopping.Interfaces
{
    public interface IProducto
    {
        int IdProducto { get; set; }
        string Nombre { get; set; }
        decimal Precio { get; set; }
        int Stock { get; set; }

        string MostrarInformacion();
    }
}
