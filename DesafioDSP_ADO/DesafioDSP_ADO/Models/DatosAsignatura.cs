using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesafioDSP_ADO.Models
{
    public class DatosAsignatura
    {
        public List<DatosAsignatura> DatosAsignaturas { get; set; }
        public int idMateria { get; set; }
        public string nombreMateria { get; set; }
        public string codigoMateria { get; set; }
        public string curso { get; set; }
        public string nTipoMateria { get; set; }
        public string nTitulacion { get; set; }
        public string creditosTeoricos { get; set; }
        public string creditosLaboratorios { get; set; }
        public string duracion { get; set; }
        public string limiteAdmision { get; set; }
        public string gruposTeo { get; set; }
        public string gruposLab { get; set; }
        public int idTipoMateria { get; set; }
        public int idTitulacion { get; set; }
    }
}