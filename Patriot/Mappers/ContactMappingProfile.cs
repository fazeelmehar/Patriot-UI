using AutoMapper;
using Patriot.Database.Domain;
using Patriot.DomainModel.Contact;

namespace Patriot.Mappers
{
    public class ContactMappingProfile : Profile
    {
        public ContactMappingProfile()
        {
            CreateMap<ContactCreateModel, Contact>()
                     .ForMember(d => d.Created, opt => opt.MapFrom(source => System.DateTime.Now));
        }
    }
}
