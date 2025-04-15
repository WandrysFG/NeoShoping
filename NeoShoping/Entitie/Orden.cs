using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeoShoping.Entities
{
    public class Orden
    {
        [Key]
        public int IdOrden { get; set; }

        [Required]
        public DateTime FechaOrden { get; set; }

        [Required]
        public decimal Total { get; set; }

        [Required]
        public string Estado { get; set; } = "Pendiente";

        public int IdProveedor { get; set; }

        [ForeignKey("IdProveedor")]
        public Proveedor oProveedor { get; set; }

        public int IdCliente { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente oCliente { get; set; }


        public List<DetalleOrden> oDetalleOrden { get; set; } = new List<DetalleOrden>();
    }
}
