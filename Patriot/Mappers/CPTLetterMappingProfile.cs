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
            CreateMap<CPTLetterCreateModel, CPTLetter>()
                     .ForMember(d => d.Created, opt => opt.MapFrom(source => System.DateTime.Now));

            CreateMap<CPTLetter, CPTLetterReadModel>();
        }
    }
}
