using AutoMapper;
using Lali.DataAccess.Entities;
using Lali.DataAccess.ViewModel;
using LaliWebShop.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lali.Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Kategorie, KategorieDto>().ReverseMap();
            //CreateMap<KategorieDto, Kategorie>();
            CreateMap<Artikel, ArtikelDto>().ReverseMap();

            CreateMap<BestellungDto,Bestellung>().ReverseMap();
            CreateMap<BestellungItem, BestellungItemDto>().ReverseMap();
            CreateMap<BestellungPosDto, BestellungPos>().ReverseMap();
            




        }
    }
}
