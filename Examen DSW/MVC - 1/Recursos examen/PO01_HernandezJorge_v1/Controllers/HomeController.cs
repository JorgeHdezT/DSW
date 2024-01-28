using Microsoft.AspNetCore.Mvc;
using PO01_HernandezJorge_v1.Models;
using System.Diagnostics;

namespace PO01_HernandezJorge_v1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //Creo la pagina de inicio para los clientes:
        public IActionResult Cliente()
        {
            return View();
        }
    }
}