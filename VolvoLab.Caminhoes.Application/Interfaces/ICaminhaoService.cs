using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VolvoLab.Caminhoes.Application.ViewModels;

namespace VolvoLab.Caminhoes.Application.Interfaces
{
    public interface  ICaminhaoService
    {
        Task<IEnumerable<CaminhaoViewModel>> GetCaminhoes();

        IEnumerable<CaminhaoModeloViewModel> GetCaminhaoModelos();

        CaminhaoViewModel GetById(Guid? id);

        void Add(CaminhaoViewModel caminhao);

        void Update(CaminhaoViewModel caminhao);

        void Remove(Guid Id);

        TestValidationResult<CaminhaoViewModel> Validator(CaminhaoViewModel caminhao);
    }
}
