using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolvoLab.Caminhoes.Domain.Entities;
using VolvoLab.Caminhoes.Domain.Interfaces.Repositories;
using VolvoLab.Caminhoes.Infra.Data.Context;

namespace VolvoLab.Caminhoes.Infra.Data.Repositories
{

    public class CaminhaoRepository : ICaminhaoRepository
    {
        private readonly ApplicationDbContext _context;

        public CaminhaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Caminhao caminhao)
        {
            _context.Add(caminhao);
            _context.SaveChanges();

        }

        public Caminhao GetById(Guid? id)
        {
            return _context.Caminhoes
                .Where(c => c.Id == id)
                .FirstOrDefault();                           
               
        }

        public async Task<IEnumerable<Caminhao>> GetCaminhoes()
        {
            return await _context.Caminhoes
                .AsNoTracking()
                .ToListAsync();                 
        }

        public void Remove(Guid Id)
        {
            var caminhao = GetById(Id);

            if (caminhao != null)
            {
                _context.Remove(caminhao);
                _context.SaveChanges();
            }
        }

        public void Update(Caminhao caminhao)
        {
            _context.Update(caminhao);
            _context.SaveChanges();
        }
    }
}
