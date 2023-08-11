using DTOs;
using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso;

public class CUMantenimientoBusquedaPorCapacidad : ICUMantenimientoBusquedaPorCapacidad
{
    public IRepositorioCabania RepoCabania { get; set; }
    public CUMantenimientoBusquedaPorCapacidad(IRepositorioCabania repo)
    {
        RepoCabania = repo;
    }

    public IEnumerable<DTOInfoMantenimiento> BuscarMantenimientosPorCapacidad(int capMin, int capMax)
    {
        //dynamy para poder acceder a las propiedades del objeto anónimo hay que tener cuidado de escribir bien el nombre.
        IEnumerable<dynamic> infoMantenimiento = RepoCabania.BuscarMantenimientosPorCapacidadEInformacionDeQuienLoHizo(capMin, capMax);
        IEnumerable<DTOInfoMantenimiento> dTOInfoMantenimientos = infoMantenimiento.Select(x => new DTOInfoMantenimiento()
        {
            NombreTrabajador = x.GetType().GetProperty("Nombre").GetValue(x).ToString(),
            MontoTotal = x.GetType().GetProperty("MontoTotal").GetValue(x),
        });
        return dTOInfoMantenimientos;
    }


}
