using Insurance.Application.DTO_s;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Features.Requests.Queries
{
    public class GetInsuranceList : IRequest<List<InsuranceDto>> 
    {
        public int id { get; set; }
    }
}
