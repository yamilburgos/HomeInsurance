using HomeInsurance.Models;
using System.Web.Mvc;

namespace HomeInsurance.Controllers
{

    public class LocationController : Controller
    {
        #region Location Form
        public ActionResult LocationForm()
        {
            return View(new Location());
        }

        [HttpPost]
        public ActionResult LocationForm(Location location)
        {
            if (!ModelState.IsValid)
            {
                return View(location);
            }

            Session["Location"] = location;
            return RedirectToAction("PropertyForm", "Property");
        }
        #endregion
    }
}