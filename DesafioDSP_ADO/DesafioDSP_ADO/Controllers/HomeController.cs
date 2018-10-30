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
        database_Access_layer.db dblayer = new database_Access_layer.db();
        public ActionResult Ver_Datos()
        {
            DataSet ds = 
            return View();
        }
    }
}