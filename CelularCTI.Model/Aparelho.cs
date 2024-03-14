using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelularCTI.Model.Entidades
{
    public class Aparelho
    {
        private Int64 id_aparelho;
        private Fabricante fabricante;
        private string modelo;
        private double largura;
        private double altura;
        private double espessura;
        private double quantidade;
        private double peso;
        private decimal preco;
        private decimal desconto;

        //criar as propriedades
        public Int64 Id_Aparelho{ get; set; }
        public Fabricante Fabricante { get; set; }  
        public string Modelo { get; set; }
        
        public double Altura {  get; set; } 
        public double Largura { get;set; }
        public double Espessura { get; set;}

        public double Quantidade
        {
            get { return Quantidade; }
            set { if (Quantidade >= 0)
                    Quantidade = value;
                else
                    throw new Exception("A quantidade deve ser maior ou igual a zero");
            // deu erro ele recebe essa mensagem :o
            } 
        }
        public double Peso { get; set; }//se eu coloco peso minusculo o throw da erro aqui por causa do exception

        public decimal Preco
        {
            get { return preco; }
            set
            {
                if (preco > 0)
                    preco = value;
                else
                    throw new Exception("O preço deve ser maior ou igual a zero");
                // deu erro ele recebe essa mensagem :o
            }
        }

        public decimal Desconto {  get; set; } 




    }
}
