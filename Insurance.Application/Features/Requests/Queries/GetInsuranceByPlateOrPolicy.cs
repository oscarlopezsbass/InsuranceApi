using Insurance.Application.DTO_s;
using Insurance.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Features.Requests.Queries
{
    public class GetInsuranceByPlateOrPolicy : IRequest<InsuranceDto> 
    {
        public Int32? PolicyNumber { get; set; }
        public string? LicencePlate { get; set; }
    }
}
