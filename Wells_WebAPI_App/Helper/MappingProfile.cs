using AutoMapper;
using Wells_WebAPI.Data.Models;
using Wells_WebAPI.Data.Models.Dto;

namespace Wells_WebAPI.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DrillBlock, DrillBlockDto>().ReverseMap();
            CreateMap<DrillBlockPoints, DrillBlockPointsDto>().ReverseMap();
            CreateMap<Hole, HoleDto>().ReverseMap();
            CreateMap<HolePoints, HolePointsDto>().ReverseMap();
        }
    }
}
