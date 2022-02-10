using AutoMapper;
using MoneyBotBackend.Models;
using MoneyBotBackend.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBotBackend.Mapper
{
    public class MicroserviceProfile : Profile
    {
        public MicroserviceProfile()
        {
            CreateMap<User, UserInformationDto>()
                .ForMember(x => x.Id, x => x.MapFrom(m => m.Id))
                .ForMember(x => x.Name, x => x.MapFrom(m => m.Name))
                .ForMember(x => x.Surname, x => x.MapFrom(m => m.Surname))
                .ForMember(x => x.PhoneNumberPrefix, x => x.MapFrom(m => m.PhoneNumberPrefix))
                .ForMember(x => x.PhoneNumber, x => x.MapFrom(m => m.PhoneNumber));

            CreateMap<Money, MoneyOperation>()
                .ForMember(x => x.Id, x => x.MapFrom(m => m.Id))
                .ForMember(x => x.Sum, x => x.MapFrom(m => m.Sum))
                .ForMember(x => x.Operation, x => x.MapFrom(m => m.Operation))
                .ForMember(x => x.DateTime, x => x.MapFrom(m => m.DateTime));
        }
    }
}
