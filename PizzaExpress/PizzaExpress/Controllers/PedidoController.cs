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
                            select new { Label= "Nome: " + N.NomeSabor + " Preço: " +  N.PrecoSabor, Name = N.NomeSabor, Value = N.IdSabor});
            return Json(Sabores, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult BuscarProduto(string term)
        {
             Produto objproduto = new Produto();
            //Searching records from list using LINQ query
            var Produtos = (from produto in objproduto.ListarNome(term) where produto.NomeProduto.Contains(term)
                           select new {Label = "Nome: " + produto.NomeProduto + " Preço: " + produto.PrecoProduto, Name = produto.NomeProduto, Value = produto.IdProduto });
            return Json(Produtos, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult BuscarCliente(string term)
        {
            Cliente c = new Cliente();
            //Searching records from list using LINQ query
            var Clientes = (from cliente in c.ListarNome(term)
                            where cliente.NomeCliente.Contains(term)
                            select new { Label = "Nome: " + cliente.NomeCliente  + " Telefone: " +  cliente.TelefoneCliente, Name = cliente.TelefoneCliente, Value = cliente.IdCliente });
            return Json(Clientes, JsonRequestBehavior.AllowGet);
        }
    }
}