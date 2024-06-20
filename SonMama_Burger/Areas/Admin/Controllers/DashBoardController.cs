//using AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SonMama_Burger.DAL;

namespace SonMama_Burger.Areas.Admin.Controllers
{

	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class DashBoardController : Controller
	{
	
        public IActionResult Index()
		{
			return View();
		}
	}
}
