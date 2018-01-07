using System.Web.Mvc;

namespace HomeInsurance.Controllers {

    public sealed class ErrorsController : Controller {
        public ActionResult LoginUser() {
            return RedirectToAction("LoginUser", "Welcome");
        }

        public ActionResult NotFound() {
            ActionResult result;

            object model = Request.Url.PathAndQuery;

            if (!Request.IsAjaxRequest())
                result = View(model);
            else
                result = PartialView("_NotFound", model);

            return result;
        }
    }
}