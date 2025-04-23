using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NeoShopping.Interfaces;

namespace NeoShopping.Entities
{
    public class Entrega : EntregaBase, IEntrega
    {
        [Key]
        public override int IdEntrega { get; set; }

        [Required]
        public override int IdOrden { get; set; }

        [Required]
        public override DateTime FechaEntrega { get; set; }

        [Required, MaxLength(50)]
        public override string RecibidoPor { get; set; }

        [MaxLength(250)]
        public override string Observaciones { get; set; }

        [ForeignKey("IdOrden")]
        public virtual Orden Orden { get; set; }

        public Entrega(int idOrden, DateTime fechaEntrega, string recibidoPor, string observaciones = "")
            : base(idOrden, fechaEntrega, recibidoPor, observaciones)
        {
        }

        public Entrega() : base()
        {
            IdOrden = 0;
            FechaEntrega = DateTime.Now;
            RecibidoPor = "Desconocido";
            Observaciones = string.Empty;
        }

        public override string MostrarInformacion()
        {
            return $"ID Entrega: {IdEntrega} ║ ID Orden: {IdOrden} ║ Fecha: {FechaEntrega:yyyy-MM-dd} ║ Recibido por: {RecibidoPor} ║ Observaciones: {Observaciones}";
        }
    }
}
