using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFI.Application.DTOs.PKICertificate
{
    public class RevokeSpecifiedCertificateRequest
    {
        public string issuerDn { get; set; }
        public string certificateSerialNumber { get; set; }
        public string reason { get; set; }
        public string date { get; set; }
        public string invalidityDate { get; set; }
    }
}

