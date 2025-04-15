using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NeoShoping.Entities;

namespace NeoShoping.Data
{
    public class NeoShopingDataContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=LAPTOP-L89JS3KG\SQLEXPRESS;Database=NeoShoping;Trusted_Connection=True;Encrypt=False;");
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-L89JS3KG\SQLEXPRESS;Database=NeoShopingBD;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
