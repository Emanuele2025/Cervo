using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Cervo.Models
{
    public static class ValidaFirma
    {


        public static ValidationResult ValidateCertificate(X509Certificate2 certificate)
        {
            var result = new ValidationResult();
            result.Certificate = certificate;
            result.Subject = certificate.SubjectName.Name;
            result.Issuer = certificate.IssuerName.Name;

            // Controlla la scadenza
            CheckExpiry(certificate, result);

            // Controlla l'uso della chiave
            CheckKeyUsage(certificate, result);

            // Controlla le estensioni critiche
            CheckCriticalExtensions(certificate, result);

            // Controlla il formato della data
            CheckDateValidity(certificate, result);

            // Determina lo stato generale
            DetermineOverallStatus(result);

            return result;
        }

        /// <summary>
        /// Controlla se il certificato è scaduto
        /// </summary>
        private static void CheckExpiry(X509Certificate2 certificate, ValidationResult result)
        {
            DateTime now = DateTime.Now;

            if (now < certificate.NotBefore)
            {
                result.IsExpired = false;
                result.IsNotYetValid = true;
                result.Issues.Add("Il certificato non è ancora valido. Diventerà valido il " +
                    certificate.NotBefore.ToString("dd/MM/yyyy HH:mm:ss"));
                result.Status = ValidationStatus.NotYetValid;
            }
            else if (now > certificate.NotAfter)
            {
                result.IsExpired = true;
                result.Issues.Add("Il certificato è SCADUTO. Data di scadenza: " +
                    certificate.NotAfter.ToString("dd/MM/yyyy HH:mm:ss"));
                result.Status = ValidationStatus.Expired;
            }
            else
            {
                result.IsExpired = false;
                result.IsNotYetValid = false;

                // Calcola i giorni rimanenti
                TimeSpan remaining = certificate.NotAfter - now;
                result.DaysUntilExpiry = (int)remaining.TotalDays;

                if (result.DaysUntilExpiry <= 30)
                {
                    result.Issues.Add($"AVVISO: Il certificato scadrà tra {result.DaysUntilExpiry} giorni " +
                        $"({certificate.NotAfter:dd/MM/yyyy})");
                    result.Status = ValidationStatus.Expiringsoon;
                }
            }
        }
        /// <summary>
        /// Controlla l'uso della chiave del certificato
        /// </summary>
        private static void CheckKeyUsage(X509Certificate2 certificate, ValidationResult result)
        {
            try
            {
                X509KeyUsageExtension keyUsageExt = certificate.Extensions["2.5.29.15"] as X509KeyUsageExtension;

                if (keyUsageExt != null)
                {
                    result.KeyUsage = new List<string>();

                    if ((keyUsageExt.KeyUsages & X509KeyUsageFlags.DigitalSignature) != 0)
                        result.KeyUsage.Add("Digital Signature");

                    if ((keyUsageExt.KeyUsages & X509KeyUsageFlags.NonRepudiation) != 0)
                        result.KeyUsage.Add("Non Repudiation");

                    if ((keyUsageExt.KeyUsages & X509KeyUsageFlags.KeyEncipherment) != 0)
                        result.KeyUsage.Add("Key Encipherment");

                    if ((keyUsageExt.KeyUsages & X509KeyUsageFlags.DataEncipherment) != 0)
                        result.KeyUsage.Add("Data Encipherment");

                    if ((keyUsageExt.KeyUsages & X509KeyUsageFlags.KeyAgreement) != 0)
                        result.KeyUsage.Add("Key Agreement");

                    if ((keyUsageExt.KeyUsages & X509KeyUsageFlags.KeyCertSign) != 0)
                        result.KeyUsage.Add("Key Cert Sign");

                    if ((keyUsageExt.KeyUsages & X509KeyUsageFlags.CrlSign) != 0)
                        result.KeyUsage.Add("CRL Sign");

                    // Verifica che la firma digitale sia consentita
                    if ((keyUsageExt.KeyUsages & X509KeyUsageFlags.DigitalSignature) == 0)
                    {
                        result.Issues.Add("Il certificato non è abilitato per la firma digitale.");
                        result.Status = ValidationStatus.Invalid;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Warnings.Add($"Errore nel controllo dell'uso della chiave: {ex.Message}");
            }
        }
        /// <summary>
        /// Controlla le estensioni critiche
        /// </summary>
        private static void CheckCriticalExtensions(X509Certificate2 certificate, ValidationResult result)
        {
            try
            {
                result.CriticalExtensions = new List<string>();

                foreach (X509Extension ext in certificate.Extensions)
                {
                    if (ext.Critical)
                    {
                        result.CriticalExtensions.Add($"{ext.Oid.FriendlyName} ({ext.Oid.Value})");
                    }
                }
            }
            catch (Exception ex)
            {
                result.Warnings.Add($"Errore nel controllo delle estensioni: {ex.Message}");
            }
        }

        /// <summary>
        /// Controlla la validità della data
        /// </summary>
        private static void CheckDateValidity(X509Certificate2 certificate, ValidationResult result)
        {
            try
            {
                result.ValidFrom = certificate.NotBefore;
                result.ValidTo = certificate.NotAfter;

                if (certificate.NotAfter <= certificate.NotBefore)
                {
                    result.Issues.Add("La data di scadenza è anteriore o uguale alla data di inizio validità.");
                    result.Status = ValidationStatus.Invalid;
                }
            }
            catch (Exception ex)
            {
                result.Warnings.Add($"Errore nel controllo della validità della data: {ex.Message}");
            }
        }

        /// <summary>
        /// Controlla se il certificato è autorità di certificazione (CA)
        /// </summary>
        public static bool IsCertificateAuthority(X509Certificate2 certificate)
        {
            try
            {
                X509BasicConstraintsExtension basicConstraints =
                    certificate.Extensions["2.5.29.19"] as X509BasicConstraintsExtension;

                return basicConstraints != null && basicConstraints.CertificateAuthority;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// Controlla la catena di certificati
        /// </summary>
        public static ChainValidationResult ValidateCertificateChain(X509Certificate2 certificate)
        {
            var result = new ChainValidationResult();
            result.Certificate = certificate;

            try
            {
                using (X509Chain chain = new X509Chain())
                {
                    // Configura il controllo della catena
                    chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
                    chain.ChainPolicy.RevocationFlag = X509RevocationFlag.ExcludeRoot;
                    chain.ChainPolicy.VerificationFlags = X509VerificationFlags.NoFlag;
                    chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 0, 5);

                    // Costruisci la catena
                    bool isValid = chain.Build(certificate);
                    result.IsValid = isValid;

                    // Estrai gli elementi della catena
                    result.ChainElements = new List<ChainElementInfo>();
                    foreach (X509ChainElement element in chain.ChainElements)
                    {
                        var elementInfo = new ChainElementInfo
                        {
                            Certificate = element.Certificate.SubjectName.Name,
                            Thumbprint = element.Certificate.Thumbprint,
                            Status = new List<string>()
                        };

                        // Aggiungi i dettagli dello stato
                        foreach (X509ChainStatus status in element.ChainElementStatus)
                        {
                            elementInfo.Status.Add($"{status.Status}: {status.StatusInformation}");
                        }

                        result.ChainElements.Add(elementInfo);
                    }

                    // Analizza gli errori della catena
                    if (!isValid)
                    {
                        result.ChainErrors = new List<string>();
                        foreach (X509ChainStatus status in chain.ChainStatus)
                        {
                            result.ChainErrors.Add($"{status.Status}: {status.StatusInformation}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.ChainErrors = new List<string> { $"Errore durante la validazione della catena: {ex.Message}" };
            }

            return result;
        }

        /// <summary>
        /// Controlla la revoca tramite CRL (Certificate Revocation List)
        /// </summary>
        public static RevocationCheckResult CheckRevocationByCRL(X509Certificate2 certificate)
        {
            var result = new RevocationCheckResult();
            result.CheckMethod = "CRL";

            try
            {
                using (X509Chain chain = new X509Chain())
                {
                    chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
                    chain.ChainPolicy.RevocationFlag = X509RevocationFlag.ExcludeRoot;
                    chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 0, 5);

                    bool isValid = chain.Build(certificate);
                    result.IsRevoked = false;
                    result.Status = "Certificato non revocato (CRL)";

                    foreach (X509ChainStatus status in chain.ChainStatus)
                    {
                        if (status.Status == X509ChainStatusFlags.Revoked)
                        {
                            result.IsRevoked = true;
                            result.Status = "Certificato REVOCATO";
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Status = $"Errore nel controllo CRL: {ex.Message}";
                result.Error = ex;
            }

            return result;
        }

        /// <summary>
        /// Determina lo stato generale della validazione
        /// </summary>
        private static void DetermineOverallStatus(ValidationResult result)
        {
            if (result.Status != ValidationStatus.Unknown)
                return;

            if (result.Issues.Count > 0)
            {
                result.Status = ValidationStatus.Invalid;
            }
            else if (result.DaysUntilExpiry < 0)
            {
                result.Status = ValidationStatus.Expired;
            }
            else if (result.DaysUntilExpiry <= 30)
            {
                result.Status = ValidationStatus.Expiringsoon;
            }
            else
            {
                result.Status = ValidationStatus.Valid;
            }
        }
        /// <summary>
        /// Ottiene una descrizione leggibile dello stato di validazione
        /// </summary>
        public static string GetStatusDescription(ValidationStatus status)
        {
            return status switch
            {
                ValidationStatus.Valid => "✓ Certificato Valido",
                ValidationStatus.Expired => "✗ Certificato Scaduto",
                ValidationStatus.ExpiringFast => " Scadenza Imminente",
                ValidationStatus.ExpiringFoon => "  Scadenza Prossima",
                ValidationStatus.NotYetValid => "  Certificato Non Ancora Valido",
                ValidationStatus.Invalid => "✗ Certificato Non Valido",
                ValidationStatus.Revoked => "✗ Certificato Revocato",
                _ => "? Stato Sconosciuto"
            };
        }

    }





    /// <summary>
    /// Enum per lo stato di validazione
    /// </summary>
    public   enum ValidationStatus
    {
        Unknown,
        Valid,
        Expired,
        ExpiringFast,
        ExpiringFoon,
        NotYetValid,
        Invalid,
        Revoked,
        Expiringsoon
    }

    /// <summary>
    /// Classe per i risultati della validazione
    /// </summary>
    public   class ValidationResult
    {
        public X509Certificate2 Certificate { get; set; }
        public string Subject { get; set; }
        public string Issuer { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public bool IsExpired { get; set; }
        public bool IsNotYetValid { get; set; }
        public int DaysUntilExpiry { get; set; }
        public ValidationStatus Status { get; set; } = ValidationStatus.Unknown;
        public List<string> Issues { get; set; } = new List<string>();
        public List<string> Warnings { get; set; } = new List<string>();
        public List<string> KeyUsage { get; set; } = new List<string>();
        public List<string> CriticalExtensions { get; set; } = new List<string>();
    }

    /// <summary>
    /// Classe per i risultati della validazione della catena
    /// </summary>
    public class ChainValidationResult
    {
        public X509Certificate2 Certificate { get; set; }
        public bool IsValid { get; set; }
        public List<ChainElementInfo> ChainElements { get; set; }
        public List<string> ChainErrors { get; set; }
    }

    /// <summary>
    /// Classe per le informazioni degli elementi della catena
    /// </summary>
    public class ChainElementInfo
    {
        public string Certificate { get; set; }
        public string Thumbprint { get; set; }
        public List<string> Status { get; set; }
    }

    /// <summary>
    /// Classe per i risultati del controllo di revoca
    /// </summary>
    public class RevocationCheckResult
    {
        public string CheckMethod { get; set; }
        public bool IsRevoked { get; set; }
        public string Status { get; set; }
        public Exception Error { get; set; }
    }







}
