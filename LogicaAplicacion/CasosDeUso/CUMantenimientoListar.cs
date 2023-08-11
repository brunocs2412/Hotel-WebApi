using DTOs;
using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUCabaniaConSusMantenimientos : ICUCabaniaConSusMantenimientos
    {
        public IRepositorioCabania RepoCabania { get; set; }

        public CUCabaniaConSusMantenimientos(IRepositorioCabania repoCabania)
        {
            RepoCabania = repoCabania;
        }

        public IEnumerable<DTOMantenimiento> GetCabania(int idCabania)
        {
            try
            {
                IEnumerable<Mantenimiento> mantenimientos = RepoCabania.CabaniaConTodosSusMantenimientos(idCabania);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
