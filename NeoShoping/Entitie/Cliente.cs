using System.ComponentModel.DataAnnotations;

namespace NeoShoping.Entities
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string Telefono { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Direccion { get; set; }
    }
}
