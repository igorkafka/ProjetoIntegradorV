using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PizzaExpress.Models
{
    public class DAOFuncionario
    {
        public void Salvar(Funcionario objFuncionario) //Salvar
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = " INSERT INTO Tb_Funcionario (nome, telefone , senha, permissao, setor) VALUES ( @nome, @telefone, @senha, @permissao, @setor)";

            comando.Parameters.AddWithValue("@nome", objFuncionario.Nome);
            comando.Parameters.AddWithValue("@telefone", objFuncionario.Telefone);
            comando.Parameters.AddWithValue("@senha", objFuncionario.Senha);
            comando.Parameters.AddWithValue("@permissao", objFuncionario.Permissao);
            comando.Parameters.AddWithValue("@setor", objFuncionario.Setor);


            Conexao con = new Conexao();
            con.ExecutarCrud(comando);
        }
        public void Alterar(Funcionario objFuncionario) //Alterar
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = " UPDATE Tb_Fucionarios SET nome=@nome, telefone=@telefone, senha=@senha, permissao=@permissao, setor=@setor WHERE id=@id";

            comando.Parameters.AddWithValue("@nome", objFuncionario.Nome);
            comando.Parameters.AddWithValue("@telefone", objFuncionario.Telefone);
            comando.Parameters.AddWithValue("@senha", objFuncionario.Senha);
            comando.Parameters.AddWithValue("@permissao", objFuncionario.Permissao);
            comando.Parameters.AddWithValue("@setor", objFuncionario.Setor);
            Conexao con = new Conexao();
            con.ExecutarCrud(comando);
        }
        public void Excluir(Funcionario objFuncionario) //Excluir
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = " DELETE Tb_Funcionarios WHERE IdFuncionario=@IdFuncionario";

            comando.Parameters.AddWithValue("@IdFuncionario", objFuncionario.IdFuncionario);

            Conexao con = new Conexao();
            con.ExecutarCrud(comando);
        }

        public Funcionario BuscarPorIdFuncionario(int IdFuncionario) //Buscar por ID
        {
            Funcionario objFuncionario = new Funcionario();


            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT*FROM Tb_Funcionarios WHERE IdFuncionario=@IdFuncionario";

            comando.Parameters.AddWithValue("@IdFuncionario", IdFuncionario);

            Conexao con = new Conexao();
            SqlDataReader dr = con.ExecutarSelect(comando);

            if (dr.HasRows)
            {
                dr.Read();
                objFuncionario.IdFuncionario = (int)dr["id"];
                objFuncionario.Nome = dr["nome"].ToString();
                objFuncionario.Telefone = dr["telefone"].ToString();
                objFuncionario.Senha = dr["Senha"].ToString();
                objFuncionario.Permissao = (int)dr["permissao"];
                objFuncionario.Setor = dr["nome"].ToString();



            }
            else
            {
                objFuncionario = null;
            }
            return objFuncionario;
        }



        public IList<Funcionario> BuscarPorNome(string nome) // Buscar por Nome
        {
            IList<Funcionario> listaDeFuncionarios = new List<Funcionario>();

            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT*FROM Tb_Funcionarios WHERE nome LIKE @nome";

            comando.Parameters.AddWithValue("@nome", "%" + nome + "%");

            Conexao con = new Conexao();
            SqlDataReader dr = con.ExecutarSelect(comando);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Funcionario objFuncionario = new Funcionario();
                    objFuncionario.IdFuncionario = (int)dr["id"];
                    objFuncionario.Nome = dr["nome"].ToString();
                    objFuncionario.Telefone = dr["telefone"].ToString();
                    objFuncionario.Senha = dr["Senha"].ToString();
                    objFuncionario.Permissao = (int)dr["permissao"];
                    objFuncionario.Setor = dr["nome"].ToString();

                    listaDeFuncionarios.Add(objFuncionario);
                }
            }
           
            return listaDeFuncionarios;
        }
    }
}
