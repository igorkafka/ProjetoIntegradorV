using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaExpress.Models
{
    public class Pedido
    {
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
        public string DescPedido
        {
            get { return descPedido; }
            set { descPedido = value; }
        }
        private string horaPedido;

        public string HoraPedido
        {
            get { return horaPedido; }
            set { horaPedido = value; }
        }



        private DateTime dataPedido;
        public DateTime DataPedido
        {
            get { return dataPedido; }
            set { dataPedido = value; }
        }

        private decimal valorTotal;

        public decimal ValorTotal
        {
            get { return valorTotal; }
            set { valorTotal = value; }
        }

        private string statusPedido;

        public string StatusPedido
        {
            get { return statusPedido; }
            set { statusPedido = value; }
        }

        private string tipoPedido;

        public string TipoPedido
        {
            get { return tipoPedido; }
            set { tipoPedido = value; }
        }

        public Pedido()
        {
            listaItemPedido = new List<ItensPedido>();
        }
    }
}