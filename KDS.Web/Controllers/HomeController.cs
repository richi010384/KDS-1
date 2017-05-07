using System.Web.Mvc;

namespace KDS.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {            
            return View();
        }
    }
}