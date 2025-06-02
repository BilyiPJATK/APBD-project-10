using APBD_tutorial_10.Core.Data;

namespace APBD_tutorial_10.Application.Repository.Interfaces;

public interface IPrescriptionRepository
{
    Task<bool> PrescriptionExistsAsync(int idPrescription);
    Task<Prescription?> GetPrescriptionAsync(int idPrescription);
    Task<IEnumerable<Prescription>> GetAllPrescriptionsAsync();
    Task AddPrescriptionAsync(Prescription prescription);
    Task<bool> DeletePrescriptionAsync(int idPrescription);
    Task<List<Prescription>> GetPrescriptionsByPatientIdAsync(int patientId);

}