
using FluentValidation;
using System;
using System.Collections.Generic;

namespace VolvoLab.Caminhoes.Application.ViewModels
{
    public class CaminhaoViewModelValidator : AbstractValidator<CaminhaoViewModel>
    {
        public List<string> _modelos;

        public CaminhaoViewModelValidator(List<string> modelos)
        {
            _modelos = modelos;

            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.NumSerie).NotNull().Length(3, 18);
            RuleFor(x => x.Modelo).NotNull().Length(2, 10);
            RuleFor(x => x.Modelo).Must(ValidatorModelo).WithMessage("Modelo inválido");
            RuleFor(x => x.AnoFab).Equal(DateTime.Now.Year);
            RuleFor(x => x.AnoMod).InclusiveBetween(DateTime.Now.Year, DateTime.Now.AddYears(1).Year);
            
        }

        private bool ValidatorModelo(CaminhaoViewModel caminhao, string Modelo)
        {
            return _modelos.Contains(Modelo);

        }


    }


}
