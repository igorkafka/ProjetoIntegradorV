using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaExpress.Models
{
    public class Cliente:Pessoa
    {
        private int idCliente;
        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

        private string nomeCliente;
        [DisplayName(displayName:"Nome")]
        public string NomeCliente
        {
            get { return nomeCliente; }
            set { nomeCliente = value; }
        }

        private string telefoneCliente;
        [DisplayName(displayName: "Telefone do Cliente")]
        public string TelefoneCliente
        {
            get { return telefoneCliente; }
            set { telefoneCliente = value; }
        }

        private string rua;
        public string Rua
        {
            get { return rua; }
            set { rua = value; }
        }

        private string bairro;
        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }

        private string numero;
        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        public void Salvar(Cliente cliente)
        {
            DAOCliente daocliente = new DAOCliente();
            daocliente.Alterar(cliente);
            
            daocliente.Salvar(cliente);
             
        }
        public void Alterar(Cliente cliente)
        {
            DAOCliente daocliente = new DAOCliente();
            

            daocliente.Alterar(cliente);
        }
        public IList<Cliente> ListarNome(String Nome)
        {
            DAOCliente dao = new Models.DAOCliente();
            return dao.BuscarPorNome(Nome);
           
        }
        public IList<Cliente> ListarTodos()
        {
            DAOCliente dao = new Models.DAOCliente();
            return dao.BuscaTodosOsClientes();
        }
        public Cliente BuscarPorId(int id)
        {
            DAOCliente dao = new DAOCliente();
            return dao.BuscarPorIdCliente(id);
        }

        public void Delete(int id)
        {
            DAOCliente dao = new DAOCliente();
            dao.Excluir(id);
        }
        
        
    }
}