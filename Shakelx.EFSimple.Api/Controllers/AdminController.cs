using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shakelx.EFSimple.Api.Controllers
{
    [Authorize(Roles = "admin,system")]
    public class AdminController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult Employees()
        {
            return View();
        }

        [Authorize(Roles = "system")]
        public IActionResult Setting()
        {
            return View();
        }
    }
}
