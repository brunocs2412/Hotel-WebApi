using DTOs;
using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso;

public class CUTipoCabaniaListar : ICUTipoCabaniaListar
{
    public IRepositorioTipo RepoTipo { get; set; }
    public CUTipoCabaniaListar(IRepositorioTipo repo)
    {
        RepoTipo = repo;
    }
    public IEnumerable<DTOTipo> ListarTiposCabania()
    {
        try
        {

            IEnumerable<Tipo> Tipo = RepoTipo.FindAll();

            IEnumerable<DTOTipo> dtoTipos = Tipo.Select(t => new DTOTipo()
            {
                Id = t.Id,
                Nombre = t.Nombre.NombreTipo,
                CostoPorHuesped = t.CostoPorHuesped.Costo,
                Descripcion = t.Descripcion
            });

            return dtoTipos;
        }
        catch (Exception)
        {
            return Enumerable.Empty<DTOTipo>();
        }
    }
}
