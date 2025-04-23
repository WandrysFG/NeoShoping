using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoShopping.Interfaces
{
    public interface IEntrega
    {
        int IdEntrega { get; set; }
        int IdOrden { get; set; }
        DateTime FechaEntrega { get; set; }
        string RecibidoPor { get; set; }
        string Observaciones { get; set; }

        string MostrarInformacion();
    }
}
