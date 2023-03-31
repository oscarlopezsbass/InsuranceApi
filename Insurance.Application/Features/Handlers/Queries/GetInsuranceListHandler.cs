using AutoMapper;
using Insurance.Application.DTO_s;
using Insurance.Application.Features.Requests.Queries;
using Insurance.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Features.Handlers.Queries
{
    public class GetInsuranceListHandler : IRequestHandler<Requests.Queries.GetInsuranceList, List<InsuranceDto>>
    {
        private readonly IInsuranceRequestReporitory _insuranceRequestRepository;
        private readonly IMapper _mapper;

        public GetInsuranceListHandler(IInsuranceRequestReporitory insuranceRequestReporitory, IMapper mapper)
        {
            _insuranceRequestRepository = insuranceRequestReporitory;
            _mapper = mapper;
        }
        public async Task<List<InsuranceDto>> Handle(Requests.Queries.GetInsuranceList request, CancellationToken cancellationToken)
        {
            var insurances = await _insuranceRequestRepository.GetAllPolicyInsurance();

            return _mapper.Map<List<InsuranceDto>>(insurances);
        }
    }
}
