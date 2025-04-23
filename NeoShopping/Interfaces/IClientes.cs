using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoShopping.Interfaces
{
    public interface ICliente
    {
        int IdCliente { get; set; }
        string Nombre { get; set; }
        string Apellido { get; set; }
        string Telefono { get; set; }
        string Email { get; set; }
        string Direccion { get; set; }

        string MostrarInformacion();
    }
}
