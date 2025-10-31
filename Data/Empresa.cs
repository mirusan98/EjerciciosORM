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

        // Tablas mapeadas
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleados>().ToTable("Empleados");
            modelBuilder.Entity<Productos>().ToTable("Productos");
            modelBuilder.Entity<Categorias>().ToTable("Categorias");
        }


    }
}

