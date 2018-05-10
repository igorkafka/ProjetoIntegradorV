using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaExpress.Models
{
    public class Funcionario:Pessoa
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public virtual ICollection<Pedido> Pedidos { get; set; }
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
           
        }
        public IList<Funcionario> Listar(String nome)
        {

            return null;
        }

    }
}