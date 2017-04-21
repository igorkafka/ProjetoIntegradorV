using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PizzaExpress.Models
{
    public class DAOCliente
    {
        public void Salvar(Cliente objCliente) //Salvar
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "INSERT INTO Tb_Cliente (nomeCliente, telefoneCliente ,rua, bairro, numero) VALUES ( @nomeCliente, @telefoneCliente, @rua, @bairro, @numero)";

            comando.Parameters.AddWithValue("@nomeCliente", objCliente.NomeCliente);
            comando.Parameters.AddWithValue("@telefoneCliente", objCliente.TelefoneCliente);
            comando.Parameters.AddWithValue("@rua", objCliente.Rua);
            comando.Parameters.AddWithValue("@bairro", objCliente.Bairro);
            comando.Parameters.AddWithValue("@numero", objCliente.Numero);


            Conexao con = new Conexao();
            con.ExecutarCrud(comando);
        }
        public void Alterar(Cliente objCliente) //Alterar
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = " UPDATE Tb_Cliente SET nomeCliente=@nomeCliente, telefoneCliente=@telefoneCliente, rua=@rua, bairro=@bairro, numero=@numero  WHERE idCliente=@idCliente";

            comando.Parameters.AddWithValue("@nomeCliente", objCliente.NomeCliente);
            comando.Parameters.AddWithValue("@TelefoneCliente", objCliente.TelefoneCliente);
            comando.Parameters.AddWithValue("@rua", objCliente.Rua);
            comando.Parameters.AddWithValue("@bairro", objCliente.Bairro);
            comando.Parameters.AddWithValue("@numero", objCliente.Numero);
            comando.Parameters.AddWithValue("@idCliente", objCliente.IdCliente);
            Conexao con = new Conexao();
            con.ExecutarCrud(comando);
        }
        public void Excluir(int id) //Excluir
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = " DELETE Tb_Cliente WHERE IdCliente=@IdCliente";

            comando.Parameters.AddWithValue("@IdCliente", id);

            Conexao con = new Conexao();
            con.ExecutarCrud(comando);
        }

        public Cliente BuscarPorIdCliente(int IdCliente) //Buscar por ID
        {
            Cliente objCliente = new Cliente();


            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM Tb_Cliente WHERE IdCliente=@IdCliente";

            comando.Parameters.AddWithValue("@IdCliente", IdCliente);

            Conexao con = new Conexao();
            SqlDataReader dr = con.ExecutarSelect(comando);

            if (dr.HasRows)
            {
                dr.Read();
                objCliente.IdCliente = (int)dr["idCliente"];
                objCliente.NomeCliente = dr["nomeCliente"].ToString();
                objCliente.TelefoneCliente = dr["telefoneCliente"].ToString();
                objCliente.Rua = dr["rua"].ToString();
                objCliente.Bairro = dr["Bairro"].ToString();
                objCliente.Numero = dr["Numero"].ToString();

            }
            
            return objCliente;
        }


        public Cliente BuscarPorClienteID(string nome) //Buscar por ID
        {
            Cliente objCliente = new Cliente();


            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT IdCliente FROM Tb_Cliente WHERE nomeCliente=@nomeCliente";

            comando.Parameters.AddWithValue("@nomeCliente", nome);

            Conexao con = new Conexao();
            SqlDataReader dr = con.ExecutarSelect(comando);

            if (dr.HasRows)
            {
                dr.Read();
                objCliente.IdCliente = (int)dr["IdCliente"];

            }
        
            
            return objCliente;
        }


        public Cliente BuscarPorTelefoneID(string telefone) //Buscar por ID
        {
            Cliente objCliente = new Cliente();


            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT IdCliente FROM Tb_Cliente WHERE telefoneCliente=@telefoneCliente";

            comando.Parameters.AddWithValue("@telefoneCliente", telefone);

            Conexao con = new Conexao();
            SqlDataReader dr = con.ExecutarSelect(comando);

            if (dr.HasRows)
            {
                dr.Read();
                objCliente.IdCliente = (int)dr["IdCliente"];

            }
           
            return objCliente;
        }


        public IList<Cliente> BuscarPorNome(string nome) //Buscar por Nome
        {
            IList<Cliente> listaDeClientes = new List<Cliente>();

            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT*FROM Tb_Cliente WHERE nomeCliente LIKE @nomeCliente";

            comando.Parameters.AddWithValue("@nomeCliente", "%" + nome + "%");

            Conexao con = new Conexao();
            SqlDataReader dr = con.ExecutarSelect(comando);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Cliente objCliente = new Cliente();

                    objCliente.IdCliente = (int)dr["IdCliente"];
                    objCliente.NomeCliente = dr["nomeCliente"].ToString();
                    objCliente.TelefoneCliente = dr["telefoneCliente"].ToString();
                    objCliente.Rua = dr["rua"].ToString();
                    objCliente.Bairro = dr["Bairro"].ToString();
                    objCliente.Numero = dr["Numero"].ToString();

                    listaDeClientes.Add(objCliente);
                }
            }
          
            return listaDeClientes;
        }

        public IList<Cliente> BuscarPorTelefone(string telefone) //Buscar por Telefone
        {
            IList<Cliente> listaDeClientes = new List<Cliente>();

            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT*FROM Tb_Cliente WHERE telefoneCliente LIKE @telefoneCliente";

            comando.Parameters.AddWithValue("@telefoneCliente", "%" + telefone + "%");

            Conexao con = new Conexao();
            SqlDataReader dr = con.ExecutarSelect(comando);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Cliente objCliente = new Cliente();

                    objCliente.IdCliente = (int)dr["IdCliente"];
                    objCliente.NomeCliente = dr["nomeCliente"].ToString();
                    objCliente.TelefoneCliente = dr["telefoneCliente"].ToString();
                    objCliente.Rua = dr["rua"].ToString();
                    objCliente.Bairro = dr["bairro"].ToString();
                    objCliente.Numero = dr["numero"].ToString();

                    listaDeClientes.Add(objCliente);
                }
            }
           
            return listaDeClientes;
        }

        public IList<Cliente> BuscaTodosOsClientes()
        {
            IList<Cliente> ListaDeClientes = new List<Cliente>();
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT*FROM Tb_Cliente";

            Conexao con = new Conexao();
            SqlDataReader dr = con.ExecutarSelect(comando);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Cliente objCliente = new Cliente();
                    objCliente.IdCliente = (int)dr["IdCliente"];
                    objCliente.NomeCliente = dr["nomeCliente"].ToString();
                    objCliente.TelefoneCliente = dr["telefoneCliente"].ToString();
                    objCliente.Rua = dr["rua"].ToString();
                    objCliente.Bairro = dr["bairro"].ToString();
                    objCliente.Numero = dr["numero"].ToString();
                    ListaDeClientes.Add(objCliente);
                }
            }
           
            

            return ListaDeClientes;
        }
    }
}