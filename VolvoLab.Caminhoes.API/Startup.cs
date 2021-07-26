using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.OpenApi.Models;
using VolvoLab.Caminhoes.API.MappingConfig;
using VolvoLab.Caminhoes.Infra.IOC;

namespace VolvoLab.Caminhoes.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAutoMapperConfiguration();
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VolvoLab.Caminhoes.API", Version = "v1" });
            });

            //Utilizado Extension method da camada Infra.Data para centralizar
            //o acesso ao ORM obedecendo aos principios da Clear Architecture
            services.AddConfig(Configuration);            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VolvoLab.Caminhoes.API v1"));
            }

            //Utilizado Extension method da camada Infra.Data para centralizar
            //o acesso ao ORM obedecendo aos principios da Clear Architecture
            app.AddConfigure();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
