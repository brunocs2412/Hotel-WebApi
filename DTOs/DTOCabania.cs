using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DTOCabania
    {
        public int? Id { get; set; }
        public int TipoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool PoseeJacuzzi { get; set; }
        public bool HabilitadoReservas { get; set; }
        public int NumHabitacion { get; set; }
        public int CapacidadMaximaPersonas { get; set; }
        public string? NombreFoto { get; set; }


    }
}
