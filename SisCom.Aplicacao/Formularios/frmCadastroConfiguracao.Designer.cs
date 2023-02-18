namespace SisCom.Aplicacao
{
    partial class frmCadastroConfiguracao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroConfiguracao));
            this.pnlMenuBotao = new System.Windows.Forms.Panel();
            this.pnlMenuBotaoBotao = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.botaoGravar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.botaoFechar = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPais = new System.Windows.Forms.TabPage();
            this.dataPais = new System.Windows.Forms.DataGridView();
            this.tabUnidadeMedida = new System.Windows.Forms.TabPage();
            this.dataUnidadeMedida = new System.Windows.Forms.DataGridView();
            this.pnlMenuBotao.SuspendLayout();
            this.pnlMenuBotaoBotao.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPais.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataPais)).BeginInit();
            this.tabUnidadeMedida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataUnidadeMedida)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMenuBotao
            // 
            this.pnlMenuBotao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlMenuBotao.Controls.Add(this.pnlMenuBotaoBotao);
            this.pnlMenuBotao.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenuBotao.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuBotao.Name = "pnlMenuBotao";
            this.pnlMenuBotao.Size = new System.Drawing.Size(1275, 72);
            this.pnlMenuBotao.TabIndex = 9;
            // 
            // pnlMenuBotaoBotao
            // 
            this.pnlMenuBotaoBotao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlMenuBotaoBotao.Controls.Add(this.label1);
            this.pnlMenuBotaoBotao.Controls.Add(this.botaoGravar);
            this.pnlMenuBotaoBotao.Controls.Add(this.label7);
            this.pnlMenuBotaoBotao.Controls.Add(this.botaoFechar);
            this.pnlMenuBotaoBotao.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMenuBotaoBotao.Location = new System.Drawing.Point(797, 0);
            this.pnlMenuBotaoBotao.Name = "pnlMenuBotaoBotao";
            this.pnlMenuBotaoBotao.Size = new System.Drawing.Size(478, 72);
            this.pnlMenuBotaoBotao.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(381, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 12);
            this.label1.TabIndex = 35;
            this.label1.Text = "Gravar";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // botaoGravar
            // 
            this.botaoGravar.Image = ((System.Drawing.Image)(resources.GetObject("botaoGravar.Image")));
            this.botaoGravar.Location = new System.Drawing.Point(371, 0);
            this.botaoGravar.Name = "botaoGravar";
            this.botaoGravar.Size = new System.Drawing.Size(53, 56);
            this.botaoGravar.TabIndex = 34;
            this.botaoGravar.UseVisualStyleBackColor = true;
            this.botaoGravar.Click += new System.EventHandler(this.botaoGravar_Click);
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
            // botaoFechar
            // 
            this.botaoFechar.Image = ((System.Drawing.Image)(resources.GetObject("botaoFechar.Image")));
            this.botaoFechar.Location = new System.Drawing.Point(424, 0);
            this.botaoFechar.Name = "botaoFechar";
            this.botaoFechar.Size = new System.Drawing.Size(53, 56);
            this.botaoFechar.TabIndex = 20;
            this.botaoFechar.UseVisualStyleBackColor = true;
            this.botaoFechar.Click += new System.EventHandler(this.botaoFechar_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPais);
            this.tabControl.Controls.Add(this.tabUnidadeMedida);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 72);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1275, 584);
            this.tabControl.TabIndex = 10;
            // 
            // tabPais
            // 
            this.tabPais.Controls.Add(this.dataPais);
            this.tabPais.Location = new System.Drawing.Point(4, 24);
            this.tabPais.Name = "tabPais";
            this.tabPais.Padding = new System.Windows.Forms.Padding(3);
            this.tabPais.Size = new System.Drawing.Size(1267, 556);
            this.tabPais.TabIndex = 1;
            this.tabPais.Text = "País";
            this.tabPais.UseVisualStyleBackColor = true;
            // 
            // dataPais
            // 
            this.dataPais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataPais.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataPais.Location = new System.Drawing.Point(3, 3);
            this.dataPais.Name = "dataPais";
            this.dataPais.RowTemplate.Height = 25;
            this.dataPais.Size = new System.Drawing.Size(1261, 550);
            this.dataPais.TabIndex = 1;
            this.dataPais.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataPais_UserDeletingRow);
            // 
            // tabUnidadeMedida
            // 
            this.tabUnidadeMedida.Controls.Add(this.dataUnidadeMedida);
            this.tabUnidadeMedida.Location = new System.Drawing.Point(4, 24);
            this.tabUnidadeMedida.Name = "tabUnidadeMedida";
            this.tabUnidadeMedida.Padding = new System.Windows.Forms.Padding(3);
            this.tabUnidadeMedida.Size = new System.Drawing.Size(1267, 556);
            this.tabUnidadeMedida.TabIndex = 0;
            this.tabUnidadeMedida.Text = "Unidade de Medida";
            this.tabUnidadeMedida.UseVisualStyleBackColor = true;
            // 
            // dataUnidadeMedida
            // 
            this.dataUnidadeMedida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataUnidadeMedida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataUnidadeMedida.Location = new System.Drawing.Point(3, 3);
            this.dataUnidadeMedida.Name = "dataUnidadeMedida";
            this.dataUnidadeMedida.RowTemplate.Height = 25;
            this.dataUnidadeMedida.Size = new System.Drawing.Size(1261, 550);
            this.dataUnidadeMedida.TabIndex = 0;
            this.dataUnidadeMedida.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataUnidadeMedida_UserDeletingRow);
            // 
            // frmCadastroConfiguracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 656);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pnlMenuBotao);
            this.Name = "frmCadastroConfiguracao";
            this.Text = "Cadastro - Configuração";
            this.pnlMenuBotao.ResumeLayout(false);
            this.pnlMenuBotaoBotao.ResumeLayout(false);
            this.pnlMenuBotaoBotao.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPais.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataPais)).EndInit();
            this.tabUnidadeMedida.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataUnidadeMedida)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenuBotao;
        private System.Windows.Forms.Panel pnlMenuBotaoBotao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botaoGravar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button botaoFechar;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabUnidadeMedida;
        private System.Windows.Forms.TabPage tabPais;
        private System.Windows.Forms.DataGridView dataUnidadeMedida;
        private System.Windows.Forms.DataGridView dataPais;
    }
}