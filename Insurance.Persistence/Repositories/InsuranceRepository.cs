using Insurance.Application.Persistence.Contracts;
using Insurance.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Persistence.Repositories
{
    public class InsuranceRepository : GenericRepository<InsurancePolicy>, IInsuranceRequestReporitory
    {
        private readonly InsuranceDbContext _dbContext;
        public InsuranceRepository(InsuranceDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<InsurancePolicy>> GetAllPolicyInsurance()
        {


            var insurancePolicy = await _dbContext.InsurancePolicy
                .Include(c =>  c.Client)
                .Include(v=> v.Vehicle)
                .ToListAsync();

            return insurancePolicy;
        }

        public async Task<InsurancePolicy> GetAllPolicyInsuranceByPlateOrPolicyNumber(string ?licencePlate, int ?policyNumber)
        {


            var insurancePolicy = await _dbContext.InsurancePolicy
                .Include(c => c.Client)
                .Include(v => v.Vehicle)
                .FirstOrDefaultAsync(p=>p.Vehicle.LicensePlate== licencePlate || p.PolicyNumber== policyNumber);

            return insurancePolicy;
        }
    }
}
