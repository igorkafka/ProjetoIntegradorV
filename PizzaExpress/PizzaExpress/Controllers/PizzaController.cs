using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaExpress.Models;
namespace PizzaExpress.Controllers
{
    public class PizzaController : Controller
    {
        // GET: Pizza
       
        [HttpGet]
        public ActionResult Details(int id)
        {
            Pizza objpizza = new Pizza();
            objpizza = objpizza.BuscarPizzaId(id);
            return View(objpizza);
        }
    }
   


}