namespace SisCom.Aplicacao.Formularios
{
    partial class ucFiscal_MDFe_AdicionarNotasItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numericVolumeTransportadosPesoBruto = new System.Windows.Forms.NumericUpDown();
            this.numericValorDesconto = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericVolumeTransportadosPesoBruto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericValorDesconto)).BeginInit();
            this.SuspendLayout();
            // 
            // numericVolumeTransportadosPesoBruto
            // 
            this.numericVolumeTransportadosPesoBruto.DecimalPlaces = 2;
            this.numericVolumeTransportadosPesoBruto.Location = new System.Drawing.Point(866, 5);
            this.numericVolumeTransportadosPesoBruto.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericVolumeTransportadosPesoBruto.Name = "numericVolumeTransportadosPesoBruto";
            this.numericVolumeTransportadosPesoBruto.Size = new System.Drawing.Size(100, 23);
            this.numericVolumeTransportadosPesoBruto.TabIndex = 15;
            // 
            // numericValorDesconto
            // 
            this.numericValorDesconto.DecimalPlaces = 2;
            this.numericValorDesconto.Location = new System.Drawing.Point(760, 5);
            this.numericValorDesconto.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericValorDesconto.Name = "numericValorDesconto";
            this.numericValorDesconto.Size = new System.Drawing.Size(100, 23);
            this.numericValorDesconto.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.BackColor = System.Drawing.Color.Yellow;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(719, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 23);
            this.label1.TabIndex = 13;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(473, 5);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(240, 23);
            this.comboBox5.TabIndex = 12;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(177, 5);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(290, 23);
            this.comboBox3.TabIndex = 10;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(81, 5);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(90, 23);
            this.comboBox2.TabIndex = 9;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(5, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(70, 23);
            this.comboBox1.TabIndex = 8;
            // 
            // ucFiscal_MDFe_AdicionarNotasItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericVolumeTransportadosPesoBruto);
            this.Controls.Add(this.numericValorDesconto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Name = "ucFiscal_MDFe_AdicionarNotasItem";
            this.Size = new System.Drawing.Size(971, 33);
            ((System.ComponentModel.ISupportInitialize)(this.numericVolumeTransportadosPesoBruto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericValorDesconto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericVolumeTransportadosPesoBruto;
        private System.Windows.Forms.NumericUpDown numericValorDesconto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
