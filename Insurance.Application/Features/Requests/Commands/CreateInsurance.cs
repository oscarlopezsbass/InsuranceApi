using Insurance.Application.DTO_s;
using Insurance.Application.DTO_s.Insurance;
using Insurance.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Features.Requests.Commands
{
    public class CreateInsurance : IRequest<BaseCommandResponse>
    {
       public InsuranceCreateDto insuranceCreateDto { get; set; }
    }
}
