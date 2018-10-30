using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioDSP_ADO.Models
{
    public class DatosProfesor
    {
        public List<DatosProfesor> datosProfe { get; set; }
        public int idProfesor { get; set; }
        public string nomProfesor { get; set; }
        public string apellido { get; set; }
        public string despacho { get; set; }
        public string horariosConsultas { get; set; }
        public string nAreaConocimiento { get; set; }
        public int idAreaConocimiento { get; set; }
    }
}

