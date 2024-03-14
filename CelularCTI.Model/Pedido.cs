using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelularCTI.Model.Entidades
{
    public class Pedido
    {
        private Int64 id_pedido;
        private Aparelho aparelho;
        private DateTime dataHoraPedido;//guarda estatisticas intervalo de tempo, melhor não guardar so a data
        private string observacao;

        public long Id_pedido { get => id_pedido; set => id_pedido = value; }
        public DateTime DataHoraPedido { get => dataHoraPedido; set => dataHoraPedido = value; }
        public string Observacao { get => observacao; set => observacao = value; }
        internal Aparelho Aparelho { get => aparelho; set => aparelho = value; }
    }
}
