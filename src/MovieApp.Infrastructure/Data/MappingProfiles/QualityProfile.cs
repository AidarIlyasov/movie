using MovieApp.Core.DTO;
using MovieApp.Core.Entities;
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