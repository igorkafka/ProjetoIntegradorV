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
        [Required(ErrorMessage ="Nome é obrigatório!")]
        [StringLength(50,ErrorMessage ="É permitido até 50 caracteres")]
        [DisplayName("Nome")]
        public string NomeProduto
        {
            get { return nomeProduto; }
            set { nomeProduto = value; }
        }

        private string descProduto;
        
        [Required(ErrorMessage ="Descrição é obrigatória")]
        [StringLength(50,ErrorMessage ="É permitido até 50 caracteres")]
        [DisplayName("Descrição")]
        public string DescProduto
        {
            get { return descProduto; }
            set { descProduto = value; }
        }

        private decimal precoProduto;
        [Required(ErrorMessage ="Preço é obrigatório")]
        [DisplayName("Preço")]
        [DataType(DataType.Currency)]
        public decimal PrecoProduto
        {
            get { return precoProduto; }
            set { precoProduto = value; }

        }
        public Produto ProdutoPorId(int id)
        {

            return null;
        }
        public IList<Produto> ListarNome(string nome)
        {

            return null;
        }
        public void Salvar(Produto produto)
        {
         
            
        }
        public void Deletar(int id)
        {
      
         
        }
    }
}