namespace SisCom.Aplicacao.Formularios
{
    partial class uscTipoEmissor
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
            radioNormal = new System.Windows.Forms.RadioButton();
            radioContigencia = new System.Windows.Forms.RadioButton();
            label1 = new System.Windows.Forms.Label();
            labelEmContigencia = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // radioNormal
            // 
            radioNormal.Appearance = System.Windows.Forms.Appearance.Button;
            radioNormal.Location = new System.Drawing.Point(5, 26);
            radioNormal.Name = "radioNormal";
            radioNormal.Size = new System.Drawing.Size(60, 30);
            radioNormal.TabIndex = 0;
            radioNormal.TabStop = true;
            radioNormal.Text = "Normal";
            radioNormal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            radioNormal.UseVisualStyleBackColor = true;
            radioNormal.CheckedChanged += radioNormal_CheckedChanged;
            // 
            // radioContigencia
            // 
            radioContigencia.Appearance = System.Windows.Forms.Appearance.Button;
            radioContigencia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            radioContigencia.Location = new System.Drawing.Point(71, 26);
            radioContigencia.Name = "radioContigencia";
            radioContigencia.Size = new System.Drawing.Size(80, 30);
            radioContigencia.TabIndex = 1;
            radioContigencia.TabStop = true;
            radioContigencia.Text = "Contigência";
            radioContigencia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            radioContigencia.UseVisualStyleBackColor = true;
            radioContigencia.CheckedChanged += radioContigencia_CheckedChanged;
            // 
            // label1
            // 
            label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(5, 5);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(144, 15);
            label1.TabIndex = 2;
            label1.Text = "Tipo de Emissão";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelEmContigencia
            // 
            labelEmContigencia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelEmContigencia.ForeColor = System.Drawing.Color.Red;
            labelEmContigencia.Location = new System.Drawing.Point(6, 56);
            labelEmContigencia.Name = "labelEmContigencia";
            labelEmContigencia.Size = new System.Drawing.Size(144, 15);
            labelEmContigencia.TabIndex = 3;
            labelEmContigencia.Text = "Em Contigência";
            labelEmContigencia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            labelEmContigencia.Visible = false;
            // 
            // uscTipoEmissor
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Controls.Add(labelEmContigencia);
            Controls.Add(label1);
            Controls.Add(radioContigencia);
            Controls.Add(radioNormal);
            Name = "uscTipoEmissor";
            Size = new System.Drawing.Size(156, 83);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.RadioButton radioNormal;
        private System.Windows.Forms.RadioButton radioContigencia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelEmContigencia;
    }
}
