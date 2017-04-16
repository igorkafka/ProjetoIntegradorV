using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PizzaExpress.Models
{
    public class DAOPedido
    {
        public int Salvar(Pedido objPedido)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "INSERT INTO Tb_Pedido(DescPedido, DataPedido, PrecoTotal, TipoPedido, StatusPedido, IdCliente) VALUES (@DescPedido, @HoraPedido, @DataPedido, @PrecoTotal, @TipoPedido, @StatusPedido, @IdCliente); SELECT @@IDENTITY;)";

            comando.Parameters.AddWithValue("@DescPedido", objPedido.DescPedido);
            comando.Parameters.AddWithValue("@DataPedido", objPedido.DataPedido);
            comando.Parameters.AddWithValue("@PrecoTotal", objPedido.ValorTotal);
            comando.Parameters.AddWithValue("@TipoPedido", objPedido.TipoPedido);
            comando.Parameters.AddWithValue("@StatusPedido", objPedido.StatusPedido);
            comando.Parameters.AddWithValue("@IdCliente", objPedido.ObjCliente.IdCliente);

            Conexao con = new Conexao();
            return con.ExecutarCrud(comando);
        }


        public void Alterar(Pedido objPedido)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "UPDATE Tb_Pedido SET StatusPedido = @StatusPedido WHERE NumPedido = @NumPedido";

            comando.Parameters.AddWithValue("@NumPedido", objPedido.NumPedido);
            comando.Parameters.AddWithValue("@StatusPedido", objPedido.StatusPedido);
            Conexao con = new Conexao();
            con.ExecutarCrud(comando);
        }


        public IList<Pedido> BuscaTodosOsPedidos()
        {
            IList<Pedido> ListaDePedidos = new List<Pedido>();
            DAOCliente objClienteDAO = new DAOCliente();
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT*FROM Tb_Pedido";

            Conexao con = new Conexao();
            SqlDataReader dr = con.ExecutarSelect(comando);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Pedido objPedido = new Pedido();
                    Cliente objCliente = new Cliente();
                    objPedido.NumPedido = (int)(dr["NumPedido"]);
                    objPedido.DescPedido = dr["DescPedido"].ToString();
                 
                    objPedido.DataPedido = Convert.ToDateTime(dr["DataPedido"]);
                    objPedido.StatusPedido = dr["StatusPedido"].ToString();
                    objPedido.ObjCliente = objClienteDAO.BuscarPorIdCliente(Convert.ToInt32(dr["IdCliente"]));

                    ListaDePedidos.Add(objPedido);


                }
            }
            else
            {
                ListaDePedidos = null;
            }

            return ListaDePedidos;
        }



        public IList<Pedido> BuscaTodosOsPedidosAberto(string status)
        {
            IList<Pedido> ListaDePedidos = new List<Pedido>();
            DAOCliente objClienteDAO = new DAOCliente();
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT*FROM Tb_Pedido WHERE StatusPedido = @StatusPedido";

            comando.Parameters.AddWithValue("@StatusPedido", status);

            Conexao con = new Conexao();
            SqlDataReader dr = con.ExecutarSelect(comando);

            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    Pedido objPedido = new Pedido();
                    Cliente objCliente = new Cliente();
                    objPedido.NumPedido = (int)(dr["NumPedido"]);
                    objPedido.DescPedido = dr["DescPedido"].ToString();
               
                    objPedido.DataPedido = Convert.ToDateTime(dr["DataPedido"]);
                    objPedido.StatusPedido = dr["StatusPedido"].ToString();
                    objPedido.ObjCliente = objClienteDAO.BuscarPorIdCliente(Convert.ToInt32(dr["IdCliente"]));

                    ListaDePedidos.Add(objPedido);


                }
            }
            else
            {
                ListaDePedidos = null;
            }

            return ListaDePedidos;
        }

        public IList<Pedido> BuscaTodosOsPedidosFechado(string status)
        {
            IList<Pedido> ListaDePedidos = new List<Pedido>();
            DAOCliente objClienteDAO = new DAOCliente();
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT*FROM Tb_Pedido WHERE StatusPedido = @StatusPedido";

            comando.Parameters.AddWithValue("@StatusPedido", status);

            Conexao con = new Conexao();
            SqlDataReader dr = con.ExecutarSelect(comando);

            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    Pedido objPedido = new Pedido();
                    Cliente objCliente = new Cliente();
                    objPedido.NumPedido = (int)(dr["NumPedido"]);
                    objPedido.DescPedido = dr["DescPedido"].ToString();
                   objPedido.DataPedido = Convert.ToDateTime(dr["DataPedido"]);
                    objPedido.StatusPedido = dr["StatusPedido"].ToString();
                    objPedido.ObjCliente = objClienteDAO.BuscarPorIdCliente(Convert.ToInt32(dr["IdCliente"]));

                    ListaDePedidos.Add(objPedido);


                }
            }
            else
            {
                ListaDePedidos = null;
            }

            return ListaDePedidos;
        }


        public Pedido BuscaPorID(int id)
        {
            Pedido objPedido = new Pedido();
            DAOCliente objClienteDAO = new DAOCliente();
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT*FROM Tb_Pedido WHERE NumPedido = @NumPedido";

            comando.Parameters.AddWithValue("@NumPedido", id);

            Conexao con = new Conexao();
            SqlDataReader dr = con.ExecutarSelect(comando);

            if (dr.HasRows)
            {
                dr.Read();
                Cliente objCliente = new Cliente();
                objPedido.NumPedido = (int)(dr["NumPedido"]);
                objPedido.DescPedido = dr["DescPedido"].ToString();
                objPedido.DataPedido = Convert.ToDateTime(dr["DataPedido"]);
                objPedido.StatusPedido = dr["StatusPedido"].ToString();
                objPedido.ObjCliente = objClienteDAO.BuscarPorIdCliente(Convert.ToInt32(dr["IdCliente"]));
                objPedido.ValorTotal = Convert.ToDecimal(dr["PrecoTotal"]);
                objPedido.TipoPedido = dr["TipoPedido"].ToString();



            }
            else
            {
                objPedido = null;
            }

            return objPedido;
        }



        public IList<Pedido> BuscaPorIDCliente(int id)
        {
            IList<Pedido> listDePedido = new List<Pedido>();
            DAOCliente objClienteDAO = new DAOCliente();
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT*FROM Tb_Pedido WHERE IdCliente = @IdCliente";
            comando.Parameters.AddWithValue("@IdCliente", id);
            Conexao con = new Conexao();
            SqlDataReader dr = con.ExecutarSelect(comando);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Pedido objPedido = new Pedido();
                    objPedido.NumPedido = (int)(dr["NumPedido"]);
                    objPedido.DescPedido = dr["DescPedido"].ToString();
                    objPedido.DataPedido = Convert.ToDateTime(dr["DataPedido"]);
                    objPedido.StatusPedido = dr["StatusPedido"].ToString();
                    objPedido.ObjCliente = objClienteDAO.BuscarPorIdCliente(Convert.ToInt32(dr["IdCliente"]));
                    objPedido.ValorTotal = Convert.ToDecimal(dr["PrecoTotal"]);
                    objPedido.TipoPedido = dr["TipoPedido"].ToString();

                    listDePedido.Add(objPedido);
                }


            }
            else
            {
                listDePedido = null;
            }

            return listDePedido;
        }
    }
}