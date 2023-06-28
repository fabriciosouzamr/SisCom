namespace SisCom.Aplicacao.Formularios
{
    partial class frmCadastroEstoque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroEstoque));
            pnlMenuBotao = new System.Windows.Forms.Panel();
            pnlMenuBotaoBotao = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            botaoGravar = new System.Windows.Forms.Button();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            botaoNovo = new System.Windows.Forms.Button();
            botaoExcluir = new System.Windows.Forms.Button();
            label7 = new System.Windows.Forms.Label();
            botaoFechar = new System.Windows.Forms.Button();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabProdutosEstoque = new System.Windows.Forms.TabPage();
            gridProdutoEstoque = new System.Windows.Forms.DataGridView();
            tabLancamentoEstoque = new System.Windows.Forms.TabPage();
            groupBox1 = new System.Windows.Forms.GroupBox();
            label13 = new System.Windows.Forms.Label();
            botaoGravarlancamento = new System.Windows.Forms.Button();
            botaoNovoLancamento = new System.Windows.Forms.Button();
            textLancamentoComentario = new System.Windows.Forms.TextBox();
            label12 = new System.Windows.Forms.Label();
            numericLancamentoQuantidade = new System.Windows.Forms.NumericUpDown();
            label11 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            comboLancamentoEntradaSaida = new System.Windows.Forms.ComboBox();
            comboTipoLancamentoEstoque = new System.Windows.Forms.ComboBox();
            dateLancamento = new System.Windows.Forms.DateTimePicker();
            label8 = new System.Windows.Forms.Label();
            comboMercadoria = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            dateFiltro_DataFinal = new System.Windows.Forms.DateTimePicker();
            label3 = new System.Windows.Forms.Label();
            dateFiltro_DataInicial = new System.Windows.Forms.DateTimePicker();
            label69 = new System.Windows.Forms.Label();
            botaoAplicarFiltros = new System.Windows.Forms.Button();
            gridLancamento = new System.Windows.Forms.DataGridView();
            panel1 = new System.Windows.Forms.Panel();
            comboAlmoxarifado = new System.Windows.Forms.ComboBox();
            label9 = new System.Windows.Forms.Label();
            panel2 = new System.Windows.Forms.Panel();
            textNomeAlmoxarifado = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            comboUnidadeMedida = new System.Windows.Forms.ComboBox();
            pnlMenuBotao.SuspendLayout();
            pnlMenuBotaoBotao.SuspendLayout();
            tabControl1.SuspendLayout();
            tabProdutosEstoque.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridProdutoEstoque).BeginInit();
            tabLancamentoEstoque.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericLancamentoQuantidade).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridLancamento).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMenuBotao
            // 
            pnlMenuBotao.BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
            pnlMenuBotao.Controls.Add(pnlMenuBotaoBotao);
            pnlMenuBotao.Dock = System.Windows.Forms.DockStyle.Top;
            pnlMenuBotao.Location = new System.Drawing.Point(0, 0);
            pnlMenuBotao.Name = "pnlMenuBotao";
            pnlMenuBotao.Size = new System.Drawing.Size(1183, 72);
            pnlMenuBotao.TabIndex = 9;
            // 
            // pnlMenuBotaoBotao
            // 
            pnlMenuBotaoBotao.BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
            pnlMenuBotaoBotao.Controls.Add(label1);
            pnlMenuBotaoBotao.Controls.Add(botaoGravar);
            pnlMenuBotaoBotao.Controls.Add(label6);
            pnlMenuBotaoBotao.Controls.Add(label5);
            pnlMenuBotaoBotao.Controls.Add(botaoNovo);
            pnlMenuBotaoBotao.Controls.Add(botaoExcluir);
            pnlMenuBotaoBotao.Controls.Add(label7);
            pnlMenuBotaoBotao.Controls.Add(botaoFechar);
            pnlMenuBotaoBotao.Dock = System.Windows.Forms.DockStyle.Right;
            pnlMenuBotaoBotao.Location = new System.Drawing.Point(705, 0);
            pnlMenuBotaoBotao.Name = "pnlMenuBotaoBotao";
            pnlMenuBotaoBotao.Size = new System.Drawing.Size(478, 72);
            pnlMenuBotaoBotao.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(328, 56);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(33, 12);
            label1.TabIndex = 35;
            label1.Text = "Gravar";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // botaoGravar
            // 
            botaoGravar.Image = (System.Drawing.Image)resources.GetObject("botaoGravar.Image");
            botaoGravar.Location = new System.Drawing.Point(318, 0);
            botaoGravar.Name = "botaoGravar";
            botaoGravar.Size = new System.Drawing.Size(53, 56);
            botaoGravar.TabIndex = 34;
            botaoGravar.UseVisualStyleBackColor = true;
            botaoGravar.Click += botaoGravar_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(383, 56);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(29, 12);
            label6.TabIndex = 33;
            label6.Text = "Novo";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(275, 56);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(33, 12);
            label5.TabIndex = 32;
            label5.Text = "Excluir";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // botaoNovo
            // 
            botaoNovo.Image = (System.Drawing.Image)resources.GetObject("botaoNovo.Image");
            botaoNovo.Location = new System.Drawing.Point(371, 0);
            botaoNovo.Name = "botaoNovo";
            botaoNovo.Size = new System.Drawing.Size(53, 56);
            botaoNovo.TabIndex = 31;
            botaoNovo.UseVisualStyleBackColor = true;
            botaoNovo.Click += botaoNovo_Click;
            // 
            // botaoExcluir
            // 
            botaoExcluir.Image = (System.Drawing.Image)resources.GetObject("botaoExcluir.Image");
            botaoExcluir.Location = new System.Drawing.Point(265, 0);
            botaoExcluir.Name = "botaoExcluir";
            botaoExcluir.Size = new System.Drawing.Size(53, 56);
            botaoExcluir.TabIndex = 30;
            botaoExcluir.UseVisualStyleBackColor = true;
            botaoExcluir.Click += botaoExcluir_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label7.Location = new System.Drawing.Point(433, 56);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(34, 12);
            label7.TabIndex = 29;
            label7.Text = "Fechar";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // botaoFechar
            // 
            botaoFechar.Image = (System.Drawing.Image)resources.GetObject("botaoFechar.Image");
            botaoFechar.Location = new System.Drawing.Point(424, 0);
            botaoFechar.Name = "botaoFechar";
            botaoFechar.Size = new System.Drawing.Size(53, 56);
            botaoFechar.TabIndex = 20;
            botaoFechar.UseVisualStyleBackColor = true;
            botaoFechar.Click += botaoFechar_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabProdutosEstoque);
            tabControl1.Controls.Add(tabLancamentoEstoque);
            tabControl1.Location = new System.Drawing.Point(0, 142);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(1231, 501);
            tabControl1.TabIndex = 10;
            // 
            // tabProdutosEstoque
            // 
            tabProdutosEstoque.Controls.Add(gridProdutoEstoque);
            tabProdutosEstoque.Location = new System.Drawing.Point(4, 24);
            tabProdutosEstoque.Name = "tabProdutosEstoque";
            tabProdutosEstoque.Padding = new System.Windows.Forms.Padding(3);
            tabProdutosEstoque.Size = new System.Drawing.Size(1223, 473);
            tabProdutosEstoque.TabIndex = 1;
            tabProdutosEstoque.Text = "Produtos em Estoque";
            tabProdutosEstoque.UseVisualStyleBackColor = true;
            // 
            // gridProdutoEstoque
            // 
            gridProdutoEstoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridProdutoEstoque.Dock = System.Windows.Forms.DockStyle.Fill;
            gridProdutoEstoque.Location = new System.Drawing.Point(3, 3);
            gridProdutoEstoque.Name = "gridProdutoEstoque";
            gridProdutoEstoque.RowTemplate.Height = 25;
            gridProdutoEstoque.Size = new System.Drawing.Size(1217, 467);
            gridProdutoEstoque.TabIndex = 2;
            // 
            // tabLancamentoEstoque
            // 
            tabLancamentoEstoque.Controls.Add(groupBox1);
            tabLancamentoEstoque.Controls.Add(comboMercadoria);
            tabLancamentoEstoque.Controls.Add(label4);
            tabLancamentoEstoque.Controls.Add(dateFiltro_DataFinal);
            tabLancamentoEstoque.Controls.Add(label3);
            tabLancamentoEstoque.Controls.Add(dateFiltro_DataInicial);
            tabLancamentoEstoque.Controls.Add(label69);
            tabLancamentoEstoque.Controls.Add(botaoAplicarFiltros);
            tabLancamentoEstoque.Controls.Add(gridLancamento);
            tabLancamentoEstoque.Location = new System.Drawing.Point(4, 24);
            tabLancamentoEstoque.Name = "tabLancamentoEstoque";
            tabLancamentoEstoque.Padding = new System.Windows.Forms.Padding(3);
            tabLancamentoEstoque.Size = new System.Drawing.Size(1223, 473);
            tabLancamentoEstoque.TabIndex = 0;
            tabLancamentoEstoque.Text = "Lançamento em Estoque";
            tabLancamentoEstoque.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(comboUnidadeMedida);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(botaoGravarlancamento);
            groupBox1.Controls.Add(botaoNovoLancamento);
            groupBox1.Controls.Add(textLancamentoComentario);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(numericLancamentoQuantidade);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(comboLancamentoEntradaSaida);
            groupBox1.Controls.Add(comboTipoLancamentoEstoque);
            groupBox1.Controls.Add(dateLancamento);
            groupBox1.Controls.Add(label8);
            groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            groupBox1.Location = new System.Drawing.Point(8, 36);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(1165, 69);
            groupBox1.TabIndex = 106;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ajustes";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label13.Location = new System.Drawing.Point(521, 19);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(70, 15);
            label13.TabIndex = 115;
            label13.Text = "Comentário";
            // 
            // botaoGravarlancamento
            // 
            botaoGravarlancamento.Image = (System.Drawing.Image)resources.GetObject("botaoGravarlancamento.Image");
            botaoGravarlancamento.Location = new System.Drawing.Point(1052, 10);
            botaoGravarlancamento.Name = "botaoGravarlancamento";
            botaoGravarlancamento.Size = new System.Drawing.Size(53, 56);
            botaoGravarlancamento.TabIndex = 114;
            botaoGravarlancamento.UseVisualStyleBackColor = true;
            botaoGravarlancamento.Click += botaoGravarlancamento_Click;
            // 
            // botaoNovoLancamento
            // 
            botaoNovoLancamento.Image = (System.Drawing.Image)resources.GetObject("botaoNovoLancamento.Image");
            botaoNovoLancamento.Location = new System.Drawing.Point(1109, 10);
            botaoNovoLancamento.Name = "botaoNovoLancamento";
            botaoNovoLancamento.Size = new System.Drawing.Size(53, 56);
            botaoNovoLancamento.TabIndex = 113;
            botaoNovoLancamento.UseVisualStyleBackColor = true;
            botaoNovoLancamento.Click += botaoNovoLancamento_Click;
            // 
            // textLancamentoComentario
            // 
            textLancamentoComentario.Location = new System.Drawing.Point(521, 36);
            textLancamentoComentario.MaxLength = 1000;
            textLancamentoComentario.Name = "textLancamentoComentario";
            textLancamentoComentario.Size = new System.Drawing.Size(525, 23);
            textLancamentoComentario.TabIndex = 112;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label12.Location = new System.Drawing.Point(322, 19);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(69, 15);
            label12.TabIndex = 111;
            label12.Text = "Quantidade";
            // 
            // numericLancamentoQuantidade
            // 
            numericLancamentoQuantidade.DecimalPlaces = 2;
            numericLancamentoQuantidade.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericLancamentoQuantidade.Location = new System.Drawing.Point(322, 36);
            numericLancamentoQuantidade.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericLancamentoQuantidade.Name = "numericLancamentoQuantidade";
            numericLancamentoQuantidade.Size = new System.Drawing.Size(90, 23);
            numericLancamentoQuantidade.TabIndex = 110;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label11.Location = new System.Drawing.Point(187, 19);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(129, 15);
            label11.TabIndex = 109;
            label11.Text = "Tipo de Movimentação";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label10.Location = new System.Drawing.Point(101, 19);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(80, 15);
            label10.TabIndex = 108;
            label10.Text = "Entrada/Saída";
            // 
            // comboLancamentoEntradaSaida
            // 
            comboLancamentoEntradaSaida.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            comboLancamentoEntradaSaida.FormattingEnabled = true;
            comboLancamentoEntradaSaida.Location = new System.Drawing.Point(101, 36);
            comboLancamentoEntradaSaida.Name = "comboLancamentoEntradaSaida";
            comboLancamentoEntradaSaida.Size = new System.Drawing.Size(80, 23);
            comboLancamentoEntradaSaida.TabIndex = 107;
            comboLancamentoEntradaSaida.TabStop = false;
            // 
            // comboTipoLancamentoEstoque
            // 
            comboTipoLancamentoEstoque.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            comboTipoLancamentoEstoque.FormattingEnabled = true;
            comboTipoLancamentoEstoque.Location = new System.Drawing.Point(187, 36);
            comboTipoLancamentoEstoque.Name = "comboTipoLancamentoEstoque";
            comboTipoLancamentoEstoque.Size = new System.Drawing.Size(129, 23);
            comboTipoLancamentoEstoque.TabIndex = 106;
            comboTipoLancamentoEstoque.TabStop = false;
            // 
            // dateLancamento
            // 
            dateLancamento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dateLancamento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dateLancamento.Location = new System.Drawing.Point(6, 36);
            dateLancamento.Name = "dateLancamento";
            dateLancamento.Size = new System.Drawing.Size(89, 23);
            dateLancamento.TabIndex = 103;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label8.Location = new System.Drawing.Point(6, 19);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(31, 15);
            label8.TabIndex = 104;
            label8.Text = "Data";
            // 
            // comboMercadoria
            // 
            comboMercadoria.FormattingEnabled = true;
            comboMercadoria.Location = new System.Drawing.Point(86, 9);
            comboMercadoria.Name = "comboMercadoria";
            comboMercadoria.Size = new System.Drawing.Size(779, 23);
            comboMercadoria.TabIndex = 105;
            comboMercadoria.TabStop = false;
            comboMercadoria.SelectedIndexChanged += comboMercadoria_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(8, 13);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(76, 15);
            label4.TabIndex = 104;
            label4.Text = "Mercadoria: ";
            // 
            // dateFiltro_DataFinal
            // 
            dateFiltro_DataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dateFiltro_DataFinal.Location = new System.Drawing.Point(103, 128);
            dateFiltro_DataFinal.Name = "dateFiltro_DataFinal";
            dateFiltro_DataFinal.Size = new System.Drawing.Size(89, 23);
            dateFiltro_DataFinal.TabIndex = 101;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(103, 111);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(61, 15);
            label3.TabIndex = 103;
            label3.Text = "Data Final";
            // 
            // dateFiltro_DataInicial
            // 
            dateFiltro_DataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dateFiltro_DataInicial.Location = new System.Drawing.Point(8, 128);
            dateFiltro_DataInicial.Name = "dateFiltro_DataInicial";
            dateFiltro_DataInicial.Size = new System.Drawing.Size(89, 23);
            dateFiltro_DataInicial.TabIndex = 100;
            // 
            // label69
            // 
            label69.AutoSize = true;
            label69.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label69.Location = new System.Drawing.Point(8, 111);
            label69.Name = "label69";
            label69.Size = new System.Drawing.Size(68, 15);
            label69.TabIndex = 102;
            label69.Text = "Data Inicial";
            // 
            // botaoAplicarFiltros
            // 
            botaoAplicarFiltros.Image = (System.Drawing.Image)resources.GetObject("botaoAplicarFiltros.Image");
            botaoAplicarFiltros.Location = new System.Drawing.Point(1073, 111);
            botaoAplicarFiltros.Name = "botaoAplicarFiltros";
            botaoAplicarFiltros.Size = new System.Drawing.Size(100, 45);
            botaoAplicarFiltros.TabIndex = 98;
            botaoAplicarFiltros.TabStop = false;
            botaoAplicarFiltros.UseVisualStyleBackColor = true;
            botaoAplicarFiltros.Click += botaoAplicarFiltros_Click;
            // 
            // gridLancamento
            // 
            gridLancamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridLancamento.Location = new System.Drawing.Point(8, 162);
            gridLancamento.Name = "gridLancamento";
            gridLancamento.RowTemplate.Height = 25;
            gridLancamento.Size = new System.Drawing.Size(1165, 305);
            gridLancamento.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            panel1.Controls.Add(comboAlmoxarifado);
            panel1.Controls.Add(label9);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 72);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1183, 32);
            panel1.TabIndex = 12;
            // 
            // comboAlmoxarifado
            // 
            comboAlmoxarifado.FormattingEnabled = true;
            comboAlmoxarifado.Location = new System.Drawing.Point(103, 5);
            comboAlmoxarifado.Name = "comboAlmoxarifado";
            comboAlmoxarifado.Size = new System.Drawing.Size(766, 23);
            comboAlmoxarifado.TabIndex = 5;
            comboAlmoxarifado.TabStop = false;
            comboAlmoxarifado.SelectedIndexChanged += comboAlmoxarifado_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label9.Location = new System.Drawing.Point(10, 9);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(87, 15);
            label9.TabIndex = 4;
            label9.Text = "Almoxarifados";
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            panel2.Controls.Add(textNomeAlmoxarifado);
            panel2.Controls.Add(label2);
            panel2.Dock = System.Windows.Forms.DockStyle.Top;
            panel2.Location = new System.Drawing.Point(0, 104);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(1183, 32);
            panel2.TabIndex = 13;
            // 
            // textNomeAlmoxarifado
            // 
            textNomeAlmoxarifado.Location = new System.Drawing.Point(153, 5);
            textNomeAlmoxarifado.Name = "textNomeAlmoxarifado";
            textNomeAlmoxarifado.Size = new System.Drawing.Size(716, 23);
            textNomeAlmoxarifado.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(10, 9);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(139, 15);
            label2.TabIndex = 4;
            label2.Text = "Nome do Almoxarifado:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label14.Location = new System.Drawing.Point(418, 18);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(94, 15);
            label14.TabIndex = 117;
            label14.Text = "Unidade Medida";
            // 
            // comboUnidadeMedida
            // 
            comboUnidadeMedida.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            comboUnidadeMedida.FormattingEnabled = true;
            comboUnidadeMedida.Location = new System.Drawing.Point(418, 35);
            comboUnidadeMedida.Name = "comboUnidadeMedida";
            comboUnidadeMedida.Size = new System.Drawing.Size(97, 23);
            comboUnidadeMedida.TabIndex = 116;
            comboUnidadeMedida.TabStop = false;
            // 
            // frmCadastroEstoque
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1183, 643);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(tabControl1);
            Controls.Add(pnlMenuBotao);
            Name = "frmCadastroEstoque";
            Text = "Cadastro de Estoque";
            pnlMenuBotao.ResumeLayout(false);
            pnlMenuBotaoBotao.ResumeLayout(false);
            pnlMenuBotaoBotao.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabProdutosEstoque.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridProdutoEstoque).EndInit();
            tabLancamentoEstoque.ResumeLayout(false);
            tabLancamentoEstoque.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericLancamentoQuantidade).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridLancamento).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlMenuBotao;
        private System.Windows.Forms.Panel pnlMenuBotaoBotao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botaoGravar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button botaoNovo;
        private System.Windows.Forms.Button botaoExcluir;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button botaoFechar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabLancamentoEstoque;
        private System.Windows.Forms.TabPage tabProdutosEstoque;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboAlmoxarifado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textNomeAlmoxarifado;
        private System.Windows.Forms.DataGridView gridProdutoEstoque;
        private System.Windows.Forms.DataGridView gridLancamento;
        private System.Windows.Forms.Button botaoAplicarFiltros;
        private System.Windows.Forms.DateTimePicker dateFiltro_DataFinal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateFiltro_DataInicial;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.ComboBox comboMercadoria;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateLancamento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboTipoLancamentoEstoque;
        private System.Windows.Forms.ComboBox comboLancamentoEntradaSaida;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericLancamentoQuantidade;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button botaoGravarlancamento;
        private System.Windows.Forms.Button botaoNovoLancamento;
        private System.Windows.Forms.TextBox textLancamentoComentario;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboUnidadeMedida;
    }
}