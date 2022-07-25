
namespace SisCom.Aplicacao.Formularios
{
    partial class frmComprasConsulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmComprasConsulta));
            this.pnlMenuBotao = new System.Windows.Forms.Panel();
            this.pnlMenuBotaoBotao = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.botaoFechar = new System.Windows.Forms.Button();
            this.botaoNovo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlDadosGerais = new System.Windows.Forms.Panel();
            this.botaoLimparFiltros = new System.Windows.Forms.Button();
            this.botaoAplicarFiltros = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.comboFiltro_Modelo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboFiltro_CFOP = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboFiltro_Estado = new System.Windows.Forms.ComboBox();
            this.dateFiltro_DataFinal = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dateFiltro_DataInicial = new System.Windows.Forms.DateTimePicker();
            this.label69 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.comboFiltro_Empresa = new System.Windows.Forms.ComboBox();
            this.comboFiltro_Fornecedor = new System.Windows.Forms.ComboBox();
            this.comboFiltroTipoData = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textFiltro_NotaFiscal = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textFiltro_ChaveAcesso = new System.Windows.Forms.TextBox();
            this.gridComprasConsulta = new System.Windows.Forms.DataGridView();
            this.pnlMenuBotao.SuspendLayout();
            this.pnlMenuBotaoBotao.SuspendLayout();
            this.pnlDadosGerais.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridComprasConsulta)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMenuBotao
            // 
            this.pnlMenuBotao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlMenuBotao.Controls.Add(this.pnlMenuBotaoBotao);
            this.pnlMenuBotao.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenuBotao.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuBotao.Name = "pnlMenuBotao";
            this.pnlMenuBotao.Size = new System.Drawing.Size(866, 83);
            this.pnlMenuBotao.TabIndex = 5;
            // 
            // pnlMenuBotaoBotao
            // 
            this.pnlMenuBotaoBotao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlMenuBotaoBotao.Controls.Add(this.label7);
            this.pnlMenuBotaoBotao.Controls.Add(this.label6);
            this.pnlMenuBotaoBotao.Controls.Add(this.botaoFechar);
            this.pnlMenuBotaoBotao.Controls.Add(this.botaoNovo);
            this.pnlMenuBotaoBotao.Location = new System.Drawing.Point(759, 0);
            this.pnlMenuBotaoBotao.Name = "pnlMenuBotaoBotao";
            this.pnlMenuBotaoBotao.Size = new System.Drawing.Size(106, 83);
            this.pnlMenuBotaoBotao.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(62, 56);
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
            this.label6.Location = new System.Drawing.Point(12, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 28;
            this.label6.Text = "Novo";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // botaoFechar
            // 
            this.botaoFechar.Image = ((System.Drawing.Image)(resources.GetObject("botaoFechar.Image")));
            this.botaoFechar.Location = new System.Drawing.Point(53, 0);
            this.botaoFechar.Name = "botaoFechar";
            this.botaoFechar.Size = new System.Drawing.Size(53, 56);
            this.botaoFechar.TabIndex = 20;
            this.botaoFechar.UseVisualStyleBackColor = true;
            this.botaoFechar.Click += new System.EventHandler(this.botaoFechar_Click);
            // 
            // botaoNovo
            // 
            this.botaoNovo.Image = ((System.Drawing.Image)(resources.GetObject("botaoNovo.Image")));
            this.botaoNovo.Location = new System.Drawing.Point(0, 0);
            this.botaoNovo.Name = "botaoNovo";
            this.botaoNovo.Size = new System.Drawing.Size(53, 56);
            this.botaoNovo.TabIndex = 19;
            this.botaoNovo.UseVisualStyleBackColor = true;
            this.botaoNovo.Click += new System.EventHandler(this.botaoNovo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(0, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(672, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "Utilize os filtros abaixo para localizar um registro específico ou uma lista, em " +
    "seguida clique em Aplicar Filtros:";
            // 
            // pnlDadosGerais
            // 
            this.pnlDadosGerais.BackColor = System.Drawing.Color.Silver;
            this.pnlDadosGerais.Controls.Add(this.botaoLimparFiltros);
            this.pnlDadosGerais.Controls.Add(this.botaoAplicarFiltros);
            this.pnlDadosGerais.Controls.Add(this.label8);
            this.pnlDadosGerais.Controls.Add(this.comboFiltro_Modelo);
            this.pnlDadosGerais.Controls.Add(this.label5);
            this.pnlDadosGerais.Controls.Add(this.comboFiltro_CFOP);
            this.pnlDadosGerais.Controls.Add(this.label4);
            this.pnlDadosGerais.Controls.Add(this.comboFiltro_Estado);
            this.pnlDadosGerais.Controls.Add(this.dateFiltro_DataFinal);
            this.pnlDadosGerais.Controls.Add(this.label3);
            this.pnlDadosGerais.Controls.Add(this.dateFiltro_DataInicial);
            this.pnlDadosGerais.Controls.Add(this.label69);
            this.pnlDadosGerais.Controls.Add(this.label17);
            this.pnlDadosGerais.Controls.Add(this.label15);
            this.pnlDadosGerais.Controls.Add(this.label14);
            this.pnlDadosGerais.Controls.Add(this.comboFiltro_Empresa);
            this.pnlDadosGerais.Controls.Add(this.comboFiltro_Fornecedor);
            this.pnlDadosGerais.Controls.Add(this.comboFiltroTipoData);
            this.pnlDadosGerais.Controls.Add(this.label12);
            this.pnlDadosGerais.Controls.Add(this.textFiltro_NotaFiscal);
            this.pnlDadosGerais.Controls.Add(this.label11);
            this.pnlDadosGerais.Controls.Add(this.textFiltro_ChaveAcesso);
            this.pnlDadosGerais.Location = new System.Drawing.Point(0, 102);
            this.pnlDadosGerais.Name = "pnlDadosGerais";
            this.pnlDadosGerais.Size = new System.Drawing.Size(865, 102);
            this.pnlDadosGerais.TabIndex = 8;
            // 
            // botaoLimparFiltros
            // 
            this.botaoLimparFiltros.Image = ((System.Drawing.Image)(resources.GetObject("botaoLimparFiltros.Image")));
            this.botaoLimparFiltros.Location = new System.Drawing.Point(760, 53);
            this.botaoLimparFiltros.Name = "botaoLimparFiltros";
            this.botaoLimparFiltros.Size = new System.Drawing.Size(100, 45);
            this.botaoLimparFiltros.TabIndex = 97;
            this.botaoLimparFiltros.UseVisualStyleBackColor = true;
            this.botaoLimparFiltros.Click += new System.EventHandler(this.botaoLimparFiltros_Click);
            // 
            // botaoAplicarFiltros
            // 
            this.botaoAplicarFiltros.Image = ((System.Drawing.Image)(resources.GetObject("botaoAplicarFiltros.Image")));
            this.botaoAplicarFiltros.Location = new System.Drawing.Point(760, 9);
            this.botaoAplicarFiltros.Name = "botaoAplicarFiltros";
            this.botaoAplicarFiltros.Size = new System.Drawing.Size(100, 45);
            this.botaoAplicarFiltros.TabIndex = 96;
            this.botaoAplicarFiltros.UseVisualStyleBackColor = true;
            this.botaoAplicarFiltros.Click += new System.EventHandler(this.botaoAplicarFiltros_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(408, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 15);
            this.label8.TabIndex = 95;
            this.label8.Text = "Modelo";
            // 
            // comboFiltro_Modelo
            // 
            this.comboFiltro_Modelo.DropDownWidth = 250;
            this.comboFiltro_Modelo.FormattingEnabled = true;
            this.comboFiltro_Modelo.Location = new System.Drawing.Point(408, 68);
            this.comboFiltro_Modelo.Name = "comboFiltro_Modelo";
            this.comboFiltro_Modelo.Size = new System.Drawing.Size(71, 23);
            this.comboFiltro_Modelo.TabIndex = 94;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(286, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 15);
            this.label5.TabIndex = 93;
            this.label5.Text = "CFOP";
            // 
            // comboFiltro_CFOP
            // 
            this.comboFiltro_CFOP.FormattingEnabled = true;
            this.comboFiltro_CFOP.Location = new System.Drawing.Point(286, 68);
            this.comboFiltro_CFOP.Name = "comboFiltro_CFOP";
            this.comboFiltro_CFOP.Size = new System.Drawing.Size(60, 23);
            this.comboFiltro_CFOP.TabIndex = 92;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(352, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 15);
            this.label4.TabIndex = 91;
            this.label4.Text = "U.F.";
            // 
            // comboFiltro_Estado
            // 
            this.comboFiltro_Estado.FormattingEnabled = true;
            this.comboFiltro_Estado.Location = new System.Drawing.Point(352, 68);
            this.comboFiltro_Estado.Name = "comboFiltro_Estado";
            this.comboFiltro_Estado.Size = new System.Drawing.Size(50, 23);
            this.comboFiltro_Estado.TabIndex = 90;
            // 
            // dateFiltro_DataFinal
            // 
            this.dateFiltro_DataFinal.Enabled = false;
            this.dateFiltro_DataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFiltro_DataFinal.Location = new System.Drawing.Point(191, 24);
            this.dateFiltro_DataFinal.Name = "dateFiltro_DataFinal";
            this.dateFiltro_DataFinal.Size = new System.Drawing.Size(89, 23);
            this.dateFiltro_DataFinal.TabIndex = 89;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(191, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 88;
            this.label3.Text = "Data Final";
            // 
            // dateFiltro_DataInicial
            // 
            this.dateFiltro_DataInicial.Enabled = false;
            this.dateFiltro_DataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFiltro_DataInicial.Location = new System.Drawing.Point(96, 24);
            this.dateFiltro_DataInicial.Name = "dateFiltro_DataInicial";
            this.dateFiltro_DataInicial.Size = new System.Drawing.Size(89, 23);
            this.dateFiltro_DataInicial.TabIndex = 87;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label69.Location = new System.Drawing.Point(96, 9);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(68, 15);
            this.label69.TabIndex = 86;
            this.label69.Text = "Data Inicial";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label17.Location = new System.Drawing.Point(10, 53);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(54, 15);
            this.label17.TabIndex = 18;
            this.label17.Text = "Empresa";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(392, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 15);
            this.label15.TabIndex = 13;
            this.label15.Text = "Fornecedor";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(10, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 15);
            this.label14.TabIndex = 12;
            this.label14.Text = "Tipo Data";
            // 
            // comboFiltro_Empresa
            // 
            this.comboFiltro_Empresa.FormattingEnabled = true;
            this.comboFiltro_Empresa.Location = new System.Drawing.Point(10, 68);
            this.comboFiltro_Empresa.Name = "comboFiltro_Empresa";
            this.comboFiltro_Empresa.Size = new System.Drawing.Size(270, 23);
            this.comboFiltro_Empresa.TabIndex = 6;
            // 
            // comboFiltro_Fornecedor
            // 
            this.comboFiltro_Fornecedor.FormattingEnabled = true;
            this.comboFiltro_Fornecedor.Location = new System.Drawing.Point(392, 24);
            this.comboFiltro_Fornecedor.Name = "comboFiltro_Fornecedor";
            this.comboFiltro_Fornecedor.Size = new System.Drawing.Size(358, 23);
            this.comboFiltro_Fornecedor.TabIndex = 7;
            // 
            // comboFiltroTipoData
            // 
            this.comboFiltroTipoData.FormattingEnabled = true;
            this.comboFiltroTipoData.Location = new System.Drawing.Point(10, 24);
            this.comboFiltroTipoData.Name = "comboFiltroTipoData";
            this.comboFiltroTipoData.Size = new System.Drawing.Size(80, 23);
            this.comboFiltroTipoData.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(286, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 15);
            this.label12.TabIndex = 5;
            this.label12.Text = "Nota Fiscal";
            // 
            // textFiltro_NotaFiscal
            // 
            this.textFiltro_NotaFiscal.Location = new System.Drawing.Point(286, 24);
            this.textFiltro_NotaFiscal.Name = "textFiltro_NotaFiscal";
            this.textFiltro_NotaFiscal.Size = new System.Drawing.Size(100, 23);
            this.textFiltro_NotaFiscal.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(485, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 15);
            this.label11.TabIndex = 3;
            this.label11.Text = "Chave de Acesso";
            // 
            // textFiltro_ChaveAcesso
            // 
            this.textFiltro_ChaveAcesso.Location = new System.Drawing.Point(485, 68);
            this.textFiltro_ChaveAcesso.Name = "textFiltro_ChaveAcesso";
            this.textFiltro_ChaveAcesso.Size = new System.Drawing.Size(265, 23);
            this.textFiltro_ChaveAcesso.TabIndex = 2;
            // 
            // gridComprasConsulta
            // 
            this.gridComprasConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridComprasConsulta.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridComprasConsulta.Location = new System.Drawing.Point(0, 204);
            this.gridComprasConsulta.Name = "gridComprasConsulta";
            this.gridComprasConsulta.RowTemplate.Height = 25;
            this.gridComprasConsulta.Size = new System.Drawing.Size(866, 422);
            this.gridComprasConsulta.TabIndex = 9;
            // 
            // frmComprasConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 626);
            this.Controls.Add(this.gridComprasConsulta);
            this.Controls.Add(this.pnlDadosGerais);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnlMenuBotao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmComprasConsulta";
            this.Text = "Compras";
            this.Load += new System.EventHandler(this.frmComprasConsulta_Load);
            this.pnlMenuBotao.ResumeLayout(false);
            this.pnlMenuBotaoBotao.ResumeLayout(false);
            this.pnlMenuBotaoBotao.PerformLayout();
            this.pnlDadosGerais.ResumeLayout(false);
            this.pnlDadosGerais.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridComprasConsulta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenuBotao;
        private System.Windows.Forms.Panel pnlMenuBotaoBotao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button botaoFechar;
        private System.Windows.Forms.Button botaoNovo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlDadosGerais;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboFiltro_Empresa;
        private System.Windows.Forms.ComboBox comboFiltro_Fornecedor;
        private System.Windows.Forms.ComboBox comboFiltroTipoData;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textFiltro_NotaFiscal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textFiltro_ChaveAcesso;
        private System.Windows.Forms.DateTimePicker dateFiltro_DataInicial;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.DateTimePicker dateFiltro_DataFinal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboFiltro_Estado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboFiltro_Modelo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboFiltro_CFOP;
        private System.Windows.Forms.Button botaoLimparFiltros;
        private System.Windows.Forms.Button botaoAplicarFiltros;
        private System.Windows.Forms.DataGridView gridComprasConsulta;
    }
}