using System.ComponentModel.DataAnnotations;

namespace NeoShoping.Entities
{
    public class Proveedor : ProveedorBase
    {
        [Key]
        public override int IdProveedor { get; set; }

        [Required, MaxLength(50)]
        public override string Nombre { get; set; }

        [Required, Phone, MaxLength(20)]
        public override string Telefono { get; set; }

        [EmailAddress, MaxLength(100)]
        public override string Email { get; set; }

        [Required, MaxLength(200)]
        public override string Direccion { get; set; }

        [Required, MaxLength(15)]
        public override string RNC { get; set; }

        public Proveedor(string nombre, string telefono, string email, string direccion, string rnc)
            : base(nombre, telefono, email, direccion, rnc)
        {
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre), "Nombre no puede ser nulo.");
            Telefono = telefono;
            Email = email;
            Direccion = direccion;
            RNC = rnc;
        }

        public Proveedor() : base("Proveedor por defecto", "000-000-0000", "proveedor@email.com", "Dirección por defecto", "RNC000000")
        {
            Nombre = "Proveedor por defecto";
            Telefono = "000-000-0000";
            Email = "proveedor@email.com";
            Direccion = "Dirección por defecto";
            RNC = "RNC000000";
        }

        public override string MostrarInformacion()
        {
            return $"ID: {IdProveedor} ║ Nombre: {Nombre} ║ Teléfono: {Telefono} ║ Email: {Email} ║ Dirección: {Direccion} ║ RNC: {RNC}";
        }
    }
}
