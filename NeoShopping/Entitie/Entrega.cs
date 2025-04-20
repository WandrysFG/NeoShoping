using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeoShopping.Entities
{
    public class Entrega
    {
        [Key]
        public int IdEntrega { get; set; }

        [Required]
        public int IdOrden { get; set; }

        [Required]
        public DateTime FechaEntrega { get; set; }

        [Required, MaxLength(50)]
        public string RecibidoPor { get; set; }

        [MaxLength(250)]
        public string Observaciones { get; set; }

        [ForeignKey("IdOrden")]
        public virtual Orden Orden { get; set; }

        public Entrega(int idOrden, DateTime fechaEntrega, string recibidoPor, string observaciones = "")
        {
            IdOrden = idOrden;
            FechaEntrega = fechaEntrega;
            RecibidoPor = recibidoPor ?? throw new ArgumentNullException(nameof(recibidoPor), "RecibidoPor no puede ser nulo.");
            Observaciones = observaciones ?? string.Empty;
        }

        public Entrega()
        {
            IdOrden = 0;
            FechaEntrega = DateTime.Now;
            RecibidoPor = "Desconocido";
            Observaciones = string.Empty;
        }

        public string MostrarInformacion()
        {
            return $"ID Entrega: {IdEntrega} ║ ID Orden: {IdOrden} ║ Fecha: {FechaEntrega:yyyy-MM-dd} ║ Recibido por: {RecibidoPor} ║ Observaciones: {Observaciones}";
        }
    }
}
