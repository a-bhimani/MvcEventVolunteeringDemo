using System.Web.Mvc;

namespace MvcEventVolunteeringDemo.Controllers
{
	public class HomeController : Controller
	{
		// GET: Home
		public ActionResult Index()
		{
			return RedirectToAction("Index", "Volunteers", new { area = "" });
		}
	}
}
