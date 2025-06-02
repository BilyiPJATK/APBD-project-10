using System;
using System.Collections.Generic;

namespace APBD_tutorial_10.Application.DTOs;
    public class PrescriptionDTO
    { 
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public List<MedicamentDTO> Medicaments { get; set; } = new();
        public DoctorDTO Doctor { get; set; } = null!;
    }