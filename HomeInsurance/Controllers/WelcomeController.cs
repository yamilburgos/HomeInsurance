using HomeInsurance.Models;
using System.Linq;
using System.Web.Mvc;

namespace HomeInsurance.Controllers {

    public class WelcomeController : Controller {
        #region Database Code
        private QuotesEntity _context;

        public WelcomeController() {
            _context = new QuotesEntity();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        #endregion

        #region LoginUser
        public ActionResult LoginUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return View("LoginUser");
            }

            User existing = _context.Users.FirstOrDefault(u => u.Password == user.Password && u.Username == user.Username);

            if (existing == null) {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return View("LoginUser", user);
            }

            Session["User"] = existing;
            return RedirectToAction("GetQuote", "Quotes");
        }
        #endregion

        #region NewUser
        public ActionResult NewUser()
        {
            return View("NewUser", new Login());
        }

        [HttpPost]
        public ActionResult NewUser(Login login)
        {
            if (!ModelState.IsValid)
            {
                return View("NewUser", login);
            }

            using (QuotesEntity qe = new QuotesEntity()) {
                User u = qe.Users.FirstOrDefault(usr => usr.Username == login.Username);

                if (u != null) {
                    ModelState.AddModelError("", "This username already exists.");
                    return View("NewUser", login);
                }
            };

            User user = new Models.User(login);
            _context.Users.Add(user);
            _context.SaveChanges();
            Session["User"] = user;
            return RedirectToAction("GetQuote", "Quotes");
        }
        #endregion
    }
}