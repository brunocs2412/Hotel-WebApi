using LogicaNegocio.ExcepcionesEntidaes;
using LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio;

public class Usuario : IValidar
{
    public int Id { get; set; }
    
    [EmailAddress]
    public string Email { set; get; }

    [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
    public string Password { set; get; }

    public void ValidarDatos()
    {
        ValidarEmail();
        ValidarPassword();
    }
    public void ValidarEmail()
    {
        try
        {
            //Valida el Email por las dudas pero el atributo EmailAddress ya lo hace
            if (string.IsNullOrEmpty(Email)) throw new EmailUsuarioException("El email no puede ser vacío");
            string ExpresionRegularEmail = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
            + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
            + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
            + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$";

            if (!Regex.IsMatch(Email, ExpresionRegularEmail)) throw new EmailUsuarioException("El email ingresado no es válido");

        }
        catch (EmailUsuarioException ex)
        {
            throw ex;
        }
       
    }
    public void ValidarPassword()
    {
       
        if (!Regex.IsMatch(Password, @"[A-Z]"))
            throw new PasswordUsuarioException("La contraseña debe contener al menos una letra mayúscula");

        if (!Regex.IsMatch(Password, @"[\p{P}\p{S}]"))
            throw new PasswordUsuarioException("La contraseña debe contener al menos un signo ");

    }
}
