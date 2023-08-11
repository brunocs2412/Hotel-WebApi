using LogicaNegocio.InterfacesEntidades;
using LogicaNegocio.ExcepcionesEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Foto: IValidar
    {
        public int Id { get; set; }

        [Required]
        public string NombreFoto { get; set; }
        public int CabaniaId { get; set; }
        public void ValidarDatos()
        {
            if(string.IsNullOrEmpty(NombreFoto)) throw new FotoException("La foto debe tener un nombre");
        }
    }
}
