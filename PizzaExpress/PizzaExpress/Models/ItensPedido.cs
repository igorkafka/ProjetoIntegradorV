using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaExpress.Models
{
    public class ItensPedido
    {
        
        public int Id { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
        public virtual ICollection<Pizza> Pizzas { get; set; }
        public Pedido ObjPedido { get; set; }
        //----- Atributos ----
        private int quatidade;
        public int Quatidade
        {
            get { return quatidade; }
            set { quatidade = value; }
        }
    }
}