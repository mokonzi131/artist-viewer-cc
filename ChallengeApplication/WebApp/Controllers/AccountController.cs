using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult External(string provider)
        {
            var authProps = new AuthenticationProperties
            {
                RedirectUri = "/home/index"
            };

            return new ChallengeResult(provider, authProps);
        }

        public IActionResult Logout()
        {
            //return View();
            return Ok("logout");
        }

        public IActionResult AccessDenied()
        {
            //return View();
            return Ok("denied");
        }
    }
}