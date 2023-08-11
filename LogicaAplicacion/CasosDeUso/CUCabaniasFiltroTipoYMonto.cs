using DTOs;
using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUCabaniasFiltroTipoYMonto : ICUCabaniasFiltroTipoYMonto
    {
        public IRepositorioCabania RepositorioCabania { get; set; }

        public CUCabaniasFiltroTipoYMonto(IRepositorioCabania repoCabania)
        {
            RepositorioCabania = repoCabania;
        }
        public IEnumerable<DTOCabaniaListado> GetCabaniasFiltradas(int monto)
        {
            IEnumerable<Cabania> cabanias = RepositorioCabania.BuscarPorTipoYMonto(monto);
            IEnumerable<DTOCabaniaListado> cabaniasdto = cabanias.Select(
              cabania => new DTOCabaniaListado()
              {
                  Id = cabania.Id,
                  Nombre = cabania.Nombre.Nombre,
                  CapacidadMaximaPersonas = cabania.CapacidadMaximaPersonas,
                  NumHabitacion = cabania.NumHabitacion,
                  Descripcion = cabania.Descripcion.Descripcion,
                  HabilitadoReservas = cabania.HabilitadoReservas,
                  PoseeJacuzzi = cabania.PoseeJacuzzi,
                  NombreFoto = cabania.Fotos.First().NombreFoto,
                  TipoNombre = cabania.Tipo.Nombre.NombreTipo,
                  TipoCostoPorHuesped = cabania.Tipo.CostoPorHuesped.Costo

              });
            return cabaniasdto;
        }
    }
}



