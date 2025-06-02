using APBD_tutorial_10.Application.DTOs;
using APBD_tutorial_10.Application.Exceptions;
using APBD_tutorial_10.Application.Repository.Interfaces;
using APBD_tutorial_10.Application.Service.Interfaces;
using APBD_tutorial_10.Core.Data;

namespace APBD_tutorial_10.Application.Service;

public class PrescriptionService : IPrescriptionService
{
    private readonly IPatientRepository _patientRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IMedicamentRepository _medicamentRepository;
    private readonly IPrescriptionRepository _prescriptionRepository;
    private readonly IPrescriptionMedicamentRepository _prescriptionMedicamentRepository;

    public PrescriptionService(
        IPatientRepository patientRepository,
        IDoctorRepository doctorRepository,
        IMedicamentRepository medicamentRepository,
        IPrescriptionRepository prescriptionRepository,
        IPrescriptionMedicamentRepository prescriptionMedicamentRepository)
    {
        _patientRepository = patientRepository;
        _doctorRepository = doctorRepository;
        _medicamentRepository = medicamentRepository;
        _prescriptionRepository = prescriptionRepository;
        _prescriptionMedicamentRepository = prescriptionMedicamentRepository;
    }

    public async Task<(bool IsSuccess, string ErrorMessage)> IssuePrescriptionAsync(PrescriptionRequestDto request)
    {
        if (request.Medicaments.Count > 10)
            throw new PrescriptionExceptions.TooManyMedicamentsException();

        if (request.DueDate < request.Date)
            throw new PrescriptionExceptions.InvalidDateException();

        foreach (var med in request.Medicaments)
        {
            var exists = await _medicamentRepository.MedicamentExistsAsync(med.IdMedicament);
            if (!exists)
                throw new PrescriptionExceptions.MedicamentNotFoundException(med.IdMedicament);
        }

        bool patientExists = await _patientRepository.PatientExistsAsync(request.IdPatient);
        if (!patientExists)
        {
            throw new Exception("Patient not found."); // Or handle creation
        }

        bool doctorExists = await _doctorRepository.DoctorExistsAsync(request.IdDoctor);
        if (!doctorExists)
            throw new DoctorNotFoundException(request.IdDoctor);

        var prescription = new Prescription
        {
            Date = request.Date,
            DueDate = request.DueDate,
            IdPatient = request.IdPatient,
            IdDoctor = request.IdDoctor
        };

        await _prescriptionRepository.AddPrescriptionAsync(prescription);

        foreach (var med in request.Medicaments)
        {
            var prescriptionMedicament = new PrescriptionMedicament
            {
                IdMedicament = med.IdMedicament,
                IdPrescription = prescription.IdPrescription,
                Details = med.Details,
                Dose = med.Dose,
            };
            await _prescriptionMedicamentRepository.AddPrescriptionMedicamentAsync(prescriptionMedicament);
        }

        return (true, null);
    }

}
