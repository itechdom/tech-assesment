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
                .Include(m => m.Doctor)
                .Include(m => m.Kin)
                .ToListAsync();
        }

        public async Task<Patient> GetById(long Id)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(i => i.Id == Id);
            if (patient == null)
            {
                throw new Exception("Not FOund");
            }
            return patient;
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
