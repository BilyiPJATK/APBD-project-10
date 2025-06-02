using APBD_tutorial_10.Core.Data;

using APBD_tutorial_10.Application.Repository.Interfaces;
using APBD_tutorial_10.Core.Database;
using Microsoft.EntityFrameworkCore;

namespace APBD_tutorial_10.Application.Repository
{
    public class MedicamentRepository : IMedicamentRepository
    {
        private readonly ApplicationDbContext context;

        public MedicamentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> MedicamentExistsAsync(int idMedicament)
        {
            return await context.Medicaments.AnyAsync(m => m.IdMedicament == idMedicament);
        }

        public async Task<Medicament?> GetMedicamentAsync(int idMedicament)
        {
            return await context.Medicaments.FindAsync(idMedicament);
        }

        public async Task<IEnumerable<Medicament>> GetAllMedicamentsAsync()
        {
            return await context.Medicaments.ToListAsync();
        }

        public async Task AddMedicamentAsync(Medicament medicament)
        {
            await context.Medicaments.AddAsync(medicament);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteMedicamentAsync(int idMedicament)
        {
            var medicament = await context.Medicaments.FindAsync(idMedicament);
            if (medicament == null) return false;

            context.Medicaments.Remove(medicament);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<Medicament?> GetMedicamentByIdAsync(int id)
        {
            return await context.Medicaments.FindAsync(id);
        }

    }
}