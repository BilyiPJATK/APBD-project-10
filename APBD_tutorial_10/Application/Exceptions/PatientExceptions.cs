namespace APBD_tutorial_10.Application.Exceptions;

public static class PatientExceptions
{
    public class PatientNotFoundException(int id)
        : BaseExceptions.NotFoundException($"Patient with ID {id} not found.");
}