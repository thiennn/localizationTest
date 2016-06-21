using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace LocalizationTest.Controllers
{
    public class LocalizationController : Controller
    {
        private readonly IStringLocalizer<LocalizationController> _localizer;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public LocalizationController(IStringLocalizer<LocalizationController> localizer, IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _localizer = localizer;
            _sharedLocalizer = sharedLocalizer;
        }

        public string TestGetSingle()
        {
            return _localizer["hello"];
        }

        public IActionResult TestGetAll()
        {
            var allString = _localizer.GetAllStrings().ToList();
            return Json(allString);
        }

        public string TestGetSingleShared()
        {
            return _sharedLocalizer["hello"];
        }

        public IActionResult TestGetAllShared()
        {
            var allString = _sharedLocalizer.GetAllStrings().ToList();
            return Json(allString);
        }
    }
}
