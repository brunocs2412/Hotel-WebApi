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
    public class CUCabaniaAlta : ICUCabaniaAlta
    {
        public IRepositorioCabania RepoCabania { get; set; }
        public ICUTipoCabaniaBuscarPorNombre _cuBuscarTipoPorNombre { get; set; }


        public CUCabaniaAlta(IRepositorioCabania repoCabania, ICUTipoCabaniaBuscarPorNombre cUTipoCabaniaBuscarPorNombre)
        {
            RepoCabania = repoCabania;
            _cuBuscarTipoPorNombre = cUTipoCabaniaBuscarPorNombre;
        }

        public DTOCabania AltaCabania(DTOCabania dtoCabania)
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
                    CapacidadMaximaPersonas = dtoCabania.CapacidadMaximaPersonas,
                    Fotos = new List<Foto>()
                };

                Foto nuevaFoto = new Foto();
                nuevaFoto.NombreFoto = c.SiguienteFotoYCambiarNombre(dtoCabania.Nombre);
                c.Fotos.Add(nuevaFoto);

                RepoCabania.Add(c);
                dtoCabania.Id = c.Id;
                dtoCabania.NumHabitacion = c.NumHabitacion;
                dtoCabania.NombreFoto = nuevaFoto.NombreFoto;

            }
            catch
            {
                throw;
            }
            return dtoCabania;
        }
    }
}
