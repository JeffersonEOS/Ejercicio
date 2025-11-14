using auriga2.domain.entities;
using auriga2.infraestructure.application.models;
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
            CreateMap<TransaccionModel, TransaccionEntity>()
             .ReverseMap();
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
