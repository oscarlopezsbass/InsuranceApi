using Insurance.Application.Persistence.Contracts;
using Insurance.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.UnitTests.Mocks
{
    public static class MockInsuranceRepository
    {
        public static Mock<IInsuranceRequestReporitory> GetInsurancePolicy()
        {
            List<InsurancePolicy> insurance = new List<InsurancePolicy> {
              new InsurancePolicy {
                  Id=1,
                  PolicyNumber=1000,
                  StartDate= DateTime.Now,
                  EndDate = DateTime.Now,
                  InsuranceTypeName = "Full",
                  MaxCoveredValue=1000,
                  ProtectionDescription= "Test test test",
                  Client = new Client{
                       Name="Client 1",
                       IdentificationNumber="11111",
                       BirthDate= DateTime.Now,
                       Address= "street 1 ",
                       City = "City test",          
                  },
                  Vehicle = new Vehicle{ 
                       Model= "2000",
                       LicensePlate="AAA000",
                       HasInspection=false  
                  }
              }
            };

            var mock = new Mock<IInsuranceRequestReporitory>();

            mock.Setup(r => r.GetAllPolicyInsurance()).ReturnsAsync(insurance);
            mock.Setup(r => r.Add(It.IsAny<InsurancePolicy>())).ReturnsAsync((InsurancePolicy insurancePolicy) =>
            {
                insurance.Add(insurancePolicy);

                return insurancePolicy;
            });
                return mock;
        }
    }
}
