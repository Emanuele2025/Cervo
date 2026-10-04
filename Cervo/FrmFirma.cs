using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace Cervo
{
    public partial class FrmFirma : Form
    {
        public FrmFirma()
        {
            InitializeComponent();
        }

        private void FrmFirma_Load(object sender, EventArgs e)
        {
            //3 ottobre rivedere
        }



        #region Funzioni
        private void LoadCertificates(ComboBox cboCertificates)
        {
            try
            {
                X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly);
                cboCertificates.Items.Clear();
                foreach (X509Certificate2 cert in store.Certificates)
                {
                    if (cert.HasPrivateKey)
                    {
                        string displayName = $"{cert.SubjectName.Name} (Scade: {cert.NotAfter:dd/MM/yyyy})";
                        cboCertificates.Items.Add(new CertificateItem(displayName, cert));
                    }
                }
                if (cboCertificates.Items.Count > 0)
                {
                    cboCertificates.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Nessun certificato disponibile con chiave privata.",
                    "Avviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                store.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore nel caricamento dei certificati: {ex.Message}",
                "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion





        private void BtnFirma_Click(object sender, EventArgs e)
        {
            //if (cboCertificates.SelectedItem == null)
            //{
            //    MessageBox.Show("Selezionare un certificato.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //if (string.IsNullOrEmpty(selectedFilePath))
            //{
            //    MessageBox.Show("Selezionare un file da firmare.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //try
            //{
            //    CertificateItem certItem = (CertificateItem)cboCertificates.SelectedItem;
            //    X509Certificate2 certificate = certItem.Certificate;
            //    // Leggi il contenuto del file
            //    byte[] fileContent = File.ReadAllBytes(selectedFilePath);
            //    // Crea il ContentInfo
            //    ContentInfo contentInfo = new ContentInfo(fileContent);
            //    // Crea il SignedCms
            //    SignedCms signedCms = new SignedCms(contentInfo, false);
            //    // Crea il signer con il certificato
            //    CmsSigner signer = new CmsSigner(certificate);
            //    signer.IncludeOption = X509IncludeOption.EndCertOnly;
            //    // Firma il contenuto
            //    signedCms.ComputeSignature(signer, false);
            //    // Ottiene l'output firmato
            //    byte[] signedData = signedCms.Encode();
            //    // Salva il file P7M
            //    string p7mFilePath = selectedFilePath + ".p7m";
            //    File.WriteAllBytes(p7mFilePath, signedData);
            //    MessageBox.Show($"File firmato con successo!
            //    Percorso: { p7mFilePath}
            //    ",
            //"Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    // Reset
            //    selectedFilePath = "";
            //    txtFilePath.Clear();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Errore durante la firma: {ex.Message}
            //{ ex.StackTrace}
            //    ",
            //"Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }


      class CertificateItem
    {
        public string DisplayName { get; set; }
        public X509Certificate2 Certificate { get; set; }
        public CertificateItem(string displayName, X509Certificate2 certificate)
        {
            DisplayName = displayName;
            Certificate = certificate;
        }
        public override string ToString()
        {
            return DisplayName;
        }
    }




}
