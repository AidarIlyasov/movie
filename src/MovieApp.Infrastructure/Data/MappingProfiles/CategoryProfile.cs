using MovieApp.Core.DTO;
using MovieApp.Core.Entities;
using AutoMapper;

namespace MovieApp.Infrastructure.Data.MappingProfiles
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDto, Category>();
        }
    }
}