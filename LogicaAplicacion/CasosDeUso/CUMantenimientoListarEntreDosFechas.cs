using DTOs;
using LogicaNegocio.EntidadesNegocio;
using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso;

public class CUMantenimientoListarEntreDosFechas : ICUMantenimientoListarEntreDosFechas
{
    public IRepositorioCabania RepoCabania { get; set; }
    public CUMantenimientoListarEntreDosFechas(IRepositorioCabania repo)
    {
        RepoCabania = repo;
    }

    public IEnumerable<DTOMantenimiento> GetEntreDosFechas(int idCab, DateTime fecha, DateTime fecha2)
    {

        Cabania cabaniaConMants = RepoCabania.ListarMantenimientosRealizadosAUnaCabaniaEntreDosFechas(idCab, fecha, fecha2);
        IEnumerable<Mantenimiento> mantenimientos = cabaniaConMants.Mantenimientos;
        IEnumerable<DTOMantenimiento> dTOMantenimientos = mantenimientos.Select(x => new DTOMantenimiento()
        {
            Fecha = x.Fecha,
            Descripcion = x.Descripcion,
            Costo = x.Costo,
            NombreTrabajador = x.NombreTrabajador,
            CabaniaId = x.CabaniaId
        });
        return dTOMantenimientos;


    }

}
