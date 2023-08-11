using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DTOMantenimiento
    {
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        public string NombreTrabajador { get; set; }
        public int CabaniaId { get; set; }
    }
}
