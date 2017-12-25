using HomeInsurance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace HomeInsurance.Controllers {

    public class QuotesController : Controller {

        public static IEnumerable<string> ResidenceTypes = new string[] 
            { "Primary Residence", "Secondary Residency", "Shack" };

        public ActionResult GetQuote() {
            return View();
        }

        // Full summary of Quote/Property/Location
        public ActionResult QuoteSummary(int? quoteId)
        {
            if (!quoteId.HasValue)
            {
                try
                {
                    quoteId = (int)Session["quoteId"];
                }
                catch
                {
                    // TODO: redirect
                    return RedirectToAction("GetQuote");
                }
            }
            else
            {
                Session["quoteId"] = quoteId;
            }
            // TODO: do we have a User?
            using (QuotesEntity qe = new QuotesEntity())
            {
                Quote q = qe.Quotes.Include("Property.Location.Homeowner.User").Where(qq => qq.Id == quoteId).FirstOrDefault();
                // TODO: is q null?
                return View(q);
            };
        }

        public ActionResult QuoteDetails() {
            User user = Session["User"] as User;
            List<Quote> quotes = new List<Quote>();
            using (QuotesEntity qe = new QuotesEntity())
            {
                List<Quote> allQuotes = qe.Quotes.Include("Property.Location.Homeowner.User").ToList();
                List<Homeowner> owners = qe.HomeOwners.ToList();
                Homeowner ho = qe.HomeOwners.FirstOrDefault(h => h.UserId == user.Id);
                if (ho == null)
                {
                    // Redirect to ???
                    return View(quotes);
                }
                quotes.AddRange(qe.Quotes.Where(q => q.Property.Location.HomeownerId == ho.Id));
                return View(quotes);
            }
        }

        public ActionResult QuoteForm() {
            Property property = Session["Property"] as Property;
            Quote quote = new Quote(property);

            Session["Quote"] = quote;
            // Why is this necessary?
            return View(quote);
        }

        public ActionResult BuyQuote() {
            Quote quote = Session["Quote"] as Quote;
            Property property = Session["Property"] as Property;
            Location location = Session["Location"] as Location;
            Homeowner homeowner = Session["Homeowner"] as Homeowner;
            User user = Session["User"] as User;

            quote.Property = property;
            property.Location = location;
            location.Homeowner = homeowner;

            homeowner.User = user;
            homeowner.UserId = user.Id;

            using(QuotesEntity qe = new QuotesEntity()) {
                qe.Quotes.Add(quote);
                qe.SaveChanges();
            }
            Session.Clear();
            Session["User"] = user;
            return RedirectToAction("QuoteDetails");

        }

        // TODO: Plug this in
        //private ActionResult ActionFor<T>(T value, string redirect)
        //{
        //    if (!ModelState.IsValid) return View(value);
        //    Session[value.GetType().Name] = value;
        //    return RedirectToAction(redirect);
        //}
    }
}