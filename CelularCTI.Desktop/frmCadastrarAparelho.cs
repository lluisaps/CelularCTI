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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CelularCTI.Model
{
    public partial class FrmCadastrarAparelho : Form
    {

        public List<Fabricante> fab = new List<Fabricante>();
        public List<Aparelho> ap = new List<Aparelho>();

        public FrmCadastrarAparelho()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //if(cmbFabricante)

            if (String.IsNullOrEmpty(txtModelo.Text))
            {
               MessageBox.Show("Você deve informar o modelo do aparelho !!!",
               this.Text,
               MessageBoxButtons.OK,
               MessageBoxIcon.Question);

                txtModelo.Focus();

                return;
            }

            if (numPreco.Value <= 0)
            {
                MessageBox.Show("O preço do aparelho não pode ser menor ou igual a zero !!!",
               this.Text,
               MessageBoxButtons.OK,
               MessageBoxIcon.Question);

                numPreco.Focus();

                return;
            }

            Aparelho ap = new Aparelho();

            ap.Fabricante = fab[cmbFabricante.SelectedIndex];
            ap.Modelo = txtModelo.Text;
            ap.Largura = (float)Convert.ToDouble(numLargura.Text);
            ap.Espessura = (float)Convert.ToDouble(numLargura.Value);
            ap.Altura = (float)Convert.ToDouble(numAltura.Value);
            ap.Peso = (float)Convert.ToDouble(numPeso.Value);
            ap.Quantidade = (float)Convert.ToDouble(numQuantidade.Value);
            ap.Preco = (float)Convert.ToDecimal(numPreco.Value);
            ap.Desconto = (float)Convert.ToDecimal(numDesconto.Value);


            Servico.Salvar(ap);

            //cair na prova, contrutor 

            MessageBox.Show("Aparelho "+ txtModelo.Text + " cadastrado com sucesso !!!",
               this.Text,
               MessageBoxButtons.OK,
               MessageBoxIcon.Question);

            this.Close();

            return;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resp;
            resp = MessageBox.Show("Deseja cancelar o cadastro ?",
                this.Text,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void FrmCadastrarAparelho_Load(object sender, EventArgs e)
        {
            fab = Servico.BuscarFabricante();
            cmbFabricante.DataSource = fab;
            cmbFabricante.DisplayMember = "nome";
            cmbFabricante.ValueMember = "id_fabricante";
            cmbFabricante.SelectedIndex = 0;

        }
    }
}
