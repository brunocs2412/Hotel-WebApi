using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace LogicaAplicacion.InterfacesCasosDeUso
{
    public interface ICUCabaniaAlta
    {
        public DTOCabania AltaCabania(DTOCabania c); 
    }
}
