namespace SisCom.Aplicacao.Formularios
{
    partial class frmFiscal_Cancelamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFiscal_Cancelamento));
            this.pnlMenuBotao = new System.Windows.Forms.Panel();
            this.pnlMenuBotaoBotao = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.botaoFechar = new System.Windows.Forms.Button();
            this.botaoImprimir = new System.Windows.Forms.Button();
            this.botaoConfimar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textChaveAcesso = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textCliente = new System.Windows.Forms.TextBox();
            this.textSerie = new System.Windows.Forms.TextBox();
            this.botaoBuscar = new System.Windows.Forms.Button();
            this.textNumeroNotaFiscal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richJustificativa = new System.Windows.Forms.RichTextBox();
            this.pnlMenuBotao.SuspendLayout();
            this.pnlMenuBotaoBotao.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenuBotao
            // 
            this.pnlMenuBotao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlMenuBotao.Controls.Add(this.pnlMenuBotaoBotao);
            this.pnlMenuBotao.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenuBotao.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuBotao.Name = "pnlMenuBotao";
            this.pnlMenuBotao.Size = new System.Drawing.Size(731, 83);
            this.pnlMenuBotao.TabIndex = 15;
            // 
            // pnlMenuBotaoBotao
            // 
            this.pnlMenuBotaoBotao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlMenuBotaoBotao.Controls.Add(this.label7);
            this.pnlMenuBotaoBotao.Controls.Add(this.botaoFechar);
            this.pnlMenuBotaoBotao.Location = new System.Drawing.Point(179, 0);
            this.pnlMenuBotaoBotao.Name = "pnlMenuBotaoBotao";
            this.pnlMenuBotaoBotao.Size = new System.Drawing.Size(552, 83);
            this.pnlMenuBotaoBotao.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(505, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 12);
            this.label7.TabIndex = 29;
            this.label7.Text = "Fechar";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // botaoFechar
            // 
            this.botaoFechar.Image = ((System.Drawing.Image)(resources.GetObject("botaoFechar.Image")));
            this.botaoFechar.Location = new System.Drawing.Point(496, 0);
            this.botaoFechar.Name = "botaoFechar";
            this.botaoFechar.Size = new System.Drawing.Size(53, 56);
            this.botaoFechar.TabIndex = 20;
            this.botaoFechar.UseVisualStyleBackColor = true;
            this.botaoFechar.Click += new System.EventHandler(this.botaoFechar_Click);
            // 
            // botaoImprimir
            // 
            this.botaoImprimir.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.botaoImprimir.Location = new System.Drawing.Point(355, 557);
            this.botaoImprimir.Margin = new System.Windows.Forms.Padding(0);
            this.botaoImprimir.Name = "botaoImprimir";
            this.botaoImprimir.Size = new System.Drawing.Size(200, 40);
            this.botaoImprimir.TabIndex = 23;
            this.botaoImprimir.TabStop = false;
            this.botaoImprimir.Text = "Imprimir";
            this.botaoImprimir.UseVisualStyleBackColor = true;
            this.botaoImprimir.Click += new System.EventHandler(this.botaoImprimir_Click);
            // 
            // botaoConfimar
            // 
            this.botaoConfimar.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.botaoConfimar.Location = new System.Drawing.Point(117, 557);
            this.botaoConfimar.Margin = new System.Windows.Forms.Padding(0);
            this.botaoConfimar.Name = "botaoConfimar";
            this.botaoConfimar.Size = new System.Drawing.Size(200, 40);
            this.botaoConfimar.TabIndex = 22;
            this.botaoConfimar.TabStop = false;
            this.botaoConfimar.Text = "Confimar";
            this.botaoConfimar.UseVisualStyleBackColor = true;
            this.botaoConfimar.Click += new System.EventHandler(this.botaoConfimar_ClickAsync);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textChaveAcesso);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textCliente);
            this.groupBox1.Controls.Add(this.textSerie);
            this.groupBox1.Controls.Add(this.botaoBuscar);
            this.groupBox1.Controls.Add(this.textNumeroNotaFiscal);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(3, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(725, 139);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Digite o Número da Nota que deseja Cancelar e após isso clique em Buscar:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(5, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 19);
            this.label9.TabIndex = 8;
            this.label9.Text = "Chave de Acesso";
            // 
            // textChaveAcesso
            // 
            this.textChaveAcesso.Location = new System.Drawing.Point(5, 102);
            this.textChaveAcesso.Name = "textChaveAcesso";
            this.textChaveAcesso.ReadOnly = true;
            this.textChaveAcesso.Size = new System.Drawing.Size(714, 29);
            this.textChaveAcesso.TabIndex = 7;
            this.textChaveAcesso.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(259, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 19);
            this.label8.TabIndex = 6;
            this.label8.Text = "Cliente";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(210, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "Série";
            // 
            // textCliente
            // 
            this.textCliente.Location = new System.Drawing.Point(259, 46);
            this.textCliente.Name = "textCliente";
            this.textCliente.ReadOnly = true;
            this.textCliente.Size = new System.Drawing.Size(460, 29);
            this.textCliente.TabIndex = 4;
            this.textCliente.TabStop = false;
            // 
            // textSerie
            // 
            this.textSerie.Location = new System.Drawing.Point(210, 46);
            this.textSerie.Name = "textSerie";
            this.textSerie.ReadOnly = true;
            this.textSerie.Size = new System.Drawing.Size(43, 29);
            this.textSerie.TabIndex = 3;
            this.textSerie.TabStop = false;
            // 
            // botaoBuscar
            // 
            this.botaoBuscar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.botaoBuscar.Location = new System.Drawing.Point(129, 46);
            this.botaoBuscar.Margin = new System.Windows.Forms.Padding(0);
            this.botaoBuscar.Name = "botaoBuscar";
            this.botaoBuscar.Size = new System.Drawing.Size(75, 29);
            this.botaoBuscar.TabIndex = 2;
            this.botaoBuscar.Text = "Buscar";
            this.botaoBuscar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.botaoBuscar.UseVisualStyleBackColor = true;
            this.botaoBuscar.Click += new System.EventHandler(this.botaoBuscar_ClickAsync);
            // 
            // textNumeroNotaFiscal
            // 
            this.textNumeroNotaFiscal.Location = new System.Drawing.Point(5, 46);
            this.textNumeroNotaFiscal.Name = "textNumeroNotaFiscal";
            this.textNumeroNotaFiscal.Size = new System.Drawing.Size(122, 29);
            this.textNumeroNotaFiscal.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(5, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nùmero da Nota";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richJustificativa);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(3, 234);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(725, 230);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Justificativa";
            // 
            // richJustificativa
            // 
            this.richJustificativa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richJustificativa.Location = new System.Drawing.Point(3, 25);
            this.richJustificativa.Name = "richJustificativa";
            this.richJustificativa.Size = new System.Drawing.Size(719, 202);
            this.richJustificativa.TabIndex = 0;
            this.richJustificativa.Text = "";
            // 
            // frmFiscal_Cancelamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 645);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.botaoImprimir);
            this.Controls.Add(this.botaoConfimar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlMenuBotao);
            this.Name = "frmFiscal_Cancelamento";
            this.Text = "frmFiscal_Cancelamento";
            this.pnlMenuBotao.ResumeLayout(false);
            this.pnlMenuBotaoBotao.ResumeLayout(false);
            this.pnlMenuBotaoBotao.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenuBotao;
        private System.Windows.Forms.Panel pnlMenuBotaoBotao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button botaoFechar;
        private System.Windows.Forms.Button botaoImprimir;
        private System.Windows.Forms.Button botaoConfimar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textChaveAcesso;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textCliente;
        private System.Windows.Forms.TextBox textSerie;
        private System.Windows.Forms.Button botaoBuscar;
        private System.Windows.Forms.TextBox textNumeroNotaFiscal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richJustificativa;
    }
}