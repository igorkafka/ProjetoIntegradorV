using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaExpress.Models;
namespace PizzaExpress.Controllers
{
    [Authorize()]
    public class SaborController : Controller
    {
        // GET: Sabor
        public ActionResult Index(string pesquisar="")
        {
            Sabor sabor = new Sabor();
            if(Request.IsAjaxRequest())
            {
                if (string.IsNullOrEmpty(pesquisar) || pesquisar.Trim().Length < 2)
                    return JavaScript("alert(\"Nome Invalido, Digite algo que tenha pelo menos mais de duas letras\")");
                return PartialView("ProcurarSabor", sabor.ListarNome(pesquisar));
            }
            IList<Sabor> lista = new List<Sabor>();
            return View(lista);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Exclude ="idSabor")]Sabor sabor)
        {



            TryUpdateModel(sabor);  
            if (ModelState.IsValid)
            {
                sabor.Salvar(sabor);
                return RedirectToAction("Index");
            }
           
           
            return RedirectToAction("Index");
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
            TryUpdateModel(sabor);
            if (ModelState.IsValid)
            {
                sabor.Salvar(sabor);
            }
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }
    }
}