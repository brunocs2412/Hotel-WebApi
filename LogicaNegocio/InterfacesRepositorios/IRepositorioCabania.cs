using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioCabania: IRepositorio<Cabania>
    {

        public IEnumerable<Cabania> BuscarPorNombre(string nombre);
        public IEnumerable<Cabania> BuscarPorTipo(int tipoId);
        public IEnumerable<Cabania> BuscarPorCantMaxPersonas(int cantidad);
        public IEnumerable<Cabania> BuscarHablitadas();
        public string NuevoNombreFoto(Cabania cabania);
        public Cabania CabaniaConTodosSusMantenimientos(int CabaniaId);
        public int ContarCuantosMantenimientosTieneUnaCabaniaEnUnDia(int CabaniaId, DateTime fecha);
        public bool ValidarSiTipoEstaEnUso(int tipoId);
        public Cabania ListarMantenimientosRealizadosAUnaCabaniaEntreDosFechas(int Cabania, DateTime fecha1, DateTime fecha2);

        public void AddMantenimiento(Mantenimiento m);

        public IEnumerable<Cabania> BuscarPorTipoYMonto(int monto);
        public IEnumerable<object> BuscarMantenimientosPorCapacidadEInformacionDeQuienLoHizo(int capMin, int capMax);

    }
}
