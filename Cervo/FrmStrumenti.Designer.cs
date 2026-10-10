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
            TbcFunzionalita = new TabControl();
            TbpCertificato = new TabPage();
            BtnEstraiCertificato = new Button();
            rtbResults = new RichTextBox();
            BtnVerificaCertificato = new Button();
            TxtPercorsoFileFirmato = new TextBox();
            BtnTrovaFileP7m = new Button();
            TbpVerifica = new TabPage();
            BtnVerificaFirma = new Button();
            textBox1 = new TextBox();
            button3 = new Button();
            label2 = new Label();
            BtnChiudi = new Button();
            TbcFunzionalita.SuspendLayout();
            TbpCertificato.SuspendLayout();
            TbpVerifica.SuspendLayout();
            SuspendLayout();
            // 
            // TbcFunzionalita
            // 
            TbcFunzionalita.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TbcFunzionalita.Controls.Add(TbpCertificato);
            TbcFunzionalita.Controls.Add(TbpVerifica);
            TbcFunzionalita.Location = new Point(0, 25);
            TbcFunzionalita.Name = "TbcFunzionalita";
            TbcFunzionalita.SelectedIndex = 0;
            TbcFunzionalita.Size = new Size(800, 281);
            TbcFunzionalita.TabIndex = 0;
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
            // rtbResults
            // 
            rtbResults.Location = new Point(409, 22);
            rtbResults.Name = "rtbResults";
            rtbResults.Size = new Size(334, 235);
            rtbResults.TabIndex = 3;
            rtbResults.Text = "";
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
            // TbpVerifica
            // 
            TbpVerifica.Controls.Add(BtnVerificaFirma);
            TbpVerifica.Controls.Add(textBox1);
            TbpVerifica.Controls.Add(button3);
            TbpVerifica.Location = new Point(4, 24);
            TbpVerifica.Name = "TbpVerifica";
            TbpVerifica.Padding = new Padding(3);
            TbpVerifica.Size = new Size(792, 253);
            TbpVerifica.TabIndex = 1;
            TbpVerifica.Text = "Verifica Firma";
            TbpVerifica.UseVisualStyleBackColor = true;
            // 
            // BtnVerificaFirma
            // 
            BtnVerificaFirma.Location = new Point(18, 47);
            BtnVerificaFirma.Name = "BtnVerificaFirma";
            BtnVerificaFirma.Size = new Size(75, 23);
            BtnVerificaFirma.TabIndex = 7;
            BtnVerificaFirma.Text = "Verifica";
            BtnVerificaFirma.UseVisualStyleBackColor = true;
            BtnVerificaFirma.Click += BtnVerificaFirma_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(18, 18);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(311, 23);
            textBox1.TabIndex = 6;
            // 
            // button3
            // 
            button3.Location = new Point(335, 18);
            button3.Name = "button3";
            button3.Size = new Size(31, 23);
            button3.TabIndex = 5;
            button3.Text = "...";
            button3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.BackColor = Color.Turquoise;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(800, 22);
            label2.TabIndex = 9;
            label2.Text = "Cervo - Funzionalità per la gestione della firma digitale";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // BtnChiudi
            // 
            BtnChiudi.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnChiudi.Location = new Point(713, 415);
            BtnChiudi.Name = "BtnChiudi";
            BtnChiudi.Size = new Size(75, 23);
            BtnChiudi.TabIndex = 10;
            BtnChiudi.Text = "Chiudi";
            BtnChiudi.UseVisualStyleBackColor = true;
            BtnChiudi.Click += BtnChiudi_Click;
            // 
            // FrmStrumenti
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnChiudi);
            Controls.Add(label2);
            Controls.Add(TbcFunzionalita);
            Name = "FrmStrumenti";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cervo";
            Load += FrmStrumenti_Load;
            TbcFunzionalita.ResumeLayout(false);
            TbpCertificato.ResumeLayout(false);
            TbpCertificato.PerformLayout();
            TbpVerifica.ResumeLayout(false);
            TbpVerifica.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl TbcFunzionalita;
        private TabPage TbpCertificato;
        private TabPage TbpVerifica;
        private Button BtnVerificaCertificato;
        private TextBox TxtPercorsoFileFirmato;
        private Button BtnTrovaFileP7m;
        private RichTextBox rtbResults;
        private Button BtnEstraiCertificato;
        private Button BtnVerificaFirma;
        private TextBox textBox1;
        private Button button3;
        private Label label2;
        private Button BtnChiudi;
    }
}