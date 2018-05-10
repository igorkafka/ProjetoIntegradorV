using PizzaExpress.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PizzaExpress.Repository
{
    public class RepositoryCliente
    {
        private PizzaExpressEntity DBRepository;
        public RepositoryCliente()
        {
            this.DBRepository = new PizzaExpressEntity();
        }
        public void Inserir(Cliente ObjCliente)
        {
            this.DBRepository.Clientes.Add(ObjCliente);
            this.DBRepository.SaveChanges();
        }
        public void Atualizar(Cliente ObjCliente)
        {
            if(ObjCliente.Id != 0)
            {
                this.DBRepository.Entry(ObjCliente).State = EntityState.Modified;
                this.DBRepository.SaveChanges();
            }
        }
        public IList<Cliente> ListarPorNome(string nome)
        {
            return this.DBRepository.Clientes.Where(x => x.Nome == nome).ToList();
        }
        public void Excluir(int id)
        {
            Cliente ObjCliente = this.DBRepository.Clientes.Where(x => x.Id == id).FirstOrDefault();
            this.DBRepository.Set<Cliente>().Remove(ObjCliente);
        }
    }
}