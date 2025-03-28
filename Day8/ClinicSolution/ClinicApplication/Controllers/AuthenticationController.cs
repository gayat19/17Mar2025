using ClinicApplication.Interfaces;
using ClinicApplication.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApplication.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(ILogger<AuthenticationController> logger,
                                        IAuthenticationService authenticationService) 
        {
            _logger = logger;
            _authenticationService = authenticationService;
        }
        public IActionResult Login()
        {

            return View(new LoginUser());
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginUser login)
        {
            ViewBag.Message = "";
            try
            {
                var user = await _authenticationService.Login(login);
                if(user.Role.ToLower() == "doctor")
                {
                    //TempData["Name"] = user.Name;
                   HttpContext.Session.SetString("Name", user.Name);
                    return RedirectToAction("Index", "Doctor");
                }
                else if (user.Role.ToLower() == "patient")
                {
                    return RedirectToAction("Index", "Patient");
                }
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                _logger.LogError(ex.Message);
            }
            return View();
        }

    }
}
