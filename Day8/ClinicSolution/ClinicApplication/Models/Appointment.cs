namespace ClinicApplication.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string PatientNumber { get; set; }  =string.Empty;
        public int DoctorId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Time { get; set; } = string.Empty;

        public Patient? Patient { get; set; }
        public Doctor? Doctor { get; set; }
    }
}
