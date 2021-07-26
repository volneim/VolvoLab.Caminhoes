using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VolvoLab.Caminhoes.Domain.Entities;

namespace VolvoLab.Caminhoes.Domain.Interfaces.Repositories
{
    public interface ICaminhaoRepository
    {
        Task<IEnumerable<Caminhao>> GetCaminhoes();

        Caminhao GetById(Guid? id);

        void Add(Caminhao caminhao);

        void Update(Caminhao caminhao);

        void Remove(Guid Id);

    }
}
