using NEMESYS.Models;
using NEMESYS.Models.Interfaces;
using NEMESYS.Models.Repositories;
using NEMESYS.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Composition;

namespace NEMESYS.Controllers
{
    [Authorize(Roles = "Investigator")]
    public class InvestigationController : Controller
    {
        private readonly IInvestigationRepository _investigationRepository;
        private readonly IReportRepository _reportRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<InvestigationController> _logger;

        //Using constructor dependency injection for the controller
        //(i.e.when the controller is instnatiated, it will receive an instance of IInvestigationRepository according to the service collection config in Program.cs
        public InvestigationController(
            IInvestigationRepository investigationRepository,
            IReportRepository reportRepository,
            UserManager<ApplicationUser> userManager,
            ILogger<InvestigationController> logger)
        {
            _investigationRepository = investigationRepository;
            _reportRepository = reportRepository;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpGet]
        [Route("[controller]/Index")]
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
                var investigations = _investigationRepository.GetAllInvestigations().OrderByDescending(b => b.CreatedDate); ;
                var model = new InvestigationListViewModel()
                {
                    TotalEntries = _investigationRepository.GetAllInvestigations().Count(),
                    Investigations = _investigationRepository
                    .GetAllInvestigations()
                    .OrderByDescending(b => b.CreatedDate)
                    .Select(b => new InvestigationViewModel
                    {
                        Id = b.Id,
                        CreatedDate = b.CreatedDate,
                        Content = b.Content,
                        ImageUrl = b.ImageUrl,
                        Title = b.Title,
                        //CampusCategory = new CampusCategoryViewModel()
                        //{
                        //   Id = b.Category.Id,
                        //  Name = b.Category.Name
                        //},
                        Author = new AuthorViewModel()
                        {
                            Id = b.UserId,
                            Name = (_userManager.FindByIdAsync(b.UserId).Result != null) ?
                                _userManager.FindByIdAsync(b.UserId).Result.UserName : "Anonymous"
                        }
                    }).ToList()
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
                var investigation = _investigationRepository.GetInvestigationById(30);
                if (investigation == null)
                    return NotFound();
                else
                {
                    var model = new InvestigationViewModel()
                    {
                        Id = investigation.Id,
                        CreatedDate = investigation.CreatedDate,
                        ImageUrl = investigation.ImageUrl,
                        Title = investigation.Title,
                        Content = investigation.Content,
                        
                        Author = new AuthorViewModel()
                        {
                            Id = investigation.UserId,
                            Name = (_userManager.FindByIdAsync(investigation.UserId).Result != null) ?
                                _userManager.FindByIdAsync(investigation.UserId).Result.UserName : "Anonymous"
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
                //Load all categories and create a list of StatusViewModel
                var statusList = _reportRepository.GetAllStatuses().Select(c => new StatusViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList();

                //Pass the list into an EditReportViewModel, which is used by the View (all other properties may be left blank, unless you want to add some default values
                var model = new EditInvestigationViewModel()
                {
                    StatusList = statusList,
                    //ReportId = reportId
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
        [HttpGet("{reportId}")]
        public IActionResult Create(int reportId)
        {
            try
            {
                //Load all categories and create a list of StatusViewModel
                var statusList = _reportRepository.GetAllStatuses().Select(c => new StatusViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList();

                //Pass the list into an EditReportViewModel, which is used by the View (all other properties may be left blank, unless you want to add some default values
                var model = new EditInvestigationViewModel()
                {
                    StatusList = statusList,
                    ReportId = reportId
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
        public IActionResult Create([Bind("Title, Content, ImageToUpload, ReportId")] EditInvestigationViewModel newInvestigation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string fileName = "";
                    if (newInvestigation.ImageToUpload != null)
                    {
                        //At this point you should check for aspects such as file size, file extension etc...
                        //Then you persist using a new name for consistency and uniqueness (e.g. GUIDS)
                        var extension = "." + newInvestigation.ImageToUpload.FileName.Split('.')[newInvestigation.ImageToUpload.FileName.Split('.').Length - 1];
                        fileName = Guid.NewGuid().ToString() + extension;
                        var path = Directory.GetCurrentDirectory() + "\\wwwroot\\images\\investigations\\" + fileName;
                        using (var bits = new FileStream(path, FileMode.Create))
                        {
                            newInvestigation.ImageToUpload.CopyTo(bits);
                        }
                    }

                    Investigation investigation = new Investigation()
                    {
                        Title = newInvestigation.Title,
                        Content = newInvestigation.Content,
                        CreatedDate = DateTime.UtcNow,
                        ImageUrl = "/images/investigations/" + fileName,
                        //ReportInvestigationId = newInvestigation.Investigation.ReportInvestigationId,
                        //StatusId = newInvestigation.Investigation.Report.StatusId,
                        ReportId = newInvestigation.ReportId,
                        UserId = _userManager.GetUserId(User)
                    };
                    

                    //Persist to repository
                    _investigationRepository.CreateInvestigation(investigation);
                    return RedirectToAction("Index");
                }
                else
                {
                    //Load all categories and create a list of CampusCategoryViewModel
                    var categoryList = _reportRepository.GetAllStatuses().Select(c => new StatusViewModel()
                    {
                        Id = c.Id,
                        Name = c.Name
                    }).ToList();

                    //Re-attach to view model before sending back to the View (this is necessary so that the View can repopulate the drop down and pre-select according to the CampusCategoryId
                    newInvestigation.StatusList = categoryList;

                    return View(newInvestigation);
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
                var existingInvestigation = _investigationRepository.GetInvestigationById(id);
                if (existingInvestigation != null)
                {
                    //Check if the current user has access to this resources
                    var currentUserId = _userManager.GetUserId(User);
                    if (existingInvestigation.UserId == currentUserId || User.IsInRole("Investigator"))
                    {
                        EditInvestigationViewModel model = new EditInvestigationViewModel()
                        {
                            Id = existingInvestigation.Id,
                            Title = existingInvestigation.Title,
                            Content = existingInvestigation.Content,
                            ImageUrl = existingInvestigation.ImageUrl,
                            StatusId = _investigationRepository.GetReportByInvestigationId(existingInvestigation.Id).StatusId,
                        };

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
        public IActionResult Edit([FromRoute] int id, [Bind("Id, Title, Content, ImageToUpload")] EditInvestigationViewModel updatedInvestigation)
        {
            try
            {
                var modelToUpdate = _investigationRepository.GetInvestigationById(id);
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

                        if (updatedInvestigation.ImageToUpload != null)
                        {
                            string fileName = "";
                            //At this point you should check size, extension etc...
                            //Then persist using a new name for consistency (e.g. new Guid)
                            var extension = "." + updatedInvestigation.ImageToUpload.FileName.Split('.')[updatedInvestigation.ImageToUpload.FileName.Split('.').Length - 1];
                            fileName = Guid.NewGuid().ToString() + extension;
                            var path = Directory.GetCurrentDirectory() + "\\wwwroot\\images\\investigations\\" + fileName;
                            using (var bits = new FileStream(path, FileMode.Create))
                            {
                                updatedInvestigation.ImageToUpload.CopyTo(bits);
                            }
                            imageUrl = "/images/investigations/" + fileName;
                        }
                        else
                            imageUrl = modelToUpdate.ImageUrl;

                        modelToUpdate.Title = updatedInvestigation.Title;
                        modelToUpdate.Content = updatedInvestigation.Content;
                        modelToUpdate.ImageUrl = imageUrl;
                        modelToUpdate.UpdatedDate = DateTime.Now;
                        //modelToUpdate.ReportId = updatedInvestigation.ReportId;
                        modelToUpdate.UserId = _userManager.GetUserId(User);

                        _investigationRepository.UpdateInvestigation(modelToUpdate);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                       return View(updatedInvestigation);
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
