using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace Patriot.Mappers
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainAutoMapper(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddAutoMapper(typeof(Index));
        }
    }
}
