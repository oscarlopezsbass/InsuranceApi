using Insurance.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain
{
    public  class VehicleDto : BaseDomainEntity
    {
       
        public string LicensePlate { get; set; }
        public string Model { get; set; }
        public bool HasInspection { get; set; }
    }
}
