using AutoMapper;
using Manager.Core.Domain.DTOs;
using Manager.Core.Domain.Entities;

namespace Manager.Core.ApplicationService.Config
{
    public class FactorProfile : Profile
    {
        public FactorProfile()
        {
            CreateMap<Factor, FactorDTO>();
            CreateMap<FactorDTO, Factor>();
        }
    }
}
