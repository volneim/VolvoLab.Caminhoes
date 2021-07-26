using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VolvoLab.Caminhoes.Application.Mappings;
using VolvoLab.Caminhoes.Application.Services;
using VolvoLab.Caminhoes.Application.ViewModels;
using VolvoLab.Caminhoes.Domain.Entities;
using VolvoLab.Caminhoes.Domain.Interfaces.Repositories;
using Xunit;

namespace VolvoLab.Caminhoes.Tests.Application.Fixtures
{
    [CollectionDefinition(nameof(CaminhaoCollection))]
    public class CaminhaoCollection : ICollectionFixture<CaminhaoTestsFixture>
    { }

    public class CaminhaoTestsFixture : IDisposable
    {
        
        private static IMapper _mapper;        
        public Mock<ICaminhaoModeloRepository> caminhaoModeloRep;
        public Mock<ICaminhaoRepository> caminhaoRep;
        public CaminhaoService caminhaoService;

        public CaminhaoTestsFixture()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new ViewModelToDomainMappingProfile());
                    mc.AddProfile(new DomainToViewModelMappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            caminhaoRep = new Mock<ICaminhaoRepository>();
            caminhaoModeloRep = new Mock<ICaminhaoModeloRepository>();
            caminhaoModeloRep.Setup(cr => cr.GetCaminhaoModelos()).Returns(GetCaminhaoModelos());
            caminhaoRep.Setup(cr => cr.GetById(It.IsAny<Guid>())).Returns(GerarCaminhao());
            caminhaoRep.Setup(cr => cr.GetCaminhoes()).Returns(GerarCaminhoes());

            caminhaoService = new CaminhaoService(_mapper, caminhaoRep.Object, caminhaoModeloRep.Object);
        }

        public CaminhaoViewModel GerarCaminhaoViewModel(String NumSerie, String Modelo, int AnoFab, int AnoMod)
        {
            var caminhao = new CaminhaoViewModel()
            {
                Id = Guid.Parse("9349BCE3-4FE2-4FED-98E0-B8CEF0080356"),
                NumSerie = NumSerie,
                Modelo = Modelo,
                AnoFab = AnoFab,
                AnoMod = AnoMod
            };

            return caminhao;
        }

        public Caminhao GerarCaminhao()
        {
            var caminhao = new Caminhao()
            {
                Id = Guid.Parse("9349BCE3-4FE2-4FED-98E0-B8CEF0080356"),
                NumSerie = "Num123",
                Modelo = "FH",
                AnoFab = 2021,
                AnoMod = 2022
            };

            return caminhao;
        }

        public async Task<IEnumerable<Caminhao>> GerarCaminhoes()
        {
            var caminhoes = new List<Caminhao>()
            {
                new Caminhao()
                {
                Id = Guid.NewGuid(),
                NumSerie = "Num123",
                Modelo = "FH",
                AnoFab = 2021,
                AnoMod = 2021
                },
                new Caminhao()
                {
                Id = Guid.NewGuid(),
                NumSerie = "Num1234",
                Modelo = "FH",
                AnoFab = 2021,
                AnoMod = 2022
                }
            };

            return  caminhoes;
        }

        public IEnumerable<CaminhaoModelo> GetCaminhaoModelos()
        {
            var caminhoes = new List<CaminhaoModelo>();

            caminhoes.Add(new CaminhaoModelo()
            {
                Id = Guid.NewGuid(),
                Nome = "FH"
            });

            return caminhoes;
        }



        public void Dispose()
        {
            
        }
    }
}
