namespace SisCom.Aplicacao.Formularios
{
    partial class frmRelatorios
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
            panel1 = new System.Windows.Forms.Panel();
            radioRelatorio_Estoque = new System.Windows.Forms.RadioButton();
            radioRelatorio_VendaNaoFiscais = new System.Windows.Forms.RadioButton();
            radioRelatorio_ApuracaoPorCFOP = new System.Windows.Forms.RadioButton();
            radioRelatorio_VendasSaidas = new System.Windows.Forms.RadioButton();
            radioRelatorio_NotaFiscalSaida = new System.Windows.Forms.RadioButton();
            radioRelatorio_NotaFiscalEntrada = new System.Windows.Forms.RadioButton();
            panel2 = new System.Windows.Forms.Panel();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            panel3 = new System.Windows.Forms.Panel();
            label10 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            dateDataFinal = new System.Windows.Forms.DateTimePicker();
            dateDataInicial = new System.Windows.Forms.DateTimePicker();
            comboPessoa = new System.Windows.Forms.ComboBox();
            label8 = new System.Windows.Forms.Label();
            comboCFOP = new System.Windows.Forms.ComboBox();
            label7 = new System.Windows.Forms.Label();
            comboCliente = new System.Windows.Forms.ComboBox();
            label6 = new System.Windows.Forms.Label();
            comboEmpresa = new System.Windows.Forms.ComboBox();
            label5 = new System.Windows.Forms.Label();
            panel4 = new System.Windows.Forms.Panel();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            botaoCancelar = new System.Windows.Forms.Button();
            botaoConfirmar = new System.Windows.Forms.Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(radioRelatorio_Estoque);
            panel1.Controls.Add(radioRelatorio_VendaNaoFiscais);
            panel1.Controls.Add(radioRelatorio_ApuracaoPorCFOP);
            panel1.Controls.Add(radioRelatorio_VendasSaidas);
            panel1.Controls.Add(radioRelatorio_NotaFiscalSaida);
            panel1.Controls.Add(radioRelatorio_NotaFiscalEntrada);
            panel1.Controls.Add(panel2);
            panel1.Location = new System.Drawing.Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(290, 297);
            panel1.TabIndex = 0;
            // 
            // radioRelatorio_Estoque
            // 
            radioRelatorio_Estoque.AutoSize = true;
            radioRelatorio_Estoque.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            radioRelatorio_Estoque.Location = new System.Drawing.Point(15, 205);
            radioRelatorio_Estoque.Name = "radioRelatorio_Estoque";
            radioRelatorio_Estoque.Size = new System.Drawing.Size(89, 25);
            radioRelatorio_Estoque.TabIndex = 8;
            radioRelatorio_Estoque.TabStop = true;
            radioRelatorio_Estoque.Text = "Estoque";
            radioRelatorio_Estoque.UseVisualStyleBackColor = true;
            // 
            // radioRelatorio_VendaNaoFiscais
            // 
            radioRelatorio_VendaNaoFiscais.AutoSize = true;
            radioRelatorio_VendaNaoFiscais.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            radioRelatorio_VendaNaoFiscais.Location = new System.Drawing.Point(15, 143);
            radioRelatorio_VendaNaoFiscais.Name = "radioRelatorio_VendaNaoFiscais";
            radioRelatorio_VendaNaoFiscais.Size = new System.Drawing.Size(172, 25);
            radioRelatorio_VendaNaoFiscais.TabIndex = 7;
            radioRelatorio_VendaNaoFiscais.TabStop = true;
            radioRelatorio_VendaNaoFiscais.Text = "Vendas Não Fiscais";
            radioRelatorio_VendaNaoFiscais.UseVisualStyleBackColor = true;
            // 
            // radioRelatorio_ApuracaoPorCFOP
            // 
            radioRelatorio_ApuracaoPorCFOP.AutoSize = true;
            radioRelatorio_ApuracaoPorCFOP.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            radioRelatorio_ApuracaoPorCFOP.Location = new System.Drawing.Point(15, 112);
            radioRelatorio_ApuracaoPorCFOP.Name = "radioRelatorio_ApuracaoPorCFOP";
            radioRelatorio_ApuracaoPorCFOP.Size = new System.Drawing.Size(175, 25);
            radioRelatorio_ApuracaoPorCFOP.TabIndex = 6;
            radioRelatorio_ApuracaoPorCFOP.TabStop = true;
            radioRelatorio_ApuracaoPorCFOP.Text = "Apuração por CFOP";
            radioRelatorio_ApuracaoPorCFOP.UseVisualStyleBackColor = true;
            // 
            // radioRelatorio_VendasSaidas
            // 
            radioRelatorio_VendasSaidas.AutoSize = true;
            radioRelatorio_VendasSaidas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            radioRelatorio_VendasSaidas.Location = new System.Drawing.Point(15, 174);
            radioRelatorio_VendasSaidas.Name = "radioRelatorio_VendasSaidas";
            radioRelatorio_VendasSaidas.Size = new System.Drawing.Size(149, 25);
            radioRelatorio_VendasSaidas.TabIndex = 5;
            radioRelatorio_VendasSaidas.TabStop = true;
            radioRelatorio_VendasSaidas.Text = "Vendas x Saídas";
            radioRelatorio_VendasSaidas.UseVisualStyleBackColor = true;
            // 
            // radioRelatorio_NotaFiscalSaida
            // 
            radioRelatorio_NotaFiscalSaida.AutoSize = true;
            radioRelatorio_NotaFiscalSaida.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            radioRelatorio_NotaFiscalSaida.Location = new System.Drawing.Point(15, 81);
            radioRelatorio_NotaFiscalSaida.Name = "radioRelatorio_NotaFiscalSaida";
            radioRelatorio_NotaFiscalSaida.Size = new System.Drawing.Size(135, 25);
            radioRelatorio_NotaFiscalSaida.TabIndex = 4;
            radioRelatorio_NotaFiscalSaida.TabStop = true;
            radioRelatorio_NotaFiscalSaida.Text = "Nota de Saída";
            radioRelatorio_NotaFiscalSaida.UseVisualStyleBackColor = true;
            // 
            // radioRelatorio_NotaFiscalEntrada
            // 
            radioRelatorio_NotaFiscalEntrada.AutoSize = true;
            radioRelatorio_NotaFiscalEntrada.Checked = true;
            radioRelatorio_NotaFiscalEntrada.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            radioRelatorio_NotaFiscalEntrada.Location = new System.Drawing.Point(15, 50);
            radioRelatorio_NotaFiscalEntrada.Name = "radioRelatorio_NotaFiscalEntrada";
            radioRelatorio_NotaFiscalEntrada.Size = new System.Drawing.Size(152, 25);
            radioRelatorio_NotaFiscalEntrada.TabIndex = 1;
            radioRelatorio_NotaFiscalEntrada.TabStop = true;
            radioRelatorio_NotaFiscalEntrada.Text = "Nota de Entrada";
            radioRelatorio_NotaFiscalEntrada.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Location = new System.Drawing.Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(290, 40);
            panel2.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.ForeColor = System.Drawing.Color.Blue;
            label2.Location = new System.Drawing.Point(30, 14);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(247, 21);
            label2.TabIndex = 1;
            label2.Text = "Selecione o Relatório Desejado";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.Color.Blue;
            label1.Location = new System.Drawing.Point(2, 1);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(33, 37);
            label1.TabIndex = 0;
            label1.Text = "1";
            // 
            // panel3
            // 
            panel3.Controls.Add(label10);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(dateDataFinal);
            panel3.Controls.Add(dateDataInicial);
            panel3.Controls.Add(comboPessoa);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(comboCFOP);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(comboCliente);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(comboEmpresa);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(panel4);
            panel3.Location = new System.Drawing.Point(312, 12);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(363, 297);
            panel3.TabIndex = 1;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label10.Location = new System.Drawing.Point(100, 238);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(72, 15);
            label10.TabIndex = 22;
            label10.Text = "Data Final: *";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label9.Location = new System.Drawing.Point(11, 238);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(79, 15);
            label9.TabIndex = 21;
            label9.Text = "Data Inicial: *";
            // 
            // dateDataFinal
            // 
            dateDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dateDataFinal.Location = new System.Drawing.Point(100, 255);
            dateDataFinal.Name = "dateDataFinal";
            dateDataFinal.Size = new System.Drawing.Size(81, 23);
            dateDataFinal.TabIndex = 20;
            // 
            // dateDataInicial
            // 
            dateDataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dateDataInicial.Location = new System.Drawing.Point(11, 255);
            dateDataInicial.Name = "dateDataInicial";
            dateDataInicial.Size = new System.Drawing.Size(81, 23);
            dateDataInicial.TabIndex = 19;
            // 
            // comboPessoa
            // 
            comboPessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboPessoa.FormattingEnabled = true;
            comboPessoa.Location = new System.Drawing.Point(11, 205);
            comboPessoa.Name = "comboPessoa";
            comboPessoa.Size = new System.Drawing.Size(341, 23);
            comboPessoa.TabIndex = 9;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label8.Location = new System.Drawing.Point(11, 188);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(44, 15);
            label8.TabIndex = 8;
            label8.Text = "Pessoa";
            // 
            // comboCFOP
            // 
            comboCFOP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboCFOP.FormattingEnabled = true;
            comboCFOP.Location = new System.Drawing.Point(11, 159);
            comboCFOP.Name = "comboCFOP";
            comboCFOP.Size = new System.Drawing.Size(341, 23);
            comboCFOP.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label7.Location = new System.Drawing.Point(11, 142);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(45, 15);
            label7.TabIndex = 6;
            label7.Text = "C.F.O.P,";
            // 
            // comboCliente
            // 
            comboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboCliente.FormattingEnabled = true;
            comboCliente.Location = new System.Drawing.Point(11, 113);
            comboCliente.Name = "comboCliente";
            comboCliente.Size = new System.Drawing.Size(341, 23);
            comboCliente.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(11, 96);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(46, 15);
            label6.TabIndex = 4;
            label6.Text = "Cliente";
            // 
            // comboEmpresa
            // 
            comboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboEmpresa.FormattingEnabled = true;
            comboEmpresa.Location = new System.Drawing.Point(10, 67);
            comboEmpresa.Name = "comboEmpresa";
            comboEmpresa.Size = new System.Drawing.Size(341, 23);
            comboEmpresa.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(10, 50);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(54, 15);
            label5.TabIndex = 2;
            label5.Text = "Empresa";
            // 
            // panel4
            // 
            panel4.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(label4);
            panel4.Location = new System.Drawing.Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(363, 40);
            panel4.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label3.ForeColor = System.Drawing.Color.Blue;
            label3.Location = new System.Drawing.Point(30, 14);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(332, 21);
            label3.TabIndex = 1;
            label3.Text = "Informe os Filtros e clique em \"Confirmar\"";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label4.ForeColor = System.Drawing.Color.Blue;
            label4.Location = new System.Drawing.Point(2, 1);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(33, 37);
            label4.TabIndex = 0;
            label4.Text = "2";
            // 
            // botaoCancelar
            // 
            botaoCancelar.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            botaoCancelar.Location = new System.Drawing.Point(401, 319);
            botaoCancelar.Name = "botaoCancelar";
            botaoCancelar.Size = new System.Drawing.Size(134, 40);
            botaoCancelar.TabIndex = 2;
            botaoCancelar.Text = "Cancelar";
            botaoCancelar.UseVisualStyleBackColor = true;
            botaoCancelar.Click += botaoCancelar_Click;
            // 
            // botaoConfirmar
            // 
            botaoConfirmar.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            botaoConfirmar.Location = new System.Drawing.Point(541, 319);
            botaoConfirmar.Name = "botaoConfirmar";
            botaoConfirmar.Size = new System.Drawing.Size(134, 40);
            botaoConfirmar.TabIndex = 3;
            botaoConfirmar.Text = "Confirmar";
            botaoConfirmar.UseVisualStyleBackColor = true;
            botaoConfirmar.Click += botaoConfirmar_Click;
            // 
            // frmRelatorios
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(685, 371);
            Controls.Add(botaoConfirmar);
            Controls.Add(botaoCancelar);
            Controls.Add(panel3);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            IsMdiContainer = true;
            MaximizeBox = false;
            Name = "frmRelatorios";
            Text = "Relatórios";
            Load += frmRelatorios_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioRelatorio_NotaFiscalEntrada;
        private System.Windows.Forms.RadioButton radioRelatorio_NotaFiscalSaida;
        private System.Windows.Forms.RadioButton radioRelatorio_VendaNaoFiscais;
        private System.Windows.Forms.RadioButton radioRelatorio_ApuracaoPorCFOP;
        private System.Windows.Forms.RadioButton radioRelatorio_VendasSaidas;
        private System.Windows.Forms.RadioButton radioRelatorio_Estoque;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboEmpresa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button botaoCancelar;
        private System.Windows.Forms.Button botaoConfirmar;
        private System.Windows.Forms.ComboBox comboCliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboCFOP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboPessoa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateDataFinal;
        private System.Windows.Forms.DateTimePicker dateDataInicial;
        private System.Windows.Forms.Label label10;
    }
}