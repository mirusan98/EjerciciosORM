using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EjerciciosORM.Models;
using EjerciciosORM.Data;

namespace EjerciciosORM.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly Empresa _context;

        public EmpresaRepository(Empresa context)
        {
            _context = context;
        }

        // Empleados
        public async Task<List<Empleados>> ObtenerTodosLosEmpleadosAsync() =>
            await _context.Empleados.ToListAsync();

        public async Task<int> ObtenerCantidadEmpleadosAsync() =>
            await _context.Empleados.CountAsync();

        public async Task<Empleados> ObtenerEmpleadoPorIDAsync(int empleadoID) =>
            await _context.Empleados.FindAsync(empleadoID);

        public async Task<List<Empleados>> ObtenerEmpleadosPorNombreAsync(string nombre) =>
            await _context.Empleados
                .Where(e => e.Nombre.Contains(nombre) || e.Apellido.Contains(nombre))
                .ToListAsync();

        public async Task<List<Empleados>> ObtenerEmpleadosPorTituloAsync(string titulo) =>
            await _context.Empleados
                .Where(e => e.Titulo == titulo)
                .ToListAsync();

        public async Task<Empleados> ObtenerEmpleadoPorPaisAsync(string pais) =>
            await _context.Empleados.FirstOrDefaultAsync(e => e.Pais == pais);

        public async Task<List<Empleados>> ObtenerTodosLosEmpleadosPorPaisAsync(string pais) =>
            await _context.Empleados.Where(e => e.Pais == pais).ToListAsync();

        public async Task<Empleados> ObtenerEmpleadoMasGrandeAsync() =>
            await _context.Empleados.OrderBy(e => e.FechaNac).FirstOrDefaultAsync();

        // Estadísticas
        public async Task<List<object>> ObtenerCantidadEmpleadosPorTituloAsync() =>
            await _context.Empleados
                .GroupBy(e => e.Titulo)
                .Select(g => new { Titulo = g.Key, Cantidad = g.Count() })
                .ToListAsync<object>();

        // Productos
        public async Task<List<object>> ObtenerProductosConCategoriaAsync() =>
            await _context.Productos
                .Include(p => p.Categoria)
                .Select(p => new
                {
                    p.ProductoID,
                    p.NombreProducto,
                    Categoria = p.Categoria.NombreCategoria,
                    p.Precio
                })
                .ToListAsync<object>();

        public async Task<List<Productos>> ObtenerProductosQueContienenAsync(string palabra) =>
            await _context.Productos
                .Where(p => p.NombreProducto.Contains(palabra))
                .ToListAsync();
    }
}
