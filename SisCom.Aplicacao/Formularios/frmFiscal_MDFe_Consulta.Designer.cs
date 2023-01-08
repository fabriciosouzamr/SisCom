namespace SisCom.Aplicacao.Formularios
{
    partial class frmFiscal_MDFe_Consulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFiscal_MDFe_Consulta));
            this.botaoDesmarcarTodos = new System.Windows.Forms.Button();
            this.botaoMarcarTodos = new System.Windows.Forms.Button();
            this.botaoLimparFiltros = new System.Windows.Forms.Button();
            this.botaoAplicarFiltros = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.dateDataEmissaoFinal = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dateDataEmissaoInicial = new System.Windows.Forms.DateTimePicker();
            this.labelValidade = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlMenuBotao = new System.Windows.Forms.Panel();
            this.pnlMenuBotaoBotao = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.botaoCancelar = new System.Windows.Forms.Button();
            this.botaoEditar = new System.Windows.Forms.Button();
            this.label38 = new System.Windows.Forms.Label();
            this.botaoTransmitir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.botaoNovo = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.botaoFechar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelStatusServico = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.gridManifestoDocumentoEletronico = new System.Windows.Forms.DataGridView();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlMenuBotao.SuspendLayout();
            this.pnlMenuBotaoBotao.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridManifestoDocumentoEletronico)).BeginInit();
            this.SuspendLayout();
            // 
            // botaoDesmarcarTodos
            // 
            this.botaoDesmarcarTodos.Location = new System.Drawing.Point(107, 79);
            this.botaoDesmarcarTodos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.botaoDesmarcarTodos.Name = "botaoDesmarcarTodos";
            this.botaoDesmarcarTodos.Size = new System.Drawing.Size(118, 20);
            this.botaoDesmarcarTodos.TabIndex = 101;
            this.botaoDesmarcarTodos.Text = "Desmarcar Todos";
            this.botaoDesmarcarTodos.UseVisualStyleBackColor = true;
            this.botaoDesmarcarTodos.Click += new System.EventHandler(this.botaoDesmarcarTodos_Click);
            // 
            // botaoMarcarTodos
            // 
            this.botaoMarcarTodos.Location = new System.Drawing.Point(5, 79);
            this.botaoMarcarTodos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.botaoMarcarTodos.Name = "botaoMarcarTodos";
            this.botaoMarcarTodos.Size = new System.Drawing.Size(96, 20);
            this.botaoMarcarTodos.TabIndex = 100;
            this.botaoMarcarTodos.Text = "Marcar Todos";
            this.botaoMarcarTodos.UseVisualStyleBackColor = true;
            this.botaoMarcarTodos.Click += new System.EventHandler(this.botaoMarcarTodos_Click);
            // 
            // botaoLimparFiltros
            // 
            this.botaoLimparFiltros.Image = ((System.Drawing.Image)(resources.GetObject("botaoLimparFiltros.Image")));
            this.botaoLimparFiltros.Location = new System.Drawing.Point(1205, 54);
            this.botaoLimparFiltros.Name = "botaoLimparFiltros";
            this.botaoLimparFiltros.Size = new System.Drawing.Size(100, 45);
            this.botaoLimparFiltros.TabIndex = 99;
            this.botaoLimparFiltros.TabStop = false;
            this.botaoLimparFiltros.UseVisualStyleBackColor = true;
            this.botaoLimparFiltros.Click += new System.EventHandler(this.botaoLimparFiltros_Click);
            // 
            // botaoAplicarFiltros
            // 
            this.botaoAplicarFiltros.Image = ((System.Drawing.Image)(resources.GetObject("botaoAplicarFiltros.Image")));
            this.botaoAplicarFiltros.Location = new System.Drawing.Point(1205, 5);
            this.botaoAplicarFiltros.Name = "botaoAplicarFiltros";
            this.botaoAplicarFiltros.Size = new System.Drawing.Size(100, 45);
            this.botaoAplicarFiltros.TabIndex = 98;
            this.botaoAplicarFiltros.TabStop = false;
            this.botaoAplicarFiltros.UseVisualStyleBackColor = true;
            this.botaoAplicarFiltros.Click += new System.EventHandler(this.botaoAplicarFiltros_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(88, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 15);
            this.label10.TabIndex = 5;
            this.label10.Text = "a";
            // 
            // dateDataEmissaoFinal
            // 
            this.dateDataEmissaoFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDataEmissaoFinal.Location = new System.Drawing.Point(103, 22);
            this.dateDataEmissaoFinal.Name = "dateDataEmissaoFinal";
            this.dateDataEmissaoFinal.Size = new System.Drawing.Size(81, 23);
            this.dateDataEmissaoFinal.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 15);
            this.label9.TabIndex = 3;
            this.label9.Text = "Período de Emissão";
            // 
            // dateDataEmissaoInicial
            // 
            this.dateDataEmissaoInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDataEmissaoInicial.Location = new System.Drawing.Point(5, 22);
            this.dateDataEmissaoInicial.Name = "dateDataEmissaoInicial";
            this.dateDataEmissaoInicial.Size = new System.Drawing.Size(81, 23);
            this.dateDataEmissaoInicial.TabIndex = 2;
            // 
            // labelValidade
            // 
            this.labelValidade.AutoSize = true;
            this.labelValidade.Location = new System.Drawing.Point(355, 93);
            this.labelValidade.Name = "labelValidade";
            this.labelValidade.Size = new System.Drawing.Size(132, 15);
            this.labelValidade.TabIndex = 109;
            this.labelValidade.Tag = "Validade do Certificado:";
            this.labelValidade.Text = "Validade do Certificado:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Controls.Add(this.botaoDesmarcarTodos);
            this.panel3.Controls.Add(this.botaoMarcarTodos);
            this.panel3.Controls.Add(this.botaoLimparFiltros);
            this.panel3.Controls.Add(this.botaoAplicarFiltros);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.dateDataEmissaoFinal);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.dateDataEmissaoInicial);
            this.panel3.Location = new System.Drawing.Point(0, 112);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1314, 104);
            this.panel3.TabIndex = 107;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(0, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 26);
            this.panel1.TabIndex = 104;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(5, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(265, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Produção - NORMAL - Layout NF-e: 4.00";
            // 
            // pnlMenuBotao
            // 
            this.pnlMenuBotao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlMenuBotao.Controls.Add(this.pnlMenuBotaoBotao);
            this.pnlMenuBotao.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenuBotao.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuBotao.Name = "pnlMenuBotao";
            this.pnlMenuBotao.Size = new System.Drawing.Size(1319, 83);
            this.pnlMenuBotao.TabIndex = 103;
            // 
            // pnlMenuBotaoBotao
            // 
            this.pnlMenuBotaoBotao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlMenuBotaoBotao.Controls.Add(this.label2);
            this.pnlMenuBotaoBotao.Controls.Add(this.label1);
            this.pnlMenuBotaoBotao.Controls.Add(this.botaoCancelar);
            this.pnlMenuBotaoBotao.Controls.Add(this.botaoEditar);
            this.pnlMenuBotaoBotao.Controls.Add(this.label38);
            this.pnlMenuBotaoBotao.Controls.Add(this.botaoTransmitir);
            this.pnlMenuBotaoBotao.Controls.Add(this.label3);
            this.pnlMenuBotaoBotao.Controls.Add(this.botaoNovo);
            this.pnlMenuBotaoBotao.Controls.Add(this.label7);
            this.pnlMenuBotaoBotao.Controls.Add(this.botaoFechar);
            this.pnlMenuBotaoBotao.Location = new System.Drawing.Point(656, 0);
            this.pnlMenuBotaoBotao.Name = "pnlMenuBotaoBotao";
            this.pnlMenuBotaoBotao.Size = new System.Drawing.Size(649, 83);
            this.pnlMenuBotaoBotao.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(380, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 24);
            this.label2.TabIndex = 71;
            this.label2.Text = "Alterar\r\nNF-e";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(489, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 12);
            this.label1.TabIndex = 70;
            this.label1.Text = "Cancelar";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // botaoCancelar
            // 
            this.botaoCancelar.Image = ((System.Drawing.Image)(resources.GetObject("botaoCancelar.Image")));
            this.botaoCancelar.Location = new System.Drawing.Point(484, 1);
            this.botaoCancelar.Name = "botaoCancelar";
            this.botaoCancelar.Size = new System.Drawing.Size(53, 56);
            this.botaoCancelar.TabIndex = 69;
            this.botaoCancelar.UseVisualStyleBackColor = true;
            this.botaoCancelar.Click += new System.EventHandler(this.botaoCancelar_Click);
            // 
            // botaoEditar
            // 
            this.botaoEditar.Image = ((System.Drawing.Image)(resources.GetObject("botaoEditar.Image")));
            this.botaoEditar.Location = new System.Drawing.Point(370, 1);
            this.botaoEditar.Name = "botaoEditar";
            this.botaoEditar.Size = new System.Drawing.Size(53, 56);
            this.botaoEditar.TabIndex = 68;
            this.botaoEditar.UseVisualStyleBackColor = true;
            this.botaoEditar.Click += new System.EventHandler(this.botaoEditar_Click);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label38.Location = new System.Drawing.Point(430, 57);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(46, 12);
            this.label38.TabIndex = 67;
            this.label38.Text = "Transmitir";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // botaoTransmitir
            // 
            this.botaoTransmitir.Image = ((System.Drawing.Image)(resources.GetObject("botaoTransmitir.Image")));
            this.botaoTransmitir.Location = new System.Drawing.Point(427, 1);
            this.botaoTransmitir.Name = "botaoTransmitir";
            this.botaoTransmitir.Size = new System.Drawing.Size(53, 56);
            this.botaoTransmitir.TabIndex = 66;
            this.botaoTransmitir.UseVisualStyleBackColor = true;
            this.botaoTransmitir.Click += new System.EventHandler(this.botaoTransmitir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(547, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 24);
            this.label3.TabIndex = 65;
            this.label3.Text = "Novo\r\n(ALT+N)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // botaoNovo
            // 
            this.botaoNovo.Image = ((System.Drawing.Image)(resources.GetObject("botaoNovo.Image")));
            this.botaoNovo.Location = new System.Drawing.Point(541, 1);
            this.botaoNovo.Name = "botaoNovo";
            this.botaoNovo.Size = new System.Drawing.Size(53, 56);
            this.botaoNovo.TabIndex = 64;
            this.botaoNovo.UseVisualStyleBackColor = true;
            this.botaoNovo.Click += new System.EventHandler(this.botaoNovo_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(607, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 12);
            this.label7.TabIndex = 29;
            this.label7.Text = "Fechar";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // botaoFechar
            // 
            this.botaoFechar.Image = ((System.Drawing.Image)(resources.GetObject("botaoFechar.Image")));
            this.botaoFechar.Location = new System.Drawing.Point(598, 0);
            this.botaoFechar.Name = "botaoFechar";
            this.botaoFechar.Size = new System.Drawing.Size(53, 56);
            this.botaoFechar.TabIndex = 20;
            this.botaoFechar.UseVisualStyleBackColor = true;
            this.botaoFechar.Click += new System.EventHandler(this.botaoFechar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panelStatusServico);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(1121, 87);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(184, 26);
            this.panel2.TabIndex = 105;
            // 
            // panelStatusServico
            // 
            this.panelStatusServico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panelStatusServico.Location = new System.Drawing.Point(133, 5);
            this.panelStatusServico.Name = "panelStatusServico";
            this.panelStatusServico.Size = new System.Drawing.Size(15, 15);
            this.panelStatusServico.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(5, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Status do Serviço:";
            // 
            // gridManifestoDocumentoEletronico
            // 
            this.gridManifestoDocumentoEletronico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridManifestoDocumentoEletronico.Location = new System.Drawing.Point(0, 222);
            this.gridManifestoDocumentoEletronico.Name = "gridManifestoDocumentoEletronico";
            this.gridManifestoDocumentoEletronico.RowHeadersWidth = 51;
            this.gridManifestoDocumentoEletronico.RowTemplate.Height = 25;
            this.gridManifestoDocumentoEletronico.Size = new System.Drawing.Size(1314, 343);
            this.gridManifestoDocumentoEletronico.TabIndex = 106;
            // 
            // frmFiscal_MDFe_Consulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 570);
            this.Controls.Add(this.labelValidade);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlMenuBotao);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.gridManifestoDocumentoEletronico);
            this.Name = "frmFiscal_MDFe_Consulta";
            this.Text = "Nota Fiscal - MDF-e - Consultar";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlMenuBotao.ResumeLayout(false);
            this.pnlMenuBotaoBotao.ResumeLayout(false);
            this.pnlMenuBotaoBotao.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridManifestoDocumentoEletronico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button botaoDesmarcarTodos;
        private System.Windows.Forms.Button botaoMarcarTodos;
        private System.Windows.Forms.Button botaoLimparFiltros;
        private System.Windows.Forms.Button botaoAplicarFiltros;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateDataEmissaoFinal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateDataEmissaoInicial;
        private System.Windows.Forms.Label labelValidade;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlMenuBotao;
        private System.Windows.Forms.Panel pnlMenuBotaoBotao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button botaoFechar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelStatusServico;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView gridManifestoDocumentoEletronico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botaoCancelar;
        private System.Windows.Forms.Button botaoEditar;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Button botaoTransmitir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button botaoNovo;
    }
}