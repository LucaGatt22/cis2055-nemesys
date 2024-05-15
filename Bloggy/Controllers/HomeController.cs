using Bloggy.Models;
using Bloggy.Models.Interfaces;
using Bloggy.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bloggy.Controllers
{

    public class HomeController : Controller
    {
        private readonly IReportRepository _reportRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            IReportRepository reportRepository, 
            UserManager<ApplicationUser> userManager,
            ILogger<HomeController> logger)
        {
            _reportRepository = reportRepository;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpGet]
        [ResponseCache(Duration =10, Location = ResponseCacheLocation.Client)]

        [Authorize(Roles = "Admin")]
        public IActionResult Dashboard()
        {
            try
            {
                var model = new ReportDashboardViewModel();
                model.TotalRegisteredUsers = _userManager.Users.Count();
                model.TotalEntries = _reportRepository.GetAllReports().Count();

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message); //More on this soon
                return View("Error");
            }

        }

        public IActionResult Index()
        {
            try
            {
                //Load data from the Model
                ViewBag.Title = "NEMESYS - Home";
                ViewBag.Message = "Hello there, this is the time: " + DateTime.Now;
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return View("Error");
            }
        }

        public class ModelBindingTest
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }


        public IActionResult About(ModelBindingTest test)
        {
            try
            {
                //Load data from the Model
                ViewBag.Title = "NEMESYS - About";
                ViewBag.Message = "Hello there, this is the about page. The model binder found - " + test.Name + " - " + test.Id;
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return View("Error");
            }
        }
    }
}
