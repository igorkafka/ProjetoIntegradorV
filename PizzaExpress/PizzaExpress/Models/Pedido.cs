using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaExpress.Models
{
    public class Pedido
    {
        private Produto objproduto;
        private Pizza objpizza;
        private Sabor objsabor;
        public Sabor ObjSabor
        {
            get { return this.objsabor; }
            set { this.objsabor = value; }
        }
        private string usuario;
        public string Usuario
        {
            get { return this.usuario; }
            set { this.usuario = value; }
        }
        
        private IList<ItensPedido> listaItemPedido; //Lista ItensPedido
        public IList<ItensPedido> ListaItemPedido
        {
            get { return listaItemPedido; }
            set { listaItemPedido = value; }
        }

        private Cliente objCliente; //Agregação Cliente
        public Cliente ObjCliente
        {
            get { return objCliente; }
            set { objCliente = value; }
        }

        //----- Atributos -----

        private int numPedido;
     
        public int NumPedido
        {
            get { return numPedido; }
            set { numPedido = value; }
        }

        private string descPedido;
        [Display(Name="Descrição")]
        public string DescPedido
        {
            get { return descPedido; }
            set { descPedido = value; }
        }
        



        private DateTime dataPedido;
        [Display(Name ="Data")]
        [Required(ErrorMessage ="Data do pedido é obrigatória!")]
        [DataType(DataType.Date,ErrorMessage ="Digite uma datá valida Dia/Mês/Ano")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataPedido
        {
            get { return dataPedido; }
            set { dataPedido = value; }
        }

        private decimal valorTotal;
        [DataType(DataType.Currency)]
        public decimal ValorTotal
        {
            get { return valorTotal; }
            set { valorTotal = this.ObjProduto.PrecoProduto; }
        }

        private string statusPedido;
        [Display( Name ="Status")]
        [Required(ErrorMessage ="Status")]
        public string StatusPedido
        {
            get { return statusPedido; }
            set { statusPedido = value; }
        }

        private string tipoPedido;
        [Display(Name = "Tipo de Pedido")]
        [Required( ErrorMessage ="Tipo de Pedido é obrigatório")]
        public string TipoPedido
        {
            get { return tipoPedido; }
            set { tipoPedido = value; }
        }
        private IList<Pizza> pizzas = new List<Pizza>();
        public IList<Pizza> Pizzas { get { return pizzas; } set { this.pizzas = value; } }
        public Produto ObjProduto { get { return objproduto; } set { this.objproduto = value; } }

        public Pizza ObjPizza { get { return objpizza; } set { this.objpizza= value; } }

        public Pedido()
        {
            listaItemPedido = new List<ItensPedido>();
            Pizzas = new List<Pizza>();
            this.objpizza = new Pizza();
            this.objproduto = new Produto();
            this.objpizza.Sabores = new List<Sabor>();
            this.objpizza.Sabores.Add(new Sabor());
            this.objpizza.Sabores.Add(new Sabor());
            this.objpizza.Sabores.Add(new Sabor());
            this.objpizza.Sabores[0] = new Sabor();
            this.objpizza.Sabores[1] = new Sabor();
            this.objpizza.Sabores[2] = new Sabor();


        }
        public void salvar(Pedido pedido)
        {
            DAOPedido dao = new DAOPedido();
            dao.Salvar(pedido);
        }
        public IList<Pedido> ListarPizzasAbertos(String numero)
        {
            DAOPedido dao = new DAOPedido();
            return dao.BuscaTodosOsPedidosAberto(numero);
            
            
        }
        public IList<Pedido> ListarPizzasFechados(String numero)
        {
            DAOPedido dao = new DAOPedido();
            return dao.BuscaTodosOsPedidosFechado(numero);


        }
        public IList<Pedido> TodoosPedidos()
        {
            DAOPedido dao = new DAOPedido();
            return dao.BuscaTodosOsPedidos();
        }
    }
}