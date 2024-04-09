using CelularCTI.Model.Entidades;
using CelularCTI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CelularCTI.Desktop
{
    public partial class frmComprarAparelho : Form
    {
       

        private Aparelho ap = new Aparelho();
       
        public frmComprarAparelho(Aparelho ap)
        {
            InitializeComponent();
            this.ap = ap;
             lblFabricante.Text = ap.Fabricante.Nome;
            lblModelo.Text = ap.Modelo;
            lblDimensao.Text = ap.Largura + "x" + ap.Altura + "x" + ap.Espessura+ "(cm)";
            lblQuantidade.Text = ap.Quantidade.ToString();
            lblPeso.Text = ap.Peso.ToString() + "gramas";
            lblPreco.Text = ap.Preco.ToString("C");
            lblDesconto.Text = ap.Desconto.ToString() + "%";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resp;
            resp = MessageBox.Show("Deseja realmente cancelar a compra?",
                this.Text,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmComprarAparelho_Load(object sender, EventArgs e)
        {
            lblFabricante.Text = ap.Fabricante.Nome;
            lblModelo.Text = ap.Modelo;
            lblDimensao.Text = ap.Largura + "x" + ap.Altura + "x" + ap.Espessura+ "(cm)";
            lblQuantidade.Text = ap.Quantidade.ToString();
            lblPeso.Text = ap.Peso.ToString() + "gramas";
            lblPreco.Text = ap.Preco.ToString("C");
            lblDesconto.Text = ap.Desconto.ToString() + "%";
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            Servico.FazerPedido(ap, txtObservacao.Text);
            MessageBox.Show("Compra do aparelho " + lblModelo.Text + " Realizada com sucesso",
                this.Text,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            this.Close();
        }
    }
}
