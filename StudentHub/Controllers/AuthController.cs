using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentHub.Data;
using StudentHub.Models.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentHub.Controllers
{
    public class AuthController : Controller
    {
        SignInManager<ApplicationUser> _signInManager;
        public AuthController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login(HomeViewModel homeView)
        {
            ///Authenticate
             
            var result = await _signInManager.PasswordSignInAsync(homeView.Email, homeView.Password, homeView.RememberMe, lockoutOnFailure: true);
            return View();
        }
    }
}
