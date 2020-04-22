using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using Vidly2.Dtos;
using Vidly2.Models;

namespace Vidly2.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to DTO
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<Movie, MovieDTO>();
            Mapper.CreateMap<MembershipType, MembershipTypeDTO>();
            Mapper.CreateMap<Genre, GenreDTO>();

            //DTO to domain
            Mapper.CreateMap<CustomerDTO, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore())
                .ForMember(c => c.MembershipType, opt => opt.Ignore());
            Mapper.CreateMap<MovieDTO, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.Genre, opt => opt.Ignore());
        }
    }
}