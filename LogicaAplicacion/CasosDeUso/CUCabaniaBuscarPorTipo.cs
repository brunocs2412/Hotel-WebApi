using DTOs;
using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.ValueObjects;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUCabaniaBuscarPorTipo : ICUCabaniaBuscarPorTipo
    {
        public IRepositorioCabania RepoCabania { get; set; }

        public CUCabaniaBuscarPorTipo(IRepositorioCabania repo)
        {
            RepoCabania = repo;
        }
        public IEnumerable<DTOCabaniaListado> BuscarCabaniasPorTipo(int tipoId)
        {

            IEnumerable<Cabania> cabanias = RepoCabania.BuscarPorTipo(tipoId);
            IEnumerable<DTOCabaniaListado> dTOCabanias = cabanias.Select(cabania => new DTOCabaniaListado()
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

            return dTOCabanias;

        }
    }
}
