using Asp.AngularCore.git.Data;
using Asp.AngularCore.git.Services;
using Asp.AngularCore.git.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Asp.AngularCore.git.Controller
{
    public class AppController : Microsoft.AspNetCore.Mvc.Controller
    {

        private readonly IMailService _mailService;
        private readonly LKContext _db;

        public AppController(IMailService mailService, LKContext db)
        {
            _mailService = mailService;
            _db = db;
        }


        public IActionResult Index()
        {

            return View();

        }
        [HttpGet]
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact Us";
            //   throw new InvalidOperationException("Some thing happen bad");
            return View();

        }
        [HttpPost]
        public IActionResult Contact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _mailService.Message("usmanhaiderkhan4@gmail.com", contact.Subject, $"From:{contact.Email} - {contact.Name} - {contact.Phone} Message:{contact.Message}");
                ViewBag.Message = "Sent the Email successfully";
                ModelState.Clear();
                //send Email
            }
            else
            {
                //error
            }
            return View();

        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Shop()
        {
            var result = from c in _db.Products orderby c.Category select c;

            return View(result.ToList());

        }

    }

}
