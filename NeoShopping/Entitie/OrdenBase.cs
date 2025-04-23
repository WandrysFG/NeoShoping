using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoShopping.Entities
{
    public abstract class OrdenBase
    {
        public virtual int IdOrden { get; set; }
        public virtual DateTime FechaOrden { get; set; }
        public virtual decimal Total { get; set; }
        public virtual string Estado { get; set; }

        public OrdenBase(DateTime fechaOrden, decimal total, string estado)
        {
            FechaOrden = fechaOrden;
            Total = total;
            Estado = estado;
        }

        public OrdenBase() { }

        public abstract string MostrarInformacion();
    }
}
