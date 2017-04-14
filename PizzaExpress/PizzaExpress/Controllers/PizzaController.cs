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
        public ActionResult Index(string tamanho="")
        {
            Sabor sabor = new Sabor();
            Pizza pizza = new Pizza(sabor);
            if (Request.IsAjaxRequest())
            {
                return PartialView("ProcurarPizza", pizza.ListarPorTamanho(tamanho));
            }
            else
            {
                return View(pizza.ListarPorTamanho(tamanho));
            }
            }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "IdPizza")]Sabor objsabor)
        {
            return View();
        }
    }
   


}