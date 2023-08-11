using DTOs;
using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUCabaniaBuscarPorId: ICUCabaniaBuscarPorId
    {
        public IRepositorioCabania RepositorioCabania { get; set; }

        public CUCabaniaBuscarPorId(IRepositorioCabania repositorioCabania) { 
            this.RepositorioCabania = repositorioCabania;
        }

        public DTOCabania BuscarPorId(int id)
        {
            try
            {
                Cabania c= RepositorioCabania.FindById(id);
                DTOCabania dto = new DTOCabania()
                {
                    Id = c.Id,
                    NumHabitacion = c.NumHabitacion,
                    CapacidadMaximaPersonas = c.CapacidadMaximaPersonas,
                    Descripcion = c.Descripcion.Descripcion,
                    PoseeJacuzzi = c.PoseeJacuzzi,
                    TipoId = c.Tipo.Id,
                    HabilitadoReservas = c.HabilitadoReservas,
                    Nombre = c.Nombre.Nombre,
                    NombreFoto = c.Fotos.First().NombreFoto
                };
                return dto;
            }
            catch (Exception)
            { 
                throw;
            }
        }
    }
}
