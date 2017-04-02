using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaExpress.Models
{
    public class Produto
    {
        private ItensPedido objitensPedido; //Agregação ItensPedido
        public ItensPedido ObjitensPedido
        {
            get { return objitensPedido; }
            set { objitensPedido = value; }
        }

        //----- Atributos -----

        private int idProduto;
        public int IdProduto
        {
            get { return idProduto; }
            set { idProduto = value; }
        }
        private string nomeProduto;
        public string NomeProduto
        {
            get { return nomeProduto; }
            set { nomeProduto = value; }
        }

        private string descProduto;
        public string DescProduto
        {
            get { return descProduto; }
            set { descProduto = value; }
        }

        private decimal precoProduto;
        public decimal PrecoProduto
        {
            get { return precoProduto; }
            set { precoProduto = value; }

        }
        public Produto ProdutoPorId(int id)
        {
            DAOProduto dao = new DAOProduto();
            return dao.BuscarPorIdProduto(id);
        }
        public IList<Produto> ListarNome(string nome)
        {
            DAOProduto dao = new DAOProduto();
            return dao.BuscarPorNome(nome);
        }
        public void Salvar(Produto produto)
        {
            DAOProduto dao = new Models.DAOProduto();
            if(produto.IdProduto == 0)
            {
                dao.Salvar(produto);
            }
            else
            {
                dao.Alterar(produto);
            }
        }
        public void Deletar(int id)
        {
            DAOProduto dao = new DAOProduto();
            dao.Excluir(id);
        }
    }
}