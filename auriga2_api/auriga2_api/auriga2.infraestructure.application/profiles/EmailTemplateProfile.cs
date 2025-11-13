using AutoMapper;
using auriga2.domain.entities;
using auriga2.infraestructure.application.models;
namespace auriga2.infraestructure.application.profiles;
public class EmailTemplateProfile : Profile
{ 
    public EmailTemplateProfile()
    {
        CreateMap<EmailTemplateModel, EmailTemplateEntity>().ReverseMap();
    }
}