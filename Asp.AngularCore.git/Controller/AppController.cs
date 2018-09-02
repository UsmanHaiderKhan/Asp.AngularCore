using Asp.AngularCore.git.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Asp.AngularCore.git.Controller
{
    public class AppController : Microsoft.AspNetCore.Mvc.Controller
    {

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
            return View();

        }
        public IActionResult About()
        {
            return View();
        }


    }

}
