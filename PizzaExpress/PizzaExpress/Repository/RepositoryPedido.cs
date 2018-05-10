using PizzaExpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace PizzaExpress.Repository
{
    public class RepositoryPedido
    {
        private PizzaExpressEntity DBRepository;
        public RepositoryPedido()
        {
            this.DBRepository = new PizzaExpressEntity();
        }
        public void Inserir(Pedido pedido)
        {
            pedido.ObjFuncionario = this.DBRepository.Funcionarios.Where(x => x.Id == pedido.Id).FirstOrDefault();
            this.DBRepository.Pedidos.Add(pedido);
            this.DBRepository.SaveChanges();
        }
        public void Atualizar(Pedido pedido)
        {
            this.DBRepository.Entry<Pedido>(pedido).State = EntityState.Modified;
            this.DBRepository.SaveChanges();
        }
        public IList<Pedido> ListarPedidosAbertos()
        {
            return this.DBRepository.Pedidos.Include(x => x.ObjFuncionario).Where(x => x.StatusPedido == "Aberto").ToList();
        }
        public IList<Pedido> ListarPedidosFechados()
        {
            return this.DBRepository.Pedidos.Include(x => x.ObjFuncionario).Where(x => x.StatusPedido == "Fechado").ToList();
        }
    }
}