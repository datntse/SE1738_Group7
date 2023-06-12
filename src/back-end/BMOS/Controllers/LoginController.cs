using Microsoft.AspNetCore.Mvc;

namespace BMOS.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
