using Insurance.Application.Persistence.Contracts;
using Insurance.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePresistenceServices(this IServiceCollection services, IConfiguration configuration) {

            services.AddDbContext<InsuranceDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("InsuranceConnectionString")
                ));
            services.AddScoped(typeof (IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IInsuranceRequestReporitory, InsuranceRepository>();

            return services; 
        }
    }
}
