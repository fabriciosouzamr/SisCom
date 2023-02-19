namespace SisCom.Aplicacao.Formularios
{
    partial class frmCadastroNaturezaOperacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroNaturezaOperacao));
            this.pnlMenuBotao = new System.Windows.Forms.Panel();
            this.pnlMenuBotaoBotao = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.botaoExcluir = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.botaoFechar = new System.Windows.Forms.Button();
            this.gridNaturezaOperacao = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.botaoGravar = new System.Windows.Forms.Button();
            this.pnlMenuBotao.SuspendLayout();
            this.pnlMenuBotaoBotao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNaturezaOperacao)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMenuBotao
            // 
            this.pnlMenuBotao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlMenuBotao.Controls.Add(this.pnlMenuBotaoBotao);
            this.pnlMenuBotao.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenuBotao.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuBotao.Name = "pnlMenuBotao";
            this.pnlMenuBotao.Size = new System.Drawing.Size(931, 73);
            this.pnlMenuBotao.TabIndex = 18;
            // 
            // pnlMenuBotaoBotao
            // 
            this.pnlMenuBotaoBotao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlMenuBotaoBotao.Controls.Add(this.label2);
            this.pnlMenuBotaoBotao.Controls.Add(this.botaoGravar);
            this.pnlMenuBotaoBotao.Controls.Add(this.label1);
            this.pnlMenuBotaoBotao.Controls.Add(this.botaoExcluir);
            this.pnlMenuBotaoBotao.Controls.Add(this.label7);
            this.pnlMenuBotaoBotao.Controls.Add(this.botaoFechar);
            this.pnlMenuBotaoBotao.ImeMode = System.Windows.Forms.ImeMode.On;
            this.pnlMenuBotaoBotao.Location = new System.Drawing.Point(137, 0);
            this.pnlMenuBotaoBotao.Name = "pnlMenuBotaoBotao";
            this.pnlMenuBotaoBotao.Size = new System.Drawing.Size(794, 83);
            this.pnlMenuBotaoBotao.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(692, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 12);
            this.label1.TabIndex = 62;
            this.label1.Tag = "s";
            this.label1.Text = "Excluir";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // botaoExcluir
            // 
            this.botaoExcluir.Image = ((System.Drawing.Image)(resources.GetObject("botaoExcluir.Image")));
            this.botaoExcluir.Location = new System.Drawing.Point(682, 0);
            this.botaoExcluir.Name = "botaoExcluir";
            this.botaoExcluir.Size = new System.Drawing.Size(53, 56);
            this.botaoExcluir.TabIndex = 59;
            this.botaoExcluir.UseVisualStyleBackColor = true;
            this.botaoExcluir.Click += new System.EventHandler(this.botaoExcluir_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(746, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 12);
            this.label7.TabIndex = 29;
            this.label7.Text = "Fechar";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // botaoFechar
            // 
            this.botaoFechar.Image = ((System.Drawing.Image)(resources.GetObject("botaoFechar.Image")));
            this.botaoFechar.Location = new System.Drawing.Point(737, 0);
            this.botaoFechar.Name = "botaoFechar";
            this.botaoFechar.Size = new System.Drawing.Size(52, 56);
            this.botaoFechar.TabIndex = 20;
            this.botaoFechar.UseVisualStyleBackColor = true;
            this.botaoFechar.Click += new System.EventHandler(this.botaoFechar_Click);
            // 
            // gridNaturezaOperacao
            // 
            this.gridNaturezaOperacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridNaturezaOperacao.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridNaturezaOperacao.Location = new System.Drawing.Point(0, 71);
            this.gridNaturezaOperacao.Name = "gridNaturezaOperacao";
            this.gridNaturezaOperacao.RowHeadersWidth = 51;
            this.gridNaturezaOperacao.RowTemplate.Height = 25;
            this.gridNaturezaOperacao.Size = new System.Drawing.Size(931, 480);
            this.gridNaturezaOperacao.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(637, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 12);
            this.label2.TabIndex = 64;
            this.label2.Text = "Gravar";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // botaoGravar
            // 
            this.botaoGravar.Image = ((System.Drawing.Image)(resources.GetObject("botaoGravar.Image")));
            this.botaoGravar.Location = new System.Drawing.Point(627, 0);
            this.botaoGravar.Name = "botaoGravar";
            this.botaoGravar.Size = new System.Drawing.Size(53, 56);
            this.botaoGravar.TabIndex = 63;
            this.botaoGravar.UseVisualStyleBackColor = true;
            this.botaoGravar.Click += new System.EventHandler(this.botaoGravar_Click);
            // 
            // frmCadastroNaturezaOperacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 551);
            this.Controls.Add(this.pnlMenuBotao);
            this.Controls.Add(this.gridNaturezaOperacao);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmCadastroNaturezaOperacao";
            this.Text = "Cadastro de Natureza de Operação";
            this.Load += new System.EventHandler(this.frmCadastroNaturezaOperacao_Load);
            this.pnlMenuBotao.ResumeLayout(false);
            this.pnlMenuBotaoBotao.ResumeLayout(false);
            this.pnlMenuBotaoBotao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNaturezaOperacao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenuBotao;
        private System.Windows.Forms.Panel pnlMenuBotaoBotao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botaoExcluir;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button botaoFechar;
        private System.Windows.Forms.DataGridView gridNaturezaOperacao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button botaoGravar;
    }
}