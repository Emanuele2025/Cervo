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
            CmbCertificati = new ComboBox();
            BtnFirma = new Button();
            label2 = new Label();
            BtnChiudi = new Button();
            BtnFirmaClassiNet = new Button();
            label3 = new Label();
            TxtPercorsoNomeFile = new TextBox();
            BtnTrovaFileDaFirmare = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 37);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 0;
            label1.Text = "Certificati:";
            // 
            // CmbCertificati
            // 
            CmbCertificati.FormattingEnabled = true;
            CmbCertificati.Location = new Point(12, 55);
            CmbCertificati.Name = "CmbCertificati";
            CmbCertificati.Size = new Size(370, 23);
            CmbCertificati.TabIndex = 1;
            // 
            // BtnFirma
            // 
            BtnFirma.Location = new Point(12, 98);
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
            BtnChiudi.Image = Properties.Resources.Chiudi_uxwing;
            BtnChiudi.ImageAlign = ContentAlignment.MiddleLeft;
            BtnChiudi.Location = new Point(741, 415);
            BtnChiudi.Name = "BtnChiudi";
            BtnChiudi.Size = new Size(75, 23);
            BtnChiudi.TabIndex = 9;
            BtnChiudi.Text = "Chiudi";
            BtnChiudi.TextAlign = ContentAlignment.MiddleRight;
            BtnChiudi.UseVisualStyleBackColor = true;
            BtnChiudi.Click += BtnChiudi_Click;
            // 
            // BtnFirmaClassiNet
            // 
            BtnFirmaClassiNet.Location = new Point(119, 98);
            BtnFirmaClassiNet.Name = "BtnFirmaClassiNet";
            BtnFirmaClassiNet.Size = new Size(75, 23);
            BtnFirmaClassiNet.TabIndex = 10;
            BtnFirmaClassiNet.Text = "Firma";
            BtnFirmaClassiNet.UseVisualStyleBackColor = true;
            BtnFirmaClassiNet.Click += BtnFirmaClassiNet_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 148);
            label3.Name = "label3";
            label3.Size = new Size(172, 15);
            label3.TabIndex = 18;
            label3.Text = "Percorso e nome file da firmare";
            // 
            // TxtPercorsoNomeFile
            // 
            TxtPercorsoNomeFile.Location = new Point(12, 166);
            TxtPercorsoNomeFile.Name = "TxtPercorsoNomeFile";
            TxtPercorsoNomeFile.ReadOnly = true;
            TxtPercorsoNomeFile.Size = new Size(311, 23);
            TxtPercorsoNomeFile.TabIndex = 16;
            // 
            // BtnTrovaFileDaFirmare
            // 
            BtnTrovaFileDaFirmare.Location = new Point(329, 166);
            BtnTrovaFileDaFirmare.Name = "BtnTrovaFileDaFirmare";
            BtnTrovaFileDaFirmare.Size = new Size(31, 23);
            BtnTrovaFileDaFirmare.TabIndex = 15;
            BtnTrovaFileDaFirmare.Text = "...";
            BtnTrovaFileDaFirmare.UseVisualStyleBackColor = true;
            BtnTrovaFileDaFirmare.Click += BtnTrovaFileDaFirmare_Click;
            // 
            // FrmFirma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(828, 450);
            Controls.Add(label3);
            Controls.Add(TxtPercorsoNomeFile);
            Controls.Add(BtnTrovaFileDaFirmare);
            Controls.Add(BtnFirmaClassiNet);
            Controls.Add(BtnChiudi);
            Controls.Add(label2);
            Controls.Add(BtnFirma);
            Controls.Add(CmbCertificati);
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
        private ComboBox CmbCertificati;
        private Button BtnFirma;
        private Label label2;
        private Button BtnChiudi;
        private Button BtnFirmaClassiNet;
        private Label label3;
        private TextBox TxtPercorsoNomeFile;
        private Button BtnTrovaFileDaFirmare;
    }
}