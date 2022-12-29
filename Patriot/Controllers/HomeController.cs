using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.Logging;
using Patriot.Database;
using Patriot.Database.Domain;
using Patriot.DomainModel.Contact;
using Patriot.DomainModel.CPTLetter;
using Patriot.Helper;
using Patriot.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Patriot.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DataContext _dataContext;
        private IMapper _mapper;
        private ImportService _importService;

        public HomeController(ImportService importService, ILogger<HomeController> logger, IMapper mapper, DataContext dataContext)
        {
            _importService = importService;
            _logger = logger;
            _mapper = mapper;
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            return View(new ContactCreateModel());
        }
        [HttpPost]
        public IActionResult Index(ContactCreateModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var contact = _mapper.Map<Contact>(model);
            _dataContext.Contacts.Add(contact);
            _dataContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Import()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Import(IFormFile file)
        {
            try
            {
                if (file == null)
                    throw new Exception("File cannot be empty");

                if (!file.FileName.Contains(".xlsx") || !file.FileName.Contains(".xls"))
                    throw new Exception("File Format must be (xlsx or xls)");

                if (_importService.ImportExcelData(file))
                    return RedirectToAction("CPTLetter");
                else
                    TempData["Error"] = "Something went wrong";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return View();
        }
        public IActionResult CPTLetter()
        {
            var cptLetters = new List<MasterLetterReadModel>();
            try
            {
                cptLetters = _mapper.Map<List<MasterLetterReadModel>>(_dataContext.MasterLetters.Where(x => x.LetterType.ToLower() == "cpt").ToList());
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }

            return View(cptLetters);
        }

        public IActionResult CPTLetterGetById(Guid id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
                throw new Exception("Id cannot be null");

            var cptLetters = new MasterLetterReadModel();
            try
            {
                cptLetters = _mapper.Map<MasterLetterReadModel>(_dataContext.MasterLetters.Where(x => x.LetterType.ToLower() == "cpt" && x.Id == id).FirstOrDefault());
                if (cptLetters == null)
                    throw new Exception("Record not found");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("CPTLetter");
            }
            return PartialView("CPTDetailModal", cptLetters);
        }

        [HttpPost]
        public  IActionResult GenerateCPTLetter(List<string> Ids)
        {
            return View();
        }
    }
}
