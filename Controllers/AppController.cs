using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DutchTreat.Data;
using DutchTreat.Services;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DutchTreat.Controllers
{
  public class AppController : Controller
  {
        private readonly IMailService _mailService;
        private readonly IDutchRepository _repository;
        //private readonly DutchContext _context;


        public AppController(IMailService mailService, IDutchRepository repository)  //DutchContext context)
    {
      _mailService = mailService;
            //_context = context;
            _repository = repository;

    }

    public IActionResult Index()
    {
            //var results = _context.Products.ToList();
            return View();
    }

    [HttpGet("contact")]
    public IActionResult Contact()
    {
      return View();
    }

    [HttpPost("contact")]
    public IActionResult Contact(ContactViewModel model)
    {
      if (ModelState.IsValid)
      {
        // Send the Email
        _mailService.SendMessage("medavis00@live.com", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}");
        ViewBag.UserMessage = "Mail Sent...";
        ModelState.Clear();
      }

      return View();
    }

    public IActionResult About ()
    {
      ViewBag.Title = "About Us";
      return View();
    }

    public IActionResult Shop()
        {
            //var results = from p in _context.Products
            //    orderby p.Category
            //    select p;
            // passing results to view
            //return View(results.ToList());

            var results = _repository.GetAllProducts();
            return View(results);

        }

  }
}
