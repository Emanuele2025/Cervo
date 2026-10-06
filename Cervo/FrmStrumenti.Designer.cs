namespace Cervo
{
    partial class FrmStrumenti
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
            tabControl1 = new TabControl();
            TbpCertificato = new TabPage();
            BtnVerificaCertificato = new Button();
            TxtPercorsoFileFirmato = new TextBox();
            BtnTrovaFileP7m = new Button();
            tabPage2 = new TabPage();
            rtbResults = new RichTextBox();
            BtnEstraiCertificato = new Button();
            tabControl1.SuspendLayout();
            TbpCertificato.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(TbpCertificato);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 111);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(776, 306);
            tabControl1.TabIndex = 0;
            // 
            // TbpCertificato
            // 
            TbpCertificato.Controls.Add(BtnEstraiCertificato);
            TbpCertificato.Controls.Add(rtbResults);
            TbpCertificato.Controls.Add(BtnVerificaCertificato);
            TbpCertificato.Controls.Add(TxtPercorsoFileFirmato);
            TbpCertificato.Controls.Add(BtnTrovaFileP7m);
            TbpCertificato.Location = new Point(4, 24);
            TbpCertificato.Name = "TbpCertificato";
            TbpCertificato.Padding = new Padding(3);
            TbpCertificato.Size = new Size(768, 278);
            TbpCertificato.TabIndex = 0;
            TbpCertificato.Text = "Certificato";
            TbpCertificato.UseVisualStyleBackColor = true;
            // 
            // BtnVerificaCertificato
            // 
            BtnVerificaCertificato.Location = new Point(31, 82);
            BtnVerificaCertificato.Name = "BtnVerificaCertificato";
            BtnVerificaCertificato.Size = new Size(75, 23);
            BtnVerificaCertificato.TabIndex = 2;
            BtnVerificaCertificato.Text = "Verifica";
            BtnVerificaCertificato.UseVisualStyleBackColor = true;
            BtnVerificaCertificato.Click += BtnVerificaCertificato_Click;
            // 
            // TxtPercorsoFileFirmato
            // 
            TxtPercorsoFileFirmato.Location = new Point(24, 51);
            TxtPercorsoFileFirmato.Name = "TxtPercorsoFileFirmato";
            TxtPercorsoFileFirmato.Size = new Size(311, 23);
            TxtPercorsoFileFirmato.TabIndex = 1;
            // 
            // BtnTrovaFileP7m
            // 
            BtnTrovaFileP7m.Location = new Point(341, 51);
            BtnTrovaFileP7m.Name = "BtnTrovaFileP7m";
            BtnTrovaFileP7m.Size = new Size(31, 23);
            BtnTrovaFileP7m.TabIndex = 0;
            BtnTrovaFileP7m.Text = "...";
            BtnTrovaFileP7m.UseVisualStyleBackColor = true;
            BtnTrovaFileP7m.Click += BtnTrovaFileP7m_Click;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(768, 278);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // rtbResults
            // 
            rtbResults.Location = new Point(409, 22);
            rtbResults.Name = "rtbResults";
            rtbResults.Size = new Size(334, 235);
            rtbResults.TabIndex = 3;
            rtbResults.Text = "";
            // 
            // BtnEstraiCertificato
            // 
            BtnEstraiCertificato.Location = new Point(119, 83);
            BtnEstraiCertificato.Name = "BtnEstraiCertificato";
            BtnEstraiCertificato.Size = new Size(112, 23);
            BtnEstraiCertificato.TabIndex = 4;
            BtnEstraiCertificato.Text = "Estrai";
            BtnEstraiCertificato.UseVisualStyleBackColor = true;
            BtnEstraiCertificato.Click += BtnEstraiCertificato_Click;
            // 
            // FrmStrumenti
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "FrmStrumenti";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cervo";
            Load += FrmStrumenti_Load;
            tabControl1.ResumeLayout(false);
            TbpCertificato.ResumeLayout(false);
            TbpCertificato.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage TbpCertificato;
        private TabPage tabPage2;
        private Button BtnVerificaCertificato;
        private TextBox TxtPercorsoFileFirmato;
        private Button BtnTrovaFileP7m;
        private RichTextBox rtbResults;
        private Button BtnEstraiCertificato;
    }
}