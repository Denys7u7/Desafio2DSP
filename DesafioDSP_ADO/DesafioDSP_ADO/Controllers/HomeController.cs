using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using DesafioDSP_ADO.Models;
namespace DesafioDSP_ADO.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        db dblayer = new db();
        public ActionResult Index()
        {
            DataSet ds = dblayer.verMateriasAll();
            ViewBag.emp = ds.Tables[0];       
            return View();
        }

        public ActionResult AgregarMateria()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarMateria(FormCollection fc)
        {
            DatosAsignatura asig = new DatosAsignatura();
            asig.nombreMateria = fc["materia"];
            asig.codigoMateria = fc["codigo"];
            asig.curso = fc["curso"];
            asig.idTipoMateria = Convert.ToInt32(fc["tipo"]);
            asig.idTitulacion = Convert.ToInt32(fc["titulacion"]);
            asig.creditosTeoricos = fc["credT"];
            asig.creditosLaboratorios = fc["credL"];
            asig.duracion = fc["duracion"];
            asig.limiteAdmision = fc["limite"];
            asig.gruposTeo = fc["grupoT"];
            asig.gruposLab = fc["grupoL"];
            dblayer.agregarAsignatura(asig);
            TempData["mensaje"] = "Materia agregada correctamente";
            return RedirectToAction("Index");
        }

        public ActionResult actualizarMateria(int id)
        {
            DataSet ds = dblayer.verMaterias(id);
            ViewBag.emp = ds.Tables[0];
            return View();
        }

        [HttpPost]
        public ActionResult actualizarMateria(int id, FormCollection fc)
        {
            DatosAsignatura asig = new DatosAsignatura();
            asig.idMateria = id;
            asig.nombreMateria = fc["materia"];
            asig.codigoMateria = fc["codigo"];
            asig.curso = fc["curso"];
            asig.idTipoMateria = Convert.ToInt32(fc["tipo"]);
            asig.idTitulacion = Convert.ToInt32(fc["titulacion"]);
            asig.creditosTeoricos = fc["credT"];
            asig.creditosLaboratorios = fc["credL"];
            asig.duracion = fc["duracion"];
            asig.limiteAdmision = fc["limite"];
            asig.gruposTeo = fc["grupoT"];
            asig.gruposLab = fc["grupoL"];
            dblayer.modificarAsignatura(id,asig);
            TempData["mensaje"] = "Materia actualizada correctamente";
            return RedirectToAction("Index");
        }

        public ActionResult borrarMateria(int id)
        {
            dblayer.eliminarAsignatura(id);
            TempData["mensaje"] = "Asignatura borrada";
            return RedirectToAction("Index");
        }
    }
}