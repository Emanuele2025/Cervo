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
using static Cervo.Models.CertificateValidator;

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
                X509Store storeX509 = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
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
            //TODO:
            //verificare se quando è scaduta è comunque errore la firma, ossia non valida.
            if (string.IsNullOrEmpty(TxtPercorsoFileFirmato.Text))
            {
                Utility.MessaggioInfo("Selezionare un file P7M.");
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
                Utility.MessaggioErrore(Utility.Errore + ex.Message);
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
                Utility.MessaggioErrore(Utility.Errore + ex.Message);

            }
        }

        private void BtnVerificaFirma_Click(object sender, EventArgs e)
        {
            //   ValidaFirma.
        }

        private void BtnChiudi_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #region Funzione Verifica Firma

        /// <summary>
        /// Verifica se il certificato in un file .p7m è scaduto o revocato
        /// </summary>
        /// <param name="p7mFilePath">Percorso completo del file .p7m</param>
        /// <returns>Risultato della verifica con dettagli dello stato del certificato</returns>
        public static P7mCertificateCheckResult CheckP7mCertificateStatus(string p7mFilePath)
        {
            var result = new P7mCertificateCheckResult();

            try
            {
                // Verifica se il file esiste
                if (!File.Exists(p7mFilePath))
                {
                    result.IsValid = false;
                    result.StatusMessage = $"File non trovato: {p7mFilePath}";
                    return result;
                }

                // Verifica se ha estensione .p7m
                if (!p7mFilePath.EndsWith(".p7m", StringComparison.OrdinalIgnoreCase))
                {
                    result.IsValid = false;
                    result.StatusMessage = "Il file non ha estensione .p7m";
                    return result;
                }

                // Leggi il contenuto del file
                byte[] fileContent = File.ReadAllBytes(p7mFilePath);

                // Decodifica il file PKCS#7
                SignedCms signedCms = new SignedCms();
                signedCms.Decode(fileContent);

                // Verifica se sono presenti certificati
                if (signedCms.Certificates.Count == 0)
                {
                    result.IsValid = false;
                    result.StatusMessage = "Nessun certificato trovato nel file .p7m";
                    return result;
                }

                // Estrai il certificato firmante (il primo)
                X509Certificate2 signingCert = signedCms.Certificates[0];

                // Utilizza CertificateValidator per validare il certificato
                //CertificateValidationResult certValidationResult = ValidaFirma.ValidateCertificate(signingCert);

                //// Popola il risultato
                //result.IsValid = certValidationResult.IsValid;
                //result.StatusMessage = certValidationResult.ErrorMessage;
                //result.IsExpired = certValidationResult.IsExpired;
                //result.IsRevoked = certValidationResult.IsRevoked;
                //result.Subject = certValidationResult.Subject;
                //result.Issuer = certValidationResult.Issuer;
                //result.Thumbprint = certValidationResult.Thumbprint;
                //result.NotBefore = signingCert.NotBefore;
                //result.NotAfter = signingCert.NotAfter;
                //result.SerialNumber = signingCert.SerialNumber;

                // Calcola giorni rimanenti fino alla scadenza
                //if (!certValidationResult.IsExpired)
                //{
                //    result.DaysUntilExpiration = (int)(signingCert.NotAfter - DateTime.UtcNow).TotalDays;
                //}

                return result;
            }
            catch (CryptographicException ex)
            {
                result.IsValid = false;
                result.StatusMessage = $"Errore nella decodifica del file .p7m: {ex.Message}";
                return result;
            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.StatusMessage = $"Errore durante la verifica: {ex.Message}";
                return result;
            }
        }








        #endregion
















        private void BtnVerificaCertificatoFirmato_Click(object sender, EventArgs e)
        {
            //TODO: Controllo
            VerificaCertificatoDaFileFirmato(TxtPercorsoFileFirmatoDigitalmente.Text);
        }

        private void BtnTrovaCertificatoFileFirmato_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Seleziona un file P7M";
                openFileDialog.Filter = "File P7M (*.p7m)|*.p7m|Tutti i file (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    TxtPercorsoFileFirmatoDigitalmente.Text = openFileDialog.FileName;
                }
            }
        }


        #region VerificaCertificato

        private void VerificaCertificatoDaFileFirmato(string percorso)
        {


            // Verifica se il file esiste
            if (!File.Exists(percorso))
            {
                Utility.MessaggioInfo($"File non trovato: {percorso}");
                return;
            }

            // Verifica se ha estensione .p7m
            if (!percorso.EndsWith(".p7m", StringComparison.OrdinalIgnoreCase))
            {
                Utility.MessaggioInfo("Il file non ha estensione .p7m");
                return;

            }

            // Leggi il contenuto del file
            byte[] fileContent = File.ReadAllBytes(percorso);

            // Decodifica il file PKCS#7
            SignedCms signedCms = new SignedCms();
            signedCms.Decode(fileContent);

            // Verifica se sono presenti certificati
            if (signedCms.Certificates.Count == 0)
            {
                Utility.MessaggioInfo("INessun certificato trovato nel file .p7m");
                return;

            }

            // Estrai il certificato firmante (il primo)
            X509Certificate2 signingCert = signedCms.Certificates[0];
            var risultato = Certificati.ValidateCertificate2(signingCert);
            string message = $"Stato validazione: {(risultato.IsValid ? "✓ VALIDO" : "✗ NON VALIDO")}\n\n";

            message += $"Messaggio: {risultato.ErrorMessage}\n\n";

            if (risultato.IsValid)
            {
                message += $"Subject: {risultato.Subject}\n";
                message += $"Issuer: {risultato.Issuer}\n";
                message += $"Valido da: {risultato.NotBefore:dd/MM/yyyy HH:mm:ss}\n";
                message += $"Valido fino a: {risultato.NotAfter:dd/MM/yyyy HH:mm:ss}\n";
                message += $"Giorni rimanenti: {risultato.DaysUntilExpiration}\n";
                message += $"Thumbprint: {risultato.Thumbprint}\n";
            }

            MessageBox.Show(message, "Risultato Validazione", MessageBoxButtons.OK,
                risultato.IsValid ? MessageBoxIcon.Information : MessageBoxIcon.Warning);


        }





        #endregion










        private void BtnTrovaFileP7mCertificati_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Seleziona un file P7M";
                openFileDialog.Filter = "File P7M (*.p7m)|*.p7m|Tutti i file (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    TxtPercorsoNomeFileP7mPerCertificato.Text = openFileDialog.FileName;
                }
            }
        }

        private void BtnTrovaFilePerEstraiFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Seleziona un file P7M";
                openFileDialog.Filter = "File P7M (*.p7m)|*.p7m|Tutti i file (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    TxtPercorsoNomeFilePerEstraiFile.Text = openFileDialog.FileName;
                }
            }
        }

        private void BtnEstraFileDaP7m_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TxtPercorsoNomeFilePerEstraiFile.Text.Trim()))
                {
                    Utility.MessaggioInfo("Selezionare un file firmato di tipo .p7m");

                    return;

                }
            }
            catch (Exception ex)
            {
                Utility.MessaggioErrore(Utility.Errore + ex.Message);
            }




        }

        private void BtnEstraiFileCertificato_Click(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrEmpty(TxtPercorsoNomeFileP7mPerCertificato.Text.Trim()))
                {
                    Utility.MessaggioInfo("Selezionare un file firmato di tipo .p7m");

                    return;

                }

                var certificati = EstraiCertificati(TxtPercorsoNomeFileP7mPerCertificato.Text.Trim());

                if (certificati.Count == 0)
                {
                    Utility.MessaggioInfo("Nessun certificato trovato nel file.");
                    return;
                }

                X509Certificate2 certificato = certificati[0];

                string valoreSubectNameCertificato = certificato?.SubjectName?.Name ?? "";
                if (valoreSubectNameCertificato == "")
                {
                    valoreSubectNameCertificato = "Certificato";
                }
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Certificato DER (*.cer)|*.cer";
                    saveFileDialog.Title = "Salva il certificato.";
                    if (certificato != null)
                    {

                        //Rileva il nome dal subject 
                        string NomeFile = RilevaNomeDalSubject(certificato);
                        saveFileDialog.FileName = $"{NomeFile}.cer";
                        saveFileDialog.DefaultExt = "cer";
                        saveFileDialog.AddExtension = true;

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {

                            string percorsoNomeFileDaSalvare = saveFileDialog.FileName;

                            if (certificato != null)
                            {
                                byte[] certBytes = certificato.Export(X509ContentType.Cert);
                                File.WriteAllBytes(percorsoNomeFileDaSalvare, certBytes);

                            }

                            Utility.MessaggioInfo($"Certificato salvato con successo:\n{percorsoNomeFileDaSalvare}");

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Utility.MessaggioErrore(Utility.Errore + ex.Message);
            }
        }









        #region Gestione certificati

        /// <summary>
        /// Funzione per la gestione dello stato dei certificati
        /// </summary>
        /// <param name="certificate"></param>
        private void VerificatoStatoCertificato(X509Certificate2 certificate)
        {
            // --- CONTROLLO SCADENZA (Semplice) ---
            DateTime oggi = DateTime.Now;
            if (oggi < certificate.NotBefore)
            {
                Utility.MessaggioInfo($"Il certificato non è ancora valido.\nInizio validità: {certificate.NotBefore}");

                return;
            }
            if (oggi > certificate.NotAfter)
            {
                Utility.MessaggioInfo($"Il certificato è SCADUTO.\nData di scadenza: {certificate.NotAfter}");
                return;
            }

            // --- CONTROLLO REVOCA E CATENA (Avanzato) ---
            using (X509Chain chain = new X509Chain())
            {
                // Configurazione della politica di validazione
                chain.ChainPolicy.RevocationMode = X509RevocationMode.Online; // Forza controllo revoca online (CRL/OCSP)
                chain.ChainPolicy.RevocationFlag = X509RevocationFlag.ExcludeRoot; // Non controlla la revoca della Root CA
                chain.ChainPolicy.VerificationFlags = X509VerificationFlags.NoFlag;

                // Build() esegue la verifica effettiva
                bool isValidChain = chain.Build(certificate);

                if (isValidChain)
                {
                    Utility.MessaggioInfo("Il certificato è VALIDO, non è scaduto e non risulta revocato.");
                }
                else
                {
                    // Se isValidChain è false, analizziamo i motivi specifici (es. Revocazione)
                    string erroriTrovati = "";
                    foreach (X509ChainStatus status in chain.ChainStatus)
                    {
                        // Filtriamo per trovare specificamente la revoca
                        if (status.Status == X509ChainStatusFlags.Revoked)
                        {
                            erroriTrovati += " IL CERTIFICATO È STATO REVOCATO!\n";
                        }
                        else
                        {
                            erroriTrovati += $"  {status.Status}: {status.StatusInformation}\n";
                        }
                    }

                    Utility.MessaggioInfo($"Il certificato non è valido:\n\n{erroriTrovati}");
                }
            }
        }

        /// <summary>
        /// Metodo che estrapola i certificati del file p7m
        /// </summary>
        /// <param name="percorso"></param>
        /// <returns></returns>
        public static X509Certificate2Collection EstraiCertificati(string percorso)
        {
            byte[] dati = File.ReadAllBytes(percorso);

            var signedCms = new SignedCms();
            signedCms.Decode(dati);   // decodifica la struttura PKCS#7/CMS

            // I certificati inclusi nella firma
            return signedCms.Certificates;
        }


        /// <summary>
        /// Estrae il nome dal certificato
        /// </summary>
        private string RilevaNomeDalSubject(X509Certificate2 certificato)
        {
            return certificato.GetNameInfo(X509NameType.SimpleName, false);
        }



        #endregion




        private void BtnTrovaFilePerVerifica_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Seleziona un file P7M";
                openFileDialog.Filter = "File P7M (*.p7m)|*.p7m|Tutti i file (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    TxtPercorsoFileP7mVerifica.Text = openFileDialog.FileName;
                }
            }
        }

        private void BtnVerifica_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtPercorsoFileP7mVerifica.Text.Trim()))
            {
                Utility.MessaggioInfo("Selezionare un file firmato di tipo .p7m");
                return;

            }

            X509Certificate2 certificate = new X509Certificate2(TxtPercorsoFileP7mVerifica.Text.Trim());

            //Eseguo la funzione
            VerificatoStatoCertificato(certificate);
        }


        #region Funzioni

        /// <summary>
        /// Funzione per estrapolare le informazioni da un file firmato digitalmente formato p7m
        /// </summary>
        /// <param name="p7mFilePath"></param>
        /// <returns></returns>
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

        #endregion

        private void BtnEsporta_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog
            {
                Title = "Salva file",
                Filter = "File RTF (*.rtf)|*.rtf|Testo (*.txt)|*.txt",
                DefaultExt = "rtf",
                FileName = "Documento.rtf"
            })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Salva come RTF senza oggetti OLE
                        rtbResults.SaveFile(dlg.FileName, RichTextBoxStreamType.RichNoOleObjs);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Errore: {ex.Message}", "Errore salvataggio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
    /// <summary>
    /// Risultato della verifica dello stato del certificato in un file .p7m
    /// </summary>
    public class P7mCertificateCheckResult
    {
        /// <summary>
        /// Indica se il certificato è valido (non scaduto e non revocato)
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// Messaggio di stato (valido, scaduto, revocato, ecc.)
        /// </summary>
        public string StatusMessage { get; set; } = "";

        /// <summary>
        /// True se il certificato è scaduto
        /// </summary>
        public bool IsExpired { get; set; }

        /// <summary>
        /// True se il certificato è revocato
        /// </summary>
        public bool IsRevoked { get; set; }

        /// <summary>
        /// Subject del certificato
        /// </summary>
        public string Subject { get; set; } = "";

        /// <summary>
        /// Issuer del certificato
        /// </summary>
        public string Issuer { get; set; } = "";

        /// <summary>
        /// Thumbprint (impronta) del certificato
        /// </summary>
        public string Thumbprint { get; set; } = "";

        /// <summary>
        /// Data di inizio validità del certificato
        /// </summary>
        public DateTime NotBefore { get; set; }

        /// <summary>
        /// Data di fine validità del certificato
        /// </summary>
        public DateTime NotAfter { get; set; }

        /// <summary>
        /// Numero seriale del certificato
        /// </summary>
        public string SerialNumber { get; set; } = "";

        /// <summary>
        /// Giorni rimanenti fino alla scadenza (null se scaduto)
        /// </summary>
        public int? DaysUntilExpiration { get; set; }
    }

}
