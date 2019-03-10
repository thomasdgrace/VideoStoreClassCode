using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VideoStoreNew.ViewModels;
using Microsoft.AspNetCore.Identity;
using VideoStoreNew.Entities;

namespace VideoStoreNew.Controllers
{
    public class AccountController: Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task < IActionResult>Register(RegisterViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var newUser = new User { UserName = model.Username };
            var result = await _userManager.CreateAsync(newUser, model.Password);

            if(result.Succeeded)
            {
                await _signInManager.SignInAsync(newUser, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Login(string returnUrl="")
        {
            var model = new LoginViewModel { ReturnURL = returnUrl };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                if(!string.IsNullOrEmpty(model.ReturnURL)&&(Url.IsLocalUrl(model.ReturnURL)))
                {
                    return Redirect(model.ReturnURL);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Login Failed");
                return View(model);
            }


        }
    }
}
