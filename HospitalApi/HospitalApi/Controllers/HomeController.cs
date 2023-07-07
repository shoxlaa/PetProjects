using Microsoft.AspNetCore.Mvc;

namespace HospitalApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult AddDoctor() { }
    }
}
