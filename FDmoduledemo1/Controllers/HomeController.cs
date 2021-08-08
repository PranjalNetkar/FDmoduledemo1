using FDmoduledemo1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FDmoduledemo1.Controllers
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

        public IActionResult FD()
        {
            int P = Convert.ToInt32(HttpContext.Request.Form["amount"].ToString());
            int t = Convert.ToInt32(HttpContext.Request.Form["period"].ToString());
            double r;
            double A;
            if (t <= 3)
            {
                r = 5.51;
                string Interest = Convert.ToString(r);
                HttpContext.Session.SetString("Interest", Interest);
            }
            else if (t <= 5)
            {
                r = 6.75;
                string Interest = Convert.ToString(r);
                HttpContext.Session.SetString("Interest", Interest);
            }
            else
            {
                r = 8;
                string Interest = Convert.ToString(r);
                HttpContext.Session.SetString("Interest", Interest);
            }
            A = (P * r * t) / 100;
            string maturity = Convert.ToString(A);
            HttpContext.Session.SetString("MaturityAmount", maturity);
            string principalAmount = Convert.ToString(P);
            HttpContext.Session.SetString("PrincipleAmount", principalAmount);
            double result = A - P;
            string InterestOnFd = Convert.ToString(result);
            HttpContext.Session.SetString("InterestOnFd", InterestOnFd);
            string time = Convert.ToString(t);
            HttpContext.Session.SetString("Duration", time);
            
            ViewBag.Interest = HttpContext.Session.GetString("Interest");
            ViewBag.MaturityAmount = HttpContext.Session.GetString("MaturityAmount");
            ViewBag.PrincipleAmount = HttpContext.Session.GetString("PrincipleAmount");
            ViewBag.InterestOnFd = HttpContext.Session.GetString("InterestOnFd");
            ViewBag.Duration = HttpContext.Session.GetString("Duration");
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
    }
}
