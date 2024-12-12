using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFI.Application.DTOs.PKICertificate
{
    public class CertificatePkcs10EnrollRequest
    {
        public string certificate_request { get; set; }
        public string certificate_profile_name { get; set; } = "DigitalIdentityProfile";
        public string end_entity_profile_name { get; set; } = "DigitalIdentityProfile";
        public string certificate_authority_name { get; set; } = "DFIRootCA";
        public string username { get; set; }
        public bool? include_chain { get; set; } = false;
    }
}
