using GalaxiaApi.Models;
using GalaxiaApi.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GalaxiaApi.Controllers
{
    public class AccountController : Controller
    {
        #region Injeção de depemdência Identity
        private readonly UserManager<MeuUserIdentity> _userManager;
        private readonly SignInManager<MeuUserIdentity> _signInManager;
        private readonly RoleManager<MeuRoleIdentity> _roleManager;
        #endregion

        public AccountController(
            UserManager<MeuUserIdentity> userManager,
            SignInManager<MeuUserIdentity> signInManager,
            RoleManager<MeuRoleIdentity> roleManager
        )
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(obj.Username, obj.Password, obj.RememberMe, false).Result;

                if (result.Succeeded)
                {
                    return Content("Usuário Autorizado");
                }

                ModelState.AddModelError("", "Login Invalido!");
            }

            return View(obj);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel obj)
        {
            if (ModelState.IsValid)
            {
                MeuUserIdentity user = new MeuUserIdentity();
                user.UserName = obj.Username;
                user.Email = obj.Email;

                IdentityResult result = _userManager.CreateAsync(user, obj.Password).Result;

                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync("NormalUser").Result)
                    {
                        MeuRoleIdentity role = new MeuRoleIdentity();
                        role.Name = "NormalUser";
                        role.Descricao = "Realiza operações básicas.";
                        IdentityResult roleResult = _roleManager.
                        CreateAsync(role).Result;
                        if (!roleResult.Succeeded)
                        {
                            ModelState.AddModelError("", "Error ao criar o perfil!");
                            return View(obj);
                        }
                    }

                    _userManager.AddToRoleAsync(user, "NormalUser").Wait();
                    return RedirectToAction("Login", "Account");
                }
            }
            return View(obj);
        }
    }
}