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
    public class CUTipoCabaniaAlta : ICUTipoCabaniaAlta
    {
        public IRepositorioTipo RepoTipo { get; set; }
        public CUTipoCabaniaAlta(IRepositorioTipo repo)
        {
            RepoTipo = repo;
        }

        public DTOTipo AltaTipoCabania(DTOTipo dtoTipo)
        {
            try
            {

                Tipo tipo = new Tipo()
                {
                    Nombre = new VONombreTipo(dtoTipo.Nombre),
                    CostoPorHuesped = new VOCostoPorHuespedTipo(dtoTipo.CostoPorHuesped),
                    Descripcion = dtoTipo.Descripcion
                };

                RepoTipo.Add(tipo);
                dtoTipo.Id = tipo.Id;

                return dtoTipo;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
