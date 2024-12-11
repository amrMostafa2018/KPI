using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFI.Application.Features.PKICertificate.ViewModel
{
    public class RevokeSpecifiedCertificateResponse
    {
        public string Issuer_dn { get; set; }
        public string Serial_number { get; set; }
        public string Revocation_reason { get; set; }
        public DateTime Revocation_date { get; set; }
        public DateTime Invalidity_date { get; set; }
        public string Message { get; set; }
        public bool Revoked { get; set; }
    }
}
