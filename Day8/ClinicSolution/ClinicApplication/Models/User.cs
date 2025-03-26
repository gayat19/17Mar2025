using System.ComponentModel.DataAnnotations;

namespace ClinicApplication.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        //will not create a column for this. Only uses for loading data when required
        public Doctor? Doctor { get; set; }//Navigation property
        public string Role { get; set; } = string.Empty;

        public Patient? Patient { get; set; }//Navigation property

    }
}
