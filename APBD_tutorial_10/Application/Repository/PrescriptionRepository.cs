using APBD_tutorial_10.Core.Data;

using APBD_tutorial_10.Application.Repository.Interfaces;
using APBD_tutorial_10.Core.Database;
using Microsoft.EntityFrameworkCore;

namespace APBD_tutorial_10.Infrastructure.Repository
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly ApplicationDbContext context;

        public PrescriptionRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> PrescriptionExistsAsync(int idPrescription)
        {
            return await context.Prescriptions.AnyAsync(p => p.IdPrescription == idPrescription);
        }

        public async Task<Prescription?> GetPrescriptionAsync(int idPrescription)
        {
            return await context.Prescriptions.FindAsync(idPrescription);
        }

        public async Task<IEnumerable<Prescription>> GetAllPrescriptionsAsync()
        {
            return await context.Prescriptions.ToListAsync();
        }

        public async Task AddPrescriptionAsync(Prescription prescription)
        {
            await context.Prescriptions.AddAsync(prescription);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeletePrescriptionAsync(int idPrescription)
        {
            var prescription = await context.Prescriptions.FindAsync(idPrescription);
            if (prescription == null) return false;

            context.Prescriptions.Remove(prescription);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<List<Prescription>> GetPrescriptionsByPatientIdAsync(int patientId)
        {
            return await context.Prescriptions
                .Where(p => p.IdPatient == patientId)
                .ToListAsync();
        }

    }
}