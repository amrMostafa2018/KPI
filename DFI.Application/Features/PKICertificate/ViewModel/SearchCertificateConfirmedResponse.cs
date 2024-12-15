using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFI.Application.Features.PKICertificate.ViewModel
{
    public class SearchCertificateConfirmedResponse
    {
        public List<certificateResponse> certificates { get; set; }
        public bool more_results { get; set; }
    }

    public class certificateResponse
    {
        public string certificate { get; set; }
        public string serial_number { get; set; }
        public string response_format { get; set; }
        public string certificate_profile { get; set; }
        public string end_entity_profile { get; set; }
    }
}
