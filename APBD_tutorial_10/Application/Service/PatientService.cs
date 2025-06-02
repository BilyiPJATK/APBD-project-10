using APBD_tutorial_10.Application.DTOs;
using APBD_tutorial_10.Application.Repository.Interfaces;
using APBD_tutorial_10.Application.Service.Interfaces;

namespace APBD_tutorial_10.Application.Service;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;
    private readonly IPrescriptionRepository _prescriptionRepository;
    private readonly IPrescriptionMedicamentRepository _prescriptionMedicamentRepository;
    private readonly IMedicamentRepository _medicamentRepository;
    private readonly IDoctorRepository _doctorRepository;

    public PatientService(
        IPatientRepository patientRepository,
        IPrescriptionRepository prescriptionRepository,
        IPrescriptionMedicamentRepository prescriptionMedicamentRepository,
        IMedicamentRepository medicamentRepository,
        IDoctorRepository doctorRepository)
    {
        _patientRepository = patientRepository;
        _prescriptionRepository = prescriptionRepository;
        _prescriptionMedicamentRepository = prescriptionMedicamentRepository;
        _medicamentRepository = medicamentRepository;
        _doctorRepository = doctorRepository;
    }

    public async Task<PatientDetailsDto?> GetPatientDetailsAsync(int patientId)
    {
        var patient = await _patientRepository.GetPatientByIdAsync(patientId);
        if (patient == null)
            return null;

        var prescriptions = await _prescriptionRepository.GetPrescriptionsByPatientIdAsync(patientId);

        var prescriptionDtos = new List<PrescriptionDTO>();
        foreach (var prescription in prescriptions.OrderBy(p => p.DueDate))
        {
            var doctor = await _doctorRepository.GetDoctorByIdAsync(prescription.IdDoctor);
            var meds = await _prescriptionMedicamentRepository.GetPrescriptionMedicamentsAsync(prescription.IdPrescription);

            var medDtos = new List<MedicamentDTO>();
            foreach (var pm in meds)
            {
                var med = await _medicamentRepository.GetMedicamentByIdAsync(pm.IdMedicament);
                medDtos.Add(new MedicamentDTO
                {
                    IdMedicament = med.IdMedicament,
                    Name = med.Name,
                    Description = med.Description,
                    Dose = pm.Dose ?? 0
                });
            }

            prescriptionDtos.Add(new PrescriptionDTO
            {
                IdPrescription = prescription.IdPrescription,
                Date = prescription.Date,
                DueDate = prescription.DueDate,
                Medicaments = medDtos,
                Doctor = new DoctorDTO
                {
                    IdDoctor = doctor.IdDoctor,
                    FirstName = doctor.FirstName,
                    LastName = doctor.LastName,
                    Email = doctor.Email
                }
            });
        }

        return new PatientDetailsDto
        {
            IdPatient = patient.IdPatient,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            BirthDate = patient.BirthDate,
            Prescriptions = prescriptionDtos
        };
    }
}
