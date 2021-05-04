﻿using WebMVCFlashCards.ViewModels;
using WebMVCFlashCards.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebMVCFlashCards.Models.ForResponses;
using Microsoft.AspNetCore.Identity;

namespace WebMVCFlashCards.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private FlashCardsContext _db;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, FlashCardsContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = context;
        }

        [HttpGet]
        public async Task<IActionResult> CheckOut()
        {
            if (User.Identity.IsAuthenticated)
            {

                var user = await _userManager.FindByNameAsync(User.Identity.Name); 
                LanguageType userLanguage = _db.LanguageTypes.FirstOrDefault(LanguageType => LanguageType.LanguageId == user.LanguageId);
                return new JsonResult(new UserCheckOut
                {
                    IsAuthenticated = true,
                    IsAdmin = User.IsInRole("admin"),
                    UserId = user.Id,
                    UserName = user.Email,                   
                    UserLanguage = userLanguage.LanguageName,
                    UserLanguageId = userLanguage.LanguageId
                });
            }
            else
            {
                return new JsonResult(new UserCheckOut
                {
                    IsAuthenticated = false,
                    IsAdmin = false,
                    UserId = "-1",
                    UserName = null,
                    UserLanguage = "English",
                    UserLanguageId = 1
                });
            }
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    // проверяем, принадлежит ли URL приложению
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return Redirect("~/");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }


        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var languageID = _db.LanguageTypes.FirstOrDefault(LanguageType => LanguageType.LanguageName == model.Language).LanguageId;
                User user = new User { Email = model.Email, UserName = model.Email, LanguageId = languageID };
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(user, false);
                    return Redirect("~/");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
    }
}
