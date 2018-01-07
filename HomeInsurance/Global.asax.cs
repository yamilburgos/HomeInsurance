using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using HomeInsurance.Controllers;

namespace HomeInsurance {
    public class MvcApplication : HttpApplication {

        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_EndRequest() {
            if (Context.Response.StatusCode == 404) {
                Response.Clear();

                var rd = new RouteData();
                rd.DataTokens["area"] = "AreaName"; // In case controller is in another area
                rd.Values["controller"] = "Welcome";
                rd.Values["action"] = "LoginUser";

                IController c = new ErrorsController();
                c.Execute(new RequestContext(new HttpContextWrapper(Context), rd));
            }
        }
    }
}
