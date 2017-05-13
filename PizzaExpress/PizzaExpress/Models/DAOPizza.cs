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
            comando.CommandText = " INSERT INTO Tb_Pizza (Tamanho, PrecoPizza, Sabor1, Sabor2, Sabor3) VALUES ( @Tamanho, @PrecoPizza, @Sabor1, @Sabor2, @Sabor3); SELECT @@IDENTITY";

            comando.Parameters.AddWithValue("@Tamanho", objPizza.Tamanho);
            comando.Parameters.AddWithValue("@PrecoPizza", objPizza.PrecoPizza);
            comando.Parameters.AddWithValue("@Sabor1", objPizza.Sabores[0].IdSabor);
            if(objPizza.Sabores[1].IdSabor == 0)
            {
                comando.Parameters.AddWithValue("@Sabor2", (object)DBNull.Value);
            }
            else
            {
                comando.Parameters.AddWithValue("@Sabor2", objPizza.Sabores[1].IdSabor);
            }
            if (objPizza.Sabores[2].IdSabor == 0)
            {
                comando.Parameters.AddWithValue("@Sabor3", (object)DBNull.Value);
            }
            else
            {
                comando.Parameters.AddWithValue("@Sabor3", objPizza.Sabores[2].IdSabor);
            }
           

           


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
            Pizza objPizza = new Pizza();
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
                Sabor objsabor = new Sabor();
                objPizza.ObjListaSabor1 = objPizza.ObjListaSabor1.BuscarPorId((Convert.ToInt32(dr["Sabor1"])));
                if(dr["Sabor2"] is DBNull)
                {
                    objPizza.ObjListaSabor2.DescSabor = "Sem segundo sabor";
                }
                else
                {
                    objPizza.ObjListaSabor2 = objPizza.ObjListaSabor2.BuscarPorId(Convert.ToInt32(dr["Sabor2"]));
                }
                if (dr["Sabor3"] is DBNull)
                {
                    
                    objPizza.ObjListSabor3.DescSabor = "Sem terceiro sabor";
                }
                else
                {
                    objPizza.ObjListSabor3 = objPizza.ObjListSabor3.BuscarPorId(Convert.ToInt32(dr["Sabor3"]));
                }
               
                objPizza.PrecoPizza = Convert.ToDecimal(dr["PrecoPizza"]);
                objPizza.Status = dr["status"].ToString();
                
            }
          

            return objPizza;
        }
        public IList<Pizza> BuscarPizza(string tamanho)
        {
            IList<Pizza> listadepizza = new List<Pizza>();
            Pizza objPizza = new Pizza(new Sabor());
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM Tb_Pizza WHERE Tb_Pizza.Tamanho  like '%@tamanho%'";

            comando.Parameters.AddWithValue("@tamano", tamanho);

            Conexao con = new Conexao();
            SqlDataReader dr = con.ExecutarSelect(comando);

            if (dr.HasRows)
            {
                dr.Read();
                objPizza.IdPizza = (int)dr["IdPizza"];
                objPizza.Tamanho = dr["Tamanho"].ToString();
                objPizza.Sabores[0] = objPizza.Sabores[0].BuscarPorId(Convert.ToInt32(dr["Sabor1"]));
                objPizza.Sabores[1] = objPizza.Sabores[1].BuscarPorId(Convert.ToInt32(dr["Sabor2"]));
                objPizza.Sabores[2] = objPizza.Sabores[2].BuscarPorId(Convert.ToInt32(dr["Sabor3"]));
                objPizza.PrecoPizza = Convert.ToDecimal(dr["PrecoPizza"]);
                objPizza.Status = dr["status"].ToString();
                listadepizza.Add(objPizza);
            }


            return listadepizza;
        }
    }
}