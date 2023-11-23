using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helpers
{
    public class ManagmentPeopleProfile : Profile
    {
        public ManagmentPeopleProfile()
        {
            CreateMap<Entities.Entities.People, DTOs.PeopleDTO>().ReverseMap();
            CreateMap<Entities.Entities.LegalPerson, DTOs.LegalPersonDTO>().ReverseMap();
            CreateMap<Entities.Entities.NaturalPerson, DTOs.NaturalPersonDTO>().ReverseMap();
        }
    }
}
