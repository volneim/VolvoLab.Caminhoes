using Moq;
using System;
using VolvoLab.Caminhoes.Tests.Application.Fixtures;
using Xunit;

namespace VolvoLab.Caminhoes.Tests.Application.Services
{
    [Collection(nameof(CaminhaoCollection))]
    public class CaminhaoServiceRemoveTests
    {
        private readonly CaminhaoTestsFixture _caminhaoTestsFixture;

        public CaminhaoServiceRemoveTests(CaminhaoTestsFixture caminhaoTestsFixture)
        {
            _caminhaoTestsFixture = caminhaoTestsFixture;

            _caminhaoTestsFixture.caminhaoModeloRep.Invocations.Clear();
            _caminhaoTestsFixture.caminhaoRep.Invocations.Clear();

        }

        [Fact(DisplayName = "Remover caminhão")]
        public void RemoveCaminhao_RetornarSucesso()
        {
            // Arrange
            var id = Guid.NewGuid();
            var caminhaoService = _caminhaoTestsFixture.caminhaoService;

            // Act
             caminhaoService.Remove(id);

            //Assert
            _caminhaoTestsFixture.caminhaoRep.Verify(cr => cr.Remove(It.IsAny<Guid>()), Times.Once);          

        }

     
    }
}
