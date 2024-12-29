using Market.Data.Business;
using Market.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Market.WebUI.Controllers {
    public class BaseController(ILogger<BaseController> logger, BLLogin blLogin) : Controller {
        protected static UserModel? _LoggedUser;
        protected readonly ILogger<BaseController> _logger = logger;
        private readonly BLLogin _blLogin = blLogin;

        public async Task<IActionResult> Login(string email, string password) {
            UserModel? user = await _blLogin.LoginUser(email, password);
            if (user is not null && !string.IsNullOrEmpty(user.Name) && !string.IsNullOrEmpty(user.Email)) {
                await SaveUserData(user);
                _LoggedUser = user;
                ViewMessage($"Usuario foi logado com sucesso!", true);
                return RedirectToAction("Index", "Home");
            }
            ViewMessage("Email ou senha incorretos!", false);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout() {
            int idUser;
            if (_LoggedUser is null || (idUser = _LoggedUser.IdUser) == 0) 
                return Json(new { success = false, message = "Erro ao deslogar o usuário!" });

            await DeleteUserData();
            await _blLogin.LogoutUser(idUser);
            return Json(new { success = true });
        }

        private async Task SaveUserData(UserModel user) {
            var claims = new List<Claim> {
                new (ClaimTypes.NameIdentifier, user.IdUser.ToString()),
                new (ClaimTypes.Name, user.Name!),
                new (ClaimTypes.Email, user.Email!)
            };
            var claimsIdentity = new ClaimsIdentity(claims, "Login");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            var authenticationProperties = new AuthenticationProperties { IsPersistent = true, ExpiresUtc = DateTimeOffset.UtcNow.AddDays(2) };
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authenticationProperties);
        }

        private async Task DeleteUserData() {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        private void ViewMessage(string message, bool isSuccess) {
            TempData["ControllerMessage"] = message;
            TempData["IsSuccess"] = isSuccess;
        }
    }
}
