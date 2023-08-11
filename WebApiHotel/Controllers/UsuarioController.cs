using DTOs;
using LogicaAplicacion.CasosDeUso;
using LogicaAplicacion.InterfacesCasosDeUso;
using Microsoft.AspNetCore.Mvc;


namespace WebApiHotel.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    public ICULogin CULogin { get; set; }

    public UsuarioController(ICULogin cULogin)
    {
        CULogin = cULogin;
    }

    /// <summary>
    /// Metodo para Iniciar Session y obtener el Token
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    /// <response code="200">Si logro iniciar sesion</response>
    /// <response code="400">Datos del usuario incorrectos</response>
    /// <response code="500">Error en el servidor</response>


    [HttpPost("login")]
    public IActionResult Login(string email, string password)
    {

        try
        {
            if(string.IsNullOrEmpty(email)|| string.IsNullOrEmpty(password)) return BadRequest("Todos los datos son obligatorios");

            var dtoUsuario = CULogin.Login(email,password);

            if(dtoUsuario == null) return BadRequest("Usuario o contraseña incorrectos");


            DTOUsuarioLogeado dTOUsuarioLogeado = new DTOUsuarioLogeado()
            {
                Email = dtoUsuario.Email,
                Token = ManejadorToken.CrearToken(dtoUsuario)
            };

            
            return Ok(dTOUsuarioLogeado);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }



}
