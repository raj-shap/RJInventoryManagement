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
        public  IActionResult Register(UserDTO userDto)
        {
            var status = _authService.Registeration(userDto);
            if (status.Result.Success == false)
            {
                TempData["status"] = status.Result.Message;
                return View();
            }
                return RedirectToAction("Index","Home");
        }

    }
}
