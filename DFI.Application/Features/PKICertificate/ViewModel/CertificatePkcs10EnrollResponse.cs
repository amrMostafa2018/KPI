using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFI.Application.Features.PKICertificate.ViewModel
{
    public class CertificatePkcs10EnrollResponse
    {
        public string Certificate { get; set; }
        public string Serial_Number { get; set; }
        public string Response_Format { get; set; }
        public List<string> Certificate_Chain { get; set; }
    }
}
