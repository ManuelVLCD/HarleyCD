using Microsoft.EntityFrameworkCore;
using ORM.Model;
using System.ComponentModel;

namespace ORM.Context
{
    public class MyDataContext:DbContext //Dentro del espacio principal creamos una clase publica la cual hereda funciones de la DB_Context de Entity
    {
        public DbSet<Users> users { set; get; } //Dentro de la clase principal reamos una DbSet con atributos set, get

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySQL("server=localhost;database=Usuario;user=root;password=12345");
        }  //Conexion al gestor de base de datos

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Users>(entity => {
                entity.HasKey(e => e.Username);
                entity.Property(e => e.Password);
                entity.Property(e => e.DateLogin);

            });  //Constructor de la tabla y sus entidades
        }
    }
}
