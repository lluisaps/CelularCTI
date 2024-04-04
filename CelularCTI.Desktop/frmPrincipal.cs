using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CelularCTI.Model.Entidades;
using CelularCTI.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CelularCTI.Desktop
{
    public partial class frmPrincipal : Form
    {

        public List<Aparelho> ap = new List<Aparelho>();
        public List<Fabricante> fab = new List<Fabricante>();


        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            fab = Servico.BuscarFabricante();
            cmbFabricante.DataSource = fab;
            cmbFabricante.DisplayMember = "nome";
            cmbFabricante.ValueMember = "id_fabricante";
            cmbFabricante.SelectedIndex = 0;

            ap = Servico.BuscarAparelho();
            lstCelulares.DataSource = ap;
        }

        private void btnBuscaPreco_Click(object sender, EventArgs e)
        {
            ap = Servico.BuscarAparelho(numPrecoInicial.Value, numPrecoFinal.Value);
            lstCelulares.DataSource = ap;
        }

        private void btnBuscaModelo_Click(object sender, EventArgs e)
        {
            ap = Servico.BuscarAparelho(txtModelo.Text);
            lstCelulares.DataSource = ap;
        }

        private void btnBuscaFabricante_Click(object sender, EventArgs e)
        {
            Fabricante fabricante = new Fabricante();
            fabricante = fab[cmbFabricante.SelectedIndex];

            ap = Servico.BuscarAparelho(fabricante);
            lstCelulares.DataSource = ap;
        }
        private void btnListarAp_Click(object sender, EventArgs e)
        {
            ap = Servico.BuscarAparelho();
            lstCelulares.DataSource = ap;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new FrmCadastrarAparelho().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult resp;
            resp = MessageBox.Show("Deseja realmente sair do sistema ?",
                this.Text,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            Aparelho apSelecionado = new Aparelho();

            apSelecionado = ap[lstCelulares.SelectedIndex];
            if (apSelecionado.Quantidade > 0)
            {
                frmComprarAparelho comprarAparelho = new frmComprarAparelho();
                comprarAparelho.ShowDialog();

            }
            else
            {
                MessageBox.Show("O aparelho" + apSelecionado.Modelo +
                    "Não tem quantidade disponivel em estoque" +
                    this.Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                lstCelulares.Focus();    
            }
            new frmComprarAparelho().ShowDialog();
        }
    }
}
