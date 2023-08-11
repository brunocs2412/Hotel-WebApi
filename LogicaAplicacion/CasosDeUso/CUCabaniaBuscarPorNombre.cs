using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAccesoDatos.Repositorios;
using LogicaNegocio.ExcepcionesEntidaes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUCabaniaBuscarPorNombre : ICUCabaniaBuscarPorNombre
    {
        public IRepositorioCabania RepoCabania { get; set; }

        public CUCabaniaBuscarPorNombre(IRepositorioCabania repo)
        {
            RepoCabania = repo;
        }
        public IEnumerable<DTOCabaniaListado> BuscarCabaniaPorNombre(string nombre)
        {

            IEnumerable<Cabania> cabanias = RepoCabania.BuscarPorNombre(nombre);

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

