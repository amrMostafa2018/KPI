using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFI.Application.DTOs.PKICertificate
{
    public class CertificatePkcs10EnrollRequest
    {
        public string Certificate_Request { get; set; }
        public string Certificate_Profile_Name { get; set; } = "DigitalIdentityProfile";
        public string End_Entity_Profile_Name { get; set; } = "DigitalIdentityProfile";
        public string Certificate_Authority_Name { get; set; } = "DFIRootCA";
        public string UserName { get; set; }
        public bool? Include_Chain { get; set; } = false;
    }
}
