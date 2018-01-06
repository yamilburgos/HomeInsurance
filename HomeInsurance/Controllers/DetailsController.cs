using System.Web.Mvc;

namespace HomeInsurance.Controllers {

    public class DetailsController : Controller {
        #region Term Methods
        public ActionResult PolicyTerms() {
            return View();
        }

        public ActionResult QuoteTerms() {
            return View();
        }
        #endregion
    }
}