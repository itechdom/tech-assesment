using justice_technical_assestment.Infrastructure.Data;
using justice_technical_assestment.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justice_technical_assestment.Infrastructure.Repositories
{
    public class PatientRepository
    {
        private readonly ClinicContext _context;

        public PatientRepository(ClinicContext context)
        {
            _context = context;
        }

        public async Task<List<Patient>> Get(int PageNumber, int PageSize)
        {
            return await _context.Patients
                .Skip(PageNumber * PageSize)
                .Take(PageSize)
                .ToListAsync();
        }

        public async Task<Patient> GetById(long Id)
        {
            return await _context.Patients.FirstOrDefaultAsync(i => i.Id == Id);
        }

        public void Add(Patient patient)
        {
            _context.Patients.Add(patient);
        }

        public void Update(Patient patient)
        {
            _context.Patients.Update(patient);
        }

        public void Remove(Patient patient)
        {
            _context.Patients.Remove(patient);
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
