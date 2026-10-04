namespace Cervo
{
    partial class FrmFirma
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
            label1 = new Label();
            comboBox1 = new ComboBox();
            BtnFirma = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 114);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 0;
            label1.Text = "Certificati:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(20, 132);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(370, 23);
            comboBox1.TabIndex = 1;
            // 
            // BtnFirma
            // 
            BtnFirma.Location = new Point(51, 363);
            BtnFirma.Name = "BtnFirma";
            BtnFirma.Size = new Size(75, 23);
            BtnFirma.TabIndex = 2;
            BtnFirma.Text = "Firma";
            BtnFirma.UseVisualStyleBackColor = true;
            BtnFirma.Click += BtnFirma_Click;
            // 
            // FrmFirma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnFirma);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Name = "FrmFirma";
            Text = "FrmFirma";
            Load += FrmFirma_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private Button BtnFirma;
    }
}