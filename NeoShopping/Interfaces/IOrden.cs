using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoShopping.Interfaces
{
    public interface IOrden
    {
        int IdOrden { get; set; }
        DateTime FechaOrden { get; set; }
        decimal Total { get; set; }
        string Estado { get; set; }

        string MostrarInformacion();
    }
}
