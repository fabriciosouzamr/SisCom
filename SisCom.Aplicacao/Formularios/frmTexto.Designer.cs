namespace SisCom.Aplicacao.Formularios
{
    partial class frmTexto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTexto));
            this.pnlMenuBotaoBotao = new System.Windows.Forms.Panel();
            this.label45 = new System.Windows.Forms.Label();
            this.botaoGravar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.botaoFechar = new System.Windows.Forms.Button();
            this.richTexto = new System.Windows.Forms.RichTextBox();
            this.pnlMenuBotaoBotao.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenuBotaoBotao
            // 
            this.pnlMenuBotaoBotao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlMenuBotaoBotao.Controls.Add(this.label45);
            this.pnlMenuBotaoBotao.Controls.Add(this.botaoGravar);
            this.pnlMenuBotaoBotao.Controls.Add(this.label7);
            this.pnlMenuBotaoBotao.Controls.Add(this.botaoFechar);
            this.pnlMenuBotaoBotao.ImeMode = System.Windows.Forms.ImeMode.On;
            this.pnlMenuBotaoBotao.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuBotaoBotao.Name = "pnlMenuBotaoBotao";
            this.pnlMenuBotaoBotao.Size = new System.Drawing.Size(811, 83);
            this.pnlMenuBotaoBotao.TabIndex = 3;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label45.Location = new System.Drawing.Point(699, 56);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(33, 12);
            this.label45.TabIndex = 65;
            this.label45.Text = "Gravar";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // botaoGravar
            // 
            this.botaoGravar.Image = ((System.Drawing.Image)(resources.GetObject("botaoGravar.Image")));
            this.botaoGravar.Location = new System.Drawing.Point(689, 0);
            this.botaoGravar.Name = "botaoGravar";
            this.botaoGravar.Size = new System.Drawing.Size(53, 56);
            this.botaoGravar.TabIndex = 64;
            this.botaoGravar.UseVisualStyleBackColor = true;
            this.botaoGravar.Click += new System.EventHandler(this.botaoGravar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(755, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 12);
            this.label7.TabIndex = 29;
            this.label7.Text = "Fechar";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // botaoFechar
            // 
            this.botaoFechar.Image = ((System.Drawing.Image)(resources.GetObject("botaoFechar.Image")));
            this.botaoFechar.Location = new System.Drawing.Point(748, 0);
            this.botaoFechar.Name = "botaoFechar";
            this.botaoFechar.Size = new System.Drawing.Size(52, 56);
            this.botaoFechar.TabIndex = 20;
            this.botaoFechar.UseVisualStyleBackColor = true;
            this.botaoFechar.Click += new System.EventHandler(this.botaoFechar_Click);
            // 
            // richTexto
            // 
            this.richTexto.Location = new System.Drawing.Point(0, 83);
            this.richTexto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTexto.Name = "richTexto";
            this.richTexto.Size = new System.Drawing.Size(812, 415);
            this.richTexto.TabIndex = 4;
            this.richTexto.Text = "";
            // 
            // frmTexto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 500);
            this.Controls.Add(this.richTexto);
            this.Controls.Add(this.pnlMenuBotaoBotao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTexto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.pnlMenuBotaoBotao.ResumeLayout(false);
            this.pnlMenuBotaoBotao.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenuBotaoBotao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button botaoFechar;
        private System.Windows.Forms.RichTextBox richTexto;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Button botaoGravar;
    }
}