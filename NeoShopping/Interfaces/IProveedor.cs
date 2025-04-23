using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoShopping.Interfaces
{
    public interface IProveedor
    {
        int IdProveedor { get; set; }
        string Nombre { get; set; }
        string Telefono { get; set; }
        string Email { get; set; }
        string Direccion { get; set; }
        string RNC { get; set; }

        string MostrarInformacion();
    }
}
