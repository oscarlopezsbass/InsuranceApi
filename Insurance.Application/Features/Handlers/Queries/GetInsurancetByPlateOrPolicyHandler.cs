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
    public class GetInsurancetByPlateOrPolicyHandler : IRequestHandler<GetInsuranceByPlateOrPolicy,InsuranceDto>
    {
        private readonly IInsuranceRequestReporitory _insuranceRequestRepository;
        private readonly IMapper _mapper;

        public GetInsurancetByPlateOrPolicyHandler(IInsuranceRequestReporitory insuranceRequestReporitory, IMapper mapper)
        {
            _insuranceRequestRepository = insuranceRequestReporitory;
            _mapper = mapper;
        }
        public async Task<InsuranceDto> Handle(GetInsuranceByPlateOrPolicy request, CancellationToken cancellationToken)
        {
            var insurances = await _insuranceRequestRepository.GetAllPolicyInsuranceByPlateOrPolicyNumber(request.LicencePlate, request.PolicyNumber);

            return _mapper.Map<InsuranceDto>(insurances);
        }
    }
}
