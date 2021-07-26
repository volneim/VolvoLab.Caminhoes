using AutoMapper;
using VolvoLab.Caminhoes.Application.ViewModels;
using VolvoLab.Caminhoes.Domain.Entities;

namespace VolvoLab.Caminhoes.Application.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {

        public DomainToViewModelMappingProfile()
        {
            CreateMap<Caminhao, CaminhaoViewModel>();
            CreateMap<CaminhaoModelo, CaminhaoModeloViewModel>();
        }
    }
}
