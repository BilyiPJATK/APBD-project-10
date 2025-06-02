using APBD_tutorial_10.Core.Data;

namespace APBD_tutorial_10.Application.Repository.Interfaces;

public interface IMedicamentRepository
{
    Task<bool> MedicamentExistsAsync(int idMedicament);
    Task<Medicament?> GetMedicamentAsync(int idMedicament);
    Task<IEnumerable<Medicament>> GetAllMedicamentsAsync();
    Task AddMedicamentAsync(Medicament medicament);
    Task<bool> DeleteMedicamentAsync(int idMedicament);
    Task<Medicament?> GetMedicamentByIdAsync(int medicamentId);

}