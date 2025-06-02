using System.Threading.Tasks;
using System.Collections.Generic;
using APBD_tutorial_10.Core.Data;

namespace APBD_tutorial_10.Application.Repository.Interfaces;

    public interface IDoctorRepository
    {
        Task<bool> DoctorExistsAsync(int idDoctor);
        Task<Doctor?> GetDoctorAsync(int idDoctor);
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
        Task AddDoctorAsync(Doctor doctor);
        Task<bool> DeleteDoctorAsync(int idDoctor);
        Task<Doctor?> GetDoctorByIdAsync(int doctorId);

    }
    

