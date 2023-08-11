using DTOs;
using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUMantenimientoAlta : ICUMantenimientoAlta
    {
        public IRepositorioCabania RepoCabania { get; set; }
        public CUMantenimientoAlta(IRepositorioCabania repo)
        {
            RepoCabania = repo;
        }

        public DTOMantenimiento AltaMantenimiento(DTOMantenimiento mantenimiento)
        {
			try
			{
				Mantenimiento m = new Mantenimiento()
				{
					NombreTrabajador = mantenimiento.NombreTrabajador,
					Fecha = mantenimiento.Fecha,
					Descripcion = mantenimiento.Descripcion,
					Costo = mantenimiento.Costo,
					CabaniaId = mantenimiento.CabaniaId
				};

				RepoCabania.AddMantenimiento(m);
				return mantenimiento;
            }
			catch (Exception)
			{
				throw;
			}
        }
    }
}
