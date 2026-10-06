using System;
using System.Collections.Generic;
using System.Text;

namespace Cervo.Models
{
    public class SignatureInfo
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public List<CertificateInfo> SignerCertificates { get; set; }
        public byte[] OriginalContent { get; set; }
    }

    public class CertificateInfo
    {
        public string Subject { get; set; }
        public string Issuer { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string Thumbprint { get; set; }
        public string SerialNumber { get; set; }
        public bool IsExpired { get; set; }
        public bool SigningTime { get; set; }
    }
}
