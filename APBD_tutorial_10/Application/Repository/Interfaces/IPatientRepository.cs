using APBD_tutorial_10.Core.Data;

namespace APBD_tutorial_10.Application.Repository.Interfaces;

public interface IPatientRepository
{
    Task<bool> PatientExistsAsync(int idPatient);
    Task<Patient?> GetPatientAsync(int idPatient);
    Task<IEnumerable<Patient>> GetAllPatientsAsync();
    Task AddPatientAsync(Patient patient);
    Task<bool> DeletePatientAsync(int idPatient);
    Task<Patient?> GetPatientByIdAsync(int patientId);

}