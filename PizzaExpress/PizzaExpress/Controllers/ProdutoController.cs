using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaExpress.Models;
namespace PizzaExpress.Controllers
{
    [Authorize()]
    public class ProdutoController : Controller
    {
        public ActionResult Index(string pesquisar = "")
        {
            
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "IdProduto")]Produto produto)
        {
            
            TryUpdateModel(produto);
            if (ModelState.IsValid)
            {
                produto.Salvar(produto);
            }
                return RedirectToAction("Index");
        }
        [ActionName("Edit")]
        [HttpGet]
        public ActionResult EditGET(int id)
        {
            Produto produto = new Produto().ProdutoPorId(id);
            return View(produto);
        }
        [ActionName("Edit")]
        [HttpPost]
        public ActionResult EditPost(Produto produto)
        {
            TryUpdateModel(produto);
            if (ModelState.IsValid)
            {
                produto.Salvar(produto);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Produto produto = new Produto().ProdutoPorId(id);
            return View(produto);
        }
        [ActionName("Delete")]
        [HttpGet]
        public ActionResult DeleteGET(int id)
        {
            Produto produto = new Produto().ProdutoPorId(id);
            return View(produto);
        }
        [ActionName("Delete")]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            
            
            return RedirectToAction("Index");
        }
    }
}