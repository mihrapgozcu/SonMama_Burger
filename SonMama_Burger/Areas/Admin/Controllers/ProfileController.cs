using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SonMama_Burger.DAL;
using SonMama_Burger.Validations;
using SonMama_Burger.VM;

namespace SonMama_Burger.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProfileController : Controller
    {
        private readonly BurgerDBContext _db;

        public ProfileController(BurgerDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
		public async Task<IActionResult> Settings()
		{
			var admin = _db.Users.Where(x => x.UserName == "cevdet@deneme.com").FirstOrDefault();

			UpdateUserVM updateUserDTO = new UpdateUserVM()
			{
				Ad = admin.UserName,
				Email = admin.Email,
				PhoneNumber = admin.PhoneNumber
			};

			return View(updateUserDTO);
		}

		[HttpPost]
		public async Task<IActionResult> Settings(UpdateUserVM updateUserVM)
		{
			UpdateUserVMValidator validationRules = new UpdateUserVMValidator();
			var valid = validationRules.Validate(updateUserVM);
			if (!valid.IsValid)
			{
				var admin = _db.Users.Where(x => x.UserName == "cevdet@deneme.com").FirstOrDefault();

				admin.Email = updateUserVM.Email;
				admin.PhoneNumber = updateUserVM.PhoneNumber;
				_db.Users.Update(admin);

				return RedirectToAction("Settings");
			}

			foreach (var item in valid.Errors)
			{
				ModelState.AddModelError("Hata", item.ErrorMessage);
			}
			return View();
		}
	}
}
