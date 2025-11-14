using auriga2.domain.entities;
using auriga2.infraestructure.application.models;
using auriga2.infraestructure.application.models.responses;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auriga2.infraestructure.application.profiles
{
    public class TransaccionProfile:Profile
    {
        public TransaccionProfile() 
        {
            CreateMap<TransaccionEntity, MovimientoResponseDto>()
                      .ForMember(dest => dest.NumeroCuenta, opt => opt.Ignore()) // lo asignas manual después
                      .ForMember(dest => dest.SaldoActual, opt => opt.Ignore()).ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo.ToString()));  // lo asignas manual después
        }

        //tener en cuenta las relaciones automaticas del automaper 
        /*builder.Services.AddControllers()
            .AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
        */
        //program.cs del api 
    }
}
