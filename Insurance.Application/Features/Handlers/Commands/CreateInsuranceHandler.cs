using AutoMapper;
using Insurance.Application.DTO_s.Insurance.Validators;
using Insurance.Application.Features.Requests.Commands;
using Insurance.Application.Persistence.Contracts;
using Insurance.Application.Response;
using Insurance.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Features.Handlers.Commands
{
    public class CreateInsuranceHandler : IRequestHandler<CreateInsurance, BaseCommandResponse>
    {
        private readonly IInsuranceRequestReporitory _insuranceRequestRepository;
        private readonly IMapper _mapper;

        public CreateInsuranceHandler(IInsuranceRequestReporitory insuranceRequestReporitory, IMapper mapper)
        {
            _insuranceRequestRepository = insuranceRequestReporitory;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateInsurance request, CancellationToken cancellationToken)
        {


            BaseCommandResponse response = new BaseCommandResponse();
            var validator = new CreateInsuranceDtoValidator();
            var validationResult = await validator.ValidateAsync(request.insuranceCreateDto);

            var Insurance = _mapper.Map<InsurancePolicy>(request.insuranceCreateDto);

            Insurance = await _insuranceRequestRepository.Add(Insurance);
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation failed";
                response.Errors = validationResult.Errors.Select(e=> e.ErrorMessage).ToList();
            }
            else {
                response.Success = true;
                response.Message = "Creation Successful";
            }



            return response;
        }
    }
}
