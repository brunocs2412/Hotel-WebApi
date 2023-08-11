using DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApiHotel
{
    public class ManejadorToken
    {
        internal static string CrearToken(DTOUsuario dtoUsuario)
        {

            byte[] clave = Encoding.ASCII.GetBytes("ZWRpw6fDo28gZW0gY29tcHV0YWRvcmE=");

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            //clave secreta, generalmente se incluye en el archivo de configuración
            //Debe ser un vector de bytes         

            //Se incluye un claim para el email
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, dtoUsuario.Email),
                    //new Claim("ID", usu.Id.ToString()),
                    //new Claim(ClaimTypes.Role, dtoUsuario.Rol)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(clave),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
