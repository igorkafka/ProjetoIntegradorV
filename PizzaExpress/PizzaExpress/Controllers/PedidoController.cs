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
        public ActionResult Index(string status = "", string pesquisar = "")
        {
           
            Pedido objpedido = new Pedido();

            if(Request.IsAjaxRequest())
            {

                 if (string.IsNullOrEmpty(status))
                 {
                     return JavaScript("alert('Sem status');");
                 }
                 if(string.IsNullOrEmpty(pesquisar))
                 {
                     return JavaScript("alert('Preencha uma data');");
                 }
                 if (status == "Aberto")
                 {
                    if (objpedido.ListarPizzasAbertos(Convert.ToDateTime(pesquisar)).Count == 0)
                        return JavaScript("alert('Nenhum pedido em aberto foi encontrado no dia " + pesquisar +"');");
                     return PartialView("ProcurarPedido", objpedido.ListarPizzasAbertos(Convert.ToDateTime(pesquisar)));
                 }
                 if(status == "Fechado")
                 {
                    if (objpedido.ListarPizzasFechados(Convert.ToDateTime(pesquisar)).Count == 0)
                        return JavaScript("alert('Nenhum pedido fechado foi encontrado no dia " + pesquisar + "');");
                    return PartialView("ProcurarPedido", objpedido.ListarPizzasFechados(Convert.ToDateTime(pesquisar)));
             
                 }
                

            }
            IList<Pedido> lista = new List<Pedido>();
            return View(lista);
        }
        public ActionResult Create()
        {
          
           
            return View();
        }
        [HttpPost]
        public ActionResult Create(Pedido pedido)
        {
            if (pedido.ObjPizza.IdPizza == 0)
            {
                throw new Exception("Valor Pizza não informado");
            }
            else
            {
                pedido.ObjPizza.IdPizza = pedido.ObjPizza.salvar(pedido.ObjPizza);
            }
            if(pedido.ObjPizza.Sabores[0].IdSabor == 0)
            {
                throw new Exception("Primeiro Sabor não foi informado");
            }
            else
            {
                pedido.ObjPizza.Sabores[0] = pedido.ObjPizza.Sabores[0].BuscarPorId(pedido.ObjPizza.Sabores[0].IdSabor);
            }
            if (pedido.ObjProduto.IdProduto == 0)
            {
                throw new Exception("Valor de produto não informado!");
            }
            else
            {
                pedido.ObjProduto = pedido.ObjProduto.ProdutoPorId(pedido.ObjProduto.IdProduto);
            }   


                     if (pedido.ObjPizza.Sabores[1].IdSabor != 0)
                     {
                         pedido.ObjPizza.Sabores[1] = pedido.ObjPizza.Sabores[1].BuscarPorId(pedido.ObjPizza.Sabores[1].IdSabor);
                     
                     }
                     if (pedido.ObjPizza.Sabores[2].IdSabor != 0)
                     {
                         pedido.ObjPizza.Sabores[2] = pedido.ObjPizza.Sabores[2].BuscarPorId(pedido.ObjPizza.Sabores[2].IdSabor);
                         
                     }
            pedido.salvar(pedido);
            return RedirectToAction("Index");
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
                            select new { Label = "Nome: " + cliente.NomeCliente  + " Telefone: " +  cliente.TelefoneCliente, Name = cliente.NomeCliente, Value = cliente.IdCliente });
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
            TryUpdateModel(objpedido);
            if (ModelState.IsValid)
            {
                objpedido.AlterarStatus(objpedido);
            }
            return RedirectToAction("Index", "Pedido");
        }
        public ActionResult Details(int id)
        {
            Pedido objpedido = new Pedido();
            objpedido = objpedido.BuscarPorId(id);
            return View(objpedido);
        }
       
        
    }
}