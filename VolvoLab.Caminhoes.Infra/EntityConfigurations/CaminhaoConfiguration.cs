using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using VolvoLab.Caminhoes.Domain.Entities;

namespace VolvoLab.Caminhoes.Infra.Data.EntityConfigurations
{
    public class CaminhaoConfiguration : IEntityTypeConfiguration<Caminhao>
    {
        public void Configure(EntityTypeBuilder<Caminhao> builder)
        {
            builder.ToTable("Caminhoes");

            builder.HasKey(p => p.Id).HasName("PrimaryKey_Caminhao");
          
            builder.Property(p => p.NumSerie).HasMaxLength(18).IsRequired();

            builder.Property(p => p.Modelo).HasMaxLength(10).IsRequired();

            builder.Property(p => p.AnoFab).IsRequired();

            builder.Property(p => p.AnoMod).IsRequired();

            builder.HasData(
                new Caminhao
                {
                    Id = Guid.NewGuid(),
                    NumSerie = "123ABC",
                    Modelo = "FH",
                    AnoFab = 2021,
                    AnoMod = 2022
                },
                new Caminhao
                {
                    Id = Guid.NewGuid(),
                    NumSerie = "3452XXY",
                    Modelo = "FM",
                    AnoFab = 2021,
                    AnoMod = 2021
                }
                ); ;

        }
    }
}
