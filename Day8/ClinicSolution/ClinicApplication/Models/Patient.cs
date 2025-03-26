

namespace ClinicApplication.Models
{
    public class Patient
    {
        public string PatientNumber { get; set; } = string.Empty;
        public string Phone{ get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public float  Age { get; set; }
        public string Email { get; set; } = string.Empty;
        public User? User { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }
    }
}
