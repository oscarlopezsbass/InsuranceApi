using Azure;
using Insurance.Application.DTO_s;
using Insurance.Application.DTO_s.Insurance;
using Insurance.Application.Features.Handlers.Commands;
using Insurance.Application.Features.Requests.Commands;
using Insurance.Application.Features.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Insurance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InsuranceController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<InsuranceController>
        [HttpGet("getInsurancesPolicies")]
        public async Task<ActionResult<List<InsuranceDto>>> Get()
        {
            var Insurances = await _mediator.Send(new GetInsuranceList());
            return  Ok(Insurances);
        }

        // GET api/<InsuranceController>/5
        [HttpGet("getByLicencePlateOrPolicyNumber")]
        public async Task<ActionResult<InsuranceDto>> Get(string? licencePlate, Int32? policyNumber )
        {
            var Insurance = await _mediator.Send(new GetInsuranceByPlateOrPolicy { LicencePlate = licencePlate, PolicyNumber = policyNumber });
            return Ok(Insurance);
        }

        // POST api/<InsuranceController>
        [HttpPost("CreateInsurancePolicy")]
        public async Task<ActionResult> Post([FromBody] InsuranceCreateDto dto)
        {
            var command = new CreateInsurance { insuranceCreateDto = dto };
            var response =  await _mediator.Send(command);
            return Ok(response);
        }

      
    }
}
