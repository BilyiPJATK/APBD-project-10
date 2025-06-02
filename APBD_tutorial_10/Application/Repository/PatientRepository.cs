using APBD_tutorial_10.Application.Repository.Interfaces;
using APBD_tutorial_10.Core.Data;
using APBD_tutorial_10.Core.Database;
using Microsoft.EntityFrameworkCore;


namespace APBD_tutorial_10.Application.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext context;

        public PatientRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> PatientExistsAsync(int idPatient)
        {
            return await context.Patients.AnyAsync(p => p.IdPatient == idPatient);
        }

        public async Task<Patient?> GetPatientAsync(int idPatient)
        {
            return await context.Patients.FindAsync(idPatient);
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await context.Patients.ToListAsync();
        }

        public async Task AddPatientAsync(Patient patient)
        {
            await context.Patients.AddAsync(patient);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeletePatientAsync(int idPatient)
        {
            var patient = await context.Patients.FindAsync(idPatient);
            if (patient == null) return false;

            context.Patients.Remove(patient);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<Patient?> GetPatientByIdAsync(int patientId)
        {
            return await context.Patients.FirstOrDefaultAsync(p => p.IdPatient == patientId);
        }
    }
}