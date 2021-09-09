using AutoMapper;
using ClubsCore.Mapping.DTO;
using ClubsCore.Models;

namespace ClubsCore.Mapping
{
    public class ClubProfile : Profile
    {
        public ClubProfile()
        {
            CreateMap<Club, ClubDTO>()
                .ForMember(dest => dest.StudentCount,
                           opt => opt.MapFrom(src => src.Students.Count));

            CreateMap<Club, ClubListingDTO>();
        }
    }
}