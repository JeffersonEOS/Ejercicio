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
    public class BancoProfile: Profile
    {
        public BancoProfile() 
        {
            CreateMap<BancoModel, BancoEntity>()
               .ReverseMap();
        }
    }
}
