using DTOs;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosDeUso;

public interface ICUTipoCabaniaListar
{
    public IEnumerable<DTOTipo> ListarTiposCabania();

}