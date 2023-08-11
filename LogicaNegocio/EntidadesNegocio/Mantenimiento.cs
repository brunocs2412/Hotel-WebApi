using LogicaNegocio.InterfacesEntidades;
using LogicaNegocio.ExcepcionesEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio;

public class Mantenimiento: IValidar
{

    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public string Descripcion { get; set; }
    public double Costo { get; set; }
    public string NombreTrabajador { get; set; }
    public Cabania? Cabania { get; set; }
    public int CabaniaId { get; set; }


   
    public void ValidarDatos()
    {
        if (Fecha > DateTime.Now) throw new MantenimientoException("La fecha del mantenimiento no es válida");
        if (Descripcion.Length < Parametros.TopeMinimoMantenimiento || Descripcion.Length > Parametros.TopeMaximoMantenimiento) throw new TipoException($"La descripción debe tener entre {Parametros.TopeMinimoMantenimiento} y {Parametros.TopeMaximoMantenimiento} caracteres");
        if (Costo < 0) throw new MantenimientoException("El costo del mantenimiento debe ser igual o mayor que 0.");
    }
}
