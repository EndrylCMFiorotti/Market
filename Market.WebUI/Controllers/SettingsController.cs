using Microsoft.AspNetCore.Mvc;

namespace Market.WebUI.Controllers {
    public class SettingsController : Controller {
        private readonly ILogger<SettingsController> _logger;

        public SettingsController(ILogger<SettingsController> logger) {
            _logger = logger;
        }

        public ActionResult Index() {
            return View();
        }
    }
}
