
using System.ComponentModel.DataAnnotations;

namespace NeoShoping.Entities
{
    public class Entrega
    {
        [Key]
        public int IdEntrega { get; set; }
        public int IdOrden { get; set; }
        public DateTime FechaEntrega { get; set; }
        public required string RecibidoPor { get; set; }
        public string Observaciones { get; set; }

        public required Orden Orden { get; set; }
    }
}