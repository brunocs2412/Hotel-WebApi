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
    [Index("NombreTipo", IsUnique = true)]

    public class VONombreTipo : IValidar
    {
        public string NombreTipo { get; set; }

        public VONombreTipo(string nombre)
        {
            NombreTipo = nombre;
            ValidarDatos();
        }

        public VONombreTipo() { }

        public void ValidarDatos()
        {
            ValidarNombre();
        }

        public void ValidarNombre()
        {
            bool espacioEncontrado = false;
            bool palabraValida = true;

            foreach (char caracter in NombreTipo)
            {
                if (caracter == ' ')
                {
                    if (espacioEncontrado)
                    {
                        palabraValida = false;
                    }
                    espacioEncontrado = true;
                }
                else if (!char.IsLetter(caracter))
                {
                    palabraValida = false;
                }
                else
                {
                    espacioEncontrado = false;
                }

                if (!palabraValida)
                {
                    break;
                }
            }

            if (!palabraValida)
            {
                throw new TipoException("El nombre debe contener solo letras y solo un espacio por palabra");
            }

            if (NombreTipo.StartsWith(" ") || NombreTipo.EndsWith(" "))
            {
                throw new TipoException("El nombre no puede contener espacios al inicio ni al final");
            }
        }
    }
}
