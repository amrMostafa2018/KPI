using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFI.Application.DTOs.PKICertificate
{
    public class RevokeSpecifiedCertificateRequest
    {
        public string IssuerDn { get; set; }
        public string CertificateSerialNumber { get; set; }
        public string Reason { get; set; }
        public string Date { get; set; }
        public string InvalidityDate { get; set; }
    }
}


//max_number_of_results