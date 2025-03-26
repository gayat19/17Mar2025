namespace FirstMVCApp.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<string>? Specialties { get; set; }
    }
}
