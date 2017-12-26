using HomeInsurance.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace HomeInsurance.Controllers {

	public class PolicyController : Controller {

		public ActionResult Confirmation() {
			int policyId;

			try	{
				policyId = (int)Session["policyId"];
			}

			catch {
				return RedirectToAction("GetStarted", "Quotes");
			}

			using (QuotesEntity qe = new QuotesEntity()) {
				Policy p = qe.Policies.FirstOrDefault(pp => pp.Id == policyId);
				return View(p);
			}
		}

		public ActionResult BuyPolicy()	{
			VerifyPolicy vp = new VerifyPolicy();
			vp.PolicyStartDate = DateTime.Now.ToString("MM/dd/yyyy");

            try	{
				vp.QuoteId = (int)Session["quoteId"];
			}

			catch {
				return RedirectToAction("GetStarted", "Quotes");
			}

			return View(vp);
		}

		[HttpPost]
		public ActionResult BuyPolicy(VerifyPolicy verify) {
			DateTime startDate;

			if (!DateTime.TryParse(verify.PolicyStartDate, out startDate)) {
				ModelState.AddModelError("", "Invalid Date Format");
				return View(verify);
			}

			TimeSpan delta = startDate - DateTime.Now;

			if (delta.TotalDays < -1 || delta.TotalDays > 60) {
				ModelState.AddModelError("", "Policy start date connot be more than 60 days from today's date.");
				return View(verify);
			}

			Policy p = new Policy();
			p.PolicyEffDate = startDate.ToString("MM/dd/yyyy");
			p.PolicyEndDate = startDate.AddYears(1).ToString("MM/dd/yyyy");
			p.QuoteId = (int)Session["quoteId"];
			p.PolicyKey = p.QuoteId.ToString() + "_1";
			p.PolicyStatus = startDate <= DateTime.Now ? "ACTIVE" : "PENDING";
			p.PolicyTerm = 1;

			using (QuotesEntity qe = new QuotesEntity()) {
				qe.Policies.Add(p);
				qe.SaveChanges();
			}

			Session["policyId"] = p.Id;
			return RedirectToAction("Confirmation");
		}
	}
}