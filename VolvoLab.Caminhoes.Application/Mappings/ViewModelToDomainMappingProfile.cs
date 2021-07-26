using AutoMapper;
using VolvoLab.Caminhoes.Application.ViewModels;
using VolvoLab.Caminhoes.Domain.Entities;

namespace VolvoLab.Caminhoes.Application.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CaminhaoViewModel, Caminhao>();
            CreateMap<CaminhaoModeloViewModel, CaminhaoModelo>();
        }
    }
}
