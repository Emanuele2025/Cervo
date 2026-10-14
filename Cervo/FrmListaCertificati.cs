using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace Cervo
{
    public partial class FrmListaCertificati : Form
    {
        public FrmListaCertificati()
        {
            InitializeComponent();
        }

        private void FrmListaCertificati_Load(object sender, EventArgs e)
        {
            this.Text = Utility.TitoloFinestra;
            try
            {
                //Rileva i certificati installati nel computer
                X509Store storeCertificati = new X509Store(StoreName.My, StoreLocation.CurrentUser);

                storeCertificati.Open(OpenFlags.ReadOnly);

                //Visualizzo solo i dati che interessano e li visualizza nel controllo datagridview
                var risultatoCertificati = (from dati in storeCertificati.Certificates.Cast<X509Certificate2>()

                                            select new

                                            {

                                                Oggetto = dati.Subject,

                                                EnteCertificatore = dati.Issuer,

                                                NumeroSeriale = dati.GetSerialNumberString(),

                                                ValidoFinoAl = dati.NotAfter

                                            }).ToList();
                DtgListaCertificati.DataSource = risultatoCertificati;
                storeCertificati.Close();


            }
            catch (Exception ex)
            {
                Utility.MessaggioErrore(Utility.Errore + ex.Message);
            }
        }

        private void BtnChiudi_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
