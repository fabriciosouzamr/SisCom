namespace SisCom.Aplicacao
{
    partial class frmFiscal_NuvemFiscal_Manifestar
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
            this.label4 = new System.Windows.Forms.Label();
            this.botaoManifestar = new System.Windows.Forms.Button();
            this.gridNotaFiscal = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textJustificativa = new System.Windows.Forms.TextBox();
            this.comboTipoManifestacao = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.imgAguardandoManifestacao = new System.Windows.Forms.Panel();
            this.imgManifestadaSucesso = new System.Windows.Forms.Panel();
            this.imgManifestacaoRefeitadaSEFAZ = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gridNotaFiscal)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(479, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(248, 15);
            this.label4.TabIndex = 139;
            this.label4.Text = "Listagem de Notas a ser(em) Manifestada(s)";
            // 
            // botaoManifestar
            // 
            this.botaoManifestar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.botaoManifestar.Location = new System.Drawing.Point(996, 398);
            this.botaoManifestar.Name = "botaoManifestar";
            this.botaoManifestar.Size = new System.Drawing.Size(200, 60);
            this.botaoManifestar.TabIndex = 138;
            this.botaoManifestar.TabStop = false;
            this.botaoManifestar.Text = "Confirmar Manifestação";
            this.botaoManifestar.UseVisualStyleBackColor = true;
            this.botaoManifestar.Click += new System.EventHandler(this.botaoManifestar_Click);
            // 
            // gridNotaFiscal
            // 
            this.gridNotaFiscal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridNotaFiscal.Location = new System.Drawing.Point(11, 28);
            this.gridNotaFiscal.Name = "gridNotaFiscal";
            this.gridNotaFiscal.RowTemplate.Height = 25;
            this.gridNotaFiscal.Size = new System.Drawing.Size(1185, 328);
            this.gridNotaFiscal.TabIndex = 137;
            this.gridNotaFiscal.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 402);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 15);
            this.label1.TabIndex = 140;
            this.label1.Text = "Tipo de Manifestação:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 433);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 141;
            this.label2.Text = "Justificativa:";
            // 
            // textJustificativa
            // 
            this.textJustificativa.Location = new System.Drawing.Point(239, 429);
            this.textJustificativa.Name = "textJustificativa";
            this.textJustificativa.Size = new System.Drawing.Size(522, 23);
            this.textJustificativa.TabIndex = 143;
            // 
            // comboTipoManifestacao
            // 
            this.comboTipoManifestacao.FormattingEnabled = true;
            this.comboTipoManifestacao.Location = new System.Drawing.Point(239, 398);
            this.comboTipoManifestacao.Name = "comboTipoManifestacao";
            this.comboTipoManifestacao.Size = new System.Drawing.Size(522, 23);
            this.comboTipoManifestacao.TabIndex = 142;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(190, 363);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 19);
            this.label3.TabIndex = 144;
            this.label3.Text = "Aguardando manifestação";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(443, 363);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 19);
            this.label5.TabIndex = 145;
            this.label5.Text = "Manifestada com sucesso";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(716, 363);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(240, 19);
            this.label6.TabIndex = 146;
            this.label6.Text = "Manifestação refeitada pela SEFAZ";
            // 
            // imgAguardandoManifestacao
            // 
            this.imgAguardandoManifestacao.BackColor = System.Drawing.Color.Silver;
            this.imgAguardandoManifestacao.Location = new System.Drawing.Point(170, 362);
            this.imgAguardandoManifestacao.Name = "imgAguardandoManifestacao";
            this.imgAguardandoManifestacao.Size = new System.Drawing.Size(20, 20);
            this.imgAguardandoManifestacao.TabIndex = 147;
            // 
            // imgManifestadaSucesso
            // 
            this.imgManifestadaSucesso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.imgManifestadaSucesso.Location = new System.Drawing.Point(423, 362);
            this.imgManifestadaSucesso.Name = "imgManifestadaSucesso";
            this.imgManifestadaSucesso.Size = new System.Drawing.Size(20, 20);
            this.imgManifestadaSucesso.TabIndex = 148;
            // 
            // imgManifestacaoRefeitadaSEFAZ
            // 
            this.imgManifestacaoRefeitadaSEFAZ.BackColor = System.Drawing.Color.Red;
            this.imgManifestacaoRefeitadaSEFAZ.Location = new System.Drawing.Point(696, 362);
            this.imgManifestacaoRefeitadaSEFAZ.Name = "imgManifestacaoRefeitadaSEFAZ";
            this.imgManifestacaoRefeitadaSEFAZ.Size = new System.Drawing.Size(20, 20);
            this.imgManifestacaoRefeitadaSEFAZ.TabIndex = 149;
            // 
            // frmFiscal_NuvemFiscal_Manifestar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 464);
            this.Controls.Add(this.imgManifestacaoRefeitadaSEFAZ);
            this.Controls.Add(this.imgManifestadaSucesso);
            this.Controls.Add(this.imgAguardandoManifestacao);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textJustificativa);
            this.Controls.Add(this.comboTipoManifestacao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.botaoManifestar);
            this.Controls.Add(this.gridNotaFiscal);
            this.MaximizeBox = false;
            this.Name = "frmFiscal_NuvemFiscal_Manifestar";
            this.Text = "Nuvem Fiscal - Consulte as Notas emitidas para sua Empresa - Manifestar";
            ((System.ComponentModel.ISupportInitialize)(this.gridNotaFiscal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button botaoManifestar;
        private System.Windows.Forms.DataGridView gridNotaFiscal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textJustificativa;
        private System.Windows.Forms.ComboBox comboTipoManifestacao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel imgAguardandoManifestacao;
        private System.Windows.Forms.Panel imgManifestadaSucesso;
        private System.Windows.Forms.Panel imgManifestacaoRefeitadaSEFAZ;
    }
}