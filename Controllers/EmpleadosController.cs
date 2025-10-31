using Microsoft.AspNetCore.Mvc;
using EjerciciosORM.Models;
using EjerciciosORM.Repositories;

namespace EjerciciosORM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpresaRepository _repository;

        public EmpleadosController(IEmpresaRepository repository)
        {
            _repository = repository;
        }

        // 1️⃣ Consultar empleados

        [HttpGet("TodosLosEmpleados")]
        public async Task<ActionResult<List<Empleados>>> GetTodosLosEmpleados()
        {
            var empleados = await _repository.ObtenerTodosLosEmpleadosAsync();
            return Ok(empleados);
        }

        [HttpGet("CantidadEmpleados")]
        public async Task<ActionResult<int>> GetCantidadEmpleados()
        {
            var cantidad = await _repository.ObtenerCantidadEmpleadosAsync();
            return Ok(cantidad);
        }

        [HttpGet("EmpleadoPorID")]
        public async Task<ActionResult<Empleados>> GetEmpleadoPorID([FromQuery] int empleadoID)
        {
            var empleado = await _repository.ObtenerEmpleadoPorIDAsync(empleadoID);
            if (empleado == null) return NotFound();
            return Ok(empleado);
        }

        [HttpGet("EmpleadosPorNombre")]
        public async Task<ActionResult<List<Empleados>>> GetEmpleadosPorNombre([FromQuery] string nombreEmpleado)
        {
            var empleados = await _repository.ObtenerEmpleadosPorNombreAsync(nombreEmpleado);
            return Ok(empleados);
        }

        [HttpGet("IDempleadoPorTitulo")]
        public async Task<ActionResult<List<Empleados>>> GetEmpleadosPorTitulo([FromQuery] string titulo)
        {
            var empleados = await _repository.ObtenerEmpleadosPorTituloAsync(titulo);
            return Ok(empleados);
        }

        [HttpGet("EmpleadoPorPais")]
        public async Task<ActionResult<Empleados>> GetEmpleadoPorPais([FromQuery] string country)
        {
            var empleado = await _repository.ObtenerEmpleadoPorPaisAsync(country);
            if (empleado == null) return NotFound();
            return Ok(empleado);
        }

        [HttpGet("TodosLosEmpleadosPorPais")]
        public async Task<ActionResult<List<Empleados>>> GetTodosLosEmpleadosPorPais([FromQuery] string country)
        {
            var empleados = await _repository.ObtenerTodosLosEmpleadosPorPaisAsync(country);
            return Ok(empleados);
        }

        [HttpGet("ElEmpleadoMasGrande")]
        public async Task<ActionResult<Empleados>> GetEmpleadoMasGrande()
        {
            var empleado = await _repository.ObtenerEmpleadoMasGrandeAsync();
            return Ok(empleado);
        }

        // 2️⃣ Estadísticas de empleados

        [HttpGet("CantidadEmpleadosPorTitulos")]
        public async Task<ActionResult<List<object>>> GetCantidadEmpleadosPorTitulos()
        {
            var resultado = await _repository.ObtenerCantidadEmpleadosPorTituloAsync();
            return Ok(resultado);
        }

        // 3️⃣ Productos

        [HttpGet("ObtenerProductosConCategoria")]
        public async Task<ActionResult<List<object>>> GetProductosConCategoria()
        {
            var productos = await _repository.ObtenerProductosConCategoriaAsync();
            return Ok(productos);
        }

        [HttpGet("ObtenerProductosQueContienen")]
        public async Task<ActionResult<List<Productos>>> GetProductosQueContienen([FromQuery] string palabra)
        {
            var productos = await _repository.ObtenerProductosQueContienenAsync(palabra);
            return Ok(productos);
        }
    }
}
