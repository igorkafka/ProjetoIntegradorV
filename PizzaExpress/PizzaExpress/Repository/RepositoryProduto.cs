using PizzaExpress.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PizzaExpress.Repository
{
    public class RepositoryProduto
    {
        private PizzaExpressEntity DBRepository;
        public RepositoryProduto()
        {
            this.DBRepository = new PizzaExpressEntity();
        }
        public void Inserir(Produto produto)
        {
            this.DBRepository.Produtos.Add(produto);
            this.DBRepository.SaveChanges();
        }
        public void Atualizar(Produto produto)
        {
            this.DBRepository.Entry<Produto>(produto).State = EntityState.Modified;
            this.DBRepository.SaveChanges();
        }
        public IList<Produto> ListarPorNome(string nome)
        {
            return this.DBRepository.Produtos.Where(x => x.NomeProduto == nome).ToList();
        }
    }
}