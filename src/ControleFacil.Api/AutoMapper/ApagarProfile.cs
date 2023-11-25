using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ControleFacil.Api.contract.NaturezaDeLancamento;
using ControleFacil.Api.contract.Usuario;
using ControleFacil.Api.Damain.Models;

namespace ControleFacil.Api.AutoMapper
{
    public class ApagarProfile: Profile
    {
        public ApagarProfile()
        {
            CreateMap<Apagar, ApagarRequestContract>().ReverseMap();
            CreateMap<Apagar, ApagarResponseContract>().ReverseMap();
        }
    }
}