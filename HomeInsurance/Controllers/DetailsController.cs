using System;
using System.Web.Mvc;

namespace HomeInsurance.Controllers {

    public class DetailsController : Controller {

        public ActionResult PolicyTerms() {
            return View();
        }

        public ActionResult QuoteTerms() {
            return View();
        }
    }
}