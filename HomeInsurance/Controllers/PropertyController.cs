using HomeInsurance.Models;
using System.Web.Mvc;

namespace HomeInsurance.Controllers {

    public class PropertyController : Controller {
        #region Property Form
        public ActionResult PropertyForm() {
            return View(new Property());
        }

		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PropertyForm(Property property) {
			if (!ModelState.IsValid) {
				return View(property);
			}

            property.Location = Session["Location"] as Location;
            Session["Property"] = property;
            return RedirectToAction("CoverageDetails", "Quotes");
        }
        #endregion
    }
}