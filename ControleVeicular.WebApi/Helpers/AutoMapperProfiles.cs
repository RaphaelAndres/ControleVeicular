using AutoMapper;
using ControleVeicular.Domain.Model.Identity;
using ControleVeicular.WebApi.Dtos;

namespace ControleVeicular.WebApi.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
        }
    }
}