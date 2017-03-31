using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PizzaExpress.Models
{
    public class Conexao
    {
        private SqlConnection Conectar()
        {
            string stringConexao = @"Data Source=DESKTOP-TC5QN9P;Initial Catalog=PizzaExpress;User ID=sa;Password=evangelion";

            SqlConnection conexao = new SqlConnection(stringConexao);
            conexao.Open();

            return conexao;
        }

        public void ExecutarCrud(SqlCommand comando)
        {
            SqlConnection con = Conectar();
            comando.Connection = con;
            comando.ExecuteNonQuery();
            con.Close();

            
        }

        public SqlDataReader ExecutarSelect(SqlCommand comando)
        {
            SqlConnection con = Conectar();
            comando.Connection = con;
            SqlDataReader DR = comando.ExecuteReader(CommandBehavior.CloseConnection);
            return DR;
        }
    }
}