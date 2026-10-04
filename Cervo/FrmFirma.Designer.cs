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
            label2 = new Label();
            BtnChiudi = new Button();
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
            // label2
            // 
            label2.BackColor = Color.Turquoise;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(828, 22);
            label2.TabIndex = 8;
            label2.Text = "Cervo - Firma dei file";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // BtnChiudi
            // 
            BtnChiudi.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnChiudi.Location = new Point(741, 415);
            BtnChiudi.Name = "BtnChiudi";
            BtnChiudi.Size = new Size(75, 23);
            BtnChiudi.TabIndex = 9;
            BtnChiudi.Text = "Chiudi";
            BtnChiudi.UseVisualStyleBackColor = true;
            // 
            // FrmFirma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(828, 450);
            Controls.Add(BtnChiudi);
            Controls.Add(label2);
            Controls.Add(BtnFirma);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmFirma";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmFirma";
            Load += FrmFirma_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private Button BtnFirma;
        private Label label2;
        private Button BtnChiudi;
    }
}