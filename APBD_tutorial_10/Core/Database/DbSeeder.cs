using APBD_tutorial_10.Core.Data;

namespace APBD_tutorial_10.Core.Database;

public static class DbSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
{
    // Seed Doctors
    if (!context.Doctors.Any())
    {
        context.Doctors.AddRange(
            new Doctor { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" },
            new Doctor { FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com" },
            new Doctor { FirstName = "Albert", LastName = "Einstein", Email = "albert.einstein@example.com" }
        );
        await context.SaveChangesAsync(); // Save to generate IDs
    }

    // Seed Patients
    if (!context.Patients.Any())
    {
        context.Patients.AddRange(
            new Patient { FirstName = "Alice", LastName = "Wonderland", BirthDate = new DateTime(1980, 1, 1) },
            new Patient { FirstName = "Bob", LastName = "Builder", BirthDate = new DateTime(1990, 5, 21) },
            new Patient { FirstName = "Charlie", LastName = "Brown", BirthDate = new DateTime(1975, 12, 5) }
        );
        await context.SaveChangesAsync();
    }

    // Seed Medicaments
    if (!context.Medicaments.Any())
    {
        context.Medicaments.AddRange(
            new Medicament { Name = "Aspirin", Description = "Painkiller", Type = "Tablet" },
            new Medicament { Name = "Penicillin", Description = "Antibiotic", Type = "Injection" },
            new Medicament { Name = "Ibuprofen", Description = "Anti-inflammatory", Type = "Capsule" }
        );
        await context.SaveChangesAsync();
    }

    // Fetch inserted doctors, patients, medicaments to get their generated IDs
    var doctors = context.Doctors.ToList();
    var patients = context.Patients.ToList();
    var medicaments = context.Medicaments.ToList();

    // Seed Prescriptions
    if (!context.Prescriptions.Any())
    {
        context.Prescriptions.AddRange(
            new Prescription
            {
                Date = DateTime.Now.AddDays(-10),
                DueDate = DateTime.Now.AddDays(10),
                IdPatient = patients[0].IdPatient,  // Use actual generated Id
                IdDoctor = doctors[0].IdDoctor
            },
            new Prescription
            {
                Date = DateTime.Now.AddDays(-5),
                DueDate = DateTime.Now.AddDays(15),
                IdPatient = patients[1].IdPatient,
                IdDoctor = doctors[1].IdDoctor
            },
            new Prescription
            {
                Date = DateTime.Now.AddDays(-7),
                DueDate = DateTime.Now.AddDays(7),
                IdPatient = patients[2].IdPatient,
                IdDoctor = doctors[2].IdDoctor
            }
        );
        await context.SaveChangesAsync();
    }

    var prescriptions = context.Prescriptions.ToList();

    // Seed PrescriptionMedicaments
    if (!context.PrescriptionMedicaments.Any())
    {
        context.PrescriptionMedicaments.AddRange(
            new PrescriptionMedicament
            {
                IdPrescription = prescriptions[0].IdPrescription,
                IdMedicament = medicaments[0].IdMedicament,
                Dose = 2,
                Details = "Take after meals"
            },
            new PrescriptionMedicament
            {
                IdPrescription = prescriptions[1].IdPrescription,
                IdMedicament = medicaments[1].IdMedicament,
                Dose = 1,
                Details = "Inject once daily"
            },
            new PrescriptionMedicament
            {
                IdPrescription = prescriptions[2].IdPrescription,
                IdMedicament = medicaments[2].IdMedicament,
                Dose = 3,
                Details = "Capsules every 8 hours"
            }
        );
        await context.SaveChangesAsync();
    }
}

}
