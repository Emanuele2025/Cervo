namespace Cervo
{
    partial class FrmListaCertificati
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
            label2 = new Label();
            DtgListaCertificati = new DataGridView();
            BtnChiudi = new Button();
            Oggetto = new DataGridViewTextBoxColumn();
            EnteCertificatore = new DataGridViewTextBoxColumn();
            NumeroSeriale = new DataGridViewTextBoxColumn();
            ValidoFinoAl = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)DtgListaCertificati).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.BackColor = Color.Turquoise;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(1191, 22);
            label2.TabIndex = 9;
            label2.Text = "Cervo - Lista dei certificati";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // DtgListaCertificati
            // 
            DtgListaCertificati.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DtgListaCertificati.Columns.AddRange(new DataGridViewColumn[] { Oggetto, EnteCertificatore, NumeroSeriale, ValidoFinoAl });
            DtgListaCertificati.Dock = DockStyle.Top;
            DtgListaCertificati.Location = new Point(0, 22);
            DtgListaCertificati.Name = "DtgListaCertificati";
            DtgListaCertificati.Size = new Size(1191, 526);
            DtgListaCertificati.TabIndex = 10;
            // 
            // BtnChiudi
            // 
            BtnChiudi.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnChiudi.Image = Properties.Resources.Chiudi_uxwing;
            BtnChiudi.ImageAlign = ContentAlignment.MiddleLeft;
            BtnChiudi.Location = new Point(1104, 578);
            BtnChiudi.Name = "BtnChiudi";
            BtnChiudi.Size = new Size(75, 23);
            BtnChiudi.TabIndex = 11;
            BtnChiudi.Text = "Chiudi";
            BtnChiudi.TextAlign = ContentAlignment.MiddleRight;
            BtnChiudi.UseVisualStyleBackColor = true;
            BtnChiudi.Click += BtnChiudi_Click;
            // 
            // Oggetto
            // 
            Oggetto.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Oggetto.DataPropertyName = "Oggetto";
            Oggetto.HeaderText = "Oggetto";
            Oggetto.Name = "Oggetto";
            Oggetto.Width = 300;
            // 
            // EnteCertificatore
            // 
            EnteCertificatore.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            EnteCertificatore.DataPropertyName = "EnteCertificatore";
            EnteCertificatore.HeaderText = "Ente Certificatore";
            EnteCertificatore.Name = "EnteCertificatore";
            EnteCertificatore.Width = 300;
            // 
            // NumeroSeriale
            // 
            NumeroSeriale.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            NumeroSeriale.DataPropertyName = "NumeroSeriale";
            NumeroSeriale.HeaderText = "Numero Seriale";
            NumeroSeriale.Name = "NumeroSeriale";
            NumeroSeriale.Width = 150;
            // 
            // ValidoFinoAl
            // 
            ValidoFinoAl.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ValidoFinoAl.DataPropertyName = "ValidoFinoAl";
            ValidoFinoAl.HeaderText = "Valido Fino Al";
            ValidoFinoAl.Name = "ValidoFinoAl";
            ValidoFinoAl.Width = 110;
            // 
            // FrmListaCertificati
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1191, 613);
            Controls.Add(BtnChiudi);
            Controls.Add(DtgListaCertificati);
            Controls.Add(label2);
            Name = "FrmListaCertificati";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmListaCertificati";
            Load += FrmListaCertificati_Load;
            ((System.ComponentModel.ISupportInitialize)DtgListaCertificati).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label2;
        private DataGridView DtgListaCertificati;
        private Button BtnChiudi;
        private DataGridViewTextBoxColumn Oggetto;
        private DataGridViewTextBoxColumn EnteCertificatore;
        private DataGridViewTextBoxColumn NumeroSeriale;
        private DataGridViewTextBoxColumn ValidoFinoAl;
    }
}