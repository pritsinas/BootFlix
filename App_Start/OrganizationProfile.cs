using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BootFlixBC7.Dtos;
using BootFlixBC7.Models;


namespace BootFlixBC7.App_Start
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<Viewer, ViewerDto>();
            CreateMap<ViewerDto, Viewer>();
            CreateMap<Serie, SerieDto>();
            CreateMap<SerieDto, Serie>();
            CreateMap<Genre, GenreDto>();
            CreateMap<GenreDto, Genre>();
            CreateMap<MembershipType, MembershipTypeDto>();
            CreateMap<MembershipTypeDto, MembershipType>();

            //CreateMap<SerieDto, Serie>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}