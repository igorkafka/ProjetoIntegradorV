using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaExpress.Models;
using PagedList;
namespace PizzaExpress.Controllers
{
    [Authorize()]
    public class ClienteController : Controller
    {
        // GET: Cliente
        
        public ActionResult Index(int? page ,string pesquisar="")
        {

            Cliente cliente = new Cliente();
            if (Request.IsAjaxRequest())
            {
                if (string.IsNullOrEmpty(pesquisar) || pesquisar.Trim().Length < 2) {
                    return JavaScript("alert(\"Nome Invalido, Digite algo que tenha pelo menos mais de duas letras\")");
                }
                if (cliente.ListarNome(pesquisar).Count == 0)
                    return JavaScript("alert(\'Não foi encontrado nenhum cliente com o nome: " + pesquisar + "');");
                    
               return PartialView("ProcurarCliente", cliente.ListarNome(pesquisar));
                
            }
            IList<Cliente> lista = new List<Cliente>();
            return View(lista);
            
        }
        

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "IdCliente")]Cliente cliente)
        {
            TryUpdateModel(cliente);
            if (ModelState.IsValid)
            {
                cliente.Salvar(cliente);
            }
            return RedirectToAction("Index");
        }
        [ActionName(name: "Edit")]

        [HttpGet]
        public ActionResult EditGET(int id)
        {
            Cliente cliente = new Cliente();

            return View(cliente.BuscarPorId(id));
        }
        [ActionName(name: "Edit")]
        [HttpPost]
        public ActionResult EditPOST(Cliente cliente)
        {
            TryUpdateModel(cliente);
            if (ModelState.IsValid)
            {
                cliente.Alterar(cliente);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Cliente cliente = new Cliente();
            return View(cliente.BuscarPorId(id));
        }
        [ActionName("Delete")]
        [HttpGet]
        public ActionResult DeleteGET(int id)
        {
            Cliente cliente = new Cliente();

            return View(cliente.BuscarPorId(id));
        }
        [ActionName("Delete")]
        [HttpPost]
        public ActionResult DeletePOST(int id)
        {
            Cliente cliente = new Models.Cliente();
            cliente.Delete(id);
            return RedirectToAction("Index");
        }
    }
    }
