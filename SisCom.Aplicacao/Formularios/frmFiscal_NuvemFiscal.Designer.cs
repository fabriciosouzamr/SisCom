
namespace SisCom.Aplicacao.Formularios
{
    partial class frmFiscal_NuvemFiscal
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
            this.gridNotaFiscal = new System.Windows.Forms.DataGridView();
            this.label14 = new System.Windows.Forms.Label();
            this.comboTipoManifestacao = new System.Windows.Forms.ComboBox();
            this.datePeriodoInicial = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboEmpresa = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboTipoData = new System.Windows.Forms.ComboBox();
            this.textChaveNFe = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.datePeriodoFinal = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.textNFe = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.botaoFiltrarNotas = new System.Windows.Forms.Button();
            this.botaoConsultarNotas = new System.Windows.Forms.Button();
            this.botaoManifestar = new System.Windows.Forms.Button();
            this.botaoDownload = new System.Windows.Forms.Button();
            this.botaoImprimirDanfe = new System.Windows.Forms.Button();
            this.comboTipoNSU = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboTipoTLS = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridNotaFiscal)).BeginInit();
            this.SuspendLayout();
            // 
            // gridNotaFiscal
            // 
            this.gridNotaFiscal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridNotaFiscal.Location = new System.Drawing.Point(12, 101);
            this.gridNotaFiscal.Name = "gridNotaFiscal";
            this.gridNotaFiscal.RowTemplate.Height = 25;
            this.gridNotaFiscal.Size = new System.Drawing.Size(1034, 293);
            this.gridNotaFiscal.TabIndex = 5;
            this.gridNotaFiscal.TabStop = false;
            this.gridNotaFiscal.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridNotaFiscal_CellClick);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(20, 30);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(128, 15);
            this.label14.TabIndex = 105;
            this.label14.Text = "Tipo de Manifestação:";
            // 
            // comboTipoManifestacao
            // 
            this.comboTipoManifestacao.FormattingEnabled = true;
            this.comboTipoManifestacao.Location = new System.Drawing.Point(150, 26);
            this.comboTipoManifestacao.Name = "comboTipoManifestacao";
            this.comboTipoManifestacao.Size = new System.Drawing.Size(200, 23);
            this.comboTipoManifestacao.TabIndex = 1;
            // 
            // datePeriodoInicial
            // 
            this.datePeriodoInicial.Enabled = false;
            this.datePeriodoInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePeriodoInicial.Location = new System.Drawing.Point(629, 26);
            this.datePeriodoInicial.Name = "datePeriodoInicial";
            this.datePeriodoInicial.Size = new System.Drawing.Size(81, 23);
            this.datePeriodoInicial.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(599, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 15);
            this.label8.TabIndex = 100;
            this.label8.Text = "De:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(91, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 107;
            this.label1.Text = "Empresa:";
            // 
            // comboEmpresa
            // 
            this.comboEmpresa.FormattingEnabled = true;
            this.comboEmpresa.Location = new System.Drawing.Point(150, 55);
            this.comboEmpresa.Name = "comboEmpresa";
            this.comboEmpresa.Size = new System.Drawing.Size(200, 23);
            this.comboEmpresa.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(360, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 109;
            this.label2.Text = "Tipo Data";
            // 
            // comboTipoData
            // 
            this.comboTipoData.FormattingEnabled = true;
            this.comboTipoData.Location = new System.Drawing.Point(429, 26);
            this.comboTipoData.Name = "comboTipoData";
            this.comboTipoData.Size = new System.Drawing.Size(164, 23);
            this.comboTipoData.TabIndex = 2;
            // 
            // textChaveNFe
            // 
            this.textChaveNFe.Location = new System.Drawing.Point(429, 55);
            this.textChaveNFe.Name = "textChaveNFe";
            this.textChaveNFe.Size = new System.Drawing.Size(281, 23);
            this.textChaveNFe.TabIndex = 6;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label27.Location = new System.Drawing.Point(360, 59);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(69, 15);
            this.label27.TabIndex = 123;
            this.label27.Text = "Chave NFe:";
            // 
            // datePeriodoFinal
            // 
            this.datePeriodoFinal.Enabled = false;
            this.datePeriodoFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePeriodoFinal.Location = new System.Drawing.Point(747, 26);
            this.datePeriodoFinal.Name = "datePeriodoFinal";
            this.datePeriodoFinal.Size = new System.Drawing.Size(81, 23);
            this.datePeriodoFinal.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(716, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 15);
            this.label3.TabIndex = 125;
            this.label3.Text = "até";
            // 
            // textNFe
            // 
            this.textNFe.Location = new System.Drawing.Point(747, 55);
            this.textNFe.Name = "textNFe";
            this.textNFe.Size = new System.Drawing.Size(81, 23);
            this.textNFe.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(716, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 15);
            this.label9.TabIndex = 127;
            this.label9.Text = "NFe";
            // 
            // botaoFiltrarNotas
            // 
            this.botaoFiltrarNotas.Location = new System.Drawing.Point(834, 26);
            this.botaoFiltrarNotas.Name = "botaoFiltrarNotas";
            this.botaoFiltrarNotas.Size = new System.Drawing.Size(103, 52);
            this.botaoFiltrarNotas.TabIndex = 129;
            this.botaoFiltrarNotas.TabStop = false;
            this.botaoFiltrarNotas.Text = "Filtrar Notas";
            this.botaoFiltrarNotas.UseVisualStyleBackColor = true;
            // 
            // botaoConsultarNotas
            // 
            this.botaoConsultarNotas.Location = new System.Drawing.Point(943, 26);
            this.botaoConsultarNotas.Name = "botaoConsultarNotas";
            this.botaoConsultarNotas.Size = new System.Drawing.Size(103, 52);
            this.botaoConsultarNotas.TabIndex = 130;
            this.botaoConsultarNotas.TabStop = false;
            this.botaoConsultarNotas.Text = "Consultar Notas";
            this.botaoConsultarNotas.UseVisualStyleBackColor = true;
            this.botaoConsultarNotas.Click += new System.EventHandler(this.botaoConsultarNotas_Click);
            // 
            // botaoManifestar
            // 
            this.botaoManifestar.Location = new System.Drawing.Point(267, 400);
            this.botaoManifestar.Name = "botaoManifestar";
            this.botaoManifestar.Size = new System.Drawing.Size(151, 40);
            this.botaoManifestar.TabIndex = 131;
            this.botaoManifestar.TabStop = false;
            this.botaoManifestar.Text = "Manifestar";
            this.botaoManifestar.UseVisualStyleBackColor = true;
            // 
            // botaoDownload
            // 
            this.botaoDownload.Location = new System.Drawing.Point(472, 400);
            this.botaoDownload.Name = "botaoDownload";
            this.botaoDownload.Size = new System.Drawing.Size(151, 40);
            this.botaoDownload.TabIndex = 132;
            this.botaoDownload.TabStop = false;
            this.botaoDownload.Text = "Download";
            this.botaoDownload.UseVisualStyleBackColor = true;
            // 
            // botaoImprimirDanfe
            // 
            this.botaoImprimirDanfe.Location = new System.Drawing.Point(677, 400);
            this.botaoImprimirDanfe.Name = "botaoImprimirDanfe";
            this.botaoImprimirDanfe.Size = new System.Drawing.Size(151, 40);
            this.botaoImprimirDanfe.TabIndex = 133;
            this.botaoImprimirDanfe.TabStop = false;
            this.botaoImprimirDanfe.Text = "Imprimir Danfe";
            this.botaoImprimirDanfe.UseVisualStyleBackColor = true;
            // 
            // comboTipoNSU
            // 
            this.comboTipoNSU.FormattingEnabled = true;
            this.comboTipoNSU.Location = new System.Drawing.Point(747, 3);
            this.comboTipoNSU.Name = "comboTipoNSU";
            this.comboTipoNSU.Size = new System.Drawing.Size(190, 23);
            this.comboTipoNSU.TabIndex = 135;
            this.comboTipoNSU.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(175, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(708, 15);
            this.label4.TabIndex = 136;
            this.label4.Text = "Último NSU: 0 | Última Consulta: | Ambiente: Produção | Vencimento Certificado: *" +
    " ATENÇÃO CERTIFICADO NÃO INFORMADO *";
            // 
            // comboTipoTLS
            // 
            this.comboTipoTLS.FormattingEnabled = true;
            this.comboTipoTLS.Location = new System.Drawing.Point(943, 3);
            this.comboTipoTLS.Name = "comboTipoTLS";
            this.comboTipoTLS.Size = new System.Drawing.Size(103, 23);
            this.comboTipoTLS.TabIndex = 137;
            this.comboTipoTLS.TabStop = false;
            // 
            // frmFiscal_NuvemFiscal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 447);
            this.Controls.Add(this.comboTipoTLS);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboTipoNSU);
            this.Controls.Add(this.botaoImprimirDanfe);
            this.Controls.Add(this.botaoDownload);
            this.Controls.Add(this.botaoManifestar);
            this.Controls.Add(this.botaoConsultarNotas);
            this.Controls.Add(this.botaoFiltrarNotas);
            this.Controls.Add(this.textNFe);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.datePeriodoFinal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textChaveNFe);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboTipoData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboEmpresa);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.comboTipoManifestacao);
            this.Controls.Add(this.datePeriodoInicial);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.gridNotaFiscal);
            this.MaximizeBox = false;
            this.Name = "frmFiscal_NuvemFiscal";
            this.Text = "Nuvem Fiscal - Consulte as Notas emitidas para sua Empresa";
            ((System.ComponentModel.ISupportInitialize)(this.gridNotaFiscal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridNotaFiscal;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboTipoManifestacao;
        private System.Windows.Forms.DateTimePicker datePeriodoInicial;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboEmpresa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboTipoData;
        private System.Windows.Forms.TextBox textChaveNFe;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.DateTimePicker datePeriodoFinal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textNFe;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button botaoFiltrarNotas;
        private System.Windows.Forms.Button botaoConsultarNotas;
        private System.Windows.Forms.Button botaoManifestar;
        private System.Windows.Forms.Button botaoDownload;
        private System.Windows.Forms.Button botaoImprimirDanfe;
        private System.Windows.Forms.ComboBox comboTipoNSU;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboTipoTLS;
    }
}