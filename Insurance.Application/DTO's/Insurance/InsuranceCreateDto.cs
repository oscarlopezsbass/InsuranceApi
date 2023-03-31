using Insurance.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.DTO_s.Insurance
{
    public class InsuranceCreateDto : InsuranceDto
    {
        public Int32 PolicyNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ProtectionDescription { get; set; }
        public float MaxCoveredValue { get; set; }
        public string InsuranceTypeName { get; set; }
        public string CreatedBy { get; set; }
        public string LastModificatedBy { get; set; }
        public Client Client { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
