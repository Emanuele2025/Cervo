using Cervo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace Cervo
{
    public partial class FrmStrumenti : Form
    {
        public FrmStrumenti()
        {
            InitializeComponent();
        }

        private void FrmStrumenti_Load(object sender, EventArgs e)
        {
            this.Text = Utility.TitoloFinestra;
        }

        public static SignatureInfo VerifySignature(string p7mFilePath)
        {
            var signatureInfo = new SignatureInfo();

            try
            {
                if (!File.Exists(p7mFilePath))
                {
                    signatureInfo.IsValid = false;
                    signatureInfo.Message = "File non trovato.";
                    return signatureInfo;
                }

                // Leggi il file P7M
                byte[] signedData = File.ReadAllBytes(p7mFilePath);

                // Decodifica il SignedCms
                SignedCms signedCms = new SignedCms();
                signedCms.Decode(signedData);

                // Verifica la firma (senza validare la catena di certificati)
                try
                {
                    signedCms.CheckSignature(true);
                    signatureInfo.IsValid = true;
                    signatureInfo.Message = "Firma valida.";
                }
                catch
                {
                    signatureInfo.IsValid = false;
                    signatureInfo.Message = "Firma non valida.";
                    return signatureInfo;
                }

                // Estrai le informazioni dei certificati
                signatureInfo.SignerCertificates = new List<CertificateInfo>();

                foreach (SignerInfo signer in signedCms.SignerInfos)
                {
                    X509Certificate2 signerCert = null;

                    // Cerca il certificato del firmatario
                    foreach (X509Certificate2 cert in signedCms.Certificates)
                    {
                        if (cert.Thumbprint == signer.Certificate.Thumbprint)
                        {
                            signerCert = cert;
                            break;
                        }
                    }

                    if (signerCert != null)
                    {
                        var certInfo = new CertificateInfo
                        {
                            Subject = signerCert.SubjectName.Name,
                            Issuer = signerCert.IssuerName.Name,
                            ValidFrom = signerCert.NotBefore,
                            ValidTo = signerCert.NotAfter,
                            Thumbprint = signerCert.Thumbprint,
                            SerialNumber = signerCert.SerialNumber,
                            IsExpired = signerCert.NotAfter < DateTime.Now,
                            SigningTime = signer.SignedAttributes.Cast<CryptographicAttributeObject>()
                                .Where(a => a.Oid.Value == "1.2.840.113549.1.9.3")
                                .FirstOrDefault() != null
                        };

                        signatureInfo.SignerCertificates.Add(certInfo);
                    }
                }

                // Estrai il contenuto originale
                signatureInfo.OriginalContent = signedCms.ContentInfo.Content;

                return signatureInfo;
            }
            catch (Exception ex)
            {
                signatureInfo.IsValid = false;
                signatureInfo.Message = $"Errore nella verifica: {ex.Message}";
                return signatureInfo;
            }
        }

        /// <summary>
        /// Estrae il file originale dal P7M
        /// </summary>
        public static bool ExtractContentFromP7M(string p7mFilePath, string outputFilePath)
        {
            try
            {
                var signatureInfo = VerifySignature(p7mFilePath);

                if (!signatureInfo.IsValid)
                {
                    return false;
                }

                if (signatureInfo.OriginalContent == null || signatureInfo.OriginalContent.Length == 0)
                {
                    return false;
                }

                File.WriteAllBytes(outputFilePath, signatureInfo.OriginalContent);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void TrovaCertificato()
        {

            try
            {
                X509Store storeX509 = new X509Store(StoreName.AddressBook, StoreLocation.CurrentUser);
                storeX509.Open(OpenFlags.MaxAllowed);
                X509Certificate2 certificato = storeX509.Certificates.Find(X509FindType.FindBySubjectName, "Emanuele", true)[0];
            }
            catch (Exception ex)
            {

                throw;
            }





        }

        private void BtnTrovaFileP7m_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Seleziona un file P7M";
                openFileDialog.Filter = "File P7M (*.p7m)|*.p7m|Tutti i file (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    TxtPercorsoFileFirmato.Text = openFileDialog.FileName;
                }
            }
        }

        private void BtnVerificaCertificato_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtPercorsoFileFirmato.Text))
            {
                MessageBox.Show("Selezionare un file P7M.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                SignatureInfo signatureInfo = VerifySignature(TxtPercorsoFileFirmato.Text);

                rtbResults.Clear();
                rtbResults.AppendText($"Stato Firma: {(signatureInfo.IsValid ? "VALIDA" : "NON VALIDA")}\n");
                rtbResults.AppendText($"Messaggio: {signatureInfo.Message}\n\n");
                rtbResults.AppendText("═══════════════════════════════════════════\n\n");

                if (signatureInfo.SignerCertificates != null && signatureInfo.SignerCertificates.Count > 0)
                {
                    rtbResults.AppendText($"Numero Firme: {signatureInfo.SignerCertificates.Count}\n\n");

                    int i = 1;
                    foreach (var cert in signatureInfo.SignerCertificates)
                    {
                        rtbResults.AppendText($"─── FIRMA {i} ───\n");
                        rtbResults.AppendText($"Soggetto: {cert.Subject}\n");
                        rtbResults.AppendText($"Emittente: {cert.Issuer}\n");
                        rtbResults.AppendText($"Valido Da: {cert.ValidFrom:dd/MM/yyyy HH:mm:ss}\n");
                        rtbResults.AppendText($"Valido Fino: {cert.ValidTo:dd/MM/yyyy HH:mm:ss}\n");
                        rtbResults.AppendText($"Scaduto: {(cert.IsExpired ? "SÌ" : "NO")}\n");
                        rtbResults.AppendText($"Thumbprint: {cert.Thumbprint}\n");
                        rtbResults.AppendText($"Numero Seriale: {cert.SerialNumber}\n\n");
                        i++;
                    }
                }

                // Colora il risultato
                if (signatureInfo.IsValid)
                {
                    rtbResults.Select(0, rtbResults.TextLength);
                    rtbResults.SelectionStart = 0;
                    rtbResults.SelectionLength = "Stato Firma: VALIDA".Length + 30;
                    rtbResults.SelectionColor = Color.Green;
                }
                else
                {
                    rtbResults.Select(0, rtbResults.TextLength);
                    rtbResults.SelectionStart = 0;
                    rtbResults.SelectionLength = "Stato Firma: NON VALIDA".Length + 30;
                    rtbResults.SelectionColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore nella verifica: {ex.Message}", "Errore",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEstraiCertificato_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtPercorsoFileFirmato.Text))
            {
                MessageBox.Show("Selezionare un file P7M.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Title = "Salva contenuto estratto";
                    saveFileDialog.FileName = Path.GetFileNameWithoutExtension(TxtPercorsoFileFirmato.Text);

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (ExtractContentFromP7M(TxtPercorsoFileFirmato.Text, saveFileDialog.FileName))
                        {
                            MessageBox.Show($"Contenuto estratto con successo!\n\nPercorso: {saveFileDialog.FileName}",
                                "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Errore nell'estrazione del contenuto.",
                                "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnVerificaFirma_Click(object sender, EventArgs e)
        {
         //   ValidaFirma.
        }
    }
}
