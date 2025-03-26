using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Models
{
    public enum DoctorStatus
    {
        Available,
        NotAvailable
    }
    public class Doctor : IComparable<Doctor>, IEquatable<Doctor>
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float YearsOfExperience { get; set; }
        public double ConsultingFee { get; set; }
        public string Specialization { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DoctorStatus Status { get; set; } = DoctorStatus.Available;


        public Doctor()
        {
            YearsOfExperience = 1;
            ConsultingFee = 100;
            Specialization = "General Medicine";
        }

        //overloading teh default constructor
        //Parameterized constructor
        public Doctor(int id, string name, float yearsOfExperience, double consultingFee, string specialization, string password, DoctorStatus status)
        {
            Id = id;
            Name = name;
            YearsOfExperience = yearsOfExperience;
            ConsultingFee = consultingFee;
            Specialization = specialization;
            Password = password;
            Status = status;
        }

        public override string ToString()
        {
            return $"Id: {Id}" +
                $"\nName: {Name}" +
                $"\nYears of Experience: {YearsOfExperience}" +
                $"\nConsulting Fee: $ {ConsultingFee}" +
                $"\nSpecialization: {Specialization}"+
                $"\nStatus: {Status}";

        }

        public void TakeDoctorDetailsFromConsole()
        {
            
            Console.WriteLine("Please enter the doctor Name");
            Name = Console.ReadLine()??"-----";
            Console.WriteLine("Please enter the doctor's years of experience");
            float yearsOfExperience;
            while (float.TryParse(Console.ReadLine(), out yearsOfExperience) == false)
            {
                Console.WriteLine("That was not an valid entry for years of experience. Please try again");
            }
            YearsOfExperience = yearsOfExperience;
            Console.WriteLine("Please enter the doctor's consulting fee");
            double consultingFee;
            while (double.TryParse(Console.ReadLine(), out consultingFee) == false)
            {
                Console.WriteLine("That was not an valid entry for consulting fee. Please try again");
            }
            ConsultingFee = consultingFee;
            Console.WriteLine("Please enter the doctor's specialization");
            Specialization = Console.ReadLine() ?? "General Medicine";
        }

        //IComparable interface implementation for sorting used by sort method in collection
        public int CompareTo(Doctor? other)
        {
           if(other == null)
            {
                return 1;
            }
            return this.Id.CompareTo(other.Id);
        }


        //equals methods overridden for checking also used by collections methods- remove, contains etc
        public bool Equals(Doctor? other)
        {
            return this.Id == other?.Id;
        }

        //Operator overloading - for ease of comparison
        public static bool operator ==(Doctor? doctor1, Doctor? doctor2)
        {
            return doctor1?.Id == doctor2?.Id;
        }
        public static bool operator !=(Doctor? doctor1, Doctor? doctor2)
        {
            return doctor1?.Id != doctor2?.Id;
        }
    }
}
