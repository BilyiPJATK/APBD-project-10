using APBD_tutorial_10.Core.Data;

namespace APBD_tutorial_10.Application.Repository.Interfaces;

public interface IPrescriptionMedicamentRepository
{
    Task<bool> PrescriptionMedicamentExistsAsync(int idMedicament, int idPrescription);
    Task<PrescriptionMedicament?> GetPrescriptionMedicamentAsync(int idMedicament, int idPrescription);
    Task<IEnumerable<PrescriptionMedicament>> GetAllPrescriptionMedicamentsAsync();
    Task AddPrescriptionMedicamentAsync(PrescriptionMedicament prescriptionMedicament);
    Task<bool> DeletePrescriptionMedicamentAsync(int idMedicament, int idPrescription);
    Task<List<PrescriptionMedicament>> GetPrescriptionMedicamentsAsync(int prescriptionId);

}