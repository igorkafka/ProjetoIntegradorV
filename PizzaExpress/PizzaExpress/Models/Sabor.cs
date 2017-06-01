using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaExpress.Models
{
    public class Sabor
    {
        public Sabor()
        {
            this.DescSabor = "Sem sabor";
        }
        private Pizza objPizza; //Composição Pizza
        public Pizza ObjPizza
        {
            get { return objPizza; }
            set { objPizza = value; }
        }

        //----- Atributos -----

        private int idSabor;
        public int IdSabor
        {
            get { return idSabor; }
            set { idSabor = value; }
        }

        private string nomeSabor;
        [Display( Name = "Nome")]
        [StringLength(30,ErrorMessage = "É permitido no máximo 30 e no mínimo 3 caracteres!", MinimumLength =3)]
        [Required(ErrorMessage ="Nome é obrigatório")]
        public string NomeSabor
        {
            get { return nomeSabor; }
            set { nomeSabor = value; }
        }

        private string descSabor;
        [Required(ErrorMessage = "Descrição é obrigatória")]
        [StringLength(60,ErrorMessage = "É permitido no máximo 60 caracteres!")]
        [Display(Name = "Descrição")]
        public string DescSabor
        {
            get { return descSabor; }
            set { descSabor = value; }
        }

        private decimal precoSabor;
        [Required(ErrorMessage ="O Preço do Sabor é obrigatório")]
        [DataType(DataType.Currency,ErrorMessage ="Apenas valores monetários são permitidos")]
        [Display(Name = "Preço")]
        public decimal PrecoSabor
        {
            get { return precoSabor; }
            set { precoSabor = value; }
        }
        public IList<Sabor> ListarNome(string nome)
        {
            DAOSabor dao = new DAOSabor();
             return dao.BuscarPorNome(nome);
        }
        public void Salvar(Sabor sabor)
        {
            DAOSabor dao = new DAOSabor();
            if(sabor.IdSabor == 0)
            {
                dao.Salvar(sabor);

            }
            else
            {
                dao.Alterar(sabor);
            }
        }
        public Sabor BuscarPorId(int id)
        {
            DAOSabor dao = new DAOSabor();
            return dao.BuscarPorIdSabor(id);
        }
        public void Excluir(int id)
        {
            DAOSabor dao = new DAOSabor();
            dao.Excluir(id);
        }
    }
}