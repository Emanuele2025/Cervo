using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cervo
{
    public partial class FrmInformazioni : Form
    {
        public FrmInformazioni()
        {
            InitializeComponent();
        }

        private void FrmInformazioni_Load(object sender, EventArgs e)
        {
            //Al momento utilizzato dal sito
            ////https://uxwing.com/red-x-icon/ icona chiudi, esci ed informazioni
            ///

        }

        private void BtnChiudi_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnlEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "mailto:emanuelemattei@tutanota.com",
                UseShellExecute = true
            };

            try
            {
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                Utility.MessaggioErrore("Impossibile aprire il programma di posta elettronica: " + ex.Message);

            }
        }

        private void lnkduckduckgo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = "https://duck.ai/",
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                Utility.MessaggioErrore("Impossibile aprire il sito: " + ex.Message);

            }
        }
    }
}
