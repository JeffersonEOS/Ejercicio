using AutoMapper;
using auriga2.domain.entities;
using auriga2.infraestructure.application.models;
namespace auriga2.infraestructure.application.profiles;
public class UserRoleProfile : Profile
{ 
    public UserRoleProfile()
    {
        CreateMap<UserRoleModel, UserRoleEntity>().ReverseMap();
    }
}