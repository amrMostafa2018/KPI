using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFI.Application.DTOs.PKICertificate
{
    public class SearchCertificateConfirmedRequest
    {
        public int Max_Number_Of_Results { get; set; }
        public List<PropertyCriteria> Criteria { get; set; }
    }



    public class PropertyCriteria
    {
        public string Property { get; set; }
        public string Value { get; set; }
        public string Operation { get; set; }
    }
}
