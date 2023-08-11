using LogicaNegocio.InterfacesEntidades;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using LogicaNegocio.ValueObjects;
using System.Runtime.CompilerServices;

namespace LogicaNegocio.EntidadesNegocio;


public class Cabania : IValidar
{
    public int Id { get; set; }
    public Tipo? Tipo { get; set; }
    public int TipoId { get; set; } 
    public VONombreCabania Nombre { get; set; }
    public VODescripcionCabania Descripcion { get; set; }
    public bool PoseeJacuzzi { get; set; }
    public bool HabilitadoReservas { get; set; }
    public int NumHabitacion { get; set; }
    public int CapacidadMaximaPersonas { get; set; }
    public List<Foto>? Fotos { get; set; } = new List<Foto>();
    public IEnumerable<Mantenimiento>? Mantenimientos { get; set; } = new List<Mantenimiento>();



    public void ValidarDatos()
    {
        //Creo que este no es necesario
        Descripcion.ValidarDatos();
        Nombre.ValidarDatos();
    }



    public string SiguienteFotoYCambiarNombre(string nombre)
    {
        int contadorFotosCabania = Fotos.Count();

        int contadorFotosCabaniaMasUno = contadorFotosCabania + 1;
        string contadorFotosCabaniaString = contadorFotosCabaniaMasUno.ToString();

        string nombreFoto = $"{nombre}_0{contadorFotosCabaniaString}";
        string nuevoNombreFoto = "";

        foreach (char c in nombreFoto)
        {
            if (c == ' ')
            {
                nuevoNombreFoto += "_";
            }
            nuevoNombreFoto += c;
        }
        return nuevoNombreFoto;
    }


}
