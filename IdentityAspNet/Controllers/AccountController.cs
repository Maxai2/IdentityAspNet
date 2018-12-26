using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using IdentityAspNet.ViewModels;
using IdentityAspNet.Models;

namespace IdentityAspNet.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        private SignOutResult signOutManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, SignOutResult signOutManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.signOutManager = signOutManager;
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
                Email = model.Email,
                UserName = model.Email
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
        public async IActionResult SignIn(SignInViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.Fin

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
        public void SignOut()
        {
            signOutManager.
        }
    }
}