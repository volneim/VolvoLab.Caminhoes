using Microsoft.Extensions.DependencyInjection;
using System;
using VolvoLab.Caminhoes.Application.Mappings;

namespace VolvoLab.Caminhoes.API.MappingConfig
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile),
                typeof(ViewModelToDomainMappingProfile));
        }
    }
}
