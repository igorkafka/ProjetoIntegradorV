using PizzaExpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaExpress.Repository
{
    public class RepositoryItensPedido
    {
        private PizzaExpressEntity DBRepository;
        public RepositoryItensPedido()
        {
            this.DBRepository = new PizzaExpressEntity();
        }
        public void Salvar(ItensPedido itensPedido)
        {
            
        }
    }
}