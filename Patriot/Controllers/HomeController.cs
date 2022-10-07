using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Patriot.Database;
using Patriot.Database.Domain;
using Patriot.DomainModel.Contact;
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
        public HomeController()
        {

        }
        //public HomeController(ILogger<HomeController> logger, IMapper mapper, DataContext dataContext)
        //{
        //    _logger = logger;
        //    _mapper = mapper;
        //    _dataContext = dataContext;
        //}

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
    }
}
