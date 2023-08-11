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

namespace LogicaAplicacion.CasosDeUso;

public class CUTipoCabaniaActualizar : ICUTipoCabaniaActualizar
{
    public IRepositorioTipo RepoTipo { get; set; }
    public CUTipoCabaniaActualizar(IRepositorioTipo repo)
    {
        RepoTipo = repo;
    }

    public void ActualizarTipoCabania(DTOTipo dtoTipo)
    {
        try
        {

            Tipo tipo = new Tipo()
            {
                Nombre = new VONombreTipo(dtoTipo.Nombre),
                CostoPorHuesped = new VOCostoPorHuespedTipo(dtoTipo.CostoPorHuesped),
                Descripcion = dtoTipo.Descripcion
            };

            RepoTipo.Update(tipo.Id,tipo);

        }
        catch (Exception)
        {

            throw;
        }
    }
}
