using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SonMama_Burger.Models.Entitites;
using SonMama_Burger.Validations;
using SonMama_Burger.VM;

namespace SonMama_Burger.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            LoginVMValidator validator = new LoginVMValidator();
            var valid = validator.Validate(loginVM);
            if (valid.IsValid)
            {
                AppUser appUser = await userManager.FindByNameAsync(loginVM.UserName);
                if (appUser == null)
                {
                    ViewBag.Uyarı = "Bu isimde kayıtlı kullanıcı bulunmamaktadır.";
                    return View();
                }
                else if (appUser.EmailConfirmed == false)
                {
                    TempData["Mail"] = appUser.Email;
                    return RedirectToAction("Index", "ConfirmMail");
                }
                else
                {
                    await signInManager.SignOutAsync();

                    Microsoft.AspNetCore.Identity.SignInResult signInResult = await signInManager.PasswordSignInAsync(appUser, loginVM.Password, true, false);

                    if (signInResult.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");

                    }
                    ViewBag.Uyarı = "Kullanıcı Adı veya Şifre Hatalı!";
                    return View();
                }
            }
            foreach (var item in valid.Errors)
            {
                ModelState.AddModelError("LoginHata", item.ErrorMessage);
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            RegisterVMValidator validator = new();
            var valid = validator.Validate(registerVM);
            if (valid.IsValid)
            {
                Random random = new Random();
                int code = random.Next(100000, 1000000);
                AppUser appUser = new AppUser()
                {
                    UserName = registerVM.UserName,
                    Ad = registerVM.Ad,
                    Soyad = registerVM.Soyad,
                    Cinsiyet = registerVM.Cinsiyet,
                    DogumTarihi = registerVM.DogumTarihi,
                    Email = registerVM.Email,
                    EmailConfirmed = false,

                };
                appUser.ConfirmCode = code;

                IdentityResult result = await userManager.CreateAsync(appUser, registerVM.Password);
                if (result.Succeeded)
                {
                    SendEmail(appUser.Email, code);
                    TempData["Mail"] = appUser.Email;
                    await userManager.AddToRoleAsync(appUser, "Musteri");
                    return RedirectToAction("Login", "User");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("KayitHata", item.Description);
                    }
                }
            }
            else
            {
                foreach (var hata in valid.Errors)
                {
                    ModelState.AddModelError("KayitHata", hata.ErrorMessage);
                }

            }
            return View();

        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        public void SendEmail(string email, int code)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("MamaBurger Admin", "projemama@gmail.com"); // Mailin kimden gideceği!
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", email);

            mimeMessage.From.Add(mailboxAddressFrom);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "Kayıt işlemini gerçekleştirmek için onay kodunuz: " + code;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = "Hamburger Projesi Onay Kodu";

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("projemaka@gmail.com", "wvgdopwbgegdlgcl");
            client.Send(mimeMessage);
            client.Disconnect(true);
        }
    }
}
