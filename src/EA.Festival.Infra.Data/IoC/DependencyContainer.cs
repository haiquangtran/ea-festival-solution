using AutoMapper;
using EA.Festival.ApplicationCore.Mappings;
using EA.Festival.Domain.Interfaces;
using EA.Festival.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EA.Festival.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application Core layer
            services.AddScoped<IFestivalDataService, FestivalDataService>();
        }

        public static void RegisterMappingProfiles(IServiceCollection services)
        {
            // Setup Mapping profiles
            Mapper.Initialize(config => config.AddProfile<DtoMappingProfile>());

            services.AddAutoMapper(typeof(DtoMappingProfile));
        }
    }
}
