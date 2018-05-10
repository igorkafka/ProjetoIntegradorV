using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaExpress.Models
{
    public class Pedido
    {
        public int Id { get; set; }        
        private IList<ItensPedido> listaItemPedido; //Lista ItensPedido
        public IList<ItensPedido> ListaItemPedido
        {
            get { return listaItemPedido; }
            set { listaItemPedido = value; }
        }
        //----- Atributos -----

        private int numPedido;
     
        public int NumPedido
        {
            get { return numPedido; }
            set { numPedido = value; }
        }

        private string descPedido;
        [StringLength(50,ErrorMessage ="Descrição é obrigatória")]
        [Required(ErrorMessage ="Descrição do Pedido é obrigatória")]
        [Display(Name="Descrição")]
        public string DescPedido
        {
            get { return descPedido; }
            set { descPedido = value; }
        }
        private DateTime dataPedido;
        [Display(Name ="Data")]
        [Required(ErrorMessage ="Data do pedido é obrigatória!")]
        [DataType(DataType.Date)]
        public DateTime DataPedido
        {
            get { return dataPedido; }
            set { dataPedido = value; }
        }
         
        private string statusPedido;
        
        [Display( Name ="Status")]
        public string StatusPedido
        {
            get { return statusPedido; }
            set { statusPedido = value; }
        }

        private string tipoPedido;
        [Display(Name = "Tipo de Pedido")]
        [Required( ErrorMessage ="Tipo de Pedido é obrigatório")]
       [DisplayFormat(DataFormatString = "{dd/mm/yy}", ApplyFormatInEditMode = true)]
        public string TipoPedido
        {
            get { return tipoPedido; }
            set { tipoPedido = value; }
        }
     
        public Pedido()
        { 
        }
        public void salvar(Pedido pedido)
        {
            
        }
        public IList<Pedido> ListarPizzasAbertos(DateTime data)
        {

            return null;
            
            
        }
        public IList<Pedido> ListarPizzasFechados(DateTime data)
        {

            return null;


        }
        public IList<Pedido> TodoosPedidos()
        {

            return null;
        }
        public void AlterarStatus(Pedido objpedido)
        {

        }
        public Pedido BuscarPorId(int id)
        {

            return null;
        }
        public Funcionario ObjFuncionario { get; set; }
        public virtual ICollection<Venda> Vendas { get; set; }

    }
}