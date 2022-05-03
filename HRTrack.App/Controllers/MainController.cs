using HRTrack.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HRTrack.App.Controllers
{
    [Authorize]
    public class MainController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public MainController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
