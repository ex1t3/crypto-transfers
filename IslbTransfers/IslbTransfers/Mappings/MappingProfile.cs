using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Model.Models;

namespace IslbTransfers.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserIdentityViewModel, UserIdentityKyc>()
                .ForMember(x => x.BirthDate, opt => opt.MapFrom(x => new DateTime(x.Year, x.Month, x.Day)))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(x => x.DialCode + "-" + x.Number));

            CreateMap<OAuthApiCredentials, User>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.IsExtraLogged, opt => opt.MapFrom((user) => true));

            CreateMap<UserIdentityKyc, UserIdentityViewModel>()
                .ForMember(x => x.Year, opt => opt.MapFrom(x => x.BirthDate.Year))
                .ForMember(x => x.Month, opt => opt.MapFrom(x => x.BirthDate.Month))
                .ForMember(x => x.Day, opt => opt.MapFrom(x => x.BirthDate.Day))
                .ForMember(x => x.DialCode, opt => opt.MapFrom(x => CheckForDial(x.PhoneNumber)))
                .ForMember(x => x.Number, opt => opt.MapFrom(x => CheckForNumber(x.PhoneNumber)));
        }

        private string CheckForDial(string phone)
        {
            return phone?.Split("-")[0];
        }
        private string CheckForNumber(string phone)
        {
            return phone?.Split("-")[1];
        }
    }
}
