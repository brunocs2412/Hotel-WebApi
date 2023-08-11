using DTOs;
using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiHotel.Controllers;

[Route("api/[controller]")]
[ApiController]

[Authorize]
public class TipoController : ControllerBase
{

    public ICUTipoCabaniaAlta CUAltaTipoCabania { get; set; }
    public ICUTipoCabaniaListar CUListarTiposCabania { get; set; }
    public ICUTipoCabaniaActualizar CUActualizarTipoCabania { get; set; }
    public ICUTipoCabaniaBuscarPorNombre CUTipoCabaniaBuscarPorNombre { get; set; }
    public ICUTipoCabaniaEliminar CUTipoCabaniaEliminar { get; set; }

    public TipoController(ICUTipoCabaniaAlta cUAltaTipoCabania, ICUTipoCabaniaListar cUListarTiposCabania,
        ICUTipoCabaniaActualizar cUTipoCabaniaActualizar, ICUTipoCabaniaBuscarPorNombre cUTipoCabaniaBuscarPorNombre, ICUTipoCabaniaEliminar cUTipoCabaniaEliminar
    )
    {
        CUAltaTipoCabania = cUAltaTipoCabania;
        CUListarTiposCabania = cUListarTiposCabania;
        CUActualizarTipoCabania = cUTipoCabaniaActualizar;
        CUTipoCabaniaBuscarPorNombre = cUTipoCabaniaBuscarPorNombre;
        CUTipoCabaniaEliminar = cUTipoCabaniaEliminar;
    }

    /// <summary>
    /// Te trae todos los tipos de cabanias
    /// </summary>
    /// <returns></returns>
    /// <response code="200">Te trae todos los tipos</response>
    /// <response code="404">Si no se encontraron los tipos</response>
    /// <response code="401">No esta autorizado</response>
    /// <response code="500">Eror interno del servidor</response>

    [HttpGet("todos")]
    public IActionResult GetAll()
    {
        try
        {
            return Ok(CUListarTiposCabania.ListarTiposCabania());

        }
        catch (TipoException ex)
        {
            return StatusCode(404, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    /// <summary>
    /// Crear un nuevo Tipo de Cabania
    /// </summary>
    /// <param name="dtoTipo"></param>
    /// <returns></returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Todo
    ///     {
    ///        "Nombre": "No se puede repetir ",
    ///     
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Se creo correctamente el tipo</response>
    /// <response code="400">Tenes que ingresar todos los datos correctos</response>
    /// <response code="401">No esta autorizado</response>
    /// <response code="500">Problemas con el servidor</response>

    [HttpPost]
    public IActionResult Post([FromBody] DTOTipo dtoTipo)
    {
        try
        {
            if (dtoTipo == null) return BadRequest("Ingrese todos los valores");
            dtoTipo = CUAltaTipoCabania.AltaTipoCabania(dtoTipo);

            return CreatedAtAction(nameof(BuscarTipoPorNombre), new { nombre = dtoTipo.Nombre }, dtoTipo);

        }
        catch (TipoException ex)
        {
            return StatusCode(400, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    /// <summary>
    /// Actualizar un Tipo de Cabania existente
    /// </summary>
    /// <param name="dTOTipo"></param>
    /// <returns></returns>
    /// <response code="200">se edito correctamente</response>
    /// <response code="400">Errores del cliente</response>
    /// <response code="401">No esta autorizado</response>
    /// <response code="500">Problemas con el servidor</response>

    [HttpPut()]
    public IActionResult Put([FromBody] DTOTipo dTOTipo)
    {
        try
        {
            if (dTOTipo == null) return BadRequest("Todos los datos son obligatorios");
            CUActualizarTipoCabania.ActualizarTipoCabania(dTOTipo);
            return Ok("se edito correctamente");
        }
        catch (TipoException ex)
        {
            return StatusCode(400, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    /// <summary>
    /// Eliminar un Tipo de Cabania existente
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <response code="204">Se eliminó el tipo correctamente</response>
    /// <response code="400">Errores del cliente</response>
    /// <response code="401">No esta autorizado</response>
    /// <response code="500">Problemas con el servidor</response>
    

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            CUTipoCabaniaEliminar.Delete(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            if (ex.InnerException is Microsoft.Data.SqlClient.SqlException sqlEx && sqlEx.Number == 547)
            {
                // El número 547 corresponde a un error de violación de restricción de integridad referencial en SQL Server.
                return StatusCode(400, "El tipo no puede ser eliminado porque está en uso.");
            }

            return StatusCode(500, "Error interno del servidor. Intente nuevamente más tarde.");
        }
    }

    /// <summary>
    /// Buscar un Tipo de Cabania por nombre
    /// </summary>
    /// <param name="nombre"></param>
    /// <returns></returns>
    /// <response code="200">Te trae el tipo con ese nombre</response>
    /// <response code="404">Si no se encontraro el tipo</response>
    /// <response code="401">No esta autorizado</response>
    /// <response code="500">Eror interno del servidor</response>
    
    [HttpGet("{nombre}")]
    public IActionResult BuscarTipoPorNombre(string nombre)
    {
        try
        {
            if (nombre == null || nombre == "") return BadRequest("Ingrese un nombre para buscar el Tipo");

            var tipo = CUTipoCabaniaBuscarPorNombre.BuscarTipoCabaniaPorNombre(nombre);

            return Ok(tipo);
        }
        catch (BusquedaTipoException)
        {
            return NotFound("No se encontró el tipo con el nombre");
        }
        catch (TipoException ex)
        {
            return StatusCode(400, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }



}
