using AutoMapper;
using APBD_tutorial_10.Core.Data;
using APBD_tutorial_10.Application.DTOs;

namespace APBD_tutorial_10.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Doctor, DoctorDTO>().ReverseMap();
            CreateMap<Medicament, MedicamentDTO>().ReverseMap();
            CreateMap<Patient, PatientDTO>().ReverseMap();
            CreateMap<Prescription, PrescriptionDTO>().ReverseMap();
            CreateMap<PrescriptionMedicament, PrescriptionMedicamentDTO>().ReverseMap();
        }
    }
}