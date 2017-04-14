using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaExpress.Models;
namespace PizzaExpress.Controllers
{
    public class SaborController : Controller
    {
        // GET: Sabor
        public ActionResult Index(string pesquisar="")
        {
            Sabor sabor = new Sabor();
            if(Request.IsAjaxRequest())
            {
                return PartialView("ProcurarSabor", sabor.ListarNome(pesquisar));
            }
            return View(sabor.ListarNome(pesquisar).Take(0));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Exclude ="idSabor")]Sabor sabor)
        {
            
            
           
             
            if (ModelState.IsValid)
            {
                sabor.Salvar(sabor);
                return View();
            }
           
           
            return View();
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            Sabor sabor = new Sabor().BuscarPorId(id);
            return View(sabor);
            
        }
        [ActionName("Edit")]
        [HttpGet]
        public ActionResult EditGET(int id)
        {
            Sabor sabor = new Sabor().BuscarPorId(id);
            return View(sabor);
        }
        [ActionName("Edit")]
        [HttpPost]
        public ActionResult EditPOST(Sabor sabor)
        {
            sabor.Salvar(sabor);
            return View();
        }
        [ActionName("Delete")]
        [HttpGet]
        public ActionResult DeleteGET(int id)
        {
            Sabor sabor = new Sabor().BuscarPorId(id);
            return View(sabor);
        }
        [ActionName("Delete")]
        [HttpPost]
        public ActionResult DeletePOST(int id)
        {
            Sabor sabor = new Models.Sabor();
            sabor.Excluir(id);
            return View();
        }
    }
}