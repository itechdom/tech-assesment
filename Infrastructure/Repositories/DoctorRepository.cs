using justice_technical_assestment.Infrastructure.Data;
using justice_technical_assestment.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justice_technical_assestment.Infrastructure.Repositories
{
    public class DoctorRepository
    {
        private readonly ClinicContext _context;

        public DoctorRepository(ClinicContext context)
        {
            _context = context;
        }

        public async Task<List<Doctor>> Get(int PageNumber, int PageSize)
        {
            return await _context.Doctors
                .Skip(PageNumber * PageSize)
                .Take(PageSize)
                .ToListAsync();
        }

        public async Task<Doctor> GetById(long Id)
        {
            return await _context.Doctors.FirstOrDefaultAsync(i => i.DoctorId == Id);
        }

        public void Add(Doctor patient)
        {
            _context.Doctors.Add(patient);
        }

        public void Update(Doctor patient)
        {
            _context.Doctors.Update(patient);
        }

        public void Remove(Doctor patient)
        {
            _context.Doctors.Remove(patient);
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
