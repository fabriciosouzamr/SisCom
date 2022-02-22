
namespace SisCom.Aplicacao.Formularios
{
    partial class frmCadastro
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
            this.cmdEmpresas = new System.Windows.Forms.Button();
            this.cmdConfiguracoesGerais = new System.Windows.Forms.Button();
            this.cmdTransportadoras = new System.Windows.Forms.Button();
            this.cmdFuncionarioPermissoes = new System.Windows.Forms.Button();
            this.cmdClientes = new System.Windows.Forms.Button();
            this.cmdMercadorias = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdEmpresas
            // 
            this.cmdEmpresas.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmdEmpresas.Location = new System.Drawing.Point(5, 244);
            this.cmdEmpresas.Name = "cmdEmpresas";
            this.cmdEmpresas.Size = new System.Drawing.Size(256, 40);
            this.cmdEmpresas.TabIndex = 11;
            this.cmdEmpresas.Text = "Empresas";
            this.cmdEmpresas.UseVisualStyleBackColor = true;
            this.cmdEmpresas.Click += new System.EventHandler(this.cmdEmpresas_Click);
            // 
            // cmdConfiguracoesGerais
            // 
            this.cmdConfiguracoesGerais.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmdConfiguracoesGerais.Location = new System.Drawing.Point(5, 196);
            this.cmdConfiguracoesGerais.Name = "cmdConfiguracoesGerais";
            this.cmdConfiguracoesGerais.Size = new System.Drawing.Size(256, 40);
            this.cmdConfiguracoesGerais.TabIndex = 10;
            this.cmdConfiguracoesGerais.Text = "Configurações Gerais";
            this.cmdConfiguracoesGerais.UseVisualStyleBackColor = true;
            this.cmdConfiguracoesGerais.Click += new System.EventHandler(this.cmdConfiguracoesGerais_Click);
            // 
            // cmdTransportadoras
            // 
            this.cmdTransportadoras.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmdTransportadoras.Location = new System.Drawing.Point(5, 148);
            this.cmdTransportadoras.Name = "cmdTransportadoras";
            this.cmdTransportadoras.Size = new System.Drawing.Size(256, 40);
            this.cmdTransportadoras.TabIndex = 9;
            this.cmdTransportadoras.Text = "Transportadoras";
            this.cmdTransportadoras.UseVisualStyleBackColor = true;
            this.cmdTransportadoras.Click += new System.EventHandler(this.cmdTransportadoras_Click);
            // 
            // cmdFuncionarioPermissoes
            // 
            this.cmdFuncionarioPermissoes.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmdFuncionarioPermissoes.Location = new System.Drawing.Point(5, 100);
            this.cmdFuncionarioPermissoes.Name = "cmdFuncionarioPermissoes";
            this.cmdFuncionarioPermissoes.Size = new System.Drawing.Size(256, 40);
            this.cmdFuncionarioPermissoes.TabIndex = 8;
            this.cmdFuncionarioPermissoes.Text = "Funcionário/Permissões";
            this.cmdFuncionarioPermissoes.UseVisualStyleBackColor = true;
            this.cmdFuncionarioPermissoes.Click += new System.EventHandler(this.cmdFuncionarioPermissoes_Click);
            // 
            // cmdClientes
            // 
            this.cmdClientes.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmdClientes.Location = new System.Drawing.Point(5, 52);
            this.cmdClientes.Name = "cmdClientes";
            this.cmdClientes.Size = new System.Drawing.Size(256, 40);
            this.cmdClientes.TabIndex = 7;
            this.cmdClientes.Text = "Clientes";
            this.cmdClientes.UseVisualStyleBackColor = true;
            this.cmdClientes.Click += new System.EventHandler(this.cmdClientes_Click);
            // 
            // cmdMercadorias
            // 
            this.cmdMercadorias.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmdMercadorias.Location = new System.Drawing.Point(5, 4);
            this.cmdMercadorias.Name = "cmdMercadorias";
            this.cmdMercadorias.Size = new System.Drawing.Size(256, 40);
            this.cmdMercadorias.TabIndex = 6;
            this.cmdMercadorias.Text = "Mercadorias";
            this.cmdMercadorias.UseVisualStyleBackColor = true;
            this.cmdMercadorias.Click += new System.EventHandler(this.cmdMercadorias_Click);
            // 
            // frmCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 289);
            this.Controls.Add(this.cmdEmpresas);
            this.Controls.Add(this.cmdConfiguracoesGerais);
            this.Controls.Add(this.cmdTransportadoras);
            this.Controls.Add(this.cmdFuncionarioPermissoes);
            this.Controls.Add(this.cmdClientes);
            this.Controls.Add(this.cmdMercadorias);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCadastro";
            this.Text = "Cadastros";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdEmpresas;
        private System.Windows.Forms.Button cmdConfiguracoesGerais;
        private System.Windows.Forms.Button cmdTransportadoras;
        private System.Windows.Forms.Button cmdFuncionarioPermissoes;
        private System.Windows.Forms.Button cmdClientes;
        private System.Windows.Forms.Button cmdMercadorias;
    }
}