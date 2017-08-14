using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrakCare.Web.Models;
using TrakCare.API.Services;

namespace TrakCare.Web.Controllers
{
    public class HomeController : Controller
    {
        ITrakCareServices _ITrakCareServices = new TrakCareServices();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User objUser)
        {
            if (ModelState.IsValid)
            {
                var data = _ITrakCareServices.TrakCareUserAuthen(objUser);
                ViewData["UserID"] = data.Item1.SSUSR_Initials;
                return View("UserDashBoard", data);
            }
            return View();
        }

        public ActionResult UserDashBoard()
        {
            if (ViewData["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
