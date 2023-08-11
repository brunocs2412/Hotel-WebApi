using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosDeUso
{
    public interface ICUMantenimientoListarEntreDosFechas
    {
        IEnumerable<DTOMantenimiento> GetEntreDosFechas(int idCab, DateTime fecha, DateTime fecha2);
    }
}
