using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeoShoping.Entities
{
    public class DetalleOrden
    {
        [Key]
        public int IdDetalle { get; set; }

        [Required]
        public int IdOrden { get; set; }

        [ForeignKey("IdOrden")]
        public virtual Orden Orden { get; set; }

        [Required]
        public int IdProducto { get; set; }

        [ForeignKey("IdProducto")]
        public virtual Producto Producto { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Cantidad { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal PrecioUnitario { get; set; }

        [NotMapped]
        public decimal Subtotal => Cantidad * PrecioUnitario;

        public DetalleOrden(int idOrden, int idProducto, int cantidad, decimal precioUnitario)
        {
            IdOrden = idOrden;
            IdProducto = idProducto;
            Cantidad = cantidad > 0 ? cantidad : throw new ArgumentException("Cantidad debe ser mayor que cero.", nameof(cantidad));
            PrecioUnitario = precioUnitario >= 0 ? precioUnitario : throw new ArgumentException("Precio unitario no puede ser negativo.", nameof(precioUnitario));
        }

        public DetalleOrden()
        {
            Cantidad = 1;
            PrecioUnitario = 0;
        }

        public string MostrarInformacion()
        {
            return $"ID Detalle: {IdDetalle} ║ ID Orden: {IdOrden} ║ ID Producto: {IdProducto} ║ Cantidad: {Cantidad} ║ Precio Unitario: {PrecioUnitario:C} ║ Subtotal: {Subtotal:C}";
        }
    }
}
