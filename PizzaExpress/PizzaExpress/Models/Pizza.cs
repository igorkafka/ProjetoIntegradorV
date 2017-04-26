using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaExpress.Models
{
    public class Pizza
    {
        public Pizza()
        {
           Sabor listasabor = new Sabor();
            this.ObjListaSabor = listasabor;
        }
        private Sabor objListaSabor = new Sabor(); //Lista Sabor

        public Sabor ObjListaSabor
        {
            get { return objListaSabor; }
            set { objListaSabor = value; }
        }

        public Pizza(Sabor objListaSabor)
        {

            this.objListaSabor = objListaSabor;
        }

        //----- Atributos -----

        private string status;

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        private int idPizza;

        public int IdPizza
        {
            get { return idPizza; }
            set { idPizza = value; }
        }

        private decimal precoPizza;
        [DisplayName("Preço")]
        [DataType(DataType.Currency)]
        public decimal PrecoPizza
        {
            get { return precoPizza; }
            set { precoPizza = value; }
        }

        private string tamanho;
        [Required( ErrorMessage ="Tamanho é obrigatório")]
        public string Tamanho
        {
            get { return tamanho; }
            set { tamanho = value; }
        }
        public IList<Pizza> ListarPorTamanho(string tamanho)
        {
            DAOPizza dao = new DAOPizza();
            return dao.BuscarPizza(tamanho);
        }

        public IList<Sabor> Sabores { get { return sabores; } set { this.sabores = value; } }

        private IList<Sabor> sabores;
        


        public decimal CalcularValorTotalPizza(decimal valorSabor, string tamanho)
        {
            if (tamanho == "P")
            {
                int qtdPecacoP = 4;

                PrecoPizza = valorSabor * Convert.ToDecimal(qtdPecacoP);
            }
            else
            {
                if (tamanho == "M")
                {

                    int qtdPecacoM = 6;

                    PrecoPizza = valorSabor * Convert.ToDecimal(qtdPecacoM);
                }
                else
                {
                    if (tamanho == "G")
                    {

                        int qtdPecacoG = 8;

                        PrecoPizza = valorSabor * Convert.ToDecimal(qtdPecacoG);
                    }
                }
            }

            return PrecoPizza;
        }


        public decimal CalcularValorTotalPizzaDoisSabores(decimal valorSabor1, string tamanho, decimal valorSabor2, decimal valorSabor3)
        {
            if (tamanho == "M")
            {
                int qtdSabor1 = 6;

                PrecoPizza = ((valorSabor1 * Convert.ToDecimal(qtdSabor1)) / 2) + ((valorSabor2 * Convert.ToDecimal(qtdSabor1)) / 2);
            }
            else
            {
                if (tamanho == "G")
                {
                    int qtdSabor1 = 8;

                    PrecoPizza = ((valorSabor1 * Convert.ToDecimal(qtdSabor1)) / 2) + ((valorSabor2 * Convert.ToDecimal(qtdSabor1)) / 2) + ((valorSabor3 * Convert.ToDecimal(qtdSabor1)) / 2);
                }
            }
            return PrecoPizza;
        }
        public int salvar(Pizza objpizza)
        {
           
            DAOPizza dao = new DAOPizza();
            return dao.Salvar(objpizza);
        }
    }
}