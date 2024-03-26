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
            ap = Servico.BuscarAparelho(numPrecoMin.Value, numPrecoMax.Value);
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

        private void btnComprar_Click(object sender, EventArgs e)
        {
            Aparelho selecionado = ap[lstCelulares.SelectedIndex];
            if (selecionado.Quantidade > 0)
                new frmComprar(selecionado).Show();
            else
                MessageBox.Show(

                "Não há aparelhos deste modelo no estoque!");
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new frmNovo().Show();
        }

    }
}
