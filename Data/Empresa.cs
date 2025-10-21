using EjerciciosORM.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

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
            // Opcional: configurar nombres de tablas si no coinciden con los de la BD
            modelBuilder.Entity<Empleados>().ToTable("Empleados");
            modelBuilder.Entity<Productos>().ToTable("Productos");
            modelBuilder.Entity<Categorias>().ToTable("Categorias");
        }
    }
}

