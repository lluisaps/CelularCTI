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
        private float largura;
        private float altura;
        private float espessura;
        private float quantidade;
        private float peso;
        private float preco;
        private float desconto;

        //criar as propriedades
        public Int64 Id_Aparelho{ get; set; }
        public Fabricante Fabricante { get; set; }  
        public string Modelo { get; set; }
        public float Altura {  get; set; } 
        public float Largura { get;set; }
        public float Espessura { get; set;}

        public float Quantidade
        {
            get { return Quantidade; }
            set { if (Quantidade >= 0)
                    Quantidade = value;
                else
                    throw new Exception("A quantidade deve ser maior ou igual a zero");
            // deu erro ele recebe essa mensagem :o
            } 
        }
        public float Peso { get; set; }//se eu coloco peso minusculo o throw da erro aqui por causa do exception

        public float Preco
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

        public float Desconto {  get; set; }


        public override String ToString()
        {
            return Fabricante.Nome.PadRight(15) +
                Modelo.PadRight(25) +
                Preco.ToString("#,##0.000").PadLeft(20) +
                (" "+ Quantidade + "Em estoque" );
        }




    }
}
