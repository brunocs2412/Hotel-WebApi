using DTOs;
using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUCabaniaListar: ICUCabaniaListar
    {
        public IRepositorioCabania RepoCabania { get; set; }

        public CUCabaniaListar(IRepositorioCabania repo)
        {
            RepoCabania = repo;
        }
        public IEnumerable<DTOCabaniaListado> GetCabanias()
        {
            try
            {
                IEnumerable<Cabania> cabanias = RepoCabania.FindAll();
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
            catch (Exception ex)
            {
                return Enumerable.Empty<DTOCabaniaListado>();
            }
        }
    }
}
