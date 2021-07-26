using System.Collections.Generic;
using VolvoLab.Caminhoes.Domain.Entities;

namespace VolvoLab.Caminhoes.Domain.Interfaces.Repositories
{
    public interface ICaminhaoModeloRepository
    {
        IEnumerable<CaminhaoModelo> GetCaminhaoModelos();
    }
}
