using Microsoft.EntityFrameworkCore;
using Productos.Model;
using System.ComponentModel;

namespace Productos.Context
{
    public class Data_Context : DbContext
    {
        public DbSet<Product> product { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySQL("server=localhost;database=Productos;user=root;password=12345");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.nombre);
                entity.Property(e => e.descripcion);
                entity.Property(e => e.precio);

            });
        }
    }
}
