using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaExpress.Models;
using Microsoft.AspNet.Identity;

namespace PizzaExpress.Controllers
{
    [Authorize()]
    public class PedidoController : Controller
    {
        
        // GET: Pedido
        public ActionResult Index(string status="")
        {
            FormCollection form = new FormCollection();
          
            Pedido objpedido = new Pedido();
            if(Request.IsAjaxRequest())
            {
                if (status == "Aberto")
                {
                    return PartialView("ProcurarPedido", objpedido.ListarPizzasAbertos());
                }
                else if(status == "Fechado")
                {
                    return PartialView("ProcurarPedido", objpedido.ListarPizzasFechados());
                }
                else
                {
                    return JavaScript("alert(" + status +  ")");
                }

                
                
            }

            return View(objpedido.TodoosPedidos().Take(0));
        }
        public ActionResult Create()
        {
            
           
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Sabores[1].IdSabor,Sabores[2].IdSabor")]Pedido pedido)
        {

           
            pedido.ObjPizza.IdPizza = pedido.ObjPizza.salvar(pedido.ObjPizza);
            pedido.ObjProduto = pedido.ObjProduto.ProdutoPorId(pedido.ObjProduto.IdProduto);
            pedido.ObjPizza.Sabores[0] = pedido.ObjPizza.Sabores[0].BuscarPorId(pedido.ObjPizza.Sabores[0].IdSabor);
            
            
       /*     if (pedido.ObjPizza.Sabores[1].IdSabor != 0)
            {
                pedido.ObjPizza.Sabores[1] = pedido.ObjPizza.Sabores[1].BuscarPorId(pedido.ObjPizza.Sabores[1].IdSabor);
                pedido.ValorTotal += pedido.ObjPizza.Sabores[1].PrecoSabor;
            }
            if (pedido.ObjPizza.Sabores[2].IdSabor != 0)
            {
                pedido.ObjPizza.Sabores[2] = pedido.ObjPizza.Sabores[2].BuscarPorId(pedido.ObjPizza.Sabores[2].IdSabor);
                pedido.ValorTotal += pedido.ObjPizza.Sabores[2].PrecoSabor;
           } */
          
   
            pedido.salvar(pedido);
            
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
                           select new {Label = "Nome: " + produto.NomeProduto + " Preço: " + produto.PrecoProduto, Name = produto.NomeProduto, Value = produto.IdProduto, Descricao = produto.DescProduto, PrecoProduto = produto.PrecoProduto });
            return Json(Produtos, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult BuscarCliente(string term)
        {
            Cliente c = new Cliente();
            //Searching records from list using LINQ query
            var Clientes = (from cliente in c.ListarNome(term)
                            where cliente.NomeCliente.Contains(term)
                            select new { Label = "Nome: " + cliente.NomeCliente  + " Telefone: " +  cliente.TelefoneCliente, Name = cliente.Nome, Value = cliente.IdCliente });
            return Json(Clientes, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        [ActionName("Edit")]
        public ActionResult EditGET(int id)
        {
            Pedido objpedido = new Pedido();
            objpedido = objpedido.BuscarPorId(id);
            return View(objpedido);
        }
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditPOST(Pedido objpedido)
        {
            objpedido.AlterarStatus(objpedido);
            return RedirectToAction("Index", "Pedido");
        }
       
        
    }
}