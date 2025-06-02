using APBD_tutorial_10.Core.Data;

using APBD_tutorial_10.Application.Repository.Interfaces;
using APBD_tutorial_10.Core.Database;
using Microsoft.EntityFrameworkCore;

namespace APBD_tutorial_10.Application.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext context;

        public DoctorRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> DoctorExistsAsync(int idDoctor)
        {
            return await context.Doctors.AnyAsync(d => d.IdDoctor == idDoctor);
        }

        public async Task<Doctor?> GetDoctorAsync(int idDoctor)
        {
            return await context.Doctors.FindAsync(idDoctor);
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return await context.Doctors.ToListAsync();
        }

        public async Task AddDoctorAsync(Doctor doctor)
        {
            await context.Doctors.AddAsync(doctor);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteDoctorAsync(int idDoctor)
        {
            var doctor = await context.Doctors.FindAsync(idDoctor);
            if (doctor == null) return false;

            context.Doctors.Remove(doctor);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<Doctor?> GetDoctorByIdAsync(int id)
        {
            return await context.Doctors.FindAsync(id);
        }

    }
}