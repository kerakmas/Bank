using Bank.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bank.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}