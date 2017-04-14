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
        public string NomeSabor
        {
            get { return nomeSabor; }
            set { nomeSabor = value; }
        }

        private string descSabor;
        public string DescSabor
        {
            get { return descSabor; }
            set { descSabor = value; }
        }

        private decimal precoSabor;
        [DataType(DataType.Currency)]
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