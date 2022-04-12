
namespace SisCom.Aplicacao.Formularios
{
    partial class frmCadastroFuncionarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroFuncionarios));
            this.tabEnderecos = new System.Windows.Forms.TabControl();
            this.tabIdentificacao = new System.Windows.Forms.TabPage();
            this.checkAcessoFiscal = new System.Windows.Forms.CheckBox();
            this.checkAcessoFinanceiro = new System.Windows.Forms.CheckBox();
            this.checkDesativado = new System.Windows.Forms.CheckBox();
            this.textSenhaFuncionario = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textCodigoFuncionario = new System.Windows.Forms.TextBox();
            this.textNomeFuncionario = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.pnlMenuBotao = new System.Windows.Forms.Panel();
            this.pnlMenuBotaoBotao = new System.Windows.Forms.Panel();
            this.botaoAnterior = new System.Windows.Forms.Button();
            this.botaoPosterior = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.botaoFechar = new System.Windows.Forms.Button();
            this.botaoNovo = new System.Windows.Forms.Button();
            this.botaoExcluir = new System.Windows.Forms.Button();
            this.tabEnderecos.SuspendLayout();
            this.tabIdentificacao.SuspendLayout();
            this.pnlMenuBotao.SuspendLayout();
            this.pnlMenuBotaoBotao.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabEnderecos
            // 
            this.tabEnderecos.Controls.Add(this.tabIdentificacao);
            this.tabEnderecos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabEnderecos.Location = new System.Drawing.Point(0, 83);
            this.tabEnderecos.Name = "tabEnderecos";
            this.tabEnderecos.SelectedIndex = 0;
            this.tabEnderecos.Size = new System.Drawing.Size(726, 235);
            this.tabEnderecos.TabIndex = 12;
            // 
            // tabIdentificacao
            // 
            this.tabIdentificacao.Controls.Add(this.checkAcessoFiscal);
            this.tabIdentificacao.Controls.Add(this.checkAcessoFinanceiro);
            this.tabIdentificacao.Controls.Add(this.checkDesativado);
            this.tabIdentificacao.Controls.Add(this.textSenhaFuncionario);
            this.tabIdentificacao.Controls.Add(this.label8);
            this.tabIdentificacao.Controls.Add(this.textCodigoFuncionario);
            this.tabIdentificacao.Controls.Add(this.textNomeFuncionario);
            this.tabIdentificacao.Controls.Add(this.label12);
            this.tabIdentificacao.Location = new System.Drawing.Point(4, 24);
            this.tabIdentificacao.Name = "tabIdentificacao";
            this.tabIdentificacao.Padding = new System.Windows.Forms.Padding(3);
            this.tabIdentificacao.Size = new System.Drawing.Size(718, 207);
            this.tabIdentificacao.TabIndex = 0;
            this.tabIdentificacao.Text = "Identificação";
            this.tabIdentificacao.UseVisualStyleBackColor = true;
            // 
            // checkAcessoFiscal
            // 
            this.checkAcessoFiscal.AutoSize = true;
            this.checkAcessoFiscal.Location = new System.Drawing.Point(228, 36);
            this.checkAcessoFiscal.Name = "checkAcessoFiscal";
            this.checkAcessoFiscal.Size = new System.Drawing.Size(95, 19);
            this.checkAcessoFiscal.TabIndex = 4;
            this.checkAcessoFiscal.Text = "Acesso Fiscal";
            this.checkAcessoFiscal.UseVisualStyleBackColor = true;
            // 
            // checkAcessoFinanceiro
            // 
            this.checkAcessoFinanceiro.AutoSize = true;
            this.checkAcessoFinanceiro.Location = new System.Drawing.Point(327, 36);
            this.checkAcessoFinanceiro.Name = "checkAcessoFinanceiro";
            this.checkAcessoFinanceiro.Size = new System.Drawing.Size(121, 19);
            this.checkAcessoFinanceiro.TabIndex = 5;
            this.checkAcessoFinanceiro.Text = "Acesso Financeiro";
            this.checkAcessoFinanceiro.UseVisualStyleBackColor = true;
            // 
            // checkDesativado
            // 
            this.checkDesativado.AutoSize = true;
            this.checkDesativado.Location = new System.Drawing.Point(626, 36);
            this.checkDesativado.Name = "checkDesativado";
            this.checkDesativado.Size = new System.Drawing.Size(84, 19);
            this.checkDesativado.TabIndex = 6;
            this.checkDesativado.Text = "Desativado";
            this.checkDesativado.UseVisualStyleBackColor = true;
            // 
            // textSenhaFuncionario
            // 
            this.textSenhaFuncionario.Location = new System.Drawing.Point(68, 34);
            this.textSenhaFuncionario.Name = "textSenhaFuncionario";
            this.textSenhaFuncionario.PasswordChar = '*';
            this.textSenhaFuncionario.Size = new System.Drawing.Size(140, 23);
            this.textSenhaFuncionario.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 15);
            this.label8.TabIndex = 72;
            this.label8.Text = "Senha:";
            // 
            // textCodigoFuncionario
            // 
            this.textCodigoFuncionario.Location = new System.Drawing.Point(68, 7);
            this.textCodigoFuncionario.Name = "textCodigoFuncionario";
            this.textCodigoFuncionario.ReadOnly = true;
            this.textCodigoFuncionario.Size = new System.Drawing.Size(59, 23);
            this.textCodigoFuncionario.TabIndex = 1;
            // 
            // textNomeFuncionario
            // 
            this.textNomeFuncionario.Location = new System.Drawing.Point(131, 7);
            this.textNomeFuncionario.Name = "textNomeFuncionario";
            this.textNomeFuncionario.Size = new System.Drawing.Size(579, 23);
            this.textNomeFuncionario.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 15);
            this.label12.TabIndex = 53;
            this.label12.Text = "Nome:";
            // 
            // pnlMenuBotao
            // 
            this.pnlMenuBotao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlMenuBotao.Controls.Add(this.pnlMenuBotaoBotao);
            this.pnlMenuBotao.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenuBotao.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuBotao.Name = "pnlMenuBotao";
            this.pnlMenuBotao.Size = new System.Drawing.Size(726, 83);
            this.pnlMenuBotao.TabIndex = 11;
            // 
            // pnlMenuBotaoBotao
            // 
            this.pnlMenuBotaoBotao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlMenuBotaoBotao.Controls.Add(this.botaoAnterior);
            this.pnlMenuBotaoBotao.Controls.Add(this.botaoPosterior);
            this.pnlMenuBotaoBotao.Controls.Add(this.label7);
            this.pnlMenuBotaoBotao.Controls.Add(this.label6);
            this.pnlMenuBotaoBotao.Controls.Add(this.label5);
            this.pnlMenuBotaoBotao.Controls.Add(this.botaoFechar);
            this.pnlMenuBotaoBotao.Controls.Add(this.botaoNovo);
            this.pnlMenuBotaoBotao.Controls.Add(this.botaoExcluir);
            this.pnlMenuBotaoBotao.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMenuBotaoBotao.Location = new System.Drawing.Point(248, 0);
            this.pnlMenuBotaoBotao.Name = "pnlMenuBotaoBotao";
            this.pnlMenuBotaoBotao.Size = new System.Drawing.Size(478, 83);
            this.pnlMenuBotaoBotao.TabIndex = 2;
            // 
            // botaoAnterior
            // 
            this.botaoAnterior.Image = ((System.Drawing.Image)(resources.GetObject("botaoAnterior.Image")));
            this.botaoAnterior.Location = new System.Drawing.Point(213, 0);
            this.botaoAnterior.Name = "botaoAnterior";
            this.botaoAnterior.Size = new System.Drawing.Size(53, 56);
            this.botaoAnterior.TabIndex = 32;
            this.botaoAnterior.TabStop = false;
            this.botaoAnterior.UseVisualStyleBackColor = true;
            this.botaoAnterior.Click += new System.EventHandler(this.botaoAnterior_Click);
            // 
            // botaoPosterior
            // 
            this.botaoPosterior.Image = ((System.Drawing.Image)(resources.GetObject("botaoPosterior.Image")));
            this.botaoPosterior.Location = new System.Drawing.Point(265, 0);
            this.botaoPosterior.Name = "botaoPosterior";
            this.botaoPosterior.Size = new System.Drawing.Size(53, 56);
            this.botaoPosterior.TabIndex = 31;
            this.botaoPosterior.TabStop = false;
            this.botaoPosterior.UseVisualStyleBackColor = true;
            this.botaoPosterior.Click += new System.EventHandler(this.botaoPosterior_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(433, 56);
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
            this.label6.Location = new System.Drawing.Point(383, 56);
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
            this.label5.Location = new System.Drawing.Point(328, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 12);
            this.label5.TabIndex = 27;
            this.label5.Text = "Excluir";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // botaoFechar
            // 
            this.botaoFechar.Image = ((System.Drawing.Image)(resources.GetObject("botaoFechar.Image")));
            this.botaoFechar.Location = new System.Drawing.Point(424, 0);
            this.botaoFechar.Name = "botaoFechar";
            this.botaoFechar.Size = new System.Drawing.Size(53, 56);
            this.botaoFechar.TabIndex = 20;
            this.botaoFechar.TabStop = false;
            this.botaoFechar.UseVisualStyleBackColor = true;
            this.botaoFechar.Click += new System.EventHandler(this.botaoFechar_Click);
            // 
            // botaoNovo
            // 
            this.botaoNovo.Image = ((System.Drawing.Image)(resources.GetObject("botaoNovo.Image")));
            this.botaoNovo.Location = new System.Drawing.Point(371, 0);
            this.botaoNovo.Name = "botaoNovo";
            this.botaoNovo.Size = new System.Drawing.Size(53, 56);
            this.botaoNovo.TabIndex = 19;
            this.botaoNovo.TabStop = false;
            this.botaoNovo.UseVisualStyleBackColor = true;
            this.botaoNovo.Click += new System.EventHandler(this.botaoNovo_Click);
            // 
            // botaoExcluir
            // 
            this.botaoExcluir.Image = ((System.Drawing.Image)(resources.GetObject("botaoExcluir.Image")));
            this.botaoExcluir.Location = new System.Drawing.Point(318, 0);
            this.botaoExcluir.Name = "botaoExcluir";
            this.botaoExcluir.Size = new System.Drawing.Size(53, 56);
            this.botaoExcluir.TabIndex = 18;
            this.botaoExcluir.TabStop = false;
            this.botaoExcluir.UseVisualStyleBackColor = true;
            this.botaoExcluir.Click += new System.EventHandler(this.botaoExcluir_Click);
            // 
            // frmCadastroFuncionarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 318);
            this.Controls.Add(this.tabEnderecos);
            this.Controls.Add(this.pnlMenuBotao);
            this.Name = "frmCadastroFuncionarios";
            this.Text = "Cadastro de Funcionários";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCadastroFuncionarios_FormClosing);
            this.tabEnderecos.ResumeLayout(false);
            this.tabIdentificacao.ResumeLayout(false);
            this.tabIdentificacao.PerformLayout();
            this.pnlMenuBotao.ResumeLayout(false);
            this.pnlMenuBotaoBotao.ResumeLayout(false);
            this.pnlMenuBotaoBotao.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabEnderecos;
        private System.Windows.Forms.TabPage tabIdentificacao;
        private System.Windows.Forms.Panel pnlMenuBotao;
        private System.Windows.Forms.Panel pnlMenuBotaoBotao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button botaoFechar;
        private System.Windows.Forms.Button botaoNovo;
        private System.Windows.Forms.Button botaoExcluir;
        private System.Windows.Forms.Button botaoPosterior;
        private System.Windows.Forms.Button botaoAnterior;
        private System.Windows.Forms.TextBox textCodigoFuncionario;
        private System.Windows.Forms.TextBox textNomeFuncionario;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textSenhaFuncionario;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkAcessoFiscal;
        private System.Windows.Forms.CheckBox checkAcessoFinanceiro;
        private System.Windows.Forms.CheckBox checkDesativado;
    }
}