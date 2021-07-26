using Moq;
using System;
using VolvoLab.Caminhoes.Domain.Entities;
using VolvoLab.Caminhoes.Tests.Application.Fixtures;
using Xunit;

namespace VolvoLab.Caminhoes.Tests.Application.Services
{
    [Collection(nameof(CaminhaoCollection))]
    public class CaminhaoServiceUpdateTests
    {
        private readonly CaminhaoTestsFixture _caminhaoTestsFixture;
        private const int anoFab = 2021;
        private const int anoMod = 2021;

        public CaminhaoServiceUpdateTests(CaminhaoTestsFixture caminhaoTestsFixture)
        {
            _caminhaoTestsFixture = caminhaoTestsFixture;

            _caminhaoTestsFixture.caminhaoModeloRep.Invocations.Clear();
            _caminhaoTestsFixture.caminhaoRep.Invocations.Clear();

        }

        [Fact(DisplayName = "Alterar caminh�o v�lido")]
        public void AlterarCaminhaoValido_RetornarSucesso()
        {
            // Arrange
            var anoFab = DateTime.Now.Year;
            var anoMod = anoFab;
            var caminhaoViewModel = _caminhaoTestsFixture.GerarCaminhaoViewModel("S123", "FH", anoFab, anoMod);
            var caminhaoService = _caminhaoTestsFixture.caminhaoService;

            // Act
             caminhaoService.Update(caminhaoViewModel);

            //Assert
            _caminhaoTestsFixture.caminhaoRep.Verify(cr => cr.Update(It.IsAny<Caminhao>()), Times.Once);          

        }

        [Theory(DisplayName = "Alterar caminh�o inv�lido")]
        [InlineData(null, "FH", anoFab, anoMod, "Aten��o: 'Num Serie' n�o pode ser nulo")]
        [InlineData("S", "FH", anoFab, anoMod, "Aten��o: 'Num Serie' deve ter entre 3 e 18")]
        [InlineData("S123", null, anoFab, anoMod, "Aten��o: 'Modelo' n�o pode ser nulo")]              
        [InlineData("S123", "F", anoFab, anoMod, "Aten��o: 'Modelo' deve ter entre 2 e 10")]
        [InlineData("S123", "FH", anoFab - 1, anoMod, "Aten��o: 'Ano Fab' deve ser igual a")]
        [InlineData("S123", "FH", anoFab, anoMod + 2, "Aten��o: 'Ano Mod' deve estar entre")]
        [InlineData("S123", "FS", anoFab, anoMod, "Aten��o: Modelo inv�lido")]
        public void AlterarCaminhaoInvalido_RetornarException(string NumSerie, string modelo, int anoFab, int anoMod, string msgException )
        {
            // Arrange
            var caminhaoViewModel = _caminhaoTestsFixture.GerarCaminhaoViewModel(NumSerie,
                                                                        modelo,
                                                                        anoFab,
                                                                        anoMod);

            var caminhaoService = _caminhaoTestsFixture.caminhaoService;

            // Act
            Action act = () => caminhaoService.Update(caminhaoViewModel);

            //Assert
            Exception exception = Assert.Throws<Exception>(act);
            Assert.StartsWith(msgException, exception.Message);


        }

    }
}
