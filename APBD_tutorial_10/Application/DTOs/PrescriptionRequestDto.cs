namespace APBD_tutorial_10.Application.DTOs;

public class PrescriptionRequestDto
{
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public int IdDoctor { get; set; }
    public int IdPatient { get; set; }
    public List<MedicamentRequestDto> Medicaments { get; set; } = new();
}