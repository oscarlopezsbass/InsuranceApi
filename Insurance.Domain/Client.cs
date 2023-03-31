using Insurance.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain
{
    public  class Client : BaseDomainEntity
    {

        public string Name { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string City{ get; set; }
        public string Address { get; set; }
        public string CreatedBy { get; set; }
        public string LastModificatedBy { get; set; }
    }
}
