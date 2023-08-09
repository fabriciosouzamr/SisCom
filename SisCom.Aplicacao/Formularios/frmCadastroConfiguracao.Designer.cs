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
            pnlMenuBotao = new System.Windows.Forms.Panel();
            pnlMenuBotaoBotao = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            botaoGravar = new System.Windows.Forms.Button();
            label7 = new System.Windows.Forms.Label();
            botaoFechar = new System.Windows.Forms.Button();
            tabControl = new System.Windows.Forms.TabControl();
            tabPais = new System.Windows.Forms.TabPage();
            dataPais = new System.Windows.Forms.DataGridView();
            tabUnidadeMedida = new System.Windows.Forms.TabPage();
            dataUnidadeMedida = new System.Windows.Forms.DataGridView();
            tabEstadoIcms = new System.Windows.Forms.TabPage();
            dataEstadoIcms = new System.Windows.Forms.DataGridView();
            pnlMenuBotao.SuspendLayout();
            pnlMenuBotaoBotao.SuspendLayout();
            tabControl.SuspendLayout();
            tabPais.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataPais).BeginInit();
            tabUnidadeMedida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataUnidadeMedida).BeginInit();
            tabEstadoIcms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataEstadoIcms).BeginInit();
            SuspendLayout();
            // 
            // pnlMenuBotao
            // 
            pnlMenuBotao.BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
            pnlMenuBotao.Controls.Add(pnlMenuBotaoBotao);
            pnlMenuBotao.Dock = System.Windows.Forms.DockStyle.Top;
            pnlMenuBotao.Location = new System.Drawing.Point(0, 0);
            pnlMenuBotao.Name = "pnlMenuBotao";
            pnlMenuBotao.Size = new System.Drawing.Size(1275, 72);
            pnlMenuBotao.TabIndex = 9;
            // 
            // pnlMenuBotaoBotao
            // 
            pnlMenuBotaoBotao.BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
            pnlMenuBotaoBotao.Controls.Add(label1);
            pnlMenuBotaoBotao.Controls.Add(botaoGravar);
            pnlMenuBotaoBotao.Controls.Add(label7);
            pnlMenuBotaoBotao.Controls.Add(botaoFechar);
            pnlMenuBotaoBotao.Dock = System.Windows.Forms.DockStyle.Right;
            pnlMenuBotaoBotao.Location = new System.Drawing.Point(797, 0);
            pnlMenuBotaoBotao.Name = "pnlMenuBotaoBotao";
            pnlMenuBotaoBotao.Size = new System.Drawing.Size(478, 72);
            pnlMenuBotaoBotao.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(381, 56);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(33, 12);
            label1.TabIndex = 35;
            label1.Text = "Gravar";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // botaoGravar
            // 
            botaoGravar.Image = (System.Drawing.Image)resources.GetObject("botaoGravar.Image");
            botaoGravar.Location = new System.Drawing.Point(371, 0);
            botaoGravar.Name = "botaoGravar";
            botaoGravar.Size = new System.Drawing.Size(53, 56);
            botaoGravar.TabIndex = 34;
            botaoGravar.UseVisualStyleBackColor = true;
            botaoGravar.Click += botaoGravar_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label7.Location = new System.Drawing.Point(433, 56);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(34, 12);
            label7.TabIndex = 29;
            label7.Text = "Fechar";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // botaoFechar
            // 
            botaoFechar.Image = (System.Drawing.Image)resources.GetObject("botaoFechar.Image");
            botaoFechar.Location = new System.Drawing.Point(424, 0);
            botaoFechar.Name = "botaoFechar";
            botaoFechar.Size = new System.Drawing.Size(53, 56);
            botaoFechar.TabIndex = 20;
            botaoFechar.UseVisualStyleBackColor = true;
            botaoFechar.Click += botaoFechar_Click;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPais);
            tabControl.Controls.Add(tabUnidadeMedida);
            tabControl.Controls.Add(tabEstadoIcms);
            tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl.Location = new System.Drawing.Point(0, 72);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(1275, 584);
            tabControl.TabIndex = 10;
            // 
            // tabPais
            // 
            tabPais.Controls.Add(dataPais);
            tabPais.Location = new System.Drawing.Point(4, 24);
            tabPais.Name = "tabPais";
            tabPais.Padding = new System.Windows.Forms.Padding(3);
            tabPais.Size = new System.Drawing.Size(1267, 556);
            tabPais.TabIndex = 1;
            tabPais.Text = "País";
            tabPais.UseVisualStyleBackColor = true;
            // 
            // dataPais
            // 
            dataPais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataPais.Dock = System.Windows.Forms.DockStyle.Fill;
            dataPais.Location = new System.Drawing.Point(3, 3);
            dataPais.Name = "dataPais";
            dataPais.RowTemplate.Height = 25;
            dataPais.Size = new System.Drawing.Size(1261, 550);
            dataPais.TabIndex = 1;
            dataPais.UserDeletingRow += dataPais_UserDeletingRow;
            // 
            // tabUnidadeMedida
            // 
            tabUnidadeMedida.Controls.Add(dataUnidadeMedida);
            tabUnidadeMedida.Location = new System.Drawing.Point(4, 24);
            tabUnidadeMedida.Name = "tabUnidadeMedida";
            tabUnidadeMedida.Padding = new System.Windows.Forms.Padding(3);
            tabUnidadeMedida.Size = new System.Drawing.Size(1267, 556);
            tabUnidadeMedida.TabIndex = 0;
            tabUnidadeMedida.Text = "Unidade de Medida";
            tabUnidadeMedida.UseVisualStyleBackColor = true;
            // 
            // dataUnidadeMedida
            // 
            dataUnidadeMedida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataUnidadeMedida.Dock = System.Windows.Forms.DockStyle.Fill;
            dataUnidadeMedida.Location = new System.Drawing.Point(3, 3);
            dataUnidadeMedida.Name = "dataUnidadeMedida";
            dataUnidadeMedida.RowTemplate.Height = 25;
            dataUnidadeMedida.Size = new System.Drawing.Size(1261, 550);
            dataUnidadeMedida.TabIndex = 0;
            dataUnidadeMedida.UserDeletingRow += dataUnidadeMedida_UserDeletingRow;
            // 
            // tabEstadoIcms
            // 
            tabEstadoIcms.Controls.Add(dataEstadoIcms);
            tabEstadoIcms.Location = new System.Drawing.Point(4, 24);
            tabEstadoIcms.Name = "tabEstadoIcms";
            tabEstadoIcms.Padding = new System.Windows.Forms.Padding(3);
            tabEstadoIcms.Size = new System.Drawing.Size(1267, 556);
            tabEstadoIcms.TabIndex = 2;
            tabEstadoIcms.Text = "Estados Icms";
            tabEstadoIcms.UseVisualStyleBackColor = true;
            // 
            // dataEstadoIcms
            // 
            dataEstadoIcms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataEstadoIcms.Dock = System.Windows.Forms.DockStyle.Fill;
            dataEstadoIcms.Location = new System.Drawing.Point(3, 3);
            dataEstadoIcms.Name = "dataEstadoIcms";
            dataEstadoIcms.RowTemplate.Height = 25;
            dataEstadoIcms.Size = new System.Drawing.Size(1261, 550);
            dataEstadoIcms.TabIndex = 1;
            // 
            // frmCadastroConfiguracao
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1275, 656);
            Controls.Add(tabControl);
            Controls.Add(pnlMenuBotao);
            Name = "frmCadastroConfiguracao";
            Text = "Cadastro - Configuração";
            pnlMenuBotao.ResumeLayout(false);
            pnlMenuBotaoBotao.ResumeLayout(false);
            pnlMenuBotaoBotao.PerformLayout();
            tabControl.ResumeLayout(false);
            tabPais.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataPais).EndInit();
            tabUnidadeMedida.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataUnidadeMedida).EndInit();
            tabEstadoIcms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataEstadoIcms).EndInit();
            ResumeLayout(false);
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
        private System.Windows.Forms.TabPage tabEstadoIcms;
        private System.Windows.Forms.DataGridView dataEstadoIcms;
    }
}