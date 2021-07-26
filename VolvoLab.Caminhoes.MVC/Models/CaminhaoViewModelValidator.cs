
using FluentValidation;
using System;

namespace VolvoLab.Caminhoes.MVC.Models
{
    public class CaminhaoViewModelValidator : AbstractValidator<CaminhaoViewModel>
    {
        public CaminhaoViewModelValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.NumSerie).NotNull().Length(3, 18);
            RuleFor(x => x.Modelo).NotNull().Length(2, 10);
            RuleFor(x => x.AnoFab).Equal(DateTime.Now.Year);
            RuleFor(x => x.AnoMod).InclusiveBetween(DateTime.Now.Year, DateTime.Now.AddYears(1).Year);
        }
    }
}
