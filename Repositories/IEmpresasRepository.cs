using EjerciciosORM.Models;

namespace EjerciciosORM.Repositories
{
    public interface IEmpresaRepository
    {
        Task<List<Empleados>> ObtenerTodosLosEmpleadosAsync();
        Task<int> ObtenerCantidadEmpleadosAsync();
        Task<Empleados> ObtenerEmpleadoPorIDAsync(int id);
        Task<Empleados> ObtenerEmpleadoPorNombreAsync(string nombre);
        Task<Empleados> ObtenerEmpleadoPorTituloAsync(string titulo);
        Task<Empleados> ObtenerEmpleadoPorPaisAsync(string country);
        Task<List<Empleados>> ObtenerTodosLosEmpleadosPorPaisAsync(string country);
        Task<Empleados> ObtenerEmpleadoMasGrandeAsync();
        Task<List<object>> ObtenerCantidadEmpleadosPorTitulosAsync();
        Task<List<Productos>> ObtenerProductosConCategoriaAsync();
        Task<List<Productos>> ObtenerProductosQueContienenAsync(string palabra);

    }
}

