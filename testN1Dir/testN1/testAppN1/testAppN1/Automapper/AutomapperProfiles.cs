using AutoMapper;
using testAppN1.Models.Domain;
using testAppN1.Models.DTOmodels;

namespace testAppN1.Automapper
{
    public class AutomapperProfiles:Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Region, RegionDto>()
                .ReverseMap();

            CreateMap<Region, AddRegionDTO>()
                .ReverseMap();

            CreateMap<Region, UpdateRegionDto>()
                .ReverseMap();
        }
    }
}
