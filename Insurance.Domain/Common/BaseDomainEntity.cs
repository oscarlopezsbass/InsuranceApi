using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Common
{
    public abstract class BaseDomainEntity
    {

        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModificatedDate { get; set; }
        public string LastModificatedBy { get; set; }

    }
}
