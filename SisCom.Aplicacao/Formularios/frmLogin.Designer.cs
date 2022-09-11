namespace SisCom.Aplicacao.Formularios
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.cmdEntrar = new System.Windows.Forms.Button();
            this.cmdSair = new System.Windows.Forms.Button();
            this.textSenha = new System.Windows.Forms.TextBox();
            this.comboUsuario = new System.Windows.Forms.ComboBox();
            this.comboEmpresa = new System.Windows.Forms.ComboBox();
            this.pnlLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLogin
            // 
            this.pnlLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlLogin.BackgroundImage")));
            this.pnlLogin.Controls.Add(this.comboEmpresa);
            this.pnlLogin.Controls.Add(this.cmdEntrar);
            this.pnlLogin.Controls.Add(this.cmdSair);
            this.pnlLogin.Controls.Add(this.textSenha);
            this.pnlLogin.Controls.Add(this.comboUsuario);
            this.pnlLogin.Location = new System.Drawing.Point(214, 235);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(471, 322);
            this.pnlLogin.TabIndex = 0;
            // 
            // cmdEntrar
            // 
            this.cmdEntrar.Image = ((System.Drawing.Image)(resources.GetObject("cmdEntrar.Image")));
            this.cmdEntrar.Location = new System.Drawing.Point(250, 210);
            this.cmdEntrar.Name = "cmdEntrar";
            this.cmdEntrar.Size = new System.Drawing.Size(168, 50);
            this.cmdEntrar.TabIndex = 3;
            this.cmdEntrar.UseVisualStyleBackColor = true;
            this.cmdEntrar.Click += new System.EventHandler(this.cmdEntrar_Click);
            // 
            // cmdSair
            // 
            this.cmdSair.Image = ((System.Drawing.Image)(resources.GetObject("cmdSair.Image")));
            this.cmdSair.Location = new System.Drawing.Point(46, 210);
            this.cmdSair.Name = "cmdSair";
            this.cmdSair.Size = new System.Drawing.Size(168, 50);
            this.cmdSair.TabIndex = 2;
            this.cmdSair.UseVisualStyleBackColor = true;
            this.cmdSair.Click += new System.EventHandler(this.cmdSair_Click);
            // 
            // textSenha
            // 
            this.textSenha.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textSenha.Location = new System.Drawing.Point(128, 110);
            this.textSenha.Name = "textSenha";
            this.textSenha.PasswordChar = '*';
            this.textSenha.Size = new System.Drawing.Size(314, 34);
            this.textSenha.TabIndex = 1;
            // 
            // comboUsuario
            // 
            this.comboUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboUsuario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboUsuario.FormattingEnabled = true;
            this.comboUsuario.Location = new System.Drawing.Point(128, 64);
            this.comboUsuario.Name = "comboUsuario";
            this.comboUsuario.Size = new System.Drawing.Size(314, 36);
            this.comboUsuario.TabIndex = 0;
            // 
            // comboEmpresa
            // 
            this.comboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEmpresa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboEmpresa.FormattingEnabled = true;
            this.comboEmpresa.Location = new System.Drawing.Point(128, 153);
            this.comboEmpresa.Name = "comboEmpresa";
            this.comboEmpresa.Size = new System.Drawing.Size(314, 36);
            this.comboEmpresa.TabIndex = 4;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1446, 739);
            this.Controls.Add(this.pnlLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.Text = "Acesso";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.frmLogin_Resize);
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.ComboBox comboUsuario;
        private System.Windows.Forms.TextBox textSenha;
        private System.Windows.Forms.Button cmdSair;
        private System.Windows.Forms.Button cmdEntrar;
        private System.Windows.Forms.ComboBox comboEmpresa;
    }
}