namespace APBD_tutorial_10.Application.Exceptions;

public static class PrescriptionExceptions
{
    public class TooManyMedicamentsException()
        : BaseExceptions.ValidationException("Cannot assign more than 10 medicaments.");

    public class InvalidDateException()
        : BaseExceptions.ValidationException("DueDate must be greater than or equal to Date.");

    public class MedicamentNotFoundException(int id)
        : BaseExceptions.NotFoundException($"Medicament with ID {id} not found.");
}