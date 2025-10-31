using System.Collections.Generic;
using System.Threading.Tasks;
using EjerciciosORM.Models;

namespace EjerciciosORM.Repositories
{
    public interface IEmpresaRepository
    {
        Task<List<Empleados>> ObtenerTodosLosEmpleadosAsync();
        Task<int> ObtenerCantidadEmpleadosAsync();
        Task<Empleados> ObtenerEmpleadoPorIDAsync(int empleadoID);
        Task<List<Empleados>> ObtenerEmpleadosPorNombreAsync(string nombre);
        Task<List<Empleados>> ObtenerEmpleadosPorTituloAsync(string titulo);
        Task<Empleados> ObtenerEmpleadoPorPaisAsync(string pais);
        Task<List<Empleados>> ObtenerTodosLosEmpleadosPorPaisAsync(string pais);
        Task<Empleados> ObtenerEmpleadoMasGrandeAsync();
        Task<List<object>> ObtenerCantidadEmpleadosPorTituloAsync();
        Task<List<object>> ObtenerProductosConCategoriaAsync();
        Task<List<Productos>> ObtenerProductosQueContienenAsync(string palabra);
    }
}

