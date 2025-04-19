using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeoShoping.Entities
{
    public class Cliente : ClienteBase
    {
        [Key]
        public override int IdCliente { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
        public override string Nombre { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El apellido no puede tener más de 100 caracteres.")]
        public override string Apellido { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "El teléfono no puede tener más de 20 caracteres.")]
        public override string Telefono { get; set; }

        [StringLength(100, ErrorMessage = "El email no puede tener más de 100 caracteres.")]
        [EmailAddress(ErrorMessage = "El email no tiene un formato válido.")]
        public override string Email { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "La dirección no puede tener más de 200 caracteres.")]
        public override string Direccion { get; set; }

        public Cliente(string nombre, string apellido, string telefono, string email, string direccion)
            : base(nombre, apellido, telefono, email, direccion)
        {
        }

        public Cliente() : base("", "", "", "", "")
        {
        }

        public override string MostrarInformacion()
        {
            return $"ID Cliente: {IdCliente} ║ Nombre: {Nombre} {Apellido} ║ Teléfono: {Telefono} ║ Email: {Email} ║ Dirección: {Direccion}\n";
        }
    }
}
