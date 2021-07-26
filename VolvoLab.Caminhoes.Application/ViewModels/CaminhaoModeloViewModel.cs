
using System;
using System.ComponentModel.DataAnnotations;

namespace VolvoLab.Caminhoes.Application.ViewModels
{
    public class CaminhaoModeloViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório")]
        [MinLength(3)]
        [MaxLength(10)]    
        public string Nome { get; set; }

    }
}
