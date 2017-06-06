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
            Sabor ListaSabor2 = new Sabor();
            this.Sabores = new List<Sabor>();
            this.Sabores.Add(new Sabor());
            this.Sabores.Add(new Sabor());
            this.Sabores.Add(new Sabor());
            this.Sabores[0] = new Sabor();
            this.Sabores[1] = new Sabor();
            this.Sabores[2] = new Sabor();
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
        public decimal VerificarSabores()
        {
            if (this.Sabores[0].IdSabor != 0 || this.Sabores[1].IdSabor == 0 || this.Sabores[2].IdSabor == 0)
            {

                // return CalcularValorTotalPizza(this.Sabores[0].PrecoSabor, Tamanho);
                return 10;
            }
            else if(this.Sabores[0].IdSabor != 0 || this.Sabores[1].IdSabor != 0 || this.Sabores[2].IdSabor == 0)
            {
                // return CalcularValorTotalPizzaDoisSabores(this.Sabores[0].PrecoSabor, this.Tamanho, this.Sabores[1].PrecoSabor);
                return 20;
            }
            else if (this.Sabores[0].IdSabor != 0 || this.Sabores[1].IdSabor != 0 || this.Sabores[2].IdSabor != 0)
            {
                // return CalcularValorTotalPizzasTresSabores(this.Sabores[0].PrecoSabor, this.Tamanho, this.Sabores[1].PrecoSabor, this.Sabores[2].PrecoSabor);
                return 30;
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
            DAOPizza dao = new DAOPizza();
            return dao.BuscarPizza(tamanho);
        }
        [Required(ErrorMessage ="Sabores são obrigatórios")]

        public IList<Sabor> Sabores { get { return this.sabores; } set { this.sabores = value; } }

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
            
            DAOPizza dao = new DAOPizza();
            return dao.Salvar(objpizza);
        }
        public Pizza BuscarPizzaId(int id)
        {
            DAOPizza dao = new DAOPizza();
            return dao.BuscarPizza(id);
        }
    }
}