using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesEntidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    [Owned]
    [Index("Costo")]
    public class VOCostoPorHuespedTipo:IValidar
    {
        public double Costo { get; set; }

        public VOCostoPorHuespedTipo(double costo)
        {
            Costo = costo;
            ValidarDatos();
        }

        public VOCostoPorHuespedTipo() { }  

        public void ValidarDatos()
        {
            if(Costo < 0) throw new TipoException("El costo por huésped debe ser igual o mayor que 0.");
        }
    }
}
