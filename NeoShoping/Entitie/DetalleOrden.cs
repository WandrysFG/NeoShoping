
using System.ComponentModel.DataAnnotations;

namespace NeoShoping.Entities
{
    public class DetalleOrden
    {
        [Key]
        public int IdDetalleOrden { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get { return Cantidad * PrecioUnitario; } }

        public required Orden oOrden { get; set; }
        public required Producto oProducto { get; set; }
    }
}