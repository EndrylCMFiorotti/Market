using Market.Data.Business;
using Market.Data.Entity;
using Market.Data.Models;
using Market.Data.Models.Home;
using Market.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Security.Claims;

namespace Market.WebUI.Controllers {
    public class HomeController(ILogger<HomeController> logger, BLLogin blLogin, BLProduct blProduct) : BaseController(logger, blLogin) {
        private readonly BLProduct _blProduct = blProduct;

        [HttpGet]
        public async Task<IActionResult> Index() {
            HomeViewModel model = new() {
                ProductList = await _blProduct.GetAllProducts()
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
