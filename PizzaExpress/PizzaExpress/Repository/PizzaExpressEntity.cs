using PizzaExpress.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PizzaExpress.Repository
{
    public class PizzaExpressEntity:DbContext
    {
       public virtual DbSet<Cliente> Clientes { get; set; }
       public virtual DbSet<Funcionario> Funcionarios { get; set; }
       public virtual DbSet<Pedido> Pedidos { get; set; }
       public virtual DbSet<ItensPedido> ItensPedidos { get; set;}
       public virtual DbSet<Pizza> Pizzas { get; set; }
       public virtual DbSet<Sabor> Sabores { get; set; }
       public virtual DbSet<Produto> Produtos { get; set; }
    }
}