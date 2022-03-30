using MovieApp.Application.DTO;
using MovieApp.Application.Entities;
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