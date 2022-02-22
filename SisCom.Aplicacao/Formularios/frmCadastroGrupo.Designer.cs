
namespace SisCom.Aplicacao.Formularios
{
    partial class frmCadastroGrupo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroGrupo));
            this.gridSubGrupo = new System.Windows.Forms.DataGridView();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabSubGrupo = new System.Windows.Forms.TabPage();
            this.checkNaoVender = new System.Windows.Forms.CheckBox();
            this.botaoFabricante = new System.Windows.Forms.Button();
            this.botaoSubGrupo = new System.Windows.Forms.Button();
            this.textNomeGrupo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlDadosGerais = new System.Windows.Forms.Panel();
            this.comboPesquisarPesquisa = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboPesquisarTipoFiltro = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.botaoImprimir = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.botaoFechar = new System.Windows.Forms.Button();
            this.botaoNovo = new System.Windows.Forms.Button();
            this.botaoExcluir = new System.Windows.Forms.Button();
            this.botaoPosterior = new System.Windows.Forms.Button();
            this.botaoAnterior = new System.Windows.Forms.Button();
            this.pnlMenuBotaoBotao = new System.Windows.Forms.Panel();
            this.pnlPesquisar = new System.Windows.Forms.Panel();
            this.pnlMenuBotao = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gridSubGrupo)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabSubGrupo.SuspendLayout();
            this.pnlDadosGerais.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlMenuBotaoBotao.SuspendLayout();
            this.pnlPesquisar.SuspendLayout();
            this.pnlMenuBotao.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridSubGrupo
            // 
            this.gridSubGrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSubGrupo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSubGrupo.Location = new System.Drawing.Point(3, 3);
            this.gridSubGrupo.Name = "gridSubGrupo";
            this.gridSubGrupo.RowTemplate.Height = 25;
            this.gridSubGrupo.Size = new System.Drawing.Size(731, 229);
            this.gridSubGrupo.TabIndex = 1;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabSubGrupo);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 187);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(745, 263);
            this.tabControl.TabIndex = 9;
            // 
            // tabSubGrupo
            // 
            this.tabSubGrupo.Controls.Add(this.gridSubGrupo);
            this.tabSubGrupo.Location = new System.Drawing.Point(4, 24);
            this.tabSubGrupo.Name = "tabSubGrupo";
            this.tabSubGrupo.Padding = new System.Windows.Forms.Padding(3);
            this.tabSubGrupo.Size = new System.Drawing.Size(737, 235);
            this.tabSubGrupo.TabIndex = 0;
            this.tabSubGrupo.Text = "SubGrupos";
            this.tabSubGrupo.UseVisualStyleBackColor = true;
            // 
            // checkNaoVender
            // 
            this.checkNaoVender.AutoSize = true;
            this.checkNaoVender.Location = new System.Drawing.Point(10, 34);
            this.checkNaoVender.Name = "checkNaoVender";
            this.checkNaoVender.Size = new System.Drawing.Size(87, 19);
            this.checkNaoVender.TabIndex = 18;
            this.checkNaoVender.Text = "Não Vender";
            this.checkNaoVender.UseVisualStyleBackColor = true;
            this.checkNaoVender.Click += new System.EventHandler(this.checkNaoVender_CheckedChanged);
            // 
            // botaoFabricante
            // 
            this.botaoFabricante.Location = new System.Drawing.Point(745, 74);
            this.botaoFabricante.Name = "botaoFabricante";
            this.botaoFabricante.Size = new System.Drawing.Size(23, 23);
            this.botaoFabricante.TabIndex = 17;
            this.botaoFabricante.UseVisualStyleBackColor = true;
            // 
            // botaoSubGrupo
            // 
            this.botaoSubGrupo.Location = new System.Drawing.Point(745, 51);
            this.botaoSubGrupo.Name = "botaoSubGrupo";
            this.botaoSubGrupo.Size = new System.Drawing.Size(23, 23);
            this.botaoSubGrupo.TabIndex = 16;
            this.botaoSubGrupo.UseVisualStyleBackColor = true;
            // 
            // textNomeGrupo
            // 
            this.textNomeGrupo.Location = new System.Drawing.Point(106, 5);
            this.textNomeGrupo.Name = "textNomeGrupo";
            this.textNomeGrupo.Size = new System.Drawing.Size(635, 23);
            this.textNomeGrupo.TabIndex = 6;
            this.textNomeGrupo.Click += new System.EventHandler(this.textNomeGrupo_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(10, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "Nome do Grupo";
            // 
            // pnlDadosGerais
            // 
            this.pnlDadosGerais.BackColor = System.Drawing.Color.Silver;
            this.pnlDadosGerais.Controls.Add(this.checkNaoVender);
            this.pnlDadosGerais.Controls.Add(this.botaoFabricante);
            this.pnlDadosGerais.Controls.Add(this.botaoSubGrupo);
            this.pnlDadosGerais.Controls.Add(this.textNomeGrupo);
            this.pnlDadosGerais.Controls.Add(this.label10);
            this.pnlDadosGerais.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDadosGerais.Location = new System.Drawing.Point(0, 131);
            this.pnlDadosGerais.Name = "pnlDadosGerais";
            this.pnlDadosGerais.Size = new System.Drawing.Size(745, 56);
            this.pnlDadosGerais.TabIndex = 8;
            // 
            // comboPesquisarPesquisa
            // 
            this.comboPesquisarPesquisa.FormattingEnabled = true;
            this.comboPesquisarPesquisa.Location = new System.Drawing.Point(431, 15);
            this.comboPesquisarPesquisa.Name = "comboPesquisarPesquisa";
            this.comboPesquisarPesquisa.Size = new System.Drawing.Size(300, 23);
            this.comboPesquisarPesquisa.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(365, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 15);
            this.label9.TabIndex = 2;
            this.label9.Text = "SubGrupo:";
            // 
            // comboPesquisarTipoFiltro
            // 
            this.comboPesquisarTipoFiltro.FormattingEnabled = true;
            this.comboPesquisarTipoFiltro.Location = new System.Drawing.Point(55, 15);
            this.comboPesquisarTipoFiltro.Name = "comboPesquisarTipoFiltro";
            this.comboPesquisarTipoFiltro.Size = new System.Drawing.Size(300, 23);
            this.comboPesquisarTipoFiltro.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(10, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Grupo:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboPesquisarPesquisa);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.comboPesquisarTipoFiltro);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(10, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(734, 40);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pesquisar Registros: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(164, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 12);
            this.label1.TabIndex = 31;
            this.label1.Text = "Imprimir";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // botaoImprimir
            // 
            this.botaoImprimir.Image = ((System.Drawing.Image)(resources.GetObject("botaoImprimir.Image")));
            this.botaoImprimir.Location = new System.Drawing.Point(159, 0);
            this.botaoImprimir.Name = "botaoImprimir";
            this.botaoImprimir.Size = new System.Drawing.Size(53, 56);
            this.botaoImprimir.TabIndex = 30;
            this.botaoImprimir.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(274, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 12);
            this.label7.TabIndex = 29;
            this.label7.Text = "Fechar";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(224, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 28;
            this.label6.Text = "Novo";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(116, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 12);
            this.label5.TabIndex = 27;
            this.label5.Text = "Excluir";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // botaoFechar
            // 
            this.botaoFechar.Image = ((System.Drawing.Image)(resources.GetObject("botaoFechar.Image")));
            this.botaoFechar.Location = new System.Drawing.Point(265, 0);
            this.botaoFechar.Name = "botaoFechar";
            this.botaoFechar.Size = new System.Drawing.Size(53, 56);
            this.botaoFechar.TabIndex = 20;
            this.botaoFechar.UseVisualStyleBackColor = true;
            this.botaoFechar.Click += new System.EventHandler(this.botaoFechar_Click);
            // 
            // botaoNovo
            // 
            this.botaoNovo.Image = ((System.Drawing.Image)(resources.GetObject("botaoNovo.Image")));
            this.botaoNovo.Location = new System.Drawing.Point(212, 0);
            this.botaoNovo.Name = "botaoNovo";
            this.botaoNovo.Size = new System.Drawing.Size(53, 56);
            this.botaoNovo.TabIndex = 19;
            this.botaoNovo.UseVisualStyleBackColor = true;
            this.botaoNovo.Click += new System.EventHandler(this.botaoNovo_Click);
            // 
            // botaoExcluir
            // 
            this.botaoExcluir.Image = ((System.Drawing.Image)(resources.GetObject("botaoExcluir.Image")));
            this.botaoExcluir.Location = new System.Drawing.Point(106, 0);
            this.botaoExcluir.Name = "botaoExcluir";
            this.botaoExcluir.Size = new System.Drawing.Size(53, 56);
            this.botaoExcluir.TabIndex = 18;
            this.botaoExcluir.UseVisualStyleBackColor = true;
            this.botaoExcluir.Click += new System.EventHandler(this.botaoExcluir_Click);
            // 
            // botaoPosterior
            // 
            this.botaoPosterior.Image = ((System.Drawing.Image)(resources.GetObject("botaoPosterior.Image")));
            this.botaoPosterior.Location = new System.Drawing.Point(53, 0);
            this.botaoPosterior.Name = "botaoPosterior";
            this.botaoPosterior.Size = new System.Drawing.Size(53, 56);
            this.botaoPosterior.TabIndex = 12;
            this.botaoPosterior.UseVisualStyleBackColor = true;
            this.botaoPosterior.Click += new System.EventHandler(this.botaoPosterior_Click);
            // 
            // botaoAnterior
            // 
            this.botaoAnterior.Image = ((System.Drawing.Image)(resources.GetObject("botaoAnterior.Image")));
            this.botaoAnterior.Location = new System.Drawing.Point(0, 0);
            this.botaoAnterior.Name = "botaoAnterior";
            this.botaoAnterior.Size = new System.Drawing.Size(53, 56);
            this.botaoAnterior.TabIndex = 11;
            this.botaoAnterior.UseVisualStyleBackColor = true;
            this.botaoAnterior.Click += new System.EventHandler(this.botaoAnterior_Click);
            // 
            // pnlMenuBotaoBotao
            // 
            this.pnlMenuBotaoBotao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlMenuBotaoBotao.Controls.Add(this.label1);
            this.pnlMenuBotaoBotao.Controls.Add(this.botaoImprimir);
            this.pnlMenuBotaoBotao.Controls.Add(this.label7);
            this.pnlMenuBotaoBotao.Controls.Add(this.label6);
            this.pnlMenuBotaoBotao.Controls.Add(this.label5);
            this.pnlMenuBotaoBotao.Controls.Add(this.botaoFechar);
            this.pnlMenuBotaoBotao.Controls.Add(this.botaoNovo);
            this.pnlMenuBotaoBotao.Controls.Add(this.botaoExcluir);
            this.pnlMenuBotaoBotao.Controls.Add(this.botaoPosterior);
            this.pnlMenuBotaoBotao.Controls.Add(this.botaoAnterior);
            this.pnlMenuBotaoBotao.Location = new System.Drawing.Point(426, 0);
            this.pnlMenuBotaoBotao.Name = "pnlMenuBotaoBotao";
            this.pnlMenuBotaoBotao.Size = new System.Drawing.Size(318, 83);
            this.pnlMenuBotaoBotao.TabIndex = 2;
            // 
            // pnlPesquisar
            // 
            this.pnlPesquisar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnlPesquisar.Controls.Add(this.groupBox1);
            this.pnlPesquisar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPesquisar.Location = new System.Drawing.Point(0, 83);
            this.pnlPesquisar.Name = "pnlPesquisar";
            this.pnlPesquisar.Size = new System.Drawing.Size(745, 48);
            this.pnlPesquisar.TabIndex = 7;
            // 
            // pnlMenuBotao
            // 
            this.pnlMenuBotao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlMenuBotao.Controls.Add(this.pnlMenuBotaoBotao);
            this.pnlMenuBotao.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenuBotao.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuBotao.Name = "pnlMenuBotao";
            this.pnlMenuBotao.Size = new System.Drawing.Size(745, 83);
            this.pnlMenuBotao.TabIndex = 6;
            // 
            // frmCadastroGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 450);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pnlDadosGerais);
            this.Controls.Add(this.pnlPesquisar);
            this.Controls.Add(this.pnlMenuBotao);
            this.Name = "frmCadastroGrupo";
            this.Text = "Cadastro de Grupo";
            ((System.ComponentModel.ISupportInitialize)(this.gridSubGrupo)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabSubGrupo.ResumeLayout(false);
            this.pnlDadosGerais.ResumeLayout(false);
            this.pnlDadosGerais.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlMenuBotaoBotao.ResumeLayout(false);
            this.pnlMenuBotaoBotao.PerformLayout();
            this.pnlPesquisar.ResumeLayout(false);
            this.pnlMenuBotao.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridSubGrupo;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabSubGrupo;
        private System.Windows.Forms.CheckBox checkNaoVender;
        private System.Windows.Forms.Button botaoFabricante;
        private System.Windows.Forms.Button botaoSubGrupo;
        private System.Windows.Forms.TextBox textNomeGrupo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel pnlDadosGerais;
        private System.Windows.Forms.ComboBox comboPesquisarPesquisa;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboPesquisarTipoFiltro;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botaoImprimir;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button botaoFechar;
        private System.Windows.Forms.Button botaoNovo;
        private System.Windows.Forms.Button botaoExcluir;
        private System.Windows.Forms.Button botaoPosterior;
        private System.Windows.Forms.Button botaoAnterior;
        private System.Windows.Forms.Panel pnlMenuBotaoBotao;
        private System.Windows.Forms.Panel pnlPesquisar;
        private System.Windows.Forms.Panel pnlMenuBotao;
    }
}