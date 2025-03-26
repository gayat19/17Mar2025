namespace ClinicApplication.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException() : base("The entity was not found")
        {
        }
        public EntityNotFoundException(string message) : base(message)
        {
        }
    }
}
