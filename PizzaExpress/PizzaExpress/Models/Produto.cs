using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaExpress.Models
{
    public class Produto
    {
        public Produto()
        {
           
        }
        private ItensPedido objitensPedido; //Agregação ItensPedido
        public ItensPedido ObjitensPedido
        {
            get { return objitensPedido; }
            set { objitensPedido = value; }
        }

        //----- Atributos -----

        private int idProduto;
        [ScaffoldColumn(false)]
        public int IdProduto
        {
            get { return idProduto; }
            set { idProduto = value; }
        }
        private string nomeProduto;
        
        [DisplayName("Nome")]
        public string NomeProduto
        {
            get { return nomeProduto; }
            set { nomeProduto = value; }
        }

        private string descProduto;
        [DisplayName("Descrição")]
        public string DescProduto
        {
            get { return descProduto; }
            set { descProduto = value; }
        }

        private decimal precoProduto;
        [DisplayName("Preço")]
        [DataType(DataType.Currency)]
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