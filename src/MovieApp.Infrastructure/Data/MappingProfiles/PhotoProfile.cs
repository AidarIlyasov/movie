using MovieApp.Core.DTO;
using MovieApp.Core.Entities;
using AutoMapper;

namespace MovieApp.Infrastructure.Data.MappingProfiles
{
    public class PhotoProfile: Profile
    {
        public PhotoProfile()
        {
            CreateMap<PhotoDto, Photo>();
        }
    }
}