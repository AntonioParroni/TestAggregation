using API.DTO;
using API.Model;
using AutoMapper;

namespace API.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Activities, ActivitiesDTO>()
            .ForMember(dest => dest.Project, opt => opt.MapFrom(src => src.Project.Name))
            .ForMember(dest => dest.Employment, opt => opt.MapFrom(src => src.Employment.Name))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.ActivityDate));

        CreateMap<Employment, EmploymentDTO>();
        CreateMap<Projects, ProjectDTO>();
    }
}