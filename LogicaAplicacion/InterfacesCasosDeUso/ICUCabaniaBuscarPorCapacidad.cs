using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosDeUso
{
    public interface ICUCabaniaBuscarPorCapacidad
    {
        public IEnumerable<DTOCabaniaListado> BuscarPorCapacidad(int capacidad);
    }
}
