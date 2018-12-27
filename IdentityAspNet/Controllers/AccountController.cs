using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using IdentityAspNet.ViewModels;
using IdentityAspNet.Models;
using System.Net;

namespace IdentityAspNet.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["UserName"] = User.Identity.Name;
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View(new SignUpViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            User user = new User()
            {
                Birthday = model.Birthday,
                Email = model.Email,
                FullName = model.FullName,
                Gender = model.Gender
            };

            IdentityResult res = await userManager.CreateAsync(user, model.Pswd);

            if (res.Succeeded)
            {
                await signInManager.SignInAsync(user, true);

                return RedirectToAction("Index");
            }
            else
            {
                foreach (var er in res.Errors)
                {
                    ModelState.AddModelError("Email", er.Description);
                }

                return View(model);
            }
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View(new SignInViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = userManager.Users.FirstOrDefault(u => u.Email == model.Email && u.PasswordHash == model.Password);

            if (user != null)
            {
                await signInManager.SignInAsync(user, true);

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult SignOut()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}