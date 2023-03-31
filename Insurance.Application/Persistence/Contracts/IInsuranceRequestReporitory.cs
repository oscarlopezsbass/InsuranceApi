using Insurance.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Persistence.Contracts
{
    public interface IInsuranceRequestReporitory : IGenericRepository<InsurancePolicy>
    {
        public Task<InsurancePolicy> Add(InsurancePolicy entity);

        public Task<InsurancePolicy> Detele(InsurancePolicy entity);

        public Task<InsurancePolicy> Get(int id);
        public Task<IReadOnlyList<InsurancePolicy>> GetAll();

        public Task<InsurancePolicy> Update(InsurancePolicy entity);

        public Task<IReadOnlyList<InsurancePolicy>> GetAllPolicyInsurance();

        public Task <InsurancePolicy> GetAllPolicyInsuranceByPlateOrPolicyNumber(string? licencePlate, int? policyNumber);
    }
}
