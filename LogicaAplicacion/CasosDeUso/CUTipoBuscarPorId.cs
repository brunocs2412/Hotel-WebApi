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
    public class CUTipoBuscarPorId : ICUTipoBuscarPorId
    {

        public IRepositorioTipo RepoTipo { get; set; }

        public CUTipoBuscarPorId(IRepositorioTipo repo)
        {
            RepoTipo = repo;
        }

        public DTOTipo BuscarTipoCabaniaPorId(int id)
        {
            try
            {
                Tipo tipo = RepoTipo.FindById(id);

                DTOTipo dtoTipo = new DTOTipo()
                {
                    Id = tipo.Id,
                    Nombre = tipo.Nombre.NombreTipo,
                    CostoPorHuesped = tipo.CostoPorHuesped.Costo,
                    Descripcion = tipo.Descripcion
                };

                return dtoTipo;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
