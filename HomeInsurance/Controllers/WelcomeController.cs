using HomeInsurance.Models;
using System.Linq;
using System.Web.Mvc;

namespace HomeInsurance.Controllers {

	public class WelcomeController : Controller {
        #region LogoutUser
        public ActionResult LogoutUser() {
            Session.Clear();
            return View();
        }
        #endregion

        #region LoginUser
        public ActionResult LoginUser() {
			return View();
		}

		[HttpPost]
        [ValidateAntiForgeryToken]
		public ActionResult LoginUser(User user) {
			if (!ModelState.IsValid) {
				return View("LoginUser");
			}

			using (QuotesEntity qe = new QuotesEntity()) {
				User existing = qe.Users.FirstOrDefault(u => u.Password == user.Password 
                    && u.Username == user.Username);

				if (existing == null) {
					ModelState.AddModelError("", "The user name or password provided is incorrect.");
					return View("LoginUser", user);
				}

                return RedirectUser(existing);
			}
		}
		#endregion

		#region NewUser
		public ActionResult NewUser() {
			return View("NewUser", new NewUser());
		}

		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewUser(NewUser newUser) {
			if (!ModelState.IsValid) {
				return View("NewUser", newUser);
			}

			using (QuotesEntity qe = new QuotesEntity()) {
				User u = qe.Users.FirstOrDefault(model => model.Username == newUser.Username);

				if (u != null) {
					ModelState.AddModelError("", "This username already exists.");
					return View("NewUser", newUser);
				}

				User user = new User(newUser);
				qe.Users.Add(user);
				qe.SaveChanges();
                return RedirectUser(user);
            };
		}
        #endregion

        #region Redirect User
        private ActionResult RedirectUser(User user) {
            Session["User"] = user;
            Session["Admin"] = user.IsAdmin ? "" : null;

            if (user.IsAdmin)
                return RedirectToAction("SearchUser", "Admin");
            else
                return RedirectToAction("GetStarted", "Quotes");
        }
        #endregion
    }
}