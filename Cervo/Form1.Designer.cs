namespace Cervo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            MnsMenu = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            MniEsci = new ToolStripMenuItem();
            funzionalitàToolStripMenuItem = new ToolStripMenuItem();
            informazioniToolStripMenuItem = new ToolStripMenuItem();
            MniInfo = new ToolStripMenuItem();
            MnsMenu.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.PaleGreen;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(0, 24);
            label1.Name = "label1";
            label1.Size = new Size(1232, 22);
            label1.TabIndex = 7;
            label1.Text = "Cervo - Programma per la firma digitale";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // MnsMenu
            // 
            MnsMenu.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, funzionalitàToolStripMenuItem, informazioniToolStripMenuItem });
            MnsMenu.Location = new Point(0, 0);
            MnsMenu.Name = "MnsMenu";
            MnsMenu.Size = new Size(1232, 24);
            MnsMenu.TabIndex = 8;
            MnsMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { MniEsci });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // MniEsci
            // 
            MniEsci.Name = "MniEsci";
            MniEsci.Size = new Size(180, 22);
            MniEsci.Text = "Esci";
            MniEsci.Click += MniEsci_Click;
            // 
            // funzionalitàToolStripMenuItem
            // 
            funzionalitàToolStripMenuItem.Name = "funzionalitàToolStripMenuItem";
            funzionalitàToolStripMenuItem.Size = new Size(83, 20);
            funzionalitàToolStripMenuItem.Text = "Funzionalità";
            // 
            // informazioniToolStripMenuItem
            // 
            informazioniToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { MniInfo });
            informazioniToolStripMenuItem.Name = "informazioniToolStripMenuItem";
            informazioniToolStripMenuItem.Size = new Size(86, 20);
            informazioniToolStripMenuItem.Text = "Informazioni";
            // 
            // MniInfo
            // 
            MniInfo.Name = "MniInfo";
            MniInfo.Size = new Size(180, 22);
            MniInfo.Text = "Info...";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1232, 713);
            Controls.Add(label1);
            Controls.Add(MnsMenu);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cervo - Programma gratuito per la firma digitale";
            Load += Form1_Load;
            MnsMenu.ResumeLayout(false);
            MnsMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private MenuStrip MnsMenu;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem MniEsci;
        private ToolStripMenuItem funzionalitàToolStripMenuItem;
        private ToolStripMenuItem informazioniToolStripMenuItem;
        private ToolStripMenuItem MniInfo;
    }
}
