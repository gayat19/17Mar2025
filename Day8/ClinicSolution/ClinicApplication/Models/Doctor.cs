using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicApplication.Models
{
    public class Doctor
    {
        //Primary key with identity
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public string? Email { get; set; } =string.Empty;

        [ForeignKey("Email")]
        public User? User { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }

    }
}
