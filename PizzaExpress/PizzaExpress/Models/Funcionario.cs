using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaExpress.Models
{
    public class Funcionario:Pessoa
    {
        private int idFuncionario;
        public int IdFuncionario
        {
            get { return idFuncionario; }
            set { idFuncionario = value; }
        }

        private string senha;
        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }

        private int permissao;

        public int Permissao
        {
            get { return permissao; }
            set { permissao = value; }
        }

        private string setor;

        public string Setor
        {
            get { return setor; }
            set { setor = value; }
        }
        public void Salvar(Funcionario funcionario)
        {
            DAOFuncionario dao = new DAOFuncionario();
            if (funcionario.IdFuncionario != 0)
            {
                dao.Alterar(funcionario);
            }
            else
            {
                
                dao.Salvar(funcionario);
            }
        }
        public IList<Funcionario> Listar(String nome)
        {
            DAOFuncionario dao = new DAOFuncionario();
            return dao.BuscarPorNome(nome);
        }

    }
}