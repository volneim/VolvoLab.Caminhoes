using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VolvoLab.Caminhoes.Application.Interfaces;
using VolvoLab.Caminhoes.Application.Services;
using VolvoLab.Caminhoes.Domain.Interfaces.Repositories;
using VolvoLab.Caminhoes.Infra.Data.Context;
using VolvoLab.Caminhoes.Infra.Data.Repositories;

namespace VolvoLab.Caminhoes.Infra.IOC
{
    public static class DependencyInjection 
    {

        public static IServiceCollection AddConfig(this IServiceCollection services,
            IConfiguration Configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<ICaminhaoRepository, CaminhaoRepository>();

            services.AddScoped<ICaminhaoService, CaminhaoService>();

            services.AddScoped<ICaminhaoModeloRepository, CaminhaoModeloRepository>();

            return services;

        }

        public static IApplicationBuilder AddConfigure(this IApplicationBuilder app)
        {

            using (var migrationSvcScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                migrationSvcScope.ServiceProvider.GetService<ApplicationDbContext>().Database.Migrate();
            }


            return app;

        }

    }
}
