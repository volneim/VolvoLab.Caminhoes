using AutoMapper;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VolvoLab.Caminhoes.Application.Interfaces;
using VolvoLab.Caminhoes.Application.ViewModels;
using VolvoLab.Caminhoes.Domain.Entities;
using VolvoLab.Caminhoes.Domain.Interfaces.Repositories;

namespace VolvoLab.Caminhoes.Application.Services
{
    public class CaminhaoService : ICaminhaoService
    {
        private readonly ICaminhaoRepository _caminhaoRepository;
        private readonly ICaminhaoModeloRepository _caminhaoModeloRepository;
        private readonly IMapper _mapper;
        public TestValidationResult<CaminhaoViewModel> Validador;

        public CaminhaoService(IMapper mapper, ICaminhaoRepository caminhaoRepository, ICaminhaoModeloRepository caminhaoModeloRepository)
        {
            _mapper = mapper;
            _caminhaoRepository = caminhaoRepository;
            _caminhaoModeloRepository = caminhaoModeloRepository;
        }

        public void Add(CaminhaoViewModel caminhaoViewModel)
        {
            Validador = Validator(caminhaoViewModel);

            if (!Validador.IsValid)
            {
                var erros = string.Join("\r\n", Validador.Errors);
                throw new Exception("Atenção: " + erros);
            }

            Caminhao caminhao = _mapper.Map<Caminhao>(caminhaoViewModel);
            _caminhaoRepository.Add(caminhao);
        }

        public CaminhaoViewModel GetById(Guid? id)
        {
            var caminhao = _caminhaoRepository.GetById(id);
            return _mapper.Map<CaminhaoViewModel>(caminhao);
        }

        public async Task<IEnumerable<CaminhaoViewModel>> GetCaminhoes()
        {
            var caminhoes = await _caminhaoRepository.GetCaminhoes();
            return _mapper.Map<IEnumerable<CaminhaoViewModel>>(caminhoes);
        }

        public void Remove(Guid Id)
        {
            
            _caminhaoRepository.Remove(Id);
        }

        public void Update(CaminhaoViewModel caminhaoViewModel)
        {
            Validador = Validator(caminhaoViewModel);

            if (!Validador.IsValid)
            {
                var erros = string.Join("\r\n", Validador.Errors);
                throw new Exception("Atenção: " + erros);
            }

            var caminhao = _mapper.Map<Caminhao>(caminhaoViewModel);
            _caminhaoRepository.Update(caminhao);
        }

        public IEnumerable<CaminhaoModeloViewModel> GetCaminhaoModelos()
        {
            var caminhaoModelos = _caminhaoModeloRepository.GetCaminhaoModelos();
            return _mapper.Map<IEnumerable<CaminhaoModeloViewModel>>(caminhaoModelos);
        }

        public TestValidationResult<CaminhaoViewModel> Validator(CaminhaoViewModel caminhaoViewModel)
        {
            var caminhaoModelos = _caminhaoModeloRepository.GetCaminhaoModelos();
            var modelos = new List<string>();

            foreach (var caminhaoModelo in caminhaoModelos)
            {
                modelos.Add(caminhaoModelo.Nome);
            }

            var validator = new CaminhaoViewModelValidator(modelos);

            return validator.TestValidate(caminhaoViewModel);
            
        }


    }
}
