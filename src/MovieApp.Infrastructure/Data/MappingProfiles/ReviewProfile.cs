using System;
using MovieApp.Core.DTO;
using MovieApp.Core.Entities;
using AutoMapper;

namespace MovieApp.Infrastructure.Data.MappingProfiles
{
    public class ReviewProfile: Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewDto>()
                .ForMember(dest => dest.Raiting,
                    opt => opt.MapFrom(r => Math.Round(1.0 * r.Likes / (r.Likes + r.Dislikes) * 10, 1)))
                .ForMember(dest => dest.UserLogin,
                    opt => opt.MapFrom(u => u.User.Login));
        }
    }
}