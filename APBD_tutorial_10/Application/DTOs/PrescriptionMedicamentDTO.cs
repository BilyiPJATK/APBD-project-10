namespace APBD_tutorial_10.Application.DTOs;
    public class PrescriptionMedicamentDTO
    {
        public int IdMedicament { get; set; }
        public int IdPrescription { get; set; }
        public int? Dose { get; set; }
        public string Details { get; set; } = null!;

        public MedicamentDTO? Medicament { get; set; }
    }
