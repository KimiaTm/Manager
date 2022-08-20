using AutoMapper;
using Manager.Core.Domain.DTOs;
using Manager.Core.Domain.Entities;

namespace Manager.Core.ApplicationService.Config
{
    public class StoreProfile : Profile
    {
        public StoreProfile()
        {
            CreateMap<Store,StoreDTO>();
            CreateMap<StoreDTO,Store>();
        }
    }

}
