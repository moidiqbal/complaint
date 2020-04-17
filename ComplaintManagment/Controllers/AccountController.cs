using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ComplaintManagment.Controllers
{
    public class AccountController : Controller
    {



        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }
  
        public IActionResult Index(string id)
        {
            HttpContext.Session.SetString("id",id);
            return RedirectToAction("Index","Home");
        }

        public IActionResult Login()
        {
          HttpContext.Session.SetString("waqar", "Jarvik");
         var d =   HttpContext.Session.GetString("waqar");
            return View();
        }
    }
}