using Bloggy.Models;
using Bloggy.Models.Interfaces;
using Bloggy.Models.Repositories;
using Bloggy.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bloggy.Controllers
{
    [Authorize(Roles = "Reporter")]
    public class ReportController : Controller
    {
        private readonly IReportRepository _reportRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ReportController> _logger;

        //Using constructor dependency injection for the controller
        //(i.e.when the controller is instnatiated, it will receive an instance of IReportRepository according to the service collection config in Program.cs
        public ReportController(
            IReportRepository reportRepository,
            UserManager<ApplicationUser> userManager,
            ILogger<ReportController> logger)
        {
            _reportRepository = reportRepository;
            _userManager = userManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                //Just to test logging
                _logger.LogInformation("Information message");
                _logger.LogWarning("Warning message");
                _logger.LogError("Error message");
                _logger.LogCritical("Critical message");

                //Constructing a View Model to be passed on to the view
                var reports = _reportRepository.GetAllReports().OrderByDescending(b => b.CreatedDate); ;
                var model = new ReportListViewModel()
                {
                    TotalEntries = _reportRepository.GetAllReports().Count(),
                    Reports = _reportRepository
                    .GetAllReports()
                    .OrderByDescending(b => b.CreatedDate)
                    .Select(b => new ReportViewModel
                    {
                        Id = b.Id,
                        CreatedDate = b.CreatedDate,
                        Content = b.Content,
                        ImageUrl = b.ImageUrl,
                        Title = b.Title,
                        Category = new CategoryViewModel()
                        {
                            Id = b.Category.Id,
                            Name = b.Category.Name
                        },
                        Author = new AuthorViewModel()
                        {
                            Id = b.UserId,
                            Name = (_userManager.FindByIdAsync(b.UserId).Result != null) ?
                                _userManager.FindByIdAsync(b.UserId).Result.UserName : "Anonymous"
                        }
                    })
                };

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return View("Error");
            }


        }

        public IActionResult Details(int id)
        {
            try
            {
                var report = _reportRepository.GetReportById(30);
                if (report == null)
                    return NotFound();
                else
                {
                    var model = new ReportViewModel()
                    {
                        Id = report.Id,
                        CreatedDate = report.CreatedDate,
                        ImageUrl = report.ImageUrl,
                        Title = report.Title,
                        Content = report.Content,
                        Category = new CategoryViewModel()
                        {
                            Id = report.Category.Id,
                            Name = report.Category.Name
                        },
                        Author = new AuthorViewModel()
                        {
                            Id = report.UserId,
                            Name = (_userManager.FindByIdAsync(report.UserId).Result != null) ?
                                _userManager.FindByIdAsync(report.UserId).Result.UserName : "Anonymous"
                        }
                    };

                    return View(model);
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return View("Error");
            }


        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                //Load all categories and create a list of CategoryViewModel
                var categoryList = _reportRepository.GetAllCategories().Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToList();

                //Pass the list into an EditReortViewModel, which is used by the View (all other properties may be left blank, unless you want to add some default values
                var model = new EditReportViewModel()
                {
                    CategoryList = categoryList
                };

                //Pass view model to the view
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return View("Error");
            }
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Title, Content, ImageToUpload, CategoryId")] EditReportViewModel newReport)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string fileName = "";
                    if (newReport.ImageToUpload != null)
                    {
                        //At this point you should check for aspects such as file size, file extension etc...
                        //Then you persist using a new name for consistency and uniqueness (e.g. GUIDS)
                        var extension = "." + newReport.ImageToUpload.FileName.Split('.')[newReport.ImageToUpload.FileName.Split('.').Length - 1];
                        fileName = Guid.NewGuid().ToString() + extension;
                        var path = Directory.GetCurrentDirectory() + "\\wwwroot\\images\\reports\\" + fileName;
                        using (var bits = new FileStream(path, FileMode.Create))
                        {
                            newReport.ImageToUpload.CopyTo(bits);
                        }
                    }

                    Report report = new Report()
                    {
                        Title = newReport.Title,
                        Content = newReport.Content,
                        CreatedDate = DateTime.UtcNow,
                        ImageUrl = "/images/reports/" + fileName,
                        CategoryId = newReport.CategoryId,
                        UserId = _userManager.GetUserId(User)
                    };

                    //Persist to repository
                    _reportRepository.CreateReport(report);
                    return RedirectToAction("Index");
                }
                else
                {
                    //Load all categories and create a list of CategoryViewModel
                    var categoryList = _reportRepository.GetAllCategories().Select(c => new CategoryViewModel()
                    {
                        Id = c.Id,
                        Name = c.Name
                    }).ToList();

                    //Re-attach to view model before sending back to the View (this is necessary so that the View can repopulate the drop down and pre-select according to the CategoryId
                    newReport.CategoryList = categoryList;

                    return View(newReport);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return View("Error");
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                var existingReport = _reportRepository.GetReportById(id);
                if (existingReport != null)
                {
                    //Check if the current user has access to this resources
                    var currentUserId = _userManager.GetUserId(User);
                    if (existingReport.UserId == currentUserId || User.IsInRole("Administrator"))
                    {
                        EditReportViewModel model = new EditReportViewModel()
                        {
                            Id = existingReport.Id,
                            Title = existingReport.Title,
                            Content = existingReport.Content,
                            ImageUrl = existingReport.ImageUrl,
                            CategoryId = existingReport.CategoryId
                        };

                        //Load all categories and create a list of CategoryViewModel
                        var categoryList = _reportRepository.GetAllCategories().Select(c => new CategoryViewModel()
                        {
                            Id = c.Id,
                            Name = c.Name
                        }).ToList();

                        //Attach to view model - view will pre-select according to the value in CategoryId
                        model.CategoryList = categoryList;

                        return View(model);
                    }
                    else
                        return Forbid(); //or redirect to an error page or to the Index page
                }
                else
                    return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return View("Error");
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit([FromRoute] int id, [Bind("Id, Title, Content, ImageToUpload, CategoryId")] EditReportViewModel updatedReport)
        {
            try
            {
                var modelToUpdate = _reportRepository.GetReportById(id);
                if (modelToUpdate == null)
                {
                    return NotFound();
                }

                //Check if the current user has access to this resource
                var currentUserId = _userManager.GetUserId(User);
                if (modelToUpdate.UserId == currentUserId)
                {
                    if (ModelState.IsValid)
                    {
                        string imageUrl = "";

                        if (updatedReport.ImageToUpload != null)
                        {
                            string fileName = "";
                            //At this point you should check size, extension etc...
                            //Then persist using a new name for consistency (e.g. new Guid)
                            var extension = "." + updatedReport.ImageToUpload.FileName.Split('.')[updatedReport.ImageToUpload.FileName.Split('.').Length - 1];
                            fileName = Guid.NewGuid().ToString() + extension;
                            var path = Directory.GetCurrentDirectory() + "\\wwwroot\\images\\reports\\" + fileName;
                            using (var bits = new FileStream(path, FileMode.Create))
                            {
                                updatedReport.ImageToUpload.CopyTo(bits);
                            }
                            imageUrl = "/images/reports/" + fileName;
                        }
                        else
                            imageUrl = modelToUpdate.ImageUrl;

                        modelToUpdate.Title = updatedReport.Title;
                        modelToUpdate.Content = updatedReport.Content;
                        modelToUpdate.ImageUrl = imageUrl;
                        modelToUpdate.UpdatedDate = DateTime.Now;
                        modelToUpdate.CategoryId = updatedReport.CategoryId;
                        modelToUpdate.UserId = _userManager.GetUserId(User);

                        _reportRepository.UpdateReport(modelToUpdate);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        //Load all categories and create a list of CategoryViewModel
                        var categoryList = _reportRepository.GetAllCategories().Select(c => new CategoryViewModel()
                        {
                            Id = c.Id,
                            Name = c.Name
                        }).ToList();

                        //Re-attach to view model before sending back to the View (this is necessary so that the View can repopulate the drop down and pre-select according to the CategoryId
                        updatedReport.CategoryList = categoryList;

                        return View(updatedReport);
                    }
                }
                else
                    return Forbid();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return View("Error");
            }
        }

    }
}
