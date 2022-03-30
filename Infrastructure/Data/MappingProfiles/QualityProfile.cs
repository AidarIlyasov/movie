using MovieApp.Application.DTO;
using MovieApp.Application.Entities;
using AutoMapper;

namespace MovieApp.Infrastructure.Data.MappingProfiles
{
    public class QualityProfile: Profile
    {
        public QualityProfile()
        {
            CreateMap<QualityDto, Quality>();
        }
    }
}