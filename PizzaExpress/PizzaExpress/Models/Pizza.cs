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
        }


        //----- Atributos -----

        private string status;

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nome { get; set; }
        public decimal VerificarSabores()
        {
            if (this.Sabor1.Id != 0 && this.Sabor2.Id == 0 && this.Sabor3.Id == 0)
            {

                 return CalcularValorTotalPizza(this.Sabor1.PrecoSabor, Tamanho);
               
            }
            else if(this.Sabor1.Id != 0 && this.Sabor2.Id != 0 && this.Sabor3.Id == 0)
            {
                 return CalcularValorTotalPizzaDoisSabores(this.Sabor1.PrecoSabor, this.Tamanho, this.Sabor2.PrecoSabor);
                
            }
            else if (this.Sabor1.Id != 0 && this.Sabor2.Id != 0 && this.Sabor3.Id != 0)
            {
                 return CalcularValorTotalPizzasTresSabores(this.Sabor1.PrecoSabor, this.Tamanho, this.Sabor2.PrecoSabor, this.Sabor3.PrecoSabor);
               
            }
            return 0;

        }
        private decimal precoPizza;
        [DisplayName("Preço")]
        [DataType(DataType.Currency, ErrorMessage ="Valor não é válido")]
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

            return null;
         }

        public Sabor Sabor1 { get; set; }
        public Sabor  Sabor2 { get; set; }
        public Sabor Sabor3 { get; set; }

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


        public decimal CalcularValorTotalPizzaDoisSabores(decimal valorSabor1, string tamanho, decimal valorSabor2)
        {
            if (tamanho == "P")
            {
                int qtdPecacoP = 4;

                PrecoPizza = ((valorSabor1 * Convert.ToDecimal(qtdPecacoP)) / 2) + ((valorSabor2 * Convert.ToDecimal(qtdPecacoP)) / 2);
            }
            if (tamanho == "M")
            {
                int qtdPecacoP = 6;

                PrecoPizza = ((valorSabor1 * Convert.ToDecimal(qtdPecacoP)) / 2) + ((valorSabor2 * Convert.ToDecimal(qtdPecacoP) / 2));
            }
            else
            {
                if (tamanho == "G")
                {
                    int qtdPecacoP = 8;

                    PrecoPizza = ((valorSabor1 * Convert.ToDecimal(qtdPecacoP)) / 2) + ((valorSabor2 * Convert.ToDecimal(qtdPecacoP)) / 2) + ((((valorSabor1+valorSabor2)/2) * Convert.ToDecimal(qtdPecacoP)) / 2);
                }
            }
            return PrecoPizza;
        }
        public decimal CalcularValorTotalPizzasTresSabores(decimal valorSabor1, string tamanho, decimal valorSabor2,decimal valorsabor3)
        {
            if (tamanho == "P")
            {
                int qtdPecacoP = 4;

                PrecoPizza = ((valorSabor1 * Convert.ToDecimal(qtdPecacoP)) / 2) + ((valorSabor2 * Convert.ToDecimal(qtdPecacoP)) / 2) + ((valorsabor3 * Convert.ToDecimal(qtdPecacoP)) / 2);
            }
            if (tamanho == "M")
            {
                int qtdPecacoP = 6;

                PrecoPizza = ((valorSabor1 * Convert.ToDecimal(qtdPecacoP)) / 2) + ((valorSabor2 * Convert.ToDecimal(qtdPecacoP) / 2)) + ((valorsabor3 * Convert.ToDecimal(qtdPecacoP)) / 2);
            }
            else
            {
                if (tamanho == "G")
                {
                    int qtdPecacoP = 8;

                    PrecoPizza = ((valorSabor1 * Convert.ToDecimal(qtdPecacoP)) / 2) + ((valorSabor2 * Convert.ToDecimal(qtdPecacoP)) / 2) + ((((valorSabor1 + valorSabor2 + valorsabor3) / 2) * Convert.ToDecimal(qtdPecacoP)) / 2) + ((valorsabor3 * Convert.ToDecimal(qtdPecacoP)) / 2);
                }
            }
            return PrecoPizza;
        }
        public int salvar(Pizza objpizza)
        {


            return 0;
        }
        public Pizza BuscarPizzaId(int id)
        {

            return null;
        }
    }
}