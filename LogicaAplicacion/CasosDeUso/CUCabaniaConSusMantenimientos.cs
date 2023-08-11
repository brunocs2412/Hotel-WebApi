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
    public class CUMantenimientosListar : ICUMantenimientosListar
    {
        public IRepositorioCabania RepoCabania { get; set; }

        public CUMantenimientosListar(IRepositorioCabania repoCabania)
        {
            RepoCabania = repoCabania;
        }

        public IEnumerable<DTOMantenimiento> GetMantenimientos(int idCabania)
        {
            try
            {
                Cabania cabania = RepoCabania.CabaniaConTodosSusMantenimientos(idCabania);
                IEnumerable<Mantenimiento> mantenimientos = cabania.Mantenimientos;
                IEnumerable<DTOMantenimiento> dtosMantenimiento = mantenimientos.Select(mantenimientos => new DTOMantenimiento()
                {
                    Fecha = mantenimientos.Fecha,
                    Costo = mantenimientos.Costo,
                    NombreTrabajador = mantenimientos.NombreTrabajador,
                    CabaniaId = mantenimientos.CabaniaId,
                    Descripcion= mantenimientos.Descripcion
                }) ;

                return dtosMantenimiento;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
