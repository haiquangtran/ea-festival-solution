using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EA.Festival.ApplicationCore.DTOs;

namespace EA.Festival.Web.Models.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Map DTOs to View models and back again.
            CreateMap<MusicFestivalDto, MusicFestivalViewModel>().ReverseMap();
            CreateMap<MusicBandDto, MusicBandViewModel>().ReverseMap();
        }
    }
}
