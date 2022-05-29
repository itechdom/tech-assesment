using justice_technical_assestment.Infrastructure.Data;
using justice_technical_assestment.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justice_technical_assestment.Infrastructure.Repositories
{
    public class KinRepository
    {
        private readonly ClinicContext _context;

        public KinRepository(ClinicContext context)
        {
            _context = context;
        }

        public async Task<List<Kin>> Get(int PageNumber, int PageSize)
        {
            return await _context.Kins
                .Skip(PageNumber * PageSize)
                .Take(PageSize)
                .ToListAsync();
        }

        public async Task<Kin> GetById(long Id)
        {
            return await _context.Kins.FirstOrDefaultAsync(i => i.Id == Id);
        }

        public void Add(Kin kin)
        {
           _context.Kins.Add(kin);
        }

        public void Update(Kin kin)
        {
            _context.Kins.Update(kin);
        }

        public void Remove(Kin kin)
        {
            _context.Kins.Remove(kin);
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
