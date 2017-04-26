using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PizzaExpress.Models
{
    public class DAOProduto
    {
        public void Salvar(Produto objProduto)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = " INSERT INTO Tb_Produto ( NomeProduto, PrecoProduto, DescProduto ) VALUES ( @NomeProduto, @PrecoProduto, @DescProduto)";

            comando.Parameters.AddWithValue("@NomeProduto", objProduto.NomeProduto);
            comando.Parameters.AddWithValue("@PrecoProduto", objProduto.PrecoProduto);
            comando.Parameters.AddWithValue("@DescProduto", objProduto.DescProduto);

            Conexao con = new Conexao();
          con.ExecutarCrud(comando);
        }

        //Altera um Produto
        public void Alterar(Produto objProduto)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "UPDATE Tb_Produto SET NomeProduto=@NomeProduto, DescProduto=@DescProduto, PrecoProduto=@PrecoProduto  WHERE IdProduto=@IdProduto";

            comando.Parameters.AddWithValue("@IdProduto", objProduto.IdProduto);
            comando.Parameters.AddWithValue("@NomeProduto", objProduto.NomeProduto);
            comando.Parameters.AddWithValue("@PrecoProduto", objProduto.PrecoProduto);
            comando.Parameters.AddWithValue("@DescProduto", objProduto.DescProduto);

            Conexao con = new Conexao();
            con.ExecutarCrud(comando);
        }

        //Exclui um Produto
        public void Excluir(int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = " DELETE Tb_Produto WHERE IdProduto=@IdProduto";

            comando.Parameters.AddWithValue("@IdProduto", id);

            Conexao con = new Conexao();
            con.ExecutarCrud(comando);
        }

        //Busca o Produto por ID
        public Produto BuscarPorIdProduto(int id)
        {
            Produto objProduto = new Produto();

            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT*FROM Tb_Produto WHERE IdProduto=@IdProduto";
            comando.Parameters.AddWithValue("@IdProduto", id);

            Conexao con = new Conexao();
            SqlDataReader dr = con.ExecutarSelect(comando);

            if (dr.HasRows)
            {
                dr.Read();
                objProduto.IdProduto = (int)(dr["IdProduto"]);
                objProduto.NomeProduto = dr["NomeProduto"].ToString();
                objProduto.PrecoProduto = Convert.ToDecimal(dr["PrecoProduto"]);
                objProduto.DescProduto = dr["DescProduto"].ToString();
            }
           
            return objProduto;
        }

        public IList<Produto> BuscarPorNome(string nome) //Buscar por Nome
        {
            IList<Produto> listaDeProduto = new List<Produto>();

            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT*FROM Tb_Produto WHERE NomeProduto LIKE @NomeProduto";

            comando.Parameters.AddWithValue("@NomeProduto", "%" + nome + "%");

            Conexao con = new Conexao();
            SqlDataReader dr = con.ExecutarSelect(comando);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Produto objProduto = new Produto();

                    objProduto.IdProduto = (int)(dr["IdProduto"]);
                    objProduto.NomeProduto = dr["NomeProduto"].ToString();
                    objProduto.PrecoProduto = Convert.ToDecimal(dr["PrecoProduto"]);
                    objProduto.DescProduto = dr["DescProduto"].ToString();

                    listaDeProduto.Add(objProduto);
                }
            }
           
            return listaDeProduto;
        }


        //Buscar Todos os Produtos da Tabela
        public IList<Produto> BuscaTodosOsProdutos()
        {
            IList<Produto> ListaDeProdutos = new List<Produto>();
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT*FROM Tb_Produto";

            Conexao con = new Conexao();
            SqlDataReader dr = con.ExecutarSelect(comando);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Produto objProduto = new Produto();
                    objProduto.IdProduto = (int)dr["IdProduto"];
                    objProduto.NomeProduto = dr["NomeProduto"].ToString();
                    objProduto.DescProduto = dr["DescProduto"].ToString();
                    objProduto.PrecoProduto = (decimal)dr["PrecoProduto"];
                    ListaDeProdutos.Add(objProduto);
                }
            }
            

            return ListaDeProdutos;
        }
    }
}