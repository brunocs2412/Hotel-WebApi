using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ExcepcionesEntidades;

public class CabaniaException: Exception
{
    public CabaniaException(string mensaje) : base(mensaje) { }

}
