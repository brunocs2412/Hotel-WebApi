using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesEntidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    [Owned]
    [Index("Nombre")]
    public class VONombreCabania : IValidar
    {
        public string Nombre { get; set;}
        public VONombreCabania(string nombre)
        {
            Nombre = nombre;
            ValidarDatos();

        }
        public VONombreCabania()
        {

        }

        public void ValidarDatos()
        {
           ValidarNombre();
        }
        public void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre)) throw new CabaniaException("El nombre es olbigatorio");

            ValidarQueSoloHayanLetrasEnElNombre();
            //valida que no haya espacios al inicio y al final. igualk que un trim pero con regex
            if (!Regex.IsMatch(Nombre, @"^[^\s]+(\s[^\s]+)*$")) throw new CabaniaException("El nombre no puede contener espacios tanto el inicio como en el final");

        }

        public void ValidarQueSoloHayanLetrasEnElNombre()
        {
            //Si la letra no es una letra o un espacio, tira una excepcion
            foreach (char l in Nombre)
            {
                if (!char.IsWhiteSpace(l) && !char.IsLetter(l) && !char.IsWhiteSpace(l)) throw new CabaniaException("El nombre solo puede contener letras y espacios");
            }
        }


    }
}
