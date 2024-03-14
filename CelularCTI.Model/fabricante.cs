using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CelularCTI.Model
{
    public class Fabricante
    {
        //Método Construtor de classe

        //Atributos internos

        //Propriedades da classe - são os atributos que serão expostos que terão seus dados expostos 

        //Métodos 

        private Int64 id_Fabricante;
        private string nome;
        private string observacao;

        public Int64 Id_Fabricante
        {
            get { return id_Fabricante; } 
          set { id_Fabricante = value; }
                
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }   
        }
        public string Observacao
        { get { return observacao; }
        set { observacao = value; }
        }




    }
}
