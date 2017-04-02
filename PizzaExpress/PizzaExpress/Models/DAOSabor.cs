using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PizzaExpress.Models
{
    public class DAOSabor
    {
        public void Salvar(Sabor objSabor)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = " INSERT INTO Tb_Sabor (nomeSabor, descSabor , precoSabor) VALUES ( @nomeSabor, @descSabor, @precoSabor)";

            comando.Parameters.AddWithValue("@nomeSabor", objSabor.NomeSabor);
            comando.Parameters.AddWithValue("@descSabor", objSabor.DescSabor);
            comando.Parameters.AddWithValue("@precoSabor", objSabor.PrecoSabor);

            Conexao con = new Conexao();
            con.ExecutarCrud(comando);
        }

        //Altera um Sabor
        public void Alterar(Sabor objSabor)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = " UPDATE Tb_Sabor SET NomeSabor=@NomeSabor, DescSabor=@DescSabor, PrecoSabor=@PrecoSabor  WHERE IdSabor=@IdSabor";

            comando.Parameters.AddWithValue("@IdSabor", objSabor.IdSabor);
            comando.Parameters.AddWithValue("@NomeSabor", objSabor.NomeSabor);
            comando.Parameters.AddWithValue("@DescSabor", objSabor.DescSabor);
            comando.Parameters.AddWithValue("@PrecoSabor", objSabor.PrecoSabor);

            Conexao con = new Conexao();
            con.ExecutarCrud(comando);
        }

        //Exclui um Sabor
        public void Excluir(int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = " DELETE Tb_Sabor WHERE IdSabor=@IdSabor";

            comando.Parameters.AddWithValue("@IdSabor", id);

            Conexao con = new Conexao();
            con.ExecutarCrud(comando);
        }

        //Busca o Sabor por ID
        public Sabor BuscarPorIdSabor(int Id)
        {
            Sabor objSabor = new Sabor();


            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT*FROM Tb_Sabor Where IdSabor=@IdSabor";

            comando.Parameters.AddWithValue("@IdSabor", Id);

            Conexao con = new Conexao();
            SqlDataReader dr = con.ExecutarSelect(comando);

            if (dr.HasRows)
            {
                dr.Read();
                objSabor.IdSabor = (int)(dr["IdSabor"]);
                objSabor.NomeSabor = dr["NomeSabor"].ToString();
                objSabor.PrecoSabor = Convert.ToDecimal(dr["PrecoSabor"]);
                objSabor.DescSabor = dr["DescSabor"].ToString();


            }
            return objSabor;
        }


        // Buscar Sabor por Nome
        public IList<Sabor> BuscarPorNome(string nome) //Buscar por Nome
        {
            IList<Sabor> listaDeSabor = new List<Sabor>();

            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT*FROM Tb_Sabor WHERE NomeSabor LIKE @NomeSabor";

            comando.Parameters.AddWithValue("@NomeSabor", "%" + nome + "%");

            Conexao con = new Conexao();
            SqlDataReader dr = con.ExecutarSelect(comando);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Sabor objSabor = new Sabor();

                    objSabor.IdSabor = (int)(dr["IdSabor"]);
                    objSabor.NomeSabor = dr["NomeSabor"].ToString();
                    objSabor.PrecoSabor = Convert.ToDecimal(dr["PrecoSabor"]);
                    objSabor.DescSabor = dr["DescSabor"].ToString();

                    listaDeSabor.Add(objSabor);
                }
            }
            return listaDeSabor;
        }

        //Buscar Todos os Sabores da Tabela
        public IList<Sabor> BuscaTodosOsSabores()
        {
            IList<Sabor> ListaDeSabores = new List<Sabor>();
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT*FROM Tb_Sabor";

            Conexao con = new Conexao();
            SqlDataReader dr = con.ExecutarSelect(comando);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Sabor objSabor = new Sabor();
                    objSabor.NomeSabor = dr["NomeSabor"].ToString();
                    objSabor.IdSabor = (int)dr["IdSabor"];
                    objSabor.DescSabor = dr["DescSabor"].ToString();
                    objSabor.PrecoSabor = (decimal)dr["PrecoSabor"];
                    ListaDeSabores.Add(objSabor);
                }
            }
         
           

            return ListaDeSabores;
        }
    }
}