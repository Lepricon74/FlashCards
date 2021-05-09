using WebMVCFlashCards.ViewModels;
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

        public async Task<IActionResult> Register()
        {
            ViewBag.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
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

        public IActionResult GoogleLogin()
        {
            //Формируем адрес но который Google будет возвращать результат авторизоции
            string redirectUrl = Url.Action("GoogleResponse", "Account");
            var properties = _signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
            //Возвращаем 'окно входа' Google
            return new ChallengeResult("Google", properties);
        }

        public async Task<IActionResult> GoogleResponse()
        {
            //Получаем данные авторизации
            ExternalLoginInfo info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null) return RedirectToAction(nameof(Login));
            //Пытаемся авторизовать пользователя в нашей системе
            //ProviderKey связывает пользователя Google с таблицей пользователей
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);
            string[] userInfo = { info.Principal.FindFirst(ClaimTypes.Name).Value, info.Principal.FindFirst(ClaimTypes.Email).Value };
            if (result.Succeeded)
                return Redirect("~/");
            else
            {              
                //Если вход не удался - создаем нового пользователя
                User user = new User
                {
                    Email = info.Principal.FindFirst(ClaimTypes.Email).Value,
                    UserName = info.Principal.FindFirst(ClaimTypes.Email).Value,
                    LanguageId = 1
                };

                IdentityResult identResult = await _userManager.CreateAsync(user);
                if (identResult.Succeeded)
                {
                    identResult = await _userManager.AddLoginAsync(user, info);
                    if (identResult.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, false);
                        return Redirect("~/");
                    }
                }
                return AccessDenied();
            }
        }

        public IActionResult VkontakteLogin()
        {
            //Формируем адрес но который VK будет возвращать результат авторизоции
            string redirectUrl = Url.Action("VkontakteResponse", "Account");
            var properties = _signInManager.ConfigureExternalAuthenticationProperties("Vkontakte", redirectUrl);
            //Возвращаем 'окно входа' VK
            return new ChallengeResult("Vkontakte", properties);
        }

        public async Task<IActionResult> VkontakteResponse()
        {
            //Получаем данные авторизации
            ExternalLoginInfo info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null) return RedirectToAction(nameof(Login));
            //Пытаемся авторизовать пользователя в нашей системе
            //ProviderKey связывает пользователя Google с таблицей пользователей
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);
            //string userName = info.Principal.FindFirst(ClaimTypes.Name).Value;
            string userName = info.Principal.FindFirst(ClaimTypes.GivenName).Value;
            string userSurName = info.Principal.FindFirst(ClaimTypes.Surname).Value;
            //string userEmail = info.Principal.FindFirst(ClaimTypes.Email).Value;
            if (result.Succeeded)
                return Redirect("~/");
            else
            {
                //Если вход не удался - создаем нового пользователя
                User user = new User
                {
                    Email = info.Principal.FindFirst(ClaimTypes.GivenName).Value + info.Principal.FindFirst(ClaimTypes.Surname).Value,
                    UserName = info.Principal.FindFirst(ClaimTypes.GivenName).Value +info.Principal.FindFirst(ClaimTypes.Surname).Value,
                    LanguageId = 1
                };

                IdentityResult identResult = await _userManager.CreateAsync(user);
                if (identResult.Succeeded)
                {
                    identResult = await _userManager.AddLoginAsync(user, info);
                    if (identResult.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, false);
                        return Redirect("~/");
                    }
                }
                return AccessDenied();
            }
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
