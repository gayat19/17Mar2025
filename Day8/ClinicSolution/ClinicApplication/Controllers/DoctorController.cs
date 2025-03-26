using ClinicApplication.Interfaces;
using ClinicApplication.Models;
using ClinicApplication.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApplication.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IRepository<int, Doctor> _doctorRepository;

        public DoctorController(IRepository<int,Doctor> doctorRepository)
        {
            _doctorRepository = doctorRepository; 
        }
        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var doctors = await _doctorRepository.GetAll();
                return View(doctors);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Doctor());
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Doctor doctor)
        {
            try
            {
                await _doctorRepository.Add(doctor);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                ViewBag.Error = e.Message;
                return View(doctor);
            }
        }
    }
}
