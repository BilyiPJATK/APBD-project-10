namespace APBD_tutorial_10.Application.DTOs;
    public class MedicamentDTO
    {
        public int IdMedicament { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Type { get; set; } = null!;
        public int? Dose { get; set; }
    }
