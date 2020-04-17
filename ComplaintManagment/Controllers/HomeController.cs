using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ComplaintManagment.Models;
using Rest;
using RestSharp;
using Models;
using Models.ApiResponseModels;
using Newtonsoft.Json;
using ComplaintManagment.Helpers;
using Microsoft.AspNetCore.Http;

namespace ComplaintManagment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

       // [AuthorizationRequiredAttribute]
        public IActionResult Index()
        {
            var s = HttpContext.Session.GetString("id");
            if (s != null)
            {
                var client = new RestSharp.RestClient("https://localhost:44303/Complaint/v1/All");
                var response = client.Execute(new RestRequest());
                if (response.StatusCode.ToString() == "OK")
                {
                    var data = JsonConvert.DeserializeObject<ComplaintAPi>(response.Content);
                    ViewBag.records = data.data;
                }
                else
                {

                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        public IActionResult Create()
        {
            var s = HttpContext.Session.GetString("id");
            ViewBag.id = s;
            if (s != null)
            {
                return View();
            }
            else
            {
              return  RedirectToAction("Login", "Account");
            }
          //  return View();
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
