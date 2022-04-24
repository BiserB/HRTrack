using HRTrack.App.Models;
using HRTrack.Data;
using HRTrack.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HRTrack.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HRTrackDbContext dbContext;

        public HomeController(ILogger<HomeController> logger, HRTrackDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            //try
            //{
            //    var user = new AppUser()
            //    {
            //        NormalizedEmail = "test@test.com".ToUpper(),
            //        Email = "test@test.com",
            //        UserName = "Tester Test",
            //        NormalizedUserName = "Tester Test".ToUpper(),
            //        PasswordHash = "123456789",
            //        PhoneNumber = "0987654321"
            //    };

            //    dbContext.Users.Add(user);

            //    dbContext.SaveChanges();
            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}