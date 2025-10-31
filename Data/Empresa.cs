using EjerciciosORM.Models;
using Microsoft.EntityFrameworkCore;

namespace EjerciciosORM.Data
{
    public class Empresa : DbContext
    {
        public Empresa(DbContextOptions<Empresa> options)
            : base(options)
        {
        }

        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Categorias> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleados>().ToTable("Empleados");
            modelBuilder.Entity<Productos>().ToTable("Productos");
            modelBuilder.Entity<Categorias>().ToTable("Categorias");

            modelBuilder.Entity<Productos>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.CategoriaID);
        }
    }
}
