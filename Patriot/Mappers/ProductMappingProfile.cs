using AutoMapper;
using Patriot.Database.Domain;
using Patriot.DomainModel.Contact;

namespace Patriot.Mappers
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ContactCreateModel, Contact>()
                     .ForMember(d => d.Created, opt => opt.MapFrom(source => System.DateTime.Now));

        }
    }
}
