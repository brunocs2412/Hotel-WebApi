using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    [NotMapped]
    public class Parametros
    {
        public int Id {  get; set; }    
        public static int TopeMinimoTipo { get; set; }

        public static int TopeMaximoTipo { get; set; }

        public static int TopeMinimoCabania { get; set; }

        public static int TopeMaximoCabania { get; set; }
        public static int TopeMinimoMantenimiento { get; set; }

        public static int TopeMaximoMantenimiento { get; set; }

    }
}
