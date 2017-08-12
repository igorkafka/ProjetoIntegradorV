using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaExpress.Models
{
    public class Cliente : Pessoa
    {
        
            public Cliente()
            {

            }
            private int idCliente;
            [DisplayName("Código")]
            public int IdCliente
            {
                get { return idCliente; }
                set { idCliente = value; }
            }

            private string nomeCliente;

            [Required(ErrorMessage = "O nome é obrigatório!")]
            [StringLength(40, ErrorMessage = "O campo nome não pode ter mais de 40 letras e menos de 3 letras", MinimumLength = 3)]
            [DisplayName(displayName: "Nome")]
            public string NomeCliente
            {
                get { return nomeCliente; }
                set { nomeCliente = value; }
            }

            private string telefoneCliente;
            [StringLength(18, ErrorMessage = "O campo telefone não pode ter mais de 18 letras")]
            [DisplayName(displayName: "Telefone")]
            [RegularExpression("[0-9]{1,}", ErrorMessage = "Apenas algarismo númericos são permitidos")]
            [Required(ErrorMessage = "Número do Telefone do Cliente é obrigatório")]
            public string TelefoneCliente
            {
                get { return telefoneCliente; }
                set { telefoneCliente = value; }
            }

            private string rua;
            [Required(ErrorMessage = "Nome da Rua é obrigatório")]
            [StringLength(30, ErrorMessage = "O campo rua não pode ter mais de 30 letras")]
            public string Rua
            {
                get { return rua; }
                set { rua = value; }
            }

            private string bairro;
            [Required(ErrorMessage = "Nome do Bairro é obrigatório")]
            [StringLength(30, ErrorMessage = "O campo bairro não pode ter mais de 30 letras")]
            public string Bairro
            {
                get { return bairro; }
                set { bairro = value; }
            }

            private string numero;
            [RegularExpression("[0-9]{1,}", ErrorMessage = "Apenas algarismo númericos são permitidos")]
            [Required(ErrorMessage = "Número da Casa é obrigatório")]
            [StringLength(8, ErrorMessage = "O campo número da casa não pode ter mais de 8 letras")]
            public string Numero
            {
                get { return numero; }
                set { numero = value; }
            }
            public void Salvar(Cliente cliente)
            {
                
             

            }
            public void Alterar(Cliente cliente)
            {
                


               
            }
            public IList<Cliente> ListarNome(String Nome)
            {
            return null;

            }
            public IList<Cliente> ListarTodos()
            {

            return null;
            }
            public Cliente BuscarPorId(int id)
            {

            return null; 
            }

            public void Delete(int id)
            {
             
            }


        }
    }