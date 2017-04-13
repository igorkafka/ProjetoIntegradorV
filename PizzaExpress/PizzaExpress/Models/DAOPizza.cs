using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PizzaExpress.Models
{
    public class DAOPizza
    {
        public int Salvar(Pizza objPizza) //Arrumar
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = " INSERT INTO Tb_Pizza (Tamanho, PrecoPizza, Sabor1, Sabor2, Sabor3, status) VALUES ( @Tamanho, @PrecoPizza, @Sabor1, @Sabor2, @Sabor3, @status); SELECT CAST (scope_identity() AS int)";

            comando.Parameters.AddWithValue("@Tamanho", objPizza.Tamanho);
            comando.Parameters.AddWithValue("@PrecoPizza", objPizza.PrecoPizza);
            for (int i = 1; i <= objPizza.Sabores.Count(); i++)
            {
                comando.Parameters.AddWithValue("@Sabor" + i, objPizza.Sabores[i]);
            }
            comando.Parameters.AddWithValue("@status", objPizza.Status);


            Conexao con = new Conexao();
            return con.ExecutarCrud(comando);
        }

        public void Alterar(Pizza objPizza)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "UPDATE Tb_Pizza SET status = @status WHERE IdPizza = @IdPizza";

            comando.Parameters.AddWithValue("@status", objPizza.Status);
            comando.Parameters.AddWithValue("@IdPizza", objPizza.IdPizza);

            Conexao con = new Conexao();
            con.ExecutarCrud(comando);
        }

        public Pizza BuscarPizza(int id)
        {
            Pizza objPizza = new Pizza(new Sabor());
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM Tb_Pizza WHERE IdPizza = @id";

            comando.Parameters.AddWithValue("@id", id);

            Conexao con = new Conexao();
            SqlDataReader dr = con.ExecutarSelect(comando);

            if (dr.HasRows)
            {
                dr.Read();
                objPizza.IdPizza = (int)dr["IdPizza"];
                objPizza.Tamanho = dr["Tamanho"].ToString();
                objPizza.Sabor1 = dr["Sabor1"].ToString();
                objPizza.Sabor2 = dr["Sabor2"].ToString();
                objPizza.Sabor3 = dr["Sabor3"].ToString();
                objPizza.PrecoPizza = Convert.ToDecimal(dr["PrecoPizza"]);
                objPizza.Status = dr["status"].ToString();
            }
            else
            {
                objPizza = null;
            }

            return objPizza;
        }
    }
}