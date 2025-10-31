using EjerciciosORM.Repositories;
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

        public EmpleadosController(IEmpresaRepository repository)
        {
            _repository = repository;
        }


        // GET api/TodosLosEmpleados
        [HttpGet("TodosLosEmpleados")]
        public async Task<ActionResult<List<Empleados>>> GetTodosLosEmpleados()
        {
            var empleados = await _repository.ObtenerTodosLosEmpleadosAsync();
            return Ok(empleados);
        }

        // GET api/CantidadEmpleados
        [HttpGet("CantidadEmpleados")]
        public async Task<ActionResult<int>> GetCantidadEmpleados()
        {
            int cantidad = await _repository.ObtenerCantidadEmpleadosAsync();
            return Ok(cantidad);
        }

        // GET api/EmpleadoPorID
        [HttpGet("EmpleadoPorID")]
        public async Task<ActionResult<Empleados>> GetEmpleadoPorID([FromQuery] int empleadoID)
        {
            var empleado = await _repository.ObtenerEmpleadoPorIDAsync(empleadoID);
            if (empleado == null)
                return NotFound();
            return Ok(empleado);
        }

        // GET api/EmpleadosPorNombre
        [HttpGet("EmpleadosPorNombre")]
        public async Task<ActionResult<Empleados>> GetEmpleadoPorNombre([FromQuery] string nombreEmpleado)
        {
            var empleado = await _repository.ObtenerEmpleadoPorNombreAsync(nombreEmpleado);
            if (empleado == null)
                return NotFound();
            return Ok(empleado);
        }

        // GET api/IDempleadoPorTitulo
        [HttpGet("IDempleadoPorTitulo")]
        public async Task<ActionResult<Empleados>> GetEmpleadoPorTitulo([FromQuery] string titulo)
        {
            var empleado = await _repository.ObtenerEmpleadoPorTituloAsync(titulo);
            if (empleado == null)
                return NotFound();
            return Ok(empleado);
        }

        // GET api/EmpleadoPorPais
        [HttpGet("EmpleadoPorPais")]
        public async Task<ActionResult<Empleados>> GetEmpleadoPorPais([FromQuery] string country)
        {
            var empleado = await _repository.ObtenerEmpleadoPorPaisAsync(country);
            if (empleado == null)
                return NotFound();
            return Ok(empleado);
        }

        // GET api/TodosLosEmpleadosPorPais
        [HttpGet("TodosLosEmpleadosPorPais")]
        public async Task<ActionResult<List<Empleados>>> GetTodosLosEmpleadosPorPais([FromQuery] string country)
        {
            var empleados = await _repository.ObtenerTodosLosEmpleadosPorPaisAsync(country);
            return Ok(empleados);
        }

        // GET api/ElEmpleadoMasViejo
        [HttpGet("ElEmpleadoMasViejo")]
        public async Task<ActionResult<Empleados>> GetEmpleadoMasGrande()
        {
            var empleado = await _repository.ObtenerEmpleadoMasGrandeAsync();
            if (empleado == null)
                return NotFound();
            return Ok(empleado);
        }

        // GET api/CantidadEmpleadosPorTitulos
        [HttpGet("CantidadEmpleadosPorTitulos")]
        public async Task<ActionResult<List<object>>> GetCantidadEmpleadosPorTitulos()
        {
            var resultado = await _repository.ObtenerCantidadEmpleadosPorTitulosAsync();
            return Ok(resultado);
        }

        // GET api/ObtenerProductosConCategoria
        [HttpGet("ObtenerProductosConCategoria")]
        public async Task<ActionResult<List<Productos>>> GetProductosConCategoria()
        {
            var productos = await _repository.ObtenerProductosConCategoriaAsync();
            return Ok(productos);
        }

        // GET api/ObtenerProductosQueContienenXString
        [HttpGet("ObtenerProductosQueContienenX")]
        public async Task<ActionResult<List<Productos>>> GetProductosQueContienen([FromQuery] string palabra)
        {
            var productos = await _repository.ObtenerProductosQueContienenAsync(palabra);
            return Ok(productos);
        }
    }
}
