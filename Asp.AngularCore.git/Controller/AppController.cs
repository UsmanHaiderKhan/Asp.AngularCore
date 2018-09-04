using Asp.AngularCore.git.Data;
using Asp.AngularCore.git.Services;
using Asp.AngularCore.git.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Asp.AngularCore.git.Controller
{
    public class AppController : Microsoft.AspNetCore.Mvc.Controller
    {

        private readonly IMailService _mailService;
        private readonly ILKRepository _repository;

        public AppController(IMailService mailService, ILKRepository repository)
        {
            _mailService = mailService;
            _repository = repository;
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
            var result = _repository.GetAllProducts();
            return View(result);

        }

    }

}
