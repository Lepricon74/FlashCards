using WebMVCFlashCards.ViewModels;
using WebMVCFlashCards.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebMVCFlashCards.Models.ForResponses;

namespace WebMVCFlashCards.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private FlashCardsContext db;
        public AccountController(FlashCardsContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult CheckOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = db.Users.FirstOrDefault(users => users.Login == User.Identity.Name);
                LanguageType userLanguage = db.LanguageTypes.FirstOrDefault(LanguageType => LanguageType.LanguageId == user.LanguageId);
                return new JsonResult(new UserCheckOut
                {
                    IsAuthenticated = true,
                    UserId = user.Id,
                    UserName = user.Login,
                    UserLanguage = userLanguage.LanguageName,
                    UserLanguageId = userLanguage.LanguageId
                });
            }
            else
            {
                return new JsonResult(new UserCheckOut
                {
                    IsAuthenticated = false,
                    UserId = -1,
                    UserName = null,
                    UserLanguage = "English",
                    UserLanguageId = 1
                });
            }
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Login == model.Login && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(model.Login); // аутентификация

                    return Redirect("~/"); ;
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var languageID = db.LanguageTypes.FirstOrDefault(LanguageType => LanguageType.LanguageName == model.Language).LanguageId;
                User user = await db.Users.FirstOrDefaultAsync(u => u.Login == model.Login);
                if (user == null&&languageID!=0)
                {
                   
                    // добавляем пользователя в бд
                    db.Users.Add(new User { Login = model.Login, Password = model.Password, LanguageId=languageID });
                    await db.SaveChangesAsync();

                    await Authenticate(model.Login); // аутентификация

                    return Redirect("~/");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("~/");
        }
    }
}
