namespace APBD_tutorial_10.Core.Data;

public class PrescriptionMedicament
{
    public int  IdMedicament { get; set; }
    public int IdPrescription { get; set; }
    public int? Dose { get; set; }
    public string Details { get; set; }
}