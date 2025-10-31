using Microsoft.EntityFrameworkCore;
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

        // 1️⃣ Consultar empleados

        public async Task<List<Empleados>> ObtenerTodosLosEmpleadosAsync()
        {
            return await _context.Empleados.ToListAsync();
        }

        public async Task<int> ObtenerCantidadEmpleadosAsync()
        {
            return await _context.Empleados.CountAsync();
        }

        public async Task<Empleados> ObtenerEmpleadoPorIDAsync(int empleadoID)
        {
            return await _context.Empleados.FindAsync(empleadoID);
        }

        public async Task<List<Empleados>> ObtenerEmpleadosPorNombreAsync(string nombre)
        {
            return await _context.Empleados
                .Where(e => e.Nombre.Contains(nombre) || e.Apellido.Contains(nombre))
                .ToListAsync();
        }

        public async Task<List<Empleados>> ObtenerEmpleadosPorTituloAsync(string titulo)
        {
            return await _context.Empleados
                .Where(e => e.Titulo == titulo)
                .ToListAsync();
        }

        public async Task<Empleados> ObtenerEmpleadoPorPaisAsync(string pais)
        {
            return await _context.Empleados.FirstOrDefaultAsync(e => e.Pais == pais);
        }

        public async Task<List<Empleados>> ObtenerTodosLosEmpleadosPorPaisAsync(string pais)
        {
            return await _context.Empleados
                .Where(e => e.Pais == pais)
                .ToListAsync();
        }

        public async Task<Empleados> ObtenerEmpleadoMasGrandeAsync()
        {
            return await _context.Empleados
                .OrderBy(e => e.FechaNac)
                .FirstOrDefaultAsync();
        }

        // 2️⃣ Estadísticas

        public async Task<List<object>> ObtenerCantidadEmpleadosPorTituloAsync()
        {
            return await _context.Empleados
                .GroupBy(e => e.Titulo)
                .Select(g => new
                {
                    Titulo = g.Key,
                    Cantidad = g.Count()
                })
                .ToListAsync<object>();
        }

        // 3️⃣ Productos

        public async Task<List<object>> ObtenerProductosConCategoriaAsync()
        {
            return await _context.Productos
                .Include(p => p.Categoria)
                .Select(p => new
                {
                    p.ProductoID,
                    p.NombreProducto,
                    Categoria = p.Categoria.NombreCategoria,
                    p.Precio
                })
                .ToListAsync<object>();
        }

        public async Task<List<Productos>> ObtenerProductosQueContienenAsync(string palabra)
        {
            return await _context.Productos
                .Where(p => p.NombreProducto.Contains(palabra))
                .ToListAsync();
        }
    }
}
