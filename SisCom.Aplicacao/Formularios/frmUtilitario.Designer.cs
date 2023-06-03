namespace SisCom.Aplicacao.Formularios
{
    partial class frmUtilitario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUtilitario));
            this.pnlMenuBotao = new System.Windows.Forms.Panel();
            this.pnlMenuBotaoBotao = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.botaoGravar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.botaoFechar = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tbpImportarCliente = new System.Windows.Forms.TabPage();
            this.botaoImportarCliente_Processar = new System.Windows.Forms.Button();
            this.botaoImportarCliente_MDB = new System.Windows.Forms.Button();
            this.textImportarCliente_MDB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlMenuBotao.SuspendLayout();
            this.pnlMenuBotaoBotao.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tbpImportarCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenuBotao
            // 
            this.pnlMenuBotao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlMenuBotao.Controls.Add(this.pnlMenuBotaoBotao);
            this.pnlMenuBotao.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenuBotao.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuBotao.Name = "pnlMenuBotao";
            this.pnlMenuBotao.Size = new System.Drawing.Size(980, 72);
            this.pnlMenuBotao.TabIndex = 11;
            // 
            // pnlMenuBotaoBotao
            // 
            this.pnlMenuBotaoBotao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlMenuBotaoBotao.Controls.Add(this.label1);
            this.pnlMenuBotaoBotao.Controls.Add(this.botaoGravar);
            this.pnlMenuBotaoBotao.Controls.Add(this.label7);
            this.pnlMenuBotaoBotao.Controls.Add(this.botaoFechar);
            this.pnlMenuBotaoBotao.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMenuBotaoBotao.Location = new System.Drawing.Point(502, 0);
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
            this.tabControl.Controls.Add(this.tbpImportarCliente);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 72);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(980, 340);
            this.tabControl.TabIndex = 12;
            // 
            // tbpImportarCliente
            // 
            this.tbpImportarCliente.Controls.Add(this.botaoImportarCliente_Processar);
            this.tbpImportarCliente.Controls.Add(this.botaoImportarCliente_MDB);
            this.tbpImportarCliente.Controls.Add(this.textImportarCliente_MDB);
            this.tbpImportarCliente.Controls.Add(this.label3);
            this.tbpImportarCliente.Location = new System.Drawing.Point(4, 24);
            this.tbpImportarCliente.Name = "tbpImportarCliente";
            this.tbpImportarCliente.Padding = new System.Windows.Forms.Padding(3);
            this.tbpImportarCliente.Size = new System.Drawing.Size(972, 312);
            this.tbpImportarCliente.TabIndex = 0;
            this.tbpImportarCliente.Text = "Importar Cliente";
            this.tbpImportarCliente.UseVisualStyleBackColor = true;
            // 
            // botaoImportarCliente_Processar
            // 
            this.botaoImportarCliente_Processar.Location = new System.Drawing.Point(644, 6);
            this.botaoImportarCliente_Processar.Name = "botaoImportarCliente_Processar";
            this.botaoImportarCliente_Processar.Size = new System.Drawing.Size(75, 23);
            this.botaoImportarCliente_Processar.TabIndex = 410;
            this.botaoImportarCliente_Processar.Text = "Processar";
            this.botaoImportarCliente_Processar.UseVisualStyleBackColor = true;
            this.botaoImportarCliente_Processar.Click += new System.EventHandler(this.botaoImportarCliente_Processar_Click);
            // 
            // botaoImportarCliente_MDB
            // 
            this.botaoImportarCliente_MDB.Location = new System.Drawing.Point(611, 6);
            this.botaoImportarCliente_MDB.Name = "botaoImportarCliente_MDB";
            this.botaoImportarCliente_MDB.Size = new System.Drawing.Size(23, 23);
            this.botaoImportarCliente_MDB.TabIndex = 408;
            this.botaoImportarCliente_MDB.UseVisualStyleBackColor = true;
            this.botaoImportarCliente_MDB.Click += new System.EventHandler(this.botaoNuvemFiscalDiretorioXMLs_Click);
            // 
            // textImportarCliente_MDB
            // 
            this.textImportarCliente_MDB.Location = new System.Drawing.Point(86, 6);
            this.textImportarCliente_MDB.MaxLength = 200;
            this.textImportarCliente_MDB.Name = "textImportarCliente_MDB";
            this.textImportarCliente_MDB.Size = new System.Drawing.Size(523, 23);
            this.textImportarCliente_MDB.TabIndex = 409;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 15);
            this.label3.TabIndex = 407;
            this.label3.Text = "Arquivo MDB";
            // 
            // frmUtilitario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 412);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pnlMenuBotao);
            this.Name = "frmUtilitario";
            this.Text = "Utilitário";
            this.pnlMenuBotao.ResumeLayout(false);
            this.pnlMenuBotaoBotao.ResumeLayout(false);
            this.pnlMenuBotaoBotao.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tbpImportarCliente.ResumeLayout(false);
            this.tbpImportarCliente.PerformLayout();
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
        private System.Windows.Forms.TabPage tbpImportarCliente;
        private System.Windows.Forms.Button botaoImportarCliente_MDB;
        private System.Windows.Forms.TextBox textImportarCliente_MDB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button botaoImportarCliente_Processar;
    }
}