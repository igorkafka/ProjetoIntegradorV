using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaExpress.Models;
namespace PizzaExpress.Controllers
{
    public class ProdutoController : Controller
    {
        public ActionResult Index(string pesquisar = "")
        {
            Produto produto = new Produto();
            if (Request.IsAjaxRequest())
            {

                if (string.IsNullOrEmpty(pesquisar) || pesquisar.Trim().Length < 2)
                    return JavaScript("alert(\"Nome Invalido, Digite algo que tenha pelo menos mais de duas letras\")");
                return PartialView("ProcurarProduto", produto.ListarNome(pesquisar));
            }
            return View(produto.ListarNome(pesquisar).Take(0));
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
                return View();
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
            produto.Salvar(produto);
            return View();
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
            DAOProduto dao = new DAOProduto();
            dao.Excluir(id);
            return View();
        }
    }
}