using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeoShoping.Entities
{
    public class Producto : ProductoBase
    {
        [Key]
        public override int IdProducto { get; set; }

        [Required, MaxLength(50)]
        public override string Nombre { get; set; }

        [MaxLength(250)]
        public string Descripcion { get; set; }

        [Required]
        public override decimal Precio { get; set; }

        [Required]
        public override int Stock { get; set; }

        [Required]
        public int IdProveedor { get; set; }

        [ForeignKey("IdProveedor")]
        public virtual Proveedor Proveedor { get; set; }

        public Producto(string nombre, decimal precio, int stock, string descripcion)
            : base(nombre, precio, stock)
        {
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre), "Nombre no puede ser nulo.");
            Descripcion = descripcion ?? throw new ArgumentNullException(nameof(descripcion), "Descripción no puede ser nula.");
        }

        public Producto() : base("Producto por defecto", 0, 0)
        {
            Nombre = "Producto por defecto";
            Descripcion = "Descripción por defecto";
            Proveedor = new Proveedor();
        }
        public override string MostrarInformacion()
        {
            return $"ID: {IdProducto} ║ Nombre: {Nombre} ║ Precio: {Precio:C} ║ Stock: {Stock} ║ Descripción: {Descripcion} ║ Proveedor: {IdProveedor}";
        }
    }
}
