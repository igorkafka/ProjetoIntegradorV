using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaExpress.Models
{
    public class Venda
    {
        public decimal Valor { get; set; }
        public int Id { get; set; }
        public DateTime Dia { get; set; }
        public Pedido ObjPedido { get; set; }
    }
}