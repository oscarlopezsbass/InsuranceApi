using AutoMapper;
using Insurance.Application.DTO_s;
using Insurance.Application.DTO_s.Insurance;
using Insurance.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<InsurancePolicy, InsuranceDto>().ReverseMap();
            CreateMap<InsurancePolicy, InsuranceCreateDto>().ReverseMap();

            CreateMap<Vehicle, VehicleDto>().ReverseMap();
            CreateMap<Client, ClientDto>().ReverseMap();
        }

    }
}
