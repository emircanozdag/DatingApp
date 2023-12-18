using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace API;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<AppUser, MemberDto>()
        .ForMember(member => member.PhotoUrl, opt => opt.MapFrom(map => map.Photos.FirstOrDefault(f => f.IsMain).Url))
        .ForMember(member => member.Age, opt => opt.MapFrom(map => map.DateOfBirth.CalculateAge()));
        CreateMap<Photo, PhotoDto>();
    }

}
