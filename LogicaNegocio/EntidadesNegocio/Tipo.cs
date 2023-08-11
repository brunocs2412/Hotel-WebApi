using LogicaNegocio.InterfacesEntidades;
using LogicaNegocio.ExcepcionesEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using LogicaNegocio.ValueObjects;
using System.Data;

namespace LogicaNegocio.EntidadesNegocio;

[Table("Tipos")]
public class Tipo : IValidar
{
    public int Id { get; set; }
    public VONombreTipo Nombre { get; set; }
    [Range(0, double.MaxValue, ErrorMessage = "El costo por huésped debe ser igual o mayor que 0.")]
    public VOCostoPorHuespedTipo CostoPorHuesped { get; set; }
    public string Descripcion { get; set; }

    public void ValidarDatos()
    {
        if (string.IsNullOrEmpty(Nombre.NombreTipo)) throw new TipoException("El nombre es obligatorio");

        if (Descripcion.Length < Parametros.TopeMinimoTipo || Descripcion.Length > Parametros.TopeMaximoTipo)
        {
            throw new TipoException($"La descripción debe ser mayor a {Parametros.TopeMinimoTipo} y menor que {Parametros.TopeMaximoTipo}");
        }

    }

    





}
