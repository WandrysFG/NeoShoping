using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NeoShopping.Interfaces;

namespace NeoShopping.Entities
{
    public class DetalleOrden : DetalleOrdenBase, IDetalleOrden
    {
        [Key]
        public override int IdDetalle { get; set; }

        [Required]
        public override int IdOrden { get; set; }

        [ForeignKey("IdOrden")]
        public virtual Orden Orden { get; set; }

        [Required]
        public override int IdProducto { get; set; }

        [ForeignKey("IdProducto")]
        public virtual Producto Producto { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public override int Cantidad { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public override decimal PrecioUnitario { get; set; }

        [NotMapped]
        public override decimal Subtotal => base.Subtotal;

        public DetalleOrden(int idOrden, int idProducto, int cantidad, decimal precioUnitario)
            : base(idOrden, idProducto, cantidad, precioUnitario)
        {
        }

        public DetalleOrden() : base() { }

        public override string MostrarInformacion()
        {
            return $"ID Detalle: {IdDetalle} ║ ID Orden: {IdOrden} ║ ID Producto: {IdProducto} ║ Cantidad: {Cantidad} ║ Precio Unitario: {PrecioUnitario:C} ║ Subtotal: {Subtotal:C}";
        }
    }
}
