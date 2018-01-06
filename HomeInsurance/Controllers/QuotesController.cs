using HomeInsurance.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace HomeInsurance.Controllers {

    public class QuotesController : Controller {
        #region Quote Methods
        public ActionResult GetStarted() {
            return View();
        }

		// Full summary of Quote/Property/Location
		public ActionResult QuoteSummary(int? quoteId) {
			if (!quoteId.HasValue) {
				try {
					quoteId = (int)Session["quoteId"];
				}

				catch {
					// TODO: redirect
					return RedirectToAction("GetStarted", "Quotes");
				}
			}

			else {
				Session["quoteId"] = quoteId;
			}

			// TODO: do we have a User?
			using (QuotesEntity qe = new QuotesEntity()) {
                Quote q = qe.Quotes.Include("Property.Location.Homeowner.User").Where(qq => qq.Id == quoteId).FirstOrDefault();
                // TODO: is q null?
                return View(q);
            };
        }

        public ActionResult QuoteDetails() {
            User user = Session["User"] as User;
            List<Quote> quoteList = new List<Quote>();

			using (QuotesEntity qe = new QuotesEntity()) {
				List<Quote> allQuotes = qe.Quotes.Include("Property.Location.Homeowner.User").ToList();

                Homeowner ho = qe.HomeOwners.FirstOrDefault(h => h.UserId == user.Id);
                if (ho == null) return View(quoteList);

				quoteList.AddRange(qe.Quotes.Where(q => q.Property.Location.HomeownerId == ho.Id));
				return View(quoteList);
			}
		}

        public ActionResult CoverageDetails() {
            Property property = Session["Property"] as Property;
            Quote quote = new Quote(property);

			Session["Quote"] = quote;
			// Why is this necessary?
			return View(quote);
		}

		public ActionResult SaveQuote() {
			Quote quote = Session["Quote"] as Quote;
			Property property = Session["Property"] as Property;
			Location location = Session["Location"] as Location;
			Homeowner homeowner = Session["Homeowner"] as Homeowner;
			User user = Session["User"] as User;

			quote.Property = property;
			property.Location = location;
			location.Homeowner = homeowner;
			homeowner.UserId = user.Id;

			using (QuotesEntity qe = new QuotesEntity()) {
                qe.Quotes.Add(quote);
                qe.SaveChanges();
			}

			Session.Clear();
			Session["User"] = user;
			return RedirectToAction("QuoteDetails");
		}
        #endregion
    }
}