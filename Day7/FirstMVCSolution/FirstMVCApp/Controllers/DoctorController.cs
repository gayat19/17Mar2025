using FirstMVCApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
    public class DoctorController : Controller
    {
        static List<Doctor> doctors = new List<Doctor>
        {
            new Doctor { Id = 1, Name = "Dr. John Doe", Specialties = new List<string> { "Cardiologist", "Pediatrician", "Dermatologist" } },
            new Doctor { Id = 2, Name = "Dr. Jane Smith", Specialties = new List<string> { "Neurologist", "Orthopedic", "Oncologist" } }
        };
        public IActionResult Index()
        {
            return View(doctors);
        }

        public IActionResult DoctorDetails( int did)
        {
           Doctor doctor = doctors.FirstOrDefault(d => d.Id == did);
            return View(doctor);//Strongly typed view
        }
        [HttpGet]
        public IActionResult AddDoctor()
        {
            return View(new Doctor());
        }

        [HttpPost]
        public IActionResult AddDoctor(Doctor doctor)
        {
            doctors.Add(doctor);
            return RedirectToAction("Index");
        }
    }
}
