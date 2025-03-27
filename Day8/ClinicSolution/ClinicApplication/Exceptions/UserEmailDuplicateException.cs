namespace ClinicApplication.Exceptions
{
    public class UserEmailDuplicateException : Exception
    {
        public UserEmailDuplicateException(): base("Email already registered")
        {
        }
        public UserEmailDuplicateException(string message) : base(message)
        {
        }

    }
}
