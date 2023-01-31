namespace SisCom.Aplicacao.Formularios
{
    partial class frmCadastroCondutor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroCondutor));
            this.pnlMenuBotao = new System.Windows.Forms.Panel();
            this.pnlMenuBotaoBotao = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.botaoGravar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.botaoFechar = new System.Windows.Forms.Button();
            this.dataCondutor = new System.Windows.Forms.DataGridView();
            this.pnlMenuBotao.SuspendLayout();
            this.pnlMenuBotaoBotao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataCondutor)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMenuBotao
            // 
            this.pnlMenuBotao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlMenuBotao.Controls.Add(this.pnlMenuBotaoBotao);
            this.pnlMenuBotao.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenuBotao.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuBotao.Name = "pnlMenuBotao";
            this.pnlMenuBotao.Size = new System.Drawing.Size(800, 72);
            this.pnlMenuBotao.TabIndex = 10;
            // 
            // pnlMenuBotaoBotao
            // 
            this.pnlMenuBotaoBotao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlMenuBotaoBotao.Controls.Add(this.label1);
            this.pnlMenuBotaoBotao.Controls.Add(this.botaoGravar);
            this.pnlMenuBotaoBotao.Controls.Add(this.label7);
            this.pnlMenuBotaoBotao.Controls.Add(this.botaoFechar);
            this.pnlMenuBotaoBotao.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMenuBotaoBotao.Location = new System.Drawing.Point(322, 0);
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
            // dataCondutor
            // 
            this.dataCondutor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataCondutor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataCondutor.Location = new System.Drawing.Point(0, 72);
            this.dataCondutor.Name = "dataCondutor";
            this.dataCondutor.RowTemplate.Height = 25;
            this.dataCondutor.Size = new System.Drawing.Size(800, 378);
            this.dataCondutor.TabIndex = 11;
            this.dataCondutor.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataCondutor_UserDeletingRow);
            // 
            // frmCadastroCondutor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataCondutor);
            this.Controls.Add(this.pnlMenuBotao);
            this.Name = "frmCadastroCondutor";
            this.Text = "Cadastro de Condutor";
            this.pnlMenuBotao.ResumeLayout(false);
            this.pnlMenuBotaoBotao.ResumeLayout(false);
            this.pnlMenuBotaoBotao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataCondutor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenuBotao;
        private System.Windows.Forms.Panel pnlMenuBotaoBotao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botaoGravar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button botaoFechar;
        private System.Windows.Forms.DataGridView dataCondutor;
    }
}