using LogicaNegocio.EntidadesNegocio;
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
    [Index("Descripcion")]
    public class VODescripcionCabania: IValidar
    {
        public string Descripcion { get; set; }

        public VODescripcionCabania(string descripcion) {
            Descripcion = descripcion;
            ValidarDatos();
        }

        public void ValidarDatos()
        {
            ValidarDescripcion();
        }

        public void ValidarDescripcion()
        {
            if (Descripcion.Length < Parametros.TopeMinimoCabania || Descripcion.Length > Parametros.TopeMaximoCabania) throw new CabaniaException($"La descripción debe ser mayor a {Parametros.TopeMinimoCabania} y menor que {Parametros.TopeMaximoCabania}");

        }


    }
}
