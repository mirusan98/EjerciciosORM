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

        public async Task<List<Empleados>> ObtenerTodosLosEmpleadosAsync()
        {
            return await _context.Empleados.ToListAsync();
        }

        public async Task<int> ObtenerCantidadEmpleadosAsync()
        {
            return await _context.Empleados.CountAsync();
        }

        public async Task<Empleados> ObtenerEmpleadoPorIDAsync(int id)
        {
            return await _context.Empleados.FirstOrDefaultAsync(e => e.EmpleadoID == id);
        }

        public async Task<Empleados> ObtenerEmpleadoPorNombreAsync(string nombre)
        {
            return await _context.Empleados.FirstOrDefaultAsync(e => e.Nombre.Contains(nombre) || e.Apellido.Contains(nombre));
        }

        public async Task<Empleados> ObtenerEmpleadoPorTituloAsync(string titulo)
        {
            return await _context.Empleados.FirstOrDefaultAsync(e => e.Titulo == titulo);
        }

        public async Task<Empleados> ObtenerEmpleadoPorPaisAsync(string pais)
        {
            return await _context.Empleados.FirstOrDefaultAsync(e => e.Pais == pais);
        }

        public async Task<List<Empleados>> ObtenerTodosLosEmpleadosPorPaisAsync(string pais)
        {
            return await _context.Empleados.Where(e => e.Pais == pais).ToListAsync();
        }

        public async Task<Empleados> ObtenerEmpleadoMasGrandeAsync()
        {
            return await _context.Empleados.OrderBy(e => e.FechaNac).FirstOrDefaultAsync();
        }

        public async Task<List<object>> ObtenerCantidadEmpleadosPorTitulosAsync()
        {
            var resultado = await _context.Empleados.GroupBy(e => e.Titulo)
                .Select(g => new
                {
                    Titulo = g.Key,
                    Cantidad = g.Count()
                })
                .ToListAsync();

            return resultado.Cast<object>().ToList();
        }


        public async Task<List<Productos>> ObtenerProductosConCategoriaAsync()
        {
            return await _context.Productos.Include(p => p.Categoria).ToListAsync();
        }

        public async Task<List<Productos>> ObtenerProductosQueContienenAsync(string palabra)
        {
            return await _context.Productos.Where(p => p.NombreProducto.Contains(palabra)).Include(p => p.Categoria).ToListAsync();
        }
    }
}
