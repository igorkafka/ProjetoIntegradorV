using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaExpress.Models;
namespace PizzaExpress.Controllers
{
    public class PedidoController : Controller
    {
        // GET: Pedido
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public JsonResult BuscarSabor(string term)
        {
            Sabor sabor = new Sabor();
            //Searching records from list using LINQ query
            var Sabores = (from N in sabor.ListarNome(term)
                            where N.NomeSabor.Contains(term)
                            select new { Label= N.NomeSabor, Value = N.IdSabor});
            return Json(Sabores, JsonRequestBehavior.AllowGet);
        }
    }
}