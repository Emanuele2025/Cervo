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
            TbpVerificaFirma = new TabPage();
            BtnVerificaCertificatoFirmato = new Button();
            TxtPercorsoFileFirmatoDigitalmente = new TextBox();
            BtnTrovaCertificatoFileFirmato = new Button();
            TbpEstraiFile = new TabPage();
            label3 = new Label();
            BtnEstraFileDaP7m = new Button();
            TxtPercorsoNomeFilePerEstraiFile = new TextBox();
            BtnTrovaFilePerEstraiFile = new Button();
            TbpEstraiCertifcato = new TabPage();
            label1 = new Label();
            BtnEstraiFileCertificato = new Button();
            TxtPercorsoNomeFileP7mPerCertificato = new TextBox();
            BtnTrovaFileP7mCertificati = new Button();
            TbpVerificaCertificato = new TabPage();
            label4 = new Label();
            BtnVerifica = new Button();
            TxtPercorsoFileP7mVerifica = new TextBox();
            BtnTrovaFilePerVerifica = new Button();
            label2 = new Label();
            BtnChiudi = new Button();
            TbcFunzionalita.SuspendLayout();
            TbpCertificato.SuspendLayout();
            TbpVerifica.SuspendLayout();
            TbpVerificaFirma.SuspendLayout();
            TbpEstraiFile.SuspendLayout();
            TbpEstraiCertifcato.SuspendLayout();
            TbpVerificaCertificato.SuspendLayout();
            SuspendLayout();
            // 
            // TbcFunzionalita
            // 
            TbcFunzionalita.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TbcFunzionalita.Controls.Add(TbpCertificato);
            TbcFunzionalita.Controls.Add(TbpVerifica);
            TbcFunzionalita.Controls.Add(TbpVerificaFirma);
            TbcFunzionalita.Controls.Add(TbpEstraiFile);
            TbcFunzionalita.Controls.Add(TbpEstraiCertifcato);
            TbcFunzionalita.Controls.Add(TbpVerificaCertificato);
            TbcFunzionalita.Location = new Point(0, 25);
            TbcFunzionalita.Name = "TbcFunzionalita";
            TbcFunzionalita.SelectedIndex = 0;
            TbcFunzionalita.Size = new Size(800, 384);
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
            TbpCertificato.Size = new Size(792, 356);
            TbpCertificato.TabIndex = 0;
            TbpCertificato.Text = "Certificato";
            TbpCertificato.UseVisualStyleBackColor = true;
            // 
            // BtnEstraiCertificato
            // 
            BtnEstraiCertificato.Location = new Point(103, 63);
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
            rtbResults.Size = new Size(334, 316);
            rtbResults.TabIndex = 3;
            rtbResults.Text = "";
            // 
            // BtnVerificaCertificato
            // 
            BtnVerificaCertificato.Location = new Point(15, 62);
            BtnVerificaCertificato.Name = "BtnVerificaCertificato";
            BtnVerificaCertificato.Size = new Size(75, 23);
            BtnVerificaCertificato.TabIndex = 2;
            BtnVerificaCertificato.Text = "Verifica";
            BtnVerificaCertificato.UseVisualStyleBackColor = true;
            BtnVerificaCertificato.Click += BtnVerificaCertificato_Click;
            // 
            // TxtPercorsoFileFirmato
            // 
            TxtPercorsoFileFirmato.Location = new Point(8, 31);
            TxtPercorsoFileFirmato.Name = "TxtPercorsoFileFirmato";
            TxtPercorsoFileFirmato.Size = new Size(311, 23);
            TxtPercorsoFileFirmato.TabIndex = 1;
            // 
            // BtnTrovaFileP7m
            // 
            BtnTrovaFileP7m.Location = new Point(325, 31);
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
            BtnVerificaFirma.Location = new Point(8, 62);
            BtnVerificaFirma.Name = "BtnVerificaFirma";
            BtnVerificaFirma.Size = new Size(75, 23);
            BtnVerificaFirma.TabIndex = 7;
            BtnVerificaFirma.Text = "Verifica";
            BtnVerificaFirma.UseVisualStyleBackColor = true;
            BtnVerificaFirma.Click += BtnVerificaFirma_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(8, 33);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(311, 23);
            textBox1.TabIndex = 6;
            // 
            // button3
            // 
            button3.Location = new Point(325, 33);
            button3.Name = "button3";
            button3.Size = new Size(31, 23);
            button3.TabIndex = 5;
            button3.Text = "...";
            button3.UseVisualStyleBackColor = true;
            // 
            // TbpVerificaFirma
            // 
            TbpVerificaFirma.Controls.Add(BtnVerificaCertificatoFirmato);
            TbpVerificaFirma.Controls.Add(TxtPercorsoFileFirmatoDigitalmente);
            TbpVerificaFirma.Controls.Add(BtnTrovaCertificatoFileFirmato);
            TbpVerificaFirma.Location = new Point(4, 24);
            TbpVerificaFirma.Name = "TbpVerificaFirma";
            TbpVerificaFirma.Size = new Size(792, 253);
            TbpVerificaFirma.TabIndex = 2;
            TbpVerificaFirma.Text = "Verifica Firma";
            TbpVerificaFirma.UseVisualStyleBackColor = true;
            // 
            // BtnVerificaCertificatoFirmato
            // 
            BtnVerificaCertificatoFirmato.Location = new Point(8, 60);
            BtnVerificaCertificatoFirmato.Name = "BtnVerificaCertificatoFirmato";
            BtnVerificaCertificatoFirmato.Size = new Size(75, 23);
            BtnVerificaCertificatoFirmato.TabIndex = 10;
            BtnVerificaCertificatoFirmato.Text = "Verifica";
            BtnVerificaCertificatoFirmato.UseVisualStyleBackColor = true;
            BtnVerificaCertificatoFirmato.Click += BtnVerificaCertificatoFirmato_Click;
            // 
            // TxtPercorsoFileFirmatoDigitalmente
            // 
            TxtPercorsoFileFirmatoDigitalmente.Location = new Point(8, 31);
            TxtPercorsoFileFirmatoDigitalmente.Name = "TxtPercorsoFileFirmatoDigitalmente";
            TxtPercorsoFileFirmatoDigitalmente.Size = new Size(311, 23);
            TxtPercorsoFileFirmatoDigitalmente.TabIndex = 9;
            // 
            // BtnTrovaCertificatoFileFirmato
            // 
            BtnTrovaCertificatoFileFirmato.Location = new Point(325, 31);
            BtnTrovaCertificatoFileFirmato.Name = "BtnTrovaCertificatoFileFirmato";
            BtnTrovaCertificatoFileFirmato.Size = new Size(31, 23);
            BtnTrovaCertificatoFileFirmato.TabIndex = 8;
            BtnTrovaCertificatoFileFirmato.Text = "...";
            BtnTrovaCertificatoFileFirmato.UseVisualStyleBackColor = true;
            BtnTrovaCertificatoFileFirmato.Click += BtnTrovaCertificatoFileFirmato_Click;
            // 
            // TbpEstraiFile
            // 
            TbpEstraiFile.Controls.Add(label3);
            TbpEstraiFile.Controls.Add(BtnEstraFileDaP7m);
            TbpEstraiFile.Controls.Add(TxtPercorsoNomeFilePerEstraiFile);
            TbpEstraiFile.Controls.Add(BtnTrovaFilePerEstraiFile);
            TbpEstraiFile.Location = new Point(4, 24);
            TbpEstraiFile.Name = "TbpEstraiFile";
            TbpEstraiFile.Size = new Size(792, 253);
            TbpEstraiFile.TabIndex = 3;
            TbpEstraiFile.Text = "Estrai File";
            TbpEstraiFile.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 11);
            label3.Name = "label3";
            label3.Size = new Size(206, 15);
            label3.TabIndex = 15;
            label3.Text = "Percorso e nome file da cui estrae file:";
            // 
            // BtnEstraFileDaP7m
            // 
            BtnEstraFileDaP7m.Location = new Point(3, 58);
            BtnEstraFileDaP7m.Name = "BtnEstraFileDaP7m";
            BtnEstraFileDaP7m.Size = new Size(115, 23);
            BtnEstraFileDaP7m.TabIndex = 13;
            BtnEstraFileDaP7m.Text = "Estrai File";
            BtnEstraFileDaP7m.UseVisualStyleBackColor = true;
            BtnEstraFileDaP7m.Click += BtnEstraFileDaP7m_Click;
            // 
            // TxtPercorsoNomeFilePerEstraiFile
            // 
            TxtPercorsoNomeFilePerEstraiFile.Location = new Point(3, 29);
            TxtPercorsoNomeFilePerEstraiFile.Name = "TxtPercorsoNomeFilePerEstraiFile";
            TxtPercorsoNomeFilePerEstraiFile.Size = new Size(311, 23);
            TxtPercorsoNomeFilePerEstraiFile.TabIndex = 12;
            // 
            // BtnTrovaFilePerEstraiFile
            // 
            BtnTrovaFilePerEstraiFile.Location = new Point(320, 29);
            BtnTrovaFilePerEstraiFile.Name = "BtnTrovaFilePerEstraiFile";
            BtnTrovaFilePerEstraiFile.Size = new Size(31, 23);
            BtnTrovaFilePerEstraiFile.TabIndex = 11;
            BtnTrovaFilePerEstraiFile.Text = "...";
            BtnTrovaFilePerEstraiFile.UseVisualStyleBackColor = true;
            BtnTrovaFilePerEstraiFile.Click += BtnTrovaFilePerEstraiFile_Click;
            // 
            // TbpEstraiCertifcato
            // 
            TbpEstraiCertifcato.Controls.Add(label1);
            TbpEstraiCertifcato.Controls.Add(BtnEstraiFileCertificato);
            TbpEstraiCertifcato.Controls.Add(TxtPercorsoNomeFileP7mPerCertificato);
            TbpEstraiCertifcato.Controls.Add(BtnTrovaFileP7mCertificati);
            TbpEstraiCertifcato.Location = new Point(4, 24);
            TbpEstraiCertifcato.Name = "TbpEstraiCertifcato";
            TbpEstraiCertifcato.Size = new Size(792, 253);
            TbpEstraiCertifcato.TabIndex = 4;
            TbpEstraiCertifcato.Text = "Estrai Certificato";
            TbpEstraiCertifcato.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 10);
            label1.Name = "label1";
            label1.Size = new Size(142, 15);
            label1.TabIndex = 14;
            label1.Text = "Percorso e nome file p7m";
            // 
            // BtnEstraiFileCertificato
            // 
            BtnEstraiFileCertificato.Location = new Point(3, 57);
            BtnEstraiFileCertificato.Name = "BtnEstraiFileCertificato";
            BtnEstraiFileCertificato.Size = new Size(142, 23);
            BtnEstraiFileCertificato.TabIndex = 13;
            BtnEstraiFileCertificato.Text = "Estrai Certificato";
            BtnEstraiFileCertificato.UseVisualStyleBackColor = true;
            BtnEstraiFileCertificato.Click += BtnEstraiFileCertificato_Click;
            // 
            // TxtPercorsoNomeFileP7mPerCertificato
            // 
            TxtPercorsoNomeFileP7mPerCertificato.Location = new Point(3, 28);
            TxtPercorsoNomeFileP7mPerCertificato.Name = "TxtPercorsoNomeFileP7mPerCertificato";
            TxtPercorsoNomeFileP7mPerCertificato.Size = new Size(311, 23);
            TxtPercorsoNomeFileP7mPerCertificato.TabIndex = 12;
            // 
            // BtnTrovaFileP7mCertificati
            // 
            BtnTrovaFileP7mCertificati.Location = new Point(320, 28);
            BtnTrovaFileP7mCertificati.Name = "BtnTrovaFileP7mCertificati";
            BtnTrovaFileP7mCertificati.Size = new Size(31, 23);
            BtnTrovaFileP7mCertificati.TabIndex = 11;
            BtnTrovaFileP7mCertificati.Text = "...";
            BtnTrovaFileP7mCertificati.UseVisualStyleBackColor = true;
            BtnTrovaFileP7mCertificati.Click += BtnTrovaFileP7mCertificati_Click;
            // 
            // TbpVerificaCertificato
            // 
            TbpVerificaCertificato.Controls.Add(label4);
            TbpVerificaCertificato.Controls.Add(BtnVerifica);
            TbpVerificaCertificato.Controls.Add(TxtPercorsoFileP7mVerifica);
            TbpVerificaCertificato.Controls.Add(BtnTrovaFilePerVerifica);
            TbpVerificaCertificato.Location = new Point(4, 24);
            TbpVerificaCertificato.Name = "TbpVerificaCertificato";
            TbpVerificaCertificato.Size = new Size(792, 253);
            TbpVerificaCertificato.TabIndex = 5;
            TbpVerificaCertificato.Text = "Verifica Certificato";
            TbpVerificaCertificato.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 10);
            label4.Name = "label4";
            label4.Size = new Size(142, 15);
            label4.TabIndex = 18;
            label4.Text = "Percorso e nome file p7m";
            // 
            // BtnVerifica
            // 
            BtnVerifica.Location = new Point(3, 57);
            BtnVerifica.Name = "BtnVerifica";
            BtnVerifica.Size = new Size(142, 23);
            BtnVerifica.TabIndex = 17;
            BtnVerifica.Text = "Verifica Certificato";
            BtnVerifica.UseVisualStyleBackColor = true;
            BtnVerifica.Click += BtnVerifica_Click;
            // 
            // TxtPercorsoFileP7mVerifica
            // 
            TxtPercorsoFileP7mVerifica.Location = new Point(3, 28);
            TxtPercorsoFileP7mVerifica.Name = "TxtPercorsoFileP7mVerifica";
            TxtPercorsoFileP7mVerifica.Size = new Size(311, 23);
            TxtPercorsoFileP7mVerifica.TabIndex = 16;
            // 
            // BtnTrovaFilePerVerifica
            // 
            BtnTrovaFilePerVerifica.Location = new Point(320, 28);
            BtnTrovaFilePerVerifica.Name = "BtnTrovaFilePerVerifica";
            BtnTrovaFilePerVerifica.Size = new Size(31, 23);
            BtnTrovaFilePerVerifica.TabIndex = 15;
            BtnTrovaFilePerVerifica.Text = "...";
            BtnTrovaFilePerVerifica.UseVisualStyleBackColor = true;
            BtnTrovaFilePerVerifica.Click += BtnTrovaFilePerVerifica_Click;
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
            BtnChiudi.Image = Properties.Resources.Chiudi_uxwing;
            BtnChiudi.ImageAlign = ContentAlignment.MiddleLeft;
            BtnChiudi.Location = new Point(713, 415);
            BtnChiudi.Name = "BtnChiudi";
            BtnChiudi.Size = new Size(75, 23);
            BtnChiudi.TabIndex = 10;
            BtnChiudi.Text = "Chiudi";
            BtnChiudi.TextAlign = ContentAlignment.MiddleRight;
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
            TbpVerificaFirma.ResumeLayout(false);
            TbpVerificaFirma.PerformLayout();
            TbpEstraiFile.ResumeLayout(false);
            TbpEstraiFile.PerformLayout();
            TbpEstraiCertifcato.ResumeLayout(false);
            TbpEstraiCertifcato.PerformLayout();
            TbpVerificaCertificato.ResumeLayout(false);
            TbpVerificaCertificato.PerformLayout();
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
        private TabPage TbpVerificaFirma;
        private Button BtnVerificaCertificatoFirmato;
        private TextBox TxtPercorsoFileFirmatoDigitalmente;
        private Button BtnTrovaCertificatoFileFirmato;
        private TabPage TbpEstraiFile;
        private Label label3;
        private Button BtnEstraFileDaP7m;
        private TextBox TxtPercorsoNomeFilePerEstraiFile;
        private Button BtnTrovaFilePerEstraiFile;
        private TabPage TbpEstraiCertifcato;
        private Label label1;
        private Button BtnEstraiFileCertificato;
        private TextBox TxtPercorsoNomeFileP7mPerCertificato;
        private Button BtnTrovaFileP7mCertificati;
        private TabPage TbpVerificaCertificato;
        private Label label4;
        private Button BtnVerifica;
        private TextBox TxtPercorsoFileP7mVerifica;
        private Button BtnTrovaFilePerVerifica;
    }
}