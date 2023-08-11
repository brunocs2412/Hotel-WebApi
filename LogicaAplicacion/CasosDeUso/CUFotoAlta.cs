using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUFotoAlta : ICUFotoAlta
    {
        public IRepositorioCabania repositorioCabania { get; set; }

        public CUFotoAlta() { }
        public void CreateFoto(string nombre, int idCabania)
        {
            throw new NotImplementedException();
        }
    }
}
