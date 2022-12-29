using AutoMapper;
using Patriot.Database.Domain;
using Patriot.DomainModel.Contact;
using Patriot.DomainModel.CPTLetter;

namespace Patriot.Mappers
{
    public class CPTLetterMappingProfile : Profile
    {
        public CPTLetterMappingProfile()
        {
            CreateMap<MasterLetterCreateModel, MasterLetter>()
                     .ForMember(d => d.ImportDate, opt => opt.MapFrom(source => System.DateTime.Now));

            CreateMap<MasterLetter, MasterLetterReadModel>();
        }
    }
}
