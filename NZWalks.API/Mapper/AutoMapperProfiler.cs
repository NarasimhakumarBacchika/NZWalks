using AutoMapper;
using NZWalks.API.DTO;
using NZWalks.API.Model.Data;

namespace NZWalks.API.Mapper
{
    public class AutoMapperProfiler:Profile
    {

        public AutoMapperProfiler()
        {
            CreateMap<Region,RegionDTO>().ReverseMap();
            CreateMap<AddRegionDto, Region>().ReverseMap();
            CreateMap<UpdateRegionDto, Region>().ReverseMap();
            CreateMap<Walk,WalkDto>().ReverseMap();
            CreateMap<AddWalkDto, Walk>().ReverseMap();
            CreateMap<Diffculty,DiffcultyDTO>().ReverseMap();
            CreateMap<UpdateWalkDto, Walk>().ReverseMap();
            
        }
    }
}
