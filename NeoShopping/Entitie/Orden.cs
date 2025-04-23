using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NeoShopping.Interfaces;

namespace NeoShopping.Entities
{
    public class Orden : OrdenBase, IOrden
    {
        [Key]
        public override int IdOrden { get; set; }

        [Required]
        public override DateTime FechaOrden { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "El total no puede ser negativo.")]
        public override decimal Total { get; set; }

        [Required, MaxLength(50)]
        public override string Estado { get; set; }

        [Required]
        public int IdProveedor { get; set; }

        [ForeignKey("IdProveedor")]
        public virtual Proveedor Proveedor { get; set; }

        [Required]
        public int IdCliente { get; set; }

        [ForeignKey("IdCliente")]
        public virtual Cliente Cliente { get; set; }

        public Orden(int idCliente, int idProveedor, DateTime fechaOrden, decimal total, string estado)
            : base(fechaOrden, total, estado)
        {
            IdCliente = idCliente;
            IdProveedor = idProveedor;
        }

        public Orden() : base()
        {
            FechaOrden = DateTime.Now;
            Total = 0;
            Estado = "Pendiente";
            Proveedor = new Proveedor();
            Cliente = new Cliente();
        }

        public override string MostrarInformacion()
        {
            return $"ID: {IdOrden} ║ Fecha: {FechaOrden:dd/MM/yyyy} ║ Total: {Total:C} ║ Estado: {Estado} ║ Proveedor: {IdProveedor} ║ Cliente: {IdCliente}";
        }
    }
}
