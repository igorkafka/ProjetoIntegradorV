using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaExpress.Models
{
    public class ItensPedido
    {
        private Produto objProduto;

        public Produto ObjProduto
        {
            get { return objProduto; }
            set { objProduto = value; }
        }

        private Pizza objPizza;

        public Pizza ObjPizza
        {
            get { return objPizza; }
            set { objPizza = value; }
        }
        //----- Atributos -----

        private int idItem;
        public int IdItem
        {
            get { return idItem; }
            set { idItem = value; }
        }


        private int quatidade;
        public int Quatidade
        {
            get { return quatidade; }
            set { quatidade = value; }
        }


        private Pedido objPedido;
        public Pedido ObjPedido
        {
            get { return objPedido; }
            set { objPedido = value; }
        }

        public ItensPedido(Pedido objPedido)
        {
            this.objPedido = objPedido;
            objProduto = new Produto();
        }
    }
}