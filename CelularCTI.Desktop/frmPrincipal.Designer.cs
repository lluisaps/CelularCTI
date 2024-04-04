namespace CelularCTI.Desktop
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numPrecoFinal = new System.Windows.Forms.NumericUpDown();
            this.cmbFabricante = new System.Windows.Forms.ComboBox();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.btnPreco = new System.Windows.Forms.Button();
            this.btnModelo = new System.Windows.Forms.Button();
            this.a = new System.Windows.Forms.Label();
            this.bntFabricante = new System.Windows.Forms.Button();
            this.numPrecoInicial = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstCelulares = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnListar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnComprar = new System.Windows.Forms.Button();
            this.bntSair = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoFinal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoInicial)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numPrecoFinal);
            this.groupBox1.Controls.Add(this.cmbFabricante);
            this.groupBox1.Controls.Add(this.txtModelo);
            this.groupBox1.Controls.Add(this.btnPreco);
            this.groupBox1.Controls.Add(this.btnModelo);
            this.groupBox1.Controls.Add(this.a);
            this.groupBox1.Controls.Add(this.bntFabricante);
            this.groupBox1.Controls.Add(this.numPrecoInicial);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(630, 264);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pesquisar Por:";
            // 
            // numPrecoFinal
            // 
            this.numPrecoFinal.DecimalPlaces = 2;
            this.numPrecoFinal.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPrecoFinal.Location = new System.Drawing.Point(282, 43);
            this.numPrecoFinal.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numPrecoFinal.Minimum = new decimal(new int[] {
            1410065407,
            2,
            0,
            -2147483648});
            this.numPrecoFinal.Name = "numPrecoFinal";
            this.numPrecoFinal.Size = new System.Drawing.Size(120, 20);
            this.numPrecoFinal.TabIndex = 11;
            this.numPrecoFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbFabricante
            // 
            this.cmbFabricante.FormattingEnabled = true;
            this.cmbFabricante.Location = new System.Drawing.Point(112, 124);
            this.cmbFabricante.Name = "cmbFabricante";
            this.cmbFabricante.Size = new System.Drawing.Size(290, 21);
            this.cmbFabricante.TabIndex = 10;
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(112, 85);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(290, 20);
            this.txtModelo.TabIndex = 8;
            // 
            // btnPreco
            // 
            this.btnPreco.Location = new System.Drawing.Point(425, 38);
            this.btnPreco.Name = "btnPreco";
            this.btnPreco.Size = new System.Drawing.Size(75, 23);
            this.btnPreco.TabIndex = 7;
            this.btnPreco.Text = ">>";
            this.btnPreco.UseVisualStyleBackColor = true;
            this.btnPreco.Click += new System.EventHandler(this.btnBuscaPreco_Click);
            // 
            // btnModelo
            // 
            this.btnModelo.Location = new System.Drawing.Point(425, 85);
            this.btnModelo.Name = "btnModelo";
            this.btnModelo.Size = new System.Drawing.Size(75, 23);
            this.btnModelo.TabIndex = 6;
            this.btnModelo.Text = ">>";
            this.btnModelo.UseVisualStyleBackColor = true;
            this.btnModelo.Click += new System.EventHandler(this.btnBuscaModelo_Click);
            // 
            // a
            // 
            this.a.AutoSize = true;
            this.a.Location = new System.Drawing.Point(251, 48);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(14, 13);
            this.a.TabIndex = 5;
            this.a.Text = "a";
            // 
            // bntFabricante
            // 
            this.bntFabricante.Location = new System.Drawing.Point(425, 124);
            this.bntFabricante.Name = "bntFabricante";
            this.bntFabricante.Size = new System.Drawing.Size(75, 23);
            this.bntFabricante.TabIndex = 4;
            this.bntFabricante.Text = ">>";
            this.bntFabricante.UseVisualStyleBackColor = true;
            this.bntFabricante.Click += new System.EventHandler(this.btnBuscaFabricante_Click);
            // 
            // numPrecoInicial
            // 
            this.numPrecoInicial.DecimalPlaces = 2;
            this.numPrecoInicial.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPrecoInicial.Location = new System.Drawing.Point(112, 43);
            this.numPrecoInicial.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numPrecoInicial.Minimum = new decimal(new int[] {
            1410065407,
            2,
            0,
            -2147483648});
            this.numPrecoInicial.Name = "numPrecoInicial";
            this.numPrecoInicial.Size = new System.Drawing.Size(120, 20);
            this.numPrecoInicial.TabIndex = 2;
            this.numPrecoInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Preço:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Fabricante:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Modelo:";
            // 
            // lstCelulares
            // 
            this.lstCelulares.FormattingEnabled = true;
            this.lstCelulares.Location = new System.Drawing.Point(22, 19);
            this.lstCelulares.Name = "lstCelulares";
            this.lstCelulares.Size = new System.Drawing.Size(586, 212);
            this.lstCelulares.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnListar);
            this.groupBox2.Controls.Add(this.lstCelulares);
            this.groupBox2.Location = new System.Drawing.Point(12, 295);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(630, 272);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Celulares:";
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(22, 234);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(107, 32);
            this.btnListar.TabIndex = 13;
            this.btnListar.Text = "Listar todos";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListarAp_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(68, 601);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(104, 34);
            this.btnNovo.TabIndex = 11;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnComprar
            // 
            this.btnComprar.Location = new System.Drawing.Point(255, 601);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(104, 34);
            this.btnComprar.TabIndex = 12;
            this.btnComprar.Text = "Comprar";
            this.btnComprar.UseVisualStyleBackColor = true;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // bntSair
            // 
            this.bntSair.Location = new System.Drawing.Point(455, 601);
            this.bntSair.Name = "bntSair";
            this.bntSair.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bntSair.Size = new System.Drawing.Size(104, 34);
            this.bntSair.TabIndex = 13;
            this.bntSair.Text = "Sair";
            this.bntSair.UseVisualStyleBackColor = true;
            this.bntSair.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 699);
            this.Controls.Add(this.bntSair);
            this.Controls.Add(this.btnComprar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPrincipal";
            this.Text = "LojaCelularCTI O Seu mundo Mobille";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoFinal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoInicial)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numPrecoInicial;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Button btnPreco;
        private System.Windows.Forms.Button btnModelo;
        private System.Windows.Forms.Label a;
        private System.Windows.Forms.Button bntFabricante;
        private System.Windows.Forms.ListBox lstCelulares;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnComprar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.ComboBox cmbFabricante;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.NumericUpDown numPrecoFinal;
        private System.Windows.Forms.Button bntSair;
    }
}

