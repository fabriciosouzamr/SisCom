namespace SisCom.Aplicacao.Formularios
{
    partial class frmVendasConsulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVendasConsulta));
            botaoLimparFiltros = new System.Windows.Forms.Button();
            botaoAplicarFiltros = new System.Windows.Forms.Button();
            label5 = new System.Windows.Forms.Label();
            comboFiltro_Vendedor = new System.Windows.Forms.ComboBox();
            pnlDadosGerais = new System.Windows.Forms.Panel();
            label4 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            textFiltro_NFe = new System.Windows.Forms.TextBox();
            textFiltro_NFCe = new System.Windows.Forms.TextBox();
            dateFiltro_DataFinal = new System.Windows.Forms.DateTimePicker();
            label3 = new System.Windows.Forms.Label();
            dateFiltro_DataInicial = new System.Windows.Forms.DateTimePicker();
            label69 = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            comboFiltro_Empresa = new System.Windows.Forms.ComboBox();
            comboFiltro_Cliente = new System.Windows.Forms.ComboBox();
            label12 = new System.Windows.Forms.Label();
            textFiltro_Pedido = new System.Windows.Forms.TextBox();
            pnlMenuBotao = new System.Windows.Forms.Panel();
            pnlMenuBotaoBotao = new System.Windows.Forms.Panel();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            botaoFechar = new System.Windows.Forms.Button();
            botaoNovo = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            label20 = new System.Windows.Forms.Label();
            label21 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            gridVenda = new System.Windows.Forms.DataGridView();
            uscTipoEmissor1 = new uscTipoEmissor();
            pnlDadosGerais.SuspendLayout();
            pnlMenuBotao.SuspendLayout();
            pnlMenuBotaoBotao.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridVenda).BeginInit();
            SuspendLayout();
            // 
            // botaoLimparFiltros
            // 
            botaoLimparFiltros.Image = (System.Drawing.Image)resources.GetObject("botaoLimparFiltros.Image");
            botaoLimparFiltros.Location = new System.Drawing.Point(760, 53);
            botaoLimparFiltros.Name = "botaoLimparFiltros";
            botaoLimparFiltros.Size = new System.Drawing.Size(100, 45);
            botaoLimparFiltros.TabIndex = 97;
            botaoLimparFiltros.TabStop = false;
            botaoLimparFiltros.UseVisualStyleBackColor = true;
            botaoLimparFiltros.Click += botaoLimparFiltros_Click;
            // 
            // botaoAplicarFiltros
            // 
            botaoAplicarFiltros.Image = (System.Drawing.Image)resources.GetObject("botaoAplicarFiltros.Image");
            botaoAplicarFiltros.Location = new System.Drawing.Point(760, 9);
            botaoAplicarFiltros.Name = "botaoAplicarFiltros";
            botaoAplicarFiltros.Size = new System.Drawing.Size(100, 45);
            botaoAplicarFiltros.TabIndex = 96;
            botaoAplicarFiltros.TabStop = false;
            botaoAplicarFiltros.UseVisualStyleBackColor = true;
            botaoAplicarFiltros.Click += botaoAplicarFiltros_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(570, 53);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(61, 15);
            label5.TabIndex = 93;
            label5.Text = "Vendedor";
            // 
            // comboFiltro_Vendedor
            // 
            comboFiltro_Vendedor.FormattingEnabled = true;
            comboFiltro_Vendedor.Location = new System.Drawing.Point(570, 68);
            comboFiltro_Vendedor.Name = "comboFiltro_Vendedor";
            comboFiltro_Vendedor.Size = new System.Drawing.Size(184, 23);
            comboFiltro_Vendedor.TabIndex = 8;
            // 
            // pnlDadosGerais
            // 
            pnlDadosGerais.BackColor = System.Drawing.Color.Silver;
            pnlDadosGerais.Controls.Add(label4);
            pnlDadosGerais.Controls.Add(label1);
            pnlDadosGerais.Controls.Add(textFiltro_NFe);
            pnlDadosGerais.Controls.Add(textFiltro_NFCe);
            pnlDadosGerais.Controls.Add(botaoLimparFiltros);
            pnlDadosGerais.Controls.Add(botaoAplicarFiltros);
            pnlDadosGerais.Controls.Add(label5);
            pnlDadosGerais.Controls.Add(comboFiltro_Vendedor);
            pnlDadosGerais.Controls.Add(dateFiltro_DataFinal);
            pnlDadosGerais.Controls.Add(label3);
            pnlDadosGerais.Controls.Add(dateFiltro_DataInicial);
            pnlDadosGerais.Controls.Add(label69);
            pnlDadosGerais.Controls.Add(label17);
            pnlDadosGerais.Controls.Add(label15);
            pnlDadosGerais.Controls.Add(comboFiltro_Empresa);
            pnlDadosGerais.Controls.Add(comboFiltro_Cliente);
            pnlDadosGerais.Controls.Add(label12);
            pnlDadosGerais.Controls.Add(textFiltro_Pedido);
            pnlDadosGerais.Location = new System.Drawing.Point(0, 102);
            pnlDadosGerais.Name = "pnlDadosGerais";
            pnlDadosGerais.Size = new System.Drawing.Size(865, 102);
            pnlDadosGerais.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(420, 9);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(34, 15);
            label4.TabIndex = 102;
            label4.Text = "NF-e";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(312, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(41, 15);
            label1.TabIndex = 101;
            label1.Text = "NFC-e";
            // 
            // textFiltro_NFe
            // 
            textFiltro_NFe.Location = new System.Drawing.Point(420, 24);
            textFiltro_NFe.Name = "textFiltro_NFe";
            textFiltro_NFe.Size = new System.Drawing.Size(100, 23);
            textFiltro_NFe.TabIndex = 4;
            // 
            // textFiltro_NFCe
            // 
            textFiltro_NFCe.Location = new System.Drawing.Point(312, 24);
            textFiltro_NFCe.Name = "textFiltro_NFCe";
            textFiltro_NFCe.Size = new System.Drawing.Size(100, 23);
            textFiltro_NFCe.TabIndex = 3;
            // 
            // dateFiltro_DataFinal
            // 
            dateFiltro_DataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dateFiltro_DataFinal.Location = new System.Drawing.Point(107, 24);
            dateFiltro_DataFinal.Name = "dateFiltro_DataFinal";
            dateFiltro_DataFinal.Size = new System.Drawing.Size(89, 23);
            dateFiltro_DataFinal.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(107, 9);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(61, 15);
            label3.TabIndex = 88;
            label3.Text = "Data Final";
            // 
            // dateFiltro_DataInicial
            // 
            dateFiltro_DataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dateFiltro_DataInicial.Location = new System.Drawing.Point(10, 24);
            dateFiltro_DataInicial.Name = "dateFiltro_DataInicial";
            dateFiltro_DataInicial.Size = new System.Drawing.Size(89, 23);
            dateFiltro_DataInicial.TabIndex = 0;
            // 
            // label69
            // 
            label69.AutoSize = true;
            label69.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label69.Location = new System.Drawing.Point(10, 9);
            label69.Name = "label69";
            label69.Size = new System.Drawing.Size(68, 15);
            label69.TabIndex = 86;
            label69.Text = "Data Inicial";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label17.Location = new System.Drawing.Point(10, 53);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(54, 15);
            label17.TabIndex = 18;
            label17.Text = "Empresa";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label15.Location = new System.Drawing.Point(204, 53);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(46, 15);
            label15.TabIndex = 13;
            label15.Text = "Cliente";
            // 
            // comboFiltro_Empresa
            // 
            comboFiltro_Empresa.FormattingEnabled = true;
            comboFiltro_Empresa.Location = new System.Drawing.Point(10, 68);
            comboFiltro_Empresa.Name = "comboFiltro_Empresa";
            comboFiltro_Empresa.Size = new System.Drawing.Size(186, 23);
            comboFiltro_Empresa.TabIndex = 6;
            // 
            // comboFiltro_Cliente
            // 
            comboFiltro_Cliente.FormattingEnabled = true;
            comboFiltro_Cliente.Location = new System.Drawing.Point(204, 68);
            comboFiltro_Cliente.Name = "comboFiltro_Cliente";
            comboFiltro_Cliente.Size = new System.Drawing.Size(358, 23);
            comboFiltro_Cliente.TabIndex = 7;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label12.Location = new System.Drawing.Point(204, 9);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(45, 15);
            label12.TabIndex = 5;
            label12.Text = "Pedido";
            // 
            // textFiltro_Pedido
            // 
            textFiltro_Pedido.Location = new System.Drawing.Point(204, 24);
            textFiltro_Pedido.Name = "textFiltro_Pedido";
            textFiltro_Pedido.Size = new System.Drawing.Size(100, 23);
            textFiltro_Pedido.TabIndex = 2;
            // 
            // pnlMenuBotao
            // 
            pnlMenuBotao.BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
            pnlMenuBotao.Controls.Add(uscTipoEmissor1);
            pnlMenuBotao.Controls.Add(pnlMenuBotaoBotao);
            pnlMenuBotao.Dock = System.Windows.Forms.DockStyle.Top;
            pnlMenuBotao.Location = new System.Drawing.Point(0, 0);
            pnlMenuBotao.Name = "pnlMenuBotao";
            pnlMenuBotao.Size = new System.Drawing.Size(866, 83);
            pnlMenuBotao.TabIndex = 10;
            // 
            // pnlMenuBotaoBotao
            // 
            pnlMenuBotaoBotao.BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
            pnlMenuBotaoBotao.Controls.Add(label7);
            pnlMenuBotaoBotao.Controls.Add(label6);
            pnlMenuBotaoBotao.Controls.Add(botaoFechar);
            pnlMenuBotaoBotao.Controls.Add(botaoNovo);
            pnlMenuBotaoBotao.Location = new System.Drawing.Point(759, 0);
            pnlMenuBotaoBotao.Name = "pnlMenuBotaoBotao";
            pnlMenuBotaoBotao.Size = new System.Drawing.Size(106, 83);
            pnlMenuBotaoBotao.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label7.Location = new System.Drawing.Point(62, 56);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(34, 12);
            label7.TabIndex = 29;
            label7.Text = "Fechar";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(12, 56);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(29, 12);
            label6.TabIndex = 28;
            label6.Text = "Novo";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // botaoFechar
            // 
            botaoFechar.Image = (System.Drawing.Image)resources.GetObject("botaoFechar.Image");
            botaoFechar.Location = new System.Drawing.Point(53, 0);
            botaoFechar.Name = "botaoFechar";
            botaoFechar.Size = new System.Drawing.Size(53, 56);
            botaoFechar.TabIndex = 20;
            botaoFechar.TabStop = false;
            botaoFechar.UseVisualStyleBackColor = true;
            botaoFechar.Click += botaoFechar_Click;
            // 
            // botaoNovo
            // 
            botaoNovo.Image = (System.Drawing.Image)resources.GetObject("botaoNovo.Image");
            botaoNovo.Location = new System.Drawing.Point(0, 0);
            botaoNovo.Name = "botaoNovo";
            botaoNovo.Size = new System.Drawing.Size(53, 56);
            botaoNovo.TabIndex = 19;
            botaoNovo.TabStop = false;
            botaoNovo.UseVisualStyleBackColor = true;
            botaoNovo.Click += botaoNovo_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
            label2.Location = new System.Drawing.Point(0, 83);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(672, 19);
            label2.TabIndex = 11;
            label2.Text = "Utilize os filtros abaixo para localizar um registro específico ou uma lista, em seguida clique em Aplicar Filtros:";
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            panel1.Controls.Add(label20);
            panel1.Controls.Add(label21);
            panel1.Controls.Add(label18);
            panel1.Controls.Add(label19);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(label16);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(gridVenda);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(0, 206);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(866, 420);
            panel1.TabIndex = 13;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
            label20.Location = new System.Drawing.Point(786, 396);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(47, 15);
            label20.TabIndex = 24;
            label20.Text = "Estorno";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.BackColor = System.Drawing.Color.FromArgb(255, 128, 0);
            label21.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            label21.Location = new System.Drawing.Point(773, 396);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(13, 15);
            label21.TabIndex = 23;
            label21.Text = "E";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.ForeColor = System.Drawing.Color.Red;
            label18.Location = new System.Drawing.Point(694, 396);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(63, 15);
            label18.TabIndex = 22;
            label18.Text = "Cancelado";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.BackColor = System.Drawing.Color.Red;
            label19.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            label19.Location = new System.Drawing.Point(679, 396);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(15, 15);
            label19.TabIndex = 21;
            label19.Text = "C";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.ForeColor = System.Drawing.Color.Blue;
            label14.Location = new System.Drawing.Point(609, 396);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(54, 15);
            label14.TabIndex = 20;
            label14.Text = "Faturado";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = System.Drawing.Color.Blue;
            label16.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            label16.Location = new System.Drawing.Point(596, 396);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(13, 15);
            label16.TabIndex = 19;
            label16.Text = "F";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
            label11.Location = new System.Drawing.Point(528, 396);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(52, 15);
            label11.TabIndex = 18;
            label11.Text = "Fechado";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
            label13.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            label13.Location = new System.Drawing.Point(515, 396);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(13, 15);
            label13.TabIndex = 17;
            label13.Text = "F";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = System.Drawing.Color.Gray;
            label10.Location = new System.Drawing.Point(456, 396);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(43, 15);
            label10.TabIndex = 16;
            label10.Text = "Aberto";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = System.Drawing.Color.Gray;
            label9.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            label9.Location = new System.Drawing.Point(441, 396);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(15, 15);
            label9.TabIndex = 15;
            label9.Text = "A";
            // 
            // gridVenda
            // 
            gridVenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridVenda.Dock = System.Windows.Forms.DockStyle.Top;
            gridVenda.Location = new System.Drawing.Point(0, 0);
            gridVenda.Name = "gridVenda";
            gridVenda.RowHeadersWidth = 51;
            gridVenda.RowTemplate.Height = 25;
            gridVenda.Size = new System.Drawing.Size(866, 389);
            gridVenda.TabIndex = 14;
            gridVenda.DoubleClick += gridVenda_DoubleClick;
            // 
            // uscTipoEmissor1
            // 
            uscTipoEmissor1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            uscTipoEmissor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            uscTipoEmissor1.Location = new System.Drawing.Point(3, 3);
            uscTipoEmissor1.Name = "uscTipoEmissor1";
            uscTipoEmissor1.Size = new System.Drawing.Size(161, 74);
            uscTipoEmissor1.TabIndex = 3;
            // 
            // frmVendasConsulta
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(866, 626);
            Controls.Add(panel1);
            Controls.Add(pnlDadosGerais);
            Controls.Add(pnlMenuBotao);
            Controls.Add(label2);
            MaximizeBox = false;
            Name = "frmVendasConsulta";
            Text = "Vendas";
            pnlDadosGerais.ResumeLayout(false);
            pnlDadosGerais.PerformLayout();
            pnlMenuBotao.ResumeLayout(false);
            pnlMenuBotaoBotao.ResumeLayout(false);
            pnlMenuBotaoBotao.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridVenda).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button botaoLimparFiltros;
        private System.Windows.Forms.Button botaoAplicarFiltros;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboFiltro_Vendedor;
        private System.Windows.Forms.Panel pnlDadosGerais;
        private System.Windows.Forms.DateTimePicker dateFiltro_DataFinal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateFiltro_DataInicial;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox comboFiltro_Empresa;
        private System.Windows.Forms.ComboBox comboFiltro_Cliente;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textFiltro_Pedido;
        private System.Windows.Forms.Panel pnlMenuBotao;
        private System.Windows.Forms.Panel pnlMenuBotaoBotao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button botaoFechar;
        private System.Windows.Forms.Button botaoNovo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textFiltro_NFe;
        private System.Windows.Forms.TextBox textFiltro_NFCe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView gridVenda;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private uscTipoEmissor uscTipoEmissor1;
    }
}