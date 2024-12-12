using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFI.Application.DTOs.PKICertificate
{
    public class SearchCertificateConfirmedRequest
    {
        public int max_number_of_results { get; set; }
        public List<PropertyCriteria> criteria { get; set; }
    }


    public class PropertyCriteria
    {
        public string Property { get; set; }
        public string Value { get; set; }
        public string Operation { get; set; }
    }
}
