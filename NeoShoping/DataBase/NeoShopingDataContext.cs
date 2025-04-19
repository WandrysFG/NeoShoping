using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NeoShoping.Entities;

namespace NeoShoping.Data
{
    public class NeoShopingDataContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Entrega> Entregas { get; set; }
        public DbSet<DetalleOrden> DetallesOrden { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-L89JS3KG\SQLEXPRESS;Database=NeoShopingBD;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
