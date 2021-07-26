using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VolvoLab.Caminhoes.Domain.Entities;
using VolvoLab.Caminhoes.Domain.Interfaces.Repositories;
using VolvoLab.Caminhoes.Infra.Data.Context;

namespace VolvoLab.Caminhoes.Infra.Data.Repositories
{
    public class CaminhaoModeloRepository : ICaminhaoModeloRepository
    {
        private readonly ApplicationDbContext _context;

        public CaminhaoModeloRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CaminhaoModelo> GetCaminhaoModelos()
        {
            return _context.CaminhaoModelos.AsNoTracking().ToList();

        }
    }

}
