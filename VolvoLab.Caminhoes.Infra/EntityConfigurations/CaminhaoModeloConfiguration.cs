using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using VolvoLab.Caminhoes.Domain.Entities;

namespace VolvoLab.Caminhoes.Infra.Data.EntityConfigurations
{
    public class CaminhaoModeloConfiguration : IEntityTypeConfiguration<CaminhaoModelo>
    {
        public void Configure(EntityTypeBuilder<CaminhaoModelo> builder)
        {
            builder.ToTable("Caminhao_Modelos");

            builder.HasKey(p => p.Id).HasName("PrimaryKey_Caminhao_Modelos");

            builder.Property(p => p.Nome).HasMaxLength(10).IsRequired();

            builder.HasData(
                new CaminhaoModelo
                {
                    Id = Guid.NewGuid(),
                    Nome = "FH"
                },
                new CaminhaoModelo
                {
                    Id = Guid.NewGuid(),
                    Nome = "FM"
                }
                ); ;

        }
    }
}
