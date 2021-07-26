
using FluentValidation.TestHelper;
using System;
using System.ComponentModel.DataAnnotations;

namespace VolvoLab.Caminhoes.Application.ViewModels
{
    public class CaminhaoViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Número de série é obrigatório")]
        [MinLength(3)]
        [MaxLength(18)]
        public string NumSerie { get; set; }

        [Required(ErrorMessage = "O Modelo é obrigatório")]
        [MinLength(2)]
        [MaxLength(10)]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "O Ano de Fabricação é obrigatório")]
        public int AnoFab { get; set; }

        [Required(ErrorMessage = "O Ano do Modelo é obrigatório")]
        public int AnoMod { get; set; }

    }
}
