using HomeInsurance.Models;
using System.Web.Mvc;

namespace HomeInsurance.Controllers {

    public class PropertyController : Controller {
        public ActionResult PropertyForm() {
            return View(new Property());
        }

		[HttpPost]
		public ActionResult PropertyForm(Property property) {
			if (!ModelState.IsValid) {
				return View(property);
			}

            Session["Property"] = property;
            return RedirectToAction("CoverageDetails", "Quotes");
        }
    }
}