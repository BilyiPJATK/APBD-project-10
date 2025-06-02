namespace APBD_tutorial_10.Application.Exceptions
{
    public class DoctorNotFoundException : Exception
    {
        public DoctorNotFoundException(int DoctorId) 
            : base("Doctor not found.")
        {
        }

        public DoctorNotFoundException(string message) 
            : base(message)
        {
        }
    }
}