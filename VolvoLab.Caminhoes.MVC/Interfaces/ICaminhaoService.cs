using VolvoLab.Caminhoes.MVC.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace VolvoLab.Caminhoes.MVC.Interfaces
{
    public interface ICaminhaoService
    {

        Task<IEnumerable<CaminhaoViewModel>> GetCaminhoes();

        Task<IEnumerable<CaminhaoModeloViewModel>> GetCaminhaoModelos();

        Task<CaminhaoViewModel> GetById(Guid? id);

        Task Add(CaminhaoViewModel caminhao);

        Task Update(CaminhaoViewModel caminhao);

        Task Remove(CaminhaoViewModel caminhao);

    }
}
