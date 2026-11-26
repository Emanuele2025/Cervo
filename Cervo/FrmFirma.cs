using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Windows.Forms;
using System.Xml;

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

            this.Text = Utility.TitoloFinestra;
            LoadCertificates(CmbCertificati);
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
                    Utility.MessaggioInfo("Nessun certificato disponibile con chiave privata.");

                }
                store.Close();
            }
            catch (Exception ex)
            {
                Utility.MessaggioErrore(Utility.Errore + ex.Message);

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

        private void BtnChiudi_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnFirmaClassiNet_Click(object sender, EventArgs e)
        {
            try
            {
                //Frammento di codice da verificare
                if (TxtPercorsoNomeFile.Text.Trim() == "")
                {
                    Utility.MessaggioInfo("Selezionare un file.");
                    return;
                }

                byte[] dati = File.ReadAllBytes(TxtPercorsoNomeFile.Text.Trim());

                using var cert = ((CertificateItem)CmbCertificati.SelectedItem).Certificate;
                if (!cert.HasPrivateKey)
                    throw new InvalidOperationException("Il certificato non dispone della chiave privata.");

                var cms = new SignedCms(new ContentInfo(dati), detached: false);
                var firmatario = new CmsSigner(
                    SubjectIdentifierType.IssuerAndSerialNumber, cert)
                {
                    IncludeOption = X509IncludeOption.EndCertOnly,
                    DigestAlgorithm = new Oid("2.16.840.1.101.3.4.2.1") // SHA-256
                };

                cms.ComputeSignature(firmatario);
                File.WriteAllBytes(TxtPercorsoNomeFile.Text.Trim() + ".p7m", cms.Encode());





            }
            catch (Exception ex)
            {
                Utility.MessaggioErrore(Utility.Errore + ex.Message);
            }
        }

        private void BtnTrovaFileDaFirmare_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Seleziona un file P7M";
                openFileDialog.Filter = "Tutti i file (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    TxtPercorsoNomeFile.Text = openFileDialog.FileName;
                }
            }
        }

        private void BtnTrovaFileXML_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void BtnFirmaXML_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = "input.xml"; // Il percorso del file XML da firmare
                string outputFilePath = "signed_output.xml"; // Il percorso in cui salvare il file XML firmato

                // Carica un certificato dal Personal Store (modifica questo codice per caricare il certificato secondo le tue esigenze)
                X509Store store = new X509Store(StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection certs = store.Certificates.Find(X509FindType.FindBySubjectName, "IlTuoNomeCertificato", false);
                X509Certificate2 cert = certs[0];
                store.Close();

                SignXmlFile(filePath, outputFilePath, cert);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public   void SignXmlFile(string filePath, string outputFilePath, X509Certificate2 certificate)
        {
            // Carica il documento XML
            XmlDocument document = new XmlDocument
            {
                PreserveWhitespace = true
            };
            document.Load(filePath);

            // Crea un oggetto SignedXml
            SignedXml signedXml = new SignedXml(document);

            // Aggiungi la chiave del certificato per la firma
            signedXml.SigningKey = certificate.PrivateKey;

            // Crea una referenza per il file XML
            Reference reference = new Reference
            {
                Uri = ""
            };

            // Aggiungi un transform per canonizzare l'XML per la firma
            XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
            reference.AddTransform(env);

            // Aggiungi la referenza al documento SignedXml
            signedXml.AddReference(reference);

            // Crea un key info con i dettagli del certificato
            KeyInfo keyInfo = new KeyInfo();
            keyInfo.AddClause(new KeyInfoX509Data(certificate));

            // Aggiungi il key info al documento SignedXml
            signedXml.KeyInfo = keyInfo;

            // Calcola la firma
            signedXml.ComputeSignature();

            // Recupera la firma sotto forma di XML
            XmlElement xmlDigitalSignature = signedXml.GetXml();

            // Aggiungi la firma al documento XML
            document.DocumentElement.AppendChild(document.ImportNode(xmlDigitalSignature, true));

            // Salva il documento firmato
            document.Save(outputFilePath);

            Console.WriteLine("XML signed and saved at: " + outputFilePath);
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
