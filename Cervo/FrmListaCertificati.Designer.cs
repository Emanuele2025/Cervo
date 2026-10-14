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
            label2.Size = new Size(800, 22);
            label2.TabIndex = 9;
            label2.Text = "Cervo - Lista dei certificati";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // DtgListaCertificati
            // 
            DtgListaCertificati.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DtgListaCertificati.Dock = DockStyle.Top;
            DtgListaCertificati.Location = new Point(0, 22);
            DtgListaCertificati.Name = "DtgListaCertificati";
            DtgListaCertificati.Size = new Size(800, 217);
            DtgListaCertificati.TabIndex = 10;
            // 
            // BtnChiudi
            // 
            BtnChiudi.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnChiudi.Image = Properties.Resources.Chiudi_uxwing;
            BtnChiudi.ImageAlign = ContentAlignment.MiddleLeft;
            BtnChiudi.Location = new Point(713, 415);
            BtnChiudi.Name = "BtnChiudi";
            BtnChiudi.Size = new Size(75, 23);
            BtnChiudi.TabIndex = 11;
            BtnChiudi.Text = "Chiudi";
            BtnChiudi.TextAlign = ContentAlignment.MiddleRight;
            BtnChiudi.UseVisualStyleBackColor = true;
            BtnChiudi.Click += BtnChiudi_Click;
            // 
            // FrmListaCertificati
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}