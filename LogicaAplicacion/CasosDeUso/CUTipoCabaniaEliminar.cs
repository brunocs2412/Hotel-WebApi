using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUTipoCabaniaEliminar: ICUTipoCabaniaEliminar
    {
        public IRepositorioTipo _repositorioTipo;
        public CUTipoCabaniaEliminar(IRepositorioTipo repositorioTipo)
        {
            _repositorioTipo = repositorioTipo;
        }
        public void Delete(int id)
        {
            try
            {
                _repositorioTipo.Delete(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
