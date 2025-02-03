using InventoryManagement.DTOs;
using InventoryManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]  
        public async Task<IActionResult> Register(UserDTO userDto)
        {
            await _authService.Registeration(userDto);
            return RedirectToAction("Index","Home");
        }

    }
}
