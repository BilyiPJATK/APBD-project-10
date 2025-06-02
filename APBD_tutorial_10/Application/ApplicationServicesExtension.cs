using APBD_tutorial_10.Application.Repository;
using APBD_tutorial_10.Application.Repository.Interfaces;
using APBD_tutorial_10.Application.Service;
using APBD_tutorial_10.Application.Service.Interfaces;
using APBD_tutorial_10.Core.Database;
using APBD_tutorial_10.Infrastructure.Repository;

namespace APBD_tutorial_10.Application;

public static class ApplicationServicesExtension
{
    public static void RegisterApplicationServices(this IServiceCollection app)
    {
        app.AddScoped<IPrescriptionService, PrescriptionService>();

        app.AddScoped<IPatientRepository, PatientRepository>();
        app.AddScoped<IDoctorRepository, DoctorRepository>();
        app.AddScoped<IMedicamentRepository, MedicamentRepository>();
        app.AddScoped<IPrescriptionRepository, PrescriptionRepository>();
        app.AddScoped<IPrescriptionMedicamentRepository, PrescriptionMedicamentRepository>();
        app.AddScoped<IPatientService, PatientService>();
        app.AddScoped<IPatientRepository, PatientRepository>();
    }

}