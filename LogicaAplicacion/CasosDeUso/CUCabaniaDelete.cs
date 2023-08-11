using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUCabaniaDelete : ICUCabaniaDelete
    {
        public IRepositorioCabania RepoCabania { get; set; }

        public CUCabaniaDelete(IRepositorioCabania repoCab)
        {
            RepoCabania = repoCab;
        }

        public void Delete(int idCabania)
        {
            try
            {
                RepoCabania.Delete(idCabania);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
