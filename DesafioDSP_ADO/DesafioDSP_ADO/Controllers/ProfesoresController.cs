using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DesafioDSP_ADO.Models;
using System.Data;
using System.Data.SqlClient;

namespace DesafioDSP_ADO.Controllers
{
    public class ProfesoresController : Controller
    {
        // GET: Profesores
        db dblayer = new db();
        public ActionResult Index()
        {
            DataSet ds = dblayer.verProfesores();
            ViewBag.emp = ds.Tables[0];
            return View();
        }

        public ActionResult agregarProfesor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult agregarProfesor(FormCollection fc)
        {
            DatosProfesor prof = new DatosProfesor();
            prof.nomProfesor = fc["nombres"];
            prof.apellido = fc["apellidos"];
            prof.despacho = fc["despacho"];
            prof.horariosConsultas = fc["consultas"];
            prof.idAreaConocimiento = Convert.ToInt32(fc["area"]);
            dblayer.agregarProfesor(prof);
            TempData["mensaje"] = "Profesor agregado correctamente";
            return RedirectToAction("Index");
        }

        public ActionResult actualizarProfesor(int id)
        {
            DataSet ds = dblayer.verProfesoresById(id);
            ViewBag.emp = ds.Tables[0];
            return View();
        }

        [HttpPost]
        public ActionResult actualizarProfesor(int id, FormCollection fc)
        {
            DatosProfesor prof = new DatosProfesor();
            prof.nomProfesor = fc["nombres"];
            prof.apellido = fc["apellidos"];
            prof.despacho = fc["despacho"];
            prof.horariosConsultas = fc["consultas"];
            prof.idAreaConocimiento = Convert.ToInt32(fc["area"]);
            dblayer.modificarProfesor(prof,id);
            TempData["mensaje"] = "Profesor actualizado correctamente";
            return RedirectToAction("Index");
        }

        public ActionResult borrarProfesor(int id)
        {
            dblayer.eliminarProfesor(id);
            TempData["mensaje"] = "Profesor borrada";
            return RedirectToAction("Index");
        }
    }
}