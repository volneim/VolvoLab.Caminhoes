using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VolvoLab.Caminhoes.Domain.Entities;
using VolvoLab.Caminhoes.Infra.Data.EntityConfigurations;

namespace VolvoLab.Caminhoes.Infra.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Caminhao> Caminhoes { get; set; }

        public DbSet<CaminhaoModelo> CaminhaoModelos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CaminhaoConfiguration());

            builder.ApplyConfiguration(new CaminhaoModeloConfiguration());
        }

    }
}
