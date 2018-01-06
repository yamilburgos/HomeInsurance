using HomeInsurance.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace HomeInsurance.Controllers {

    public class AdminController : Controller {
        #region Search User
        public ActionResult SearchUser() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchUser(LookupUser user) {
            if (!ModelState.IsValid) {
                return View("SearchUser");
            }

            using (QuotesEntity qe = new QuotesEntity()) {
                User u = qe.Users.FirstOrDefault(model => model.Username == user.Username);

                if (u == null) {
                    ModelState.AddModelError("", "This user name doesn't exist.");
                    return View("SearchUser", user);
                }

                Session["User"] = u;
                return RedirectToAction("UserPolicies", "Admin");
            }
        }
        #endregion

        #region Policy Methods
        public ActionResult UserPolicies() {
            User user = Session["User"] as User;
            List<Policy> policyList = new List<Policy>();

            using (QuotesEntity qe = new QuotesEntity()) {
                List<Policy> allPolicy = qe.Policies.Include("Quote.Property.Location.Homeowner.User").ToList();

                Homeowner ho = qe.HomeOwners.FirstOrDefault(h => h.UserId == user.Id);
                if (ho == null) return View(policyList);

                policyList.AddRange(qe.Policies.Where(p => p.Quote.Property.Location.HomeownerId == ho.Id));
                return View(policyList);
            }
        }

        public ActionResult RenewPolicy(int? policyId) {
            using (QuotesEntity qe = new QuotesEntity()) {
                Policy p = qe.Policies.FirstOrDefault(pp => pp.Id == policyId);
                if (p == null) return UserPolicies();

                p.PolicyTerm = 2;
                p.PolicyStatus = "RENEWED";

                qe.SaveChanges();
                Session["policyId"] = p.Id;

                return RedirectToAction("Confirmation", "Policy");
            }
        }

        public ActionResult CancelPolicy(int? policyId) {
            using (QuotesEntity qe = new QuotesEntity()) {
                Policy p = qe.Policies.FirstOrDefault(pp => pp.Id == policyId);
                if (p == null) return UserPolicies();

                p.PolicyTerm = 0;
                p.PolicyStatus = "CANCELLED";

                qe.SaveChanges();
                Session["policyId"] = p.Id;

                return RedirectToAction("Confirmation", "Policy");
            }
        }
        #endregion
    }
}