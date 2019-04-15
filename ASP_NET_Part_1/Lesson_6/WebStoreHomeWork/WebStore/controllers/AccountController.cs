using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain;
using WebStore.ViewModel;

namespace WebStore.controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _UM;
        private readonly SignInManager<User> _SM;

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (!ModelState.IsValid) return View(login);

            var login_result = await _SM.PasswordSignInAsync(login.UserName, login.Password, false, false);

            if(login_result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Имя пользователя или пароль неверны");
            return View(login);
        }
    }
}
