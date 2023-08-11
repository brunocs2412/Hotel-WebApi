using DTOs;
using LogicaAplicacion.CasosDeUso;
using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiHotel.Controllers;

[Route("api/[controller]")]
[ApiController]

[Authorize]
public class CabaniaController : ControllerBase
{
    public ICUCabaniaAlta _cuAltaCabania;
    public ICUCabaniaListar _cuCabaniaListar;
    public ICUCabaniaBuscarPorNombre _cUBusquedaCabaniaPorNombre;
    public ICUCabaniaBuscarPorTipo _cUBusquedaTipo;
    public ICUCabaniaBuscarHabilitadas _cuBuscarHabilitadas;
    public ICUCabaniaBuscarPorCapacidad _cuBuscarPorCapacidad;
    public ICUMantenimientoAlta _cuMantenimientoAlta;
    public ICUCabaniaActualizar _cuCabaniaActualizar;
    public ICUCabaniaDelete _cuCabaniaDelete;
    public ICUCabaniaBuscarPorId _cuCabaniaBuscarPorId;
    public ICUCabaniasFiltroTipoYMonto _cuCabFiltroPorTipoYMonto;
    public ICUMantenimientosListar _cuMantenimientoListar;
    public ICUMantenimientoListarEntreDosFechas _cuMantenimientosEntreDosFechas;
    public ICUMantenimientoBusquedaPorCapacidad _cuMantenimientoBusquedaPorCapacidad;


    public CabaniaController(ICUCabaniaAlta cuAltaCabania, ICUCabaniaBuscarPorNombre cUBusquedaCabaniaPorNombre,
                             ICUCabaniaListar cuCabaniaListar, ICUCabaniaBuscarPorTipo cUBusquedaTipo,
                             ICUCabaniaBuscarHabilitadas cUCabaniaBuscarHabilitadas,
                             ICUCabaniaBuscarPorCapacidad cUCabaniaBuscarPorCapacidad,
                             ICUMantenimientoAlta cUMantenimientoAlta,
                             ICUCabaniaActualizar cUCabaniaActualizar, ICUCabaniaDelete cuCabaniaDelete,
                             ICUCabaniaBuscarPorId cUCabaniaBuscarPorId, ICUCabaniasFiltroTipoYMonto cUCabaniasFiltroTipoYMonto,
                             ICUMantenimientosListar cUMantenimientosListar,
                             ICUMantenimientoListarEntreDosFechas cuMantenimientosEntreDosFechas,
                             ICUMantenimientoBusquedaPorCapacidad cuMantenimientoBusquedaPorCapacidad
    )
    {

        _cuAltaCabania = cuAltaCabania;
        _cUBusquedaCabaniaPorNombre = cUBusquedaCabaniaPorNombre;
        _cuCabaniaListar = cuCabaniaListar;
        _cUBusquedaTipo = cUBusquedaTipo;
        _cuBuscarHabilitadas = cUCabaniaBuscarHabilitadas;
        _cuBuscarPorCapacidad = cUCabaniaBuscarPorCapacidad;
        _cuMantenimientoAlta = cUMantenimientoAlta;
        _cuCabaniaActualizar = cUCabaniaActualizar;
        _cuCabaniaDelete = cuCabaniaDelete;
        _cuCabaniaBuscarPorId = cUCabaniaBuscarPorId;
        _cuCabFiltroPorTipoYMonto = cUCabaniasFiltroTipoYMonto;
        _cuMantenimientoListar = cUMantenimientosListar;
        _cuMantenimientosEntreDosFechas = cuMantenimientosEntreDosFechas;
        _cuMantenimientoBusquedaPorCapacidad = cuMantenimientoBusquedaPorCapacidad;
    }



    /// <summary>
    /// Obtiene todos las cabanias que existen en el sistema
    /// </summary>
    /// <returns></returns>
    /// <response code="200">Trae todas las cabanias</response>
    /// <response code="404">Si no se encontro cabanias</response>
    /// <response code="401">Si no autorizado</response>
    /// <response code="500">Eror interno del servidor</response>

    [HttpGet]
    public IActionResult GetCabanias()
    {
        try
        {
            return Ok(_cuCabaniaListar.GetCabanias());
        }
        catch (CabaniaException)
        {
            return NotFound();
        }
        catch
        {
            return StatusCode(500);
        }
    }

    /// <summary>
    /// Trae las cabanias que contengan el string en su nombre
    /// </summary>
    /// <param name="nombre"></param>
    /// <response code="200">Trae todas las cabanias que contenga ese nombre</response>
    /// <response code="404">Si no se encontro cabanias</response>
    /// <response code="401">Si no autorizado</response>
    /// <response code="500">Eror interno del servidor</response>

    [HttpGet("buscarpornombre/{nombre}")]
    public IActionResult GetCabaniasPorNombre(string nombre)
    {
        try
        {
            IEnumerable<DTOCabaniaListado> cabanias = _cUBusquedaCabaniaPorNombre.BuscarCabaniaPorNombre(nombre);

            return Ok(cabanias);

        }
        catch (CabaniaException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }

    }

    /// <summary>
    /// Obtiene la cabania por su id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <response code="200">Trae todas las cabanias que contenga ese nombre</response>
    /// <response code="404">Si no se encontro la cabania</response>
    /// <response code="401">Si no autorizado</response>
    /// <response code="500">Eror interno del servidor</response>
    
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        try
        {
            return Ok(_cuCabaniaBuscarPorId.BuscarPorId(id));
        }
        catch (CabaniaException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }

    /// <summary>
    /// Buscar por tipo de cabania
    /// </summary>
    /// <param name="idTipo"></param>
    /// <returns></returns>
    /// <response code="200">Trae todas las cabanias que contenga ese tipo</response>
    /// <response code="404">Si no se encontro las cabanias con ese tipo</response>
    /// <response code="401">Si no autorizado</response>
    /// <response code="500">Eror interno del servidor</response>
    /// 

    [HttpGet("buscarportipo/{idTipo}")]
    public IActionResult BuscarPorTipo(int idTipo)
    {
        try
        {
            return Ok(_cUBusquedaTipo.BuscarCabaniasPorTipo(idTipo));
        }
        catch (CabaniaException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    /// <summary>
    /// busca todas las cabanias con estado habilitado = true
    /// </summary>
    /// <returns></returns>
    /// <response code="200">Trae todas las cabanias que esten hablitadas</response>
    /// <response code="404">Si no se encontraron hablitadas</response>
    /// <response code="401">Si no autorizado</response>
    /// <response code="500">Eror interno del servidor</response>
    
    [HttpGet("buscarhabilitdas")]
    public IActionResult BuscarHabilitadas()
    {
        try
        {
            return Ok(_cuBuscarHabilitadas.BuscarCabaniasHabilitadas());
        }
        catch (CabaniaException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    /// <summary>
    /// Busca todas las cabanias con capacidad mayor a la ingresada
    /// </summary>
    /// <param name="capacidad"></param>
    /// <returns></returns>
    /// <response code="200">Trae todas las cabanias con esa capacidad</response>
    /// <response code="404">Si no se encontraron cabanias</response>
    /// <response code="401">Si no autorizado</response>
    /// <response code="500">Eror interno del servidor</response>

    [HttpGet("capacidad/{capacidad}")]
    public IActionResult GetByCapacidad(int capacidad)
    {
        try
        {
            return Ok(_cuBuscarPorCapacidad.BuscarPorCapacidad(capacidad));
        }
        catch (CabaniaException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }

    }

    /// <summary>
    /// filtra las cabanias por monto
    /// </summary>
    /// <param name="monto"></param>
    /// <returns></returns>
    /// <response code="200">Trae todas las cabanias menores al monto ingresado</response>
    /// <response code="404">Si no se encontraron cabanias</response>
    /// <response code="401">Si no autorizado</response>
    /// <response code="500">Eror interno del servidor</response>
    ///

    [HttpGet("filtrarpormonto/{monto}")]
    public IActionResult FiltrarCabaniasPorTipoYMonto(int monto)
    {
        try
        {
            return Ok(_cuCabFiltroPorTipoYMonto.GetCabaniasFiltradas(monto));
        }
        catch (CabaniaException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }

    }

    /// <summary>
    /// Para crear una cabania
    /// </summary>
    /// <param name="dtoCabania"></param>
    /// <returns></returns>
    /// <remarks>
    ///  Sample request:
    ///
    ///     POST /Todo
    ///     {
    ///        "Foto": "Es necesaria para crearla",
    ///     
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Se creo correctamente la cabania</response>
    /// <response code="400">Tenes que ingresar todos los datos correctos</response>
    /// <response code="401">No esta autorizado</response>
    /// <response code="500">Problemas con el servidor</response>

    [HttpPost]
    public IActionResult AgregarCabania(DTOCabania dtoCabania)
    {
        try
        {
            if (dtoCabania == null) return BadRequest("Ingrese todos los valores");

            dtoCabania = _cuAltaCabania.AltaCabania(dtoCabania);

            return CreatedAtAction(nameof(Get), new { id = dtoCabania.Id }, dtoCabania);

        }
        catch (CabaniaException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    /// <summary>
    /// Actualizar una cabania
    /// </summary>
    /// <param name="dtoCabania"></param>
    /// <returns></returns>
    /// <response code="200">Se edito correctamente</response>
    /// <response code="400">Errores del cliente</response>
    /// <response code="401">No esta autorizado</response>
    /// <response code="500">Problemas con el servidor</response>

    [HttpPut]
    public IActionResult Put([FromBody] DTOCabania dtoCabania)
    {
        try
        {
            if (dtoCabania == null || dtoCabania.Id == null) return BadRequest("Todos los datos son obligatorios");
            _cuCabaniaActualizar.CabaniaActualizar((int)dtoCabania.Id, dtoCabania);
            return Ok();
        }
        catch (CabaniaException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }


    }

    /// <summary>
    ///  Para eliminar una cabania
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <response code="204">Se eliminó La cabania correctamente</response>
    /// <response code="400">Errores del cliente</response>
    /// <response code="401">No esta autorizado</response>
    /// <response code="500">Problemas con el servidor</response>
    /// 

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _cuCabaniaDelete.Delete(id);
            return NoContent();
        }
        catch (CabaniaException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    /// <summary>
    /// agrega un montenimiento a la cabania seleccionada
    /// </summary>
    /// <param name="dtoMantenimiento"></param>
    /// <returns></returns>
    /// <response code="200">Si se agrega el matnenimiento correctamente</response>
    /// <response code="400">Si se fallo alguna validacion</response>
    /// <response code="401">Si no autorizado</response>
    /// <response code="500">Eror interno del servidor</response>
    
    [HttpPost("alta/mantenimiento")]

    public IActionResult AgregarMantenimiento(DTOMantenimiento dtoMantenimiento)
    {
        try
        {
            return Ok(_cuMantenimientoAlta.AltaMantenimiento(dtoMantenimiento));
        }
        catch (MantenimientoException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    /// <summary>
    /// Obtiene todos los manteinimientos de una cabania
    /// </summary>
    /// <param name="idCabania"></param>
    /// <returns></returns>
    /// <response code="200">te trae todos los mantenimientos</response>
    /// <response code="404">Si no tiene ningun mantenimiento la cabania</response>
    /// <response code="401">Si no autorizado</response>
    /// <response code="500">Eror interno del servidor</response>
    
    [HttpGet("mantenimientos/{idCabania}")]
    public IActionResult GetMantenimientos(int idCabania)
    {
        try
        {
            return Ok(_cuMantenimientoListar.GetMantenimientos(idCabania));
        }
        catch (CabaniaException ex)
        {
            return BadRequest();
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }

    /// <summary>
    /// Obtiene todos los manteinimientos de una cabania entre dos fechas
    /// </summary>
    /// <param name="id"></param>
    /// <param name="fecha1"></param>
    /// <param name="fecha2"></param>
    /// <returns></returns>
    /// <response code="200">te trae todos los mantenimientos entre esas fechas</response>
    /// <response code="404">Si no tiene ningun mantenimiento la cabania entre esas fechas</response>
    /// <response code="401">Si no autorizado</response>
    /// <response code="500">Eror interno del servidor</response>
    [HttpGet("mantenimientos/entreFechas")]
    public IActionResult ListarManteinimentosEntreDosFechas(int id, DateTime fecha1, DateTime fecha2)
    {
        try
        {
            return Ok(_cuMantenimientosEntreDosFechas.GetEntreDosFechas(id, fecha1, fecha2));
        }
        catch (MantenimientoException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    /// <summary>
    /// te traer el nombre del trabajador y el monto total de todos los manteinimientos que hizo
    /// </summary>
    /// <param name="capMin"></param>
    /// <param name="capMax"></param>
    /// <returns></returns>
    /// <response code="200">te trae todos las estadisticas</response>
    /// <response code="404">Si no se encontraron en ese rango</response>
    /// <response code="401">Si no autorizado</response>
    /// <response code="500">Eror interno del servidor</response>
    [HttpGet("manteniminetos/estadistica/{capMin}/{capMax}")]
    public IActionResult MantenimientosPorCapacidad(int capMin, int capMax)
    {

        try
        {
            return Ok(_cuMantenimientoBusquedaPorCapacidad.BuscarMantenimientosPorCapacidad(capMin, capMax));
        }
        catch (CabaniaException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }

    }


}
