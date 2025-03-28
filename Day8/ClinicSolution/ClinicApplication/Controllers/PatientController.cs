using ClinicApplication.Interfaces;
using ClinicApplication.Models.ViewModels;
using ClinicApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApplication.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService) 
        {
            _patientService = patientService;
        }
        public IActionResult Create()
        {
            return View(new UserPatient());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(UserPatient patient)
        {
            if (ModelState.IsValid)
            {
                var result = await _patientService.Register(patient);
                if (result != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(patient);
        }
    }
}
