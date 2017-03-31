using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaExpress.Models
{
    public class Sabor
    {
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
        public decimal PrecoSabor
        {
            get { return precoSabor; }
            set { precoSabor = value; }
        }
    }
}