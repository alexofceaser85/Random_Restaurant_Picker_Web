using System.Web.Mvc;

namespace Random_Restaurant_Picker.Controllers {
    public class HomeController : Controller {
        #region Methods

        public ActionResult Index() {
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        #endregion
    }
}