using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Songrics.Data.Models;
using Songrics.Services.Models.Home;

namespace Songrics.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        private SignInManager<SongricsUser> signInManager;

        public AccountController(SignInManager<SongricsUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        [Route("Login")]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            var returnUrlParsed = returnUrl ?? Url.Content("~/");
            if (signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }
            // Clear the existing external cookie to ensure a clean login process
            HttpContext.SignOutAsync(IdentityConstants.ExternalScheme).GetAwaiter().GetResult();

            this.TempData["ReturnUrl"] = returnUrlParsed;


            return this.View();
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Username,
                   model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid login attempt");
            return View(model);
        }
        [Route("Register")]
        public IActionResult Register()
        {
            return this.View();
        }
       
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var user = new SongricsUser()
            {
                Email = model.Email,
                UserName = model.UserName,
                Nickname=model.Nickname  
            };

            var result = this.signInManager.UserManager.CreateAsync(user, model.Password).Result;
            if(result.Succeeded)
            {
                return this.RedirectToAction("Login", "Account");
            }
            return this.View();
        }
        [Route("Logout")]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await this.signInManager.SignOutAsync();
           
            if (returnUrl != null)
            {
                return this.RedirectToAction("Logout", "Account");
            }
            else
            {
                return this.RedirectToAction("Login", "Account");
            }
        }

    }
}

