using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NeoShopping.Entities;

namespace NeoShopping.Data
{
    public class NeoShoppingDataContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Entrega> Entregas { get; set; }
        public DbSet<DetalleOrden> DetallesOrden { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-L89JS3KG\SQLEXPRESS;Database=NeoShoppingBD;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
