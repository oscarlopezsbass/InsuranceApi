using AutoMapper;
using Insurance.Application.DTO_s;
using Insurance.Application.Features.Handlers.Queries;
using Insurance.Application.Persistence.Contracts;
using Insurance.Application.Profiles;
using Insurance.Domain;
using Insurance.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Insurance.UnitTests.InsurancePolicyTests.Queries
{
    public class GetInsuranceListHandlerTest
    {
        private readonly Mock<IInsuranceRequestReporitory> _mock;
        private readonly IMapper _mapper;
        public GetInsuranceListHandlerTest()
        {
            _mock = MockInsuranceRepository.GetInsurancePolicy();

            var mapperConfig = new MapperConfiguration(c => { c.AddProfile<MappingProfile>(); });

            _mapper =mapperConfig.CreateMapper();   
        }

        [Fact]
        public async Task GetInsuranceListTest() {
         
            var handler = new GetInsuranceListHandler(_mock.Object,_mapper);
            var result = await handler.Handle(new Application.Features.Requests.Queries.GetInsuranceList(), CancellationToken.None);

            result.ShouldBeOfType<List<InsuranceDto>>();
        }
    }
}
