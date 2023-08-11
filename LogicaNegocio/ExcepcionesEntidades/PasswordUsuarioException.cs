using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ExcepcionesEntidaes
{
    public class PasswordUsuarioException: Exception
    {
        public PasswordUsuarioException(string mensaje) : base(mensaje) { }

    }
}
