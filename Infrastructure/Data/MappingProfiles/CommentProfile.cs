using MovieApp.Application.DTO;
using MovieApp.Application.Entities;
using AutoMapper;

namespace MovieApp.Infrastructure.Data.MappingProfiles
{
    public class CommentProfile: Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDto>()
                .ForMember(dest => dest.UserLogin,
                    opt => opt.MapFrom(c => c.User.Login));
        }
    }
}