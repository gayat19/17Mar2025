namespace ClinicApplication.Exceptions
{
    public class EntityCollectionEmptyException : Exception
    {
        public EntityCollectionEmptyException() :base("The collection is empty")
        {
        }
        public EntityCollectionEmptyException(string message) : base(message)
        {
        }
    }
}
