using ClinicApplication.Interfaces;
using ClinicApplication.Models;
using ClinicApplication.Models.ViewModels;
using ClinicApplication.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApplication.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService; 
        }
        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                //var Name = TempData["Name"];
                var Name = HttpContext.Session.GetString("Name");   
                if (Name != null)
                {
                    ViewBag.Name = Name;
                }
                //var doctors = await _doctorRepository.GetAll();
                //return View(doctors);
                return View();
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
            return View(new UserDoctor());
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(UserDoctor doctor)
        {
            try
            {
               var result = await _doctorService.RegisterDoctor(doctor);
                if (result)
                    return RedirectToAction("Index");
                else
                    return View(doctor);
            }
            catch(Exception e)
            {
                ViewBag.Error = e.Message;
                return View(doctor);
            }
        }
    }
}
