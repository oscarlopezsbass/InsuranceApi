using AutoMapper;
using Insurance.Application.DTO_s.Insurance;
using Insurance.Application.Features.Handlers.Commands;
using Insurance.Application.Features.Requests.Commands;
using Insurance.Application.Persistence.Contracts;
using Insurance.Application.Profiles;
using Insurance.Application.Response;
using Insurance.Domain;
using Insurance.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.UnitTests.InsurancePolicyTests.Commands
{
    public class CreateInsuranceHandlerTests
    {
        private readonly Mock<IInsuranceRequestReporitory> _mock;
        private readonly IMapper _mapper;
        private readonly CreateInsuranceHandler _handler;
        private readonly InsuranceCreateDto _insuranceCreateDto;
        
        public CreateInsuranceHandlerTests()
        {
            
            _mock = new Mock<IInsuranceRequestReporitory>();
            var mapperConfig = new MapperConfiguration(c => { c.AddProfile<MappingProfile>(); });

            _mapper = mapperConfig.CreateMapper();

            _handler = new CreateInsuranceHandler(_mock.Object, _mapper);

            _insuranceCreateDto = new InsuranceCreateDto
            {
                PolicyNumber = 1000,
                StartDate = DateTime.Parse("2023-04-01T20:50:24.546Z"),
                EndDate = DateTime.Parse("2023-04-10T20:50:24.546Z"),
                InsuranceTypeName = "Full",
                MaxCoveredValue = 1000,
                ProtectionDescription = "Test test test",
                CreatedBy ="o",
                LastModificatedBy="o",
                Client = new Client
                {
                    Name = "Client 1",
                    IdentificationNumber = "11111",
                    BirthDate = DateTime.Now,
                    Address = "street 1 ",
                    City = "City test",
                    CreatedBy = "o",
                    LastModificatedBy = "o"
                },
                Vehicle = new Vehicle
                {
                    Model = "2000",
                    LicensePlate = "AAA000",
                    HasInspection = false,
                    CreatedBy = "o",
                    LastModificatedBy = "o"
                }
            };


        }

        [Fact]
        public async Task Valid_Insurence_Added() {
            var result = await _handler.Handle(new CreateInsurance() { insuranceCreateDto = _insuranceCreateDto }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBeTrue();

        }

        [Fact]
        public async Task Invalid_Insurence_Added()
        {
            _insuranceCreateDto.EndDate =  DateTime.Parse("2023-03-31T20:50:24.546Z");

            var result = await _handler.Handle(new CreateInsurance() { insuranceCreateDto = _insuranceCreateDto }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBeFalse();
        }
    }
}
