using MovieApp.Core.DTO;
using MovieApp.Core.Entities;
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