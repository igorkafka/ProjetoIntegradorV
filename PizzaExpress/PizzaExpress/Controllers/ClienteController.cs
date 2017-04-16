using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaExpress.Models;
using PagedList;
namespace PizzaExpress.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index(int? page ,string pesquisar="")
        {

            Cliente cliente = new Cliente();
            if (Request.IsAjaxRequest())
            {
                if (cliente.ListarNome(pesquisar) != null) {
                    return PartialView("ProcurarCliente", cliente.ListarNome(pesquisar));
                }
                 else if(cliente.ListarNome(pesquisar) == null)
                {

                    return PartialView("ProcurarCliente", cliente.ListarTodos().Take(2));
                }
            }
            return View(cliente.ListarNome(pesquisar).Take(0));
            
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
            return View();
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
            cliente.Alterar(cliente);
            return View();
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
            return View();
        }
    }
    }
