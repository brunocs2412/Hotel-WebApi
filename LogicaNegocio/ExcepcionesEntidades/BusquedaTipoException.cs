using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ExcepcionesEntidades;

public class BusquedaTipoException : Exception
{
    public BusquedaTipoException(string mensaje) : base(mensaje) { }
}
