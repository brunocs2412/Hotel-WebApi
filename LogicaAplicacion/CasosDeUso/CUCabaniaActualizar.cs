using DTOs;
using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUCabaniaActualizar : ICUCabaniaActualizar
    {
        IRepositorioCabania RepoCabania { get; set; }
        public ICUTipoBuscarPorId _cuBuscarTipoPorId { get; set; }

        public CUCabaniaActualizar(IRepositorioCabania repoCabania, ICUTipoBuscarPorId cuBuscarTipoPorId)
        {
            RepoCabania = repoCabania;
            _cuBuscarTipoPorId = cuBuscarTipoPorId;
        }

        public void CabaniaActualizar(int idCabania, DTOCabania dtoCabania)
        {
            try
            {
               
                Cabania c = new Cabania()
                {
                    TipoId = dtoCabania.TipoId,
                    Nombre = new VONombreCabania(dtoCabania.Nombre),
                    Descripcion = new VODescripcionCabania(dtoCabania.Descripcion),
                    PoseeJacuzzi = dtoCabania.PoseeJacuzzi,
                    HabilitadoReservas = dtoCabania.HabilitadoReservas,
                    NumHabitacion = dtoCabania.NumHabitacion,
                    CapacidadMaximaPersonas = dtoCabania.CapacidadMaximaPersonas,
                    Id = idCabania
                };


                RepoCabania.Update(idCabania, c);
            }
            catch 
            {
                             
                throw;
            }
        }
    }
}
