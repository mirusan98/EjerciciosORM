using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using EjerciciosORM.Models;
using EjerciciosORM.Repositories;

namespace EjerciciosORM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpresaRepository _repository;

        public EmpleadosController(IEmpresaRepository repositorio)
        {
            _repository = repositorio;
        }

        [HttpGet("TodosLosEmpleados")]
        public async Task<ActionResult<List<Empleados>>> GetTodosLosEmpleados() =>
            Ok(await _repository.ObtenerTodosLosEmpleadosAsync());

        [HttpGet("CantidadEmpleados")]
        public async Task<ActionResult<int>> GetCantidadEmpleados() =>
            Ok(await _repository.ObtenerCantidadEmpleadosAsync());

        [HttpGet("EmpleadoPorID")]
        public async Task<ActionResult<Empleados>> GetEmpleadoPorID([FromQuery] int empleadoID)
        {
            var empleado = await _repository.ObtenerEmpleadoPorIDAsync(empleadoID);
            return empleado == null ? NotFound() : Ok(empleado);
        }

        [HttpGet("EmpleadosPorNombre")]
        public async Task<ActionResult<List<Empleados>>> GetEmpleadosPorNombre([FromQuery] string nombreEmpleado) =>
            Ok(await _repository.ObtenerEmpleadosPorNombreAsync(nombreEmpleado));

        [HttpGet("IDempleadoPorTitulo")]
        public async Task<ActionResult<List<Empleados>>> GetEmpleadosPorTitulo([FromQuery] string titulo) =>
            Ok(await _repository.ObtenerEmpleadosPorTituloAsync(titulo));

        [HttpGet("EmpleadoPorPais")]
        public async Task<ActionResult<Empleados>> GetEmpleadoPorPais([FromQuery] string pais)
        {
            var empleado = await _repository.ObtenerEmpleadoPorPaisAsync(pais);
            return empleado == null ? NotFound() : Ok(empleado);
        }

        [HttpGet("TodosLosEmpleadosPorPais")]
        public async Task<ActionResult<List<Empleados>>> GetTodosLosEmpleadosPorPais([FromQuery] string pais) =>
            Ok(await _repository.ObtenerTodosLosEmpleadosPorPaisAsync(pais));

        [HttpGet("ElEmpleadoMasGrande")]
        public async Task<ActionResult<Empleados>> GetEmpleadoMasGrande() =>
            Ok(await _repository.ObtenerEmpleadoMasGrandeAsync());

        [HttpGet("CantidadEmpleadosPorTitulos")]
        public async Task<ActionResult<List<object>>> GetCantidadEmpleadosPorTitulos() =>
            Ok(await _repository.ObtenerCantidadEmpleadosPorTituloAsync());

        [HttpGet("ObtenerProductosConCategoria")]
        public async Task<ActionResult<List<object>>> GetProductosConCategoria() =>
            Ok(await _repository.ObtenerProductosConCategoriaAsync());

        [HttpGet("ObtenerProductosQueContienen")]
        public async Task<ActionResult<List<Productos>>> GetProductosQueContienen([FromQuery] string cadena) =>
            Ok(await _repository.ObtenerProductosQueContienenAsync(cadena));
    }
}
