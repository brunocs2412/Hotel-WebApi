using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosDeUso
{
    public interface ICUCabaniaActualizar
    {
        public void CabaniaActualizar(int idCabania, DTOCabania dtoCabania);
    }
}
