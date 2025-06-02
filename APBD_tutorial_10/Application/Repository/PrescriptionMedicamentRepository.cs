using APBD_tutorial_10.Core.Data;
using APBD_tutorial_10.Application.Repository.Interfaces;
using APBD_tutorial_10.Core.Database;
using Microsoft.EntityFrameworkCore;

namespace APBD_tutorial_10.Infrastructure.Repository
{
    public class PrescriptionMedicamentRepository : IPrescriptionMedicamentRepository
    {
        private readonly ApplicationDbContext context;

        public PrescriptionMedicamentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> PrescriptionMedicamentExistsAsync(int idMedicament, int idPrescription)
        {
            return await context.PrescriptionMedicaments.AnyAsync(pm =>
                pm.IdMedicament == idMedicament && pm.IdPrescription == idPrescription);
        }

        public async Task<PrescriptionMedicament?> GetPrescriptionMedicamentAsync(int idMedicament, int idPrescription)
        {
            return await context.PrescriptionMedicaments.FirstOrDefaultAsync(pm =>
                pm.IdMedicament == idMedicament && pm.IdPrescription == idPrescription);
        }

        public async Task<IEnumerable<PrescriptionMedicament>> GetAllPrescriptionMedicamentsAsync()
        {
            return await context.PrescriptionMedicaments.ToListAsync();
        }

        public async Task AddPrescriptionMedicamentAsync(PrescriptionMedicament prescriptionMedicament)
        {
            await context.PrescriptionMedicaments.AddAsync(prescriptionMedicament);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeletePrescriptionMedicamentAsync(int idMedicament, int idPrescription)
        {
            var prescriptionMedicament = await context.PrescriptionMedicaments.FirstOrDefaultAsync(pm =>
                pm.IdMedicament == idMedicament && pm.IdPrescription == idPrescription);

            if (prescriptionMedicament == null) return false;

            context.PrescriptionMedicaments.Remove(prescriptionMedicament);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<List<PrescriptionMedicament>> GetPrescriptionMedicamentsAsync(int prescriptionId)
        {
            return await context.PrescriptionMedicaments
                .Where(pm => pm.IdPrescription == prescriptionId)
                .ToListAsync();
        }

    }
}
