using PizzaExpress.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PizzaExpress.Repository
{
    public class RepositoryPizza
    {
        private PizzaExpressEntity DBRepository;
        public RepositoryPizza()
        {
            this.DBRepository = new PizzaExpressEntity();
        }
        public void Inserir(Pizza ObjPizza)
        {
            ObjPizza.Sabor1 = this.DBRepository.Sabores.Where(x => ObjPizza.Sabor1.Id == x.Id).FirstOrDefault();
            ObjPizza.Sabor2 = this.DBRepository.Sabores.Where(x => ObjPizza.Sabor2.Id == x.Id).FirstOrDefault();
            ObjPizza.Sabor3 = this.DBRepository.Sabores.Where(x => ObjPizza.Sabor3.Id == x.Id).FirstOrDefault();
            this.DBRepository.Pizzas.Add(ObjPizza);
            this.DBRepository.SaveChanges();
        }
        public void Atualizar(Pizza ObjPizza)
        {
            this.DBRepository.Entry<Pizza>(ObjPizza).State = EntityState.Modified;
            this.DBRepository.SaveChanges();
        }
        public IList<Pizza> ListarPorNome()
        {
            return this.DBRepository.Pizzas.Include(x => x.Sabor1).Include(x => x.Sabor2).Include(x => x.Sabor3).ToList();
        }
    }
}