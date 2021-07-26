using Moq;
using System;
using VolvoLab.Caminhoes.Tests.Application.Fixtures;
using Xunit;

namespace VolvoLab.Caminhoes.Tests.Application.Services
{
    [Collection(nameof(CaminhaoCollection))]
    public class CaminhaoServiceGetTests
    {
        private readonly CaminhaoTestsFixture _caminhaoTestsFixture;
 
        public CaminhaoServiceGetTests(CaminhaoTestsFixture caminhaoTestsFixture)
        {
            _caminhaoTestsFixture = caminhaoTestsFixture;

            _caminhaoTestsFixture.caminhaoModeloRep.Invocations.Clear();
            _caminhaoTestsFixture.caminhaoRep.Invocations.Clear();

        }

        [Fact(DisplayName = "Get caminhão ById")]
        public void GetCaminhaoById_RetornarSucesso()
        {
            // Arrange
            var id = Guid.Parse("9349BCE3-4FE2-4FED-98E0-B8CEF0080356");
            var caminhaoService = _caminhaoTestsFixture.caminhaoService;

            // Act
             var result = caminhaoService.GetById(id);

            //Assert
            _caminhaoTestsFixture.caminhaoRep.Verify(cr => cr.GetById(It.IsAny<Guid>()), Times.Once);
            Assert.Equal("Num123", result.NumSerie);

        }

        [Fact(DisplayName = "Get caminhões")]
        public void GetCaminhoes_RetornarSucesso()
        {
            // Arrange
            var id = Guid.Parse("9349BCE3-4FE2-4FED-98E0-B8CEF0080356");
            var caminhaoService = _caminhaoTestsFixture.caminhaoService;

            // Act
            var result = caminhaoService.GetCaminhoes();

            //Assert
            _caminhaoTestsFixture.caminhaoRep.Verify(cr => cr.GetCaminhoes(), Times.Once);
            Assert.True(result != null);
           
        }

        [Fact(DisplayName = "Get caminhão Modelos")]
        public void GetCaminhoaoModelos_RetornarSucesso()
        {
            // Arrange
            var caminhaoService = _caminhaoTestsFixture.caminhaoService;
            


            // Act
            var result = caminhaoService.GetCaminhaoModelos();

            //Assert
            _caminhaoTestsFixture.caminhaoModeloRep.Verify(cr => cr.GetCaminhaoModelos(), Times.Once);
            Assert.True(result != null);

        }



    }
}
