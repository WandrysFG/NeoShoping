using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeoShoping.Entities
{
    public class Cliente : ClienteBase
    {
        [Key]
        public override int IdCliente { get; set; }

        [Required]
        [StringLength(50)]
        public override string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public override string Apellido { get; set; }

        [Required]
        [StringLength(20)]
        public override string Telefono { get; set; }

        [StringLength(100)]
        [EmailAddress]
        public override string Email { get; set; }

        [Required]
        [StringLength(200)]
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
            return $"ID Cliente: {IdCliente} ║ Nombre: {Nombre} {Apellido} ║ Teléfono: {Telefono} ║ Email: {Email} ║ Dirección: {Direccion}";
        }
    }
}
