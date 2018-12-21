using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shakelx.EFSimple.Api.ViewModels;
using Shakelx.EFSimple.Core.Entities;

namespace Shakelx.EFSimple.Api.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: /<controller>/
        public IActionResult Login(string returlUrl = null)
        {
            TempData["returlUrl"] = returlUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(RegisterViewModel model, string returnUrl = null)
        {

            var user = await _userManager.FindByNameAsync(model.Email);

            var res = await _userManager.CheckPasswordAsync(user, model.Password);

            if (res)
            {
                var claims = new List<Claim>(){
                new Claim(ClaimTypes.Name,model.Email),
                new Claim(ClaimTypes.Role,"admin"),
                //new Claim(ClaimTypes.Role,"system")
                };
                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(claimIdentity);
                await _signInManager.SignInAsync(user, false);

                var u = HttpContext.User;
                if (returnUrl == null)
                {
                    returnUrl = TempData["returnUrl"]?.ToString();
                }
                if (returnUrl != null)
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("index", "account");
                }
            }
            return BadRequest("用户名或密码错误");
        }

        [HttpGet]
        public IActionResult Register(string returlUrl = null)
        {
            ViewData["returlUrl"] = returlUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegistorAsync(RegisterViewModel model, string returlUrl)
        {
            ViewData["returlUrl"] = returlUrl;
            if (TryValidateModel(model))
            {
                var user = new ApplicationUser
                {
                    Email = model.Email,
                    UserName = model.Email,
                    NormalizedUserName = model.Email,
                };

                var res = await _userManager.CreateAsync(user, model.Password);
                if (res.Succeeded)
                {
                    return RedirectToAction("index", "account");
                }
            }

            return BadRequest("input error");
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
