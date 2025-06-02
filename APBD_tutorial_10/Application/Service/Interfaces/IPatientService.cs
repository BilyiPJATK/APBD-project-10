using APBD_tutorial_10.Application.DTOs;

namespace APBD_tutorial_10.Application.Service.Interfaces;

public interface IPatientService
{
    Task<PatientDetailsDto?> GetPatientDetailsAsync(int idPatient);
}