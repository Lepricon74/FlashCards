using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using WebMVCFlashCards.Models;
using WebMVCFlashCards.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebMVCFlashCards.Controllers
{
    [Route("[controller]")]
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        UserManager<User> _userManager;
        RoleManager<IdentityRole> _roleManager;
        private FlashCardsContext _db;
        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, FlashCardsContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = context;
        }
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();
            var roles = _roleManager.Roles.ToList();
            var langs = _db.LanguageTypes.ToList();
            var adminList = await _userManager.GetUsersInRoleAsync("admin");
            IndexViewModel model = new IndexViewModel
            {
                Users = users,
                Roles = roles,
                Langs = langs,
                AdminUsers = adminList,
            };
            return View(model);
        }
        [Route("[action]")]
        public IActionResult CreateUser() => View();

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var languageID = _db.LanguageTypes.FirstOrDefault(LanguageType => LanguageType.LanguageName == model.Language).LanguageId;
                User user = new User { Email = model.Email, UserName = model.Email, LanguageId = languageID };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
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
        [Route("[action]")]
        public IActionResult CreateRole() => View();

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> CreateRole(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(name);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index");
        }

        [Route("[action]")]
        public async Task<IActionResult> Edit(string id)
        {
            // получаем пользователя
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var languageName = _db.LanguageTypes.FirstOrDefault(LanguageType => LanguageType.LanguageId == user.LanguageId).LanguageName;
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                EditUserViewModel model = new EditUserViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Language = languageName,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                return View(model);
            }

            return NotFound();

        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model, List<string> roles)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    var languageID = _db.LanguageTypes.FirstOrDefault(LanguageType => LanguageType.LanguageName == model.Language).LanguageId;
                    user.Email = model.Email;
                    user.UserName = model.Email;
                    user.LanguageId = languageID;
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        var userRoles = await _userManager.GetRolesAsync(user);
                        // получаем все роли
                        var allRoles = _roleManager.Roles.ToList();
                        // получаем список ролей, которые были добавлены
                        var addedRoles = roles.Except(userRoles);
                        // получаем роли, которые были удалены
                        var removedRoles = userRoles.Except(roles);

                        await _userManager.AddToRolesAsync(user, addedRoles);

                        await _userManager.RemoveFromRolesAsync(user, removedRoles);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(model);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult> DeleteUser(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }

        [Route("[action]")]
        public async Task<IActionResult> ChangePassword(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ChangePasswordViewModel model = new ChangePasswordViewModel { Id = user.Id, Email = user.Email };
            return View(model);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    var _passwordValidator = HttpContext.RequestServices.GetService(typeof(IPasswordValidator<User>)) as IPasswordValidator<User>;
                    var _passwordHasher = HttpContext.RequestServices.GetService(typeof(IPasswordHasher<User>)) as IPasswordHasher<User>;

                    IdentityResult result = await _passwordValidator.ValidateAsync(_userManager, user, model.NewPassword);
                    if (result.Succeeded)
                    {
                        user.PasswordHash = _passwordHasher.HashPassword(user, model.NewPassword);
                        await _userManager.UpdateAsync(user);
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Пользователь не найден");
                }
            }
            return View(model);
        }
    }
}
